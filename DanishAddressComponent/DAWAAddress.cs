
namespace DanishAddressComponent;

public class DAWAAddress
{
    public class DAWAAddressData
    {
        public Guid Id { get; set; }
        public DAWAStatus Status { get; set; }
        public DARStatus DarStatus { get; set; }
        public string Roadcode { get; set; } = string.Empty;
        public string Roadname { get; set; } = string.Empty;
        public string AddressingRoadname { get; set; } = string.Empty;
        public string HouseNbr { get; set; } = string.Empty;
        public string? Floor { get; set; }
        public string? Door { get; set; }
        public string? SupplementoryCityname { get; set; }
        public string ZipCode { get; set; } = string.Empty;
        public string Cityname { get; set; } = string.Empty;
        public string? LargeAmountOfMailReceiverZipCode { get; set; }
        public string? LargeAmountOfMailReceiverCityname { get; set; }
        public string Municipalcode { get; set; } = string.Empty;
        public Guid? AccessaddressId { get; set; }
        public decimal? X { get; set; }
        public decimal? Y { get; set; }
        public string Href { get; set; } = string.Empty;
    }

    public DAWAAddressData? Data { get; set; }
    public bool LargeAmountOfMailReceiverZipCode { get; set; }
    public DAWAAutoCompleteType Type { get; set; }
    public string Text { get; set; } = string.Empty;
    public string Suggestiontext { get; set; } = string.Empty;
    public int? Caretpos { get; set; }
}
