using DanishAddressComponent.Data.Dtos;
using DanishAddressComponent.Data.Models;
using DanishAddressComponent.Interface;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.JSInterop;

namespace DanishAddressComponent;

public partial class DanishAddress : IAsyncDisposable
{
    private const string JavaScriptSetupAutoCompleteComponent = "danishAddress.activateAddressComponent";
    private const string JavaScriptDestroyAutoCompleteComponent = "danishAddress.destroyComponent";

    /// <summary>
    /// Object with address to be display and/or entered.
    /// </summary>
    [Parameter]
    public required DAWAAddress Address { get; set; }

    /// <summary>
    /// Text to be displayed inside the entry textbox as long as no address is entered.
    /// </summary>
    [Parameter]
    public string PlaceHolderText { get; set; } = string.Empty;

    /// <summary>
    /// Only search for, and display, access addresses.
    /// </summary>
    [Parameter]
    public bool OnlyAccessAddresses { get; set; }

    /// <summary>
    /// Zip code(s) for which to display addresses. If more than one, seperate by pipe char.
    /// </summary>
    [Parameter]
    public string? ZipCodes { get; set; }

    /// <summary>
    /// Municipal number(s) for which to display addresses. If more than one, seperate by pipe char.
    /// </summary>
    [Parameter]
    public string? MunicipalNumbers { get; set; }

    [Inject]
    public required IJSRuntime JSRuntime { get; set; }

    [Inject]
    public required IDAWAAddressDTOBOConverter dtoBoConverter { get; set; }

    [Inject]
    protected NavigationManager NavManager { get; set; } = default!;

    // DotNet reference to be passed to the JavaScript. This ensures that the
    // JavaScript is performing callback to the correct instance of the 
    // component.
    private DotNetObjectReference<DanishAddress>? _instanceReference;

    // Identification of each instance of the component. Is used to ensure that
    // the JavaScript communicates with the correct instance.
    private string ComponentId = Guid.NewGuid().ToString();
    private IDisposable? _navDisposer;


    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender is true)
        {
            var methodName = nameof(AddressSelected);
            string? adrId = null;

            _instanceReference ??= DotNetObjectReference.Create(this);

            if (Address is not null)
            {
                if (Address.Data is not null)
                {
                    adrId = Address.Data.Id.ToString();
                }
            }
            await JSRuntime.InvokeVoidAsync(JavaScriptSetupAutoCompleteComponent, _instanceReference, ComponentId, methodName, adrId, OnlyAccessAddresses,
                ZipCodes, MunicipalNumbers);
        }
    }

    protected override void OnInitialized()
    {
        _navDisposer = NavManager.RegisterLocationChangingHandler(OnLocationChanging);
    }

    private async ValueTask OnLocationChanging(LocationChangingContext context)
    {
        await JSRuntime.InvokeVoidAsync(JavaScriptDestroyAutoCompleteComponent, ComponentId);
    }


    /// <summary>
    /// This method is exposed as a callback method for JavaScript.
    /// It is wired up so that when the user selects an (access)
    /// address, this method is called.
    /// </summary>
    /// <param name="selectedAddress"></param>
    [JSInvokable]
    public void AddressSelected(DAWAAddressDTO selectedAddress)
    {
        dtoBoConverter.FromDTOToBO(selectedAddress, Address);
    }


    /// <summary>
    /// Cleanup when the component is to be disposed.
    /// </summary>
    /// <returns></returns>
    public async ValueTask DisposeAsync()
    {
        _navDisposer?.Dispose();
        _instanceReference?.Dispose();
        await Task.CompletedTask;
    }
}
