using DanishAddressComponent.Data.Dtos;
using DanishAddressComponent.Data.Models;
using DanishAddressComponent.Interface;
using DanishAddressComponent.Utils;

namespace DanishAddressComponent.Data;

public class DAWAAddressDTOBOConverter: IDAWAAddressDTOBOConverter
{
    public void FromDTOToBO(DAWAAddressDTO dto, DAWAAddress bo)
    {
        if (dto is null || bo is null)
        {
            throw new NullReferenceException("dto or bo object is null");
        }

        bo.LargeAmountOfMailReceiverZipCode = dto.LargeAmountOfMailReceiverZipCode;
        bo.Type = EnumDAWAAddressTypeConverter.FromEnumMemberValue(dto.Type);
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
