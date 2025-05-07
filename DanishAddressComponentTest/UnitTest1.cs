using DanishAddressComponent;
using Bunit;
using DanishAddressComponent.Interface;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using DanishAddressComponent.Data.Models;
using DanishAddressComponent.Data.Dtos;
using DanishAddressComponent.Data;

namespace DanishAddressComponentTest
{
    public class Tests : TestContextWrapper
    {
        [SetUp]
        public void Setup() => TestContext = new Bunit.TestContext();

        [TearDown]
        public void TearDown() => TestContext?.Dispose();


        [Test]
        public void DefaultState()
        {
            Services.AddScoped<IDAWAAddressDTOBOConverter, DAWAAddressDTOBOConverter>();

            var plannedInvocation = JSInterop.SetupVoid("danishAddress.activateAddressComponent", _ => true);
            var renderedComponent = RenderComponent<DanishAddress>(parameters =>
            parameters
                .Add(p => p.Address, new DAWAAddress())
                .Add(p => p.PlaceHolderText, "Key in address")
                .Add(p => p.OnlyAccessAddresses, true)
                );

            string jsonString = "{\"Data\":{\"Id\":\"fe9e04a5-8c45-4b86-91ae-d11107659dc5\",\"Status\":1,\"DarStatus\":3,\"Vejkode\":\"3564\",\"Vejnavn\":\"Kapelvej\"," +
                "\"Adresseringsvejnavn\":\"Kapelvej\",\"Husnr\":\"2\",\"Etage\":null,\"D\u00F8r\":null,\"Supplerendebynavn\":null,\"Postnr\":\"2200\"," + 
                "\"Postnrnavn\":\"K\u00F8benhavn N\",\"Stormodtagerpostnr\":null,\"Stormodtagerpostnrnavn\":null,\"Kommunekode\":\"0101\"," + 
                "\"AdgangsadresseId\":\"0a3f507a-a2cb-32b8-e044-0003ba298018\",\"X\":12.55298181,\"Y\":55.68940269," + "\"Href\":\"https://api.dataforsyningen.dk/adresser/fe9e04a5-8c45-4b86-91ae-d11107659dc5\"}," +
                "\"Stormodtagerpostnr\":false,\"Type\":\"adresse\",\"Tekst\":\"Kapelvej 2, 2200 K\u00F8benhavn N\"," + 
                "\"Forslagstekst\":\"Kapelvej 2\\n2200 K\u00F8benhavn N\"," +
                "\"Caretpos\":28}";

            DAWAAddressDTO addressDto = JsonSerializer.Deserialize<DAWAAddressDTO>(jsonString)!;

            renderedComponent.Instance.AddressSelected(addressDto);

            Assert.That(renderedComponent.Instance.dtoBoConverter, Is.Not.Null);
            Assert.That(renderedComponent.Instance.Address, Is.Not.Null);

            plannedInvocation.SetVoidResult();
        }
    }
}
