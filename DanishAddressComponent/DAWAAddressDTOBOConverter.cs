
namespace DanishAddressComponent;

public class DAWAAddressDTOBOConverter: IDAWAAddressDTOBOConverter
{
    public DAWAAddress FromDTOToBO(DAWAAddressDTO dto)
    {
        DAWAAddress dawaAddressBO = new()
        {
            LargeAmountOfMailReceiverZipCode = dto.LargeAmountOfMailReceiverZipCode,
            Type = EnumDAWATypeConverter.FromEnumMemberValue(dto.Type),
            Text = dto.Text,
            Suggestiontext = dto.Suggestiontext,
            Caretpos = dto.Caretpos
        };

        if (dto.Data is not null)
        {
            dawaAddressBO.Data = new()
            {
                Id = dto.Data.Id,
                Status = (DAWAStatus)dto.Data.Status,
                DarStatus = (DARStatus)dto.Data.DarStatus,
                Roadcode = dto.Data.Roadcode,
                Roadname = dto.Data.Roadname,
                AddressingRoadname = dto.Data.AddressingRoadname,
                HouseNbr = dto.Data.HouseNbr,
                Floor = dto.Data.Floor,
                Door = dto.Data.Door,
                SupplementoryCityname = dto.Data.SupplementoryCityname,
                ZipCode = dto.Data.ZipCode,
                Cityname = dto.Data.Cityname,
                LargeAmountOfMailReceiverZipCode = dto.Data.LargeAmountOfMailReceiverZipCode,
                LargeAmountOfMailReceiverCityname = dto.Data.LargeAmountOfMailReceiverCityname,
                Municipalcode = dto.Data.Municipalcode,
                AccessaddressId = dto.Data.AccessaddressId,
                X = dto.Data.X,
                Y = dto.Data.Y,
                Href = dto.Data.Href
            };
        }

        return dawaAddressBO;
    }
    public void FromDTOToBO(DAWAAddressDTO dto, DAWAAddress bo)
    {
        if (dto is null || bo is null)
        {
            throw new NullReferenceException("dto or bo object is null");
        }

        bo.LargeAmountOfMailReceiverZipCode = dto.LargeAmountOfMailReceiverZipCode;
        bo.Type = EnumDAWATypeConverter.FromEnumMemberValue(dto.Type);
        bo.Text = dto.Text;
        bo.Suggestiontext = dto.Suggestiontext;
        bo.Caretpos = dto.Caretpos;

        if (dto.Data is not null)
        {
            bo.Data ??= new();
            bo.Data.Id = dto.Data.Id;
            bo.Data.Status = dto.Data.Status;
            bo.Data.DarStatus = dto.Data.DarStatus;
            bo.Data.Roadcode = dto.Data.Roadcode;
            bo.Data.Roadname = dto.Data.Roadname;
            bo.Data.AddressingRoadname = dto.Data.AddressingRoadname;
            bo.Data.HouseNbr = dto.Data.HouseNbr;
            bo.Data.Floor = dto.Data.Floor;
            bo.Data.Door = dto.Data.Door;
            bo.Data.SupplementoryCityname = dto.Data.SupplementoryCityname;
            bo.Data.ZipCode = dto.Data.ZipCode;
            bo.Data.Cityname = dto.Data.Cityname;
            bo.Data.LargeAmountOfMailReceiverZipCode = dto.Data.LargeAmountOfMailReceiverZipCode;
            bo.Data.LargeAmountOfMailReceiverCityname = dto.Data.LargeAmountOfMailReceiverCityname;
            bo.Data.Municipalcode = dto.Data.Municipalcode;
            bo.Data.AccessaddressId = dto.Data.AccessaddressId;
            bo.Data.X = dto.Data.X;
            bo.Data.Y = dto.Data.Y;
            bo.Data.Href = dto.Data.Href;
        }
    }
}
