var danishAddress = {
    activateAddressComponent: function (dotNetInstance, componentId, method, addressId, onlyAccessAddresses, zipCode, municipalNumbers) {
        var adrId = null;
        if (addressId !== null && addressId !== "")
            adrId = addressId;
        var parms = {};
        if (zipCode !== null && zipCode !== "")
            parms.postnr = zipCode;
        if (municipalNumbers !== null && municipalNumbers !== "")
            parms.kommunekode = municipalNumbers;

        var adrComponent = document.getElementById(componentId);
        if (adrComponent === null) {
            alert("An error has occurred. The component with Id '" + componentId + "' cannot be found. It will not be possible to search for addresses.");
            return;
        }
        dawaAutocomplete.dawaAutocomplete(adrComponent, {
            id: adrId,
            adgangsadresserOnly: onlyAccessAddresses,
            select: function (selected) {
                dotNetInstance.invokeMethodAsync(method, selected);
            },
            params: parms
        });
    },
    destroyComponent: function (componentId) {
        var adrComponent = document.getElementById(componentId);
        var autocomplete = dawaAutocomplete.dawaAutocomplete(adrComponent, {});
        autocomplete.destroy();
    }
};
