using System.Text.Json.Serialization;

namespace DanishAddressComponent;

public class DAWAAddressDTO
{
    public class DAWAAddressDataDTO
    {
        public Guid Id { get; set; }
        public DAWAStatus Status { get; set; }
        public DARStatus DarStatus { get; set; }

        [JsonPropertyName("Vejkode")]
        public string Roadcode { get; set; } = string.Empty;

        [JsonPropertyName("Vejnavn")]
        public string Roadname { get; set; } = string.Empty;

        [JsonPropertyName("Adresseringsvejnavn")]
        public string AddressingRoadname { get; set; } = string.Empty;

        [JsonPropertyName("Husnr")]
        public string HouseNbr { get; set; } = string.Empty;

        [JsonPropertyName("Etage")]
        public string? Floor { get; set; }

        [JsonPropertyName("Dør")]
        public string? Door { get; set; }

        [JsonPropertyName("Supplerendebynavn")]
        public string? SupplementoryCityname { get; set; }

        [JsonPropertyName("Postnr")]
        public string ZipCode { get; set; } = string.Empty;

        [JsonPropertyName("Postnrnavn")]
        public string Cityname { get; set; } = string.Empty;

        [JsonPropertyName("Stormodtagerpostnr")]
        public string? LargeAmountOfMailReceiverZipCode { get; set; }

        [JsonPropertyName("Stormodtagerpostnrnavn")]
        public string? LargeAmountOfMailReceiverCityname { get; set; }

        [JsonPropertyName("Kommunekode")]
        public string Municipalcode { get; set; } = string.Empty;

        [JsonPropertyName("AdgangsadresseId")]
        public Guid? AccessaddressId { get; set; }
        public decimal? X { get; set; }
        public decimal? Y { get; set; }
        public string Href { get; set; } = string.Empty;
    }

    public DAWAAddressDataDTO? Data { get; set; }

    [JsonPropertyName("Stormodtagerpostnr")]
    public bool LargeAmountOfMailReceiverZipCode { get; set; }
    public string Type { get; set; } = string.Empty;

    [JsonPropertyName("Tekst")]
    public string Text { get; set; } = string.Empty;

    [JsonPropertyName("Forslagstekst")]
    public string Suggestiontext { get; set; } = string.Empty;
    public int? Caretpos { get; set; }
}
