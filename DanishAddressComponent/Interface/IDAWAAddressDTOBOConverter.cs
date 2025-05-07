using DanishAddressComponent.Data.Dtos;
using DanishAddressComponent.Data.Models;

namespace DanishAddressComponent.Interface;

public interface IDAWAAddressDTOBOConverter
{
    /// <summary>
    /// Copy and translate info from the DTO object to the BO object.
    /// It is required that BO is an existing object.
    /// The method is designed this way, as the address component is to 
    /// update the address object provided by the caller.
    /// </summary>
    /// <param name="dto">Dto object to copy from</param>
    /// <param name="bo">Business object to copy to</param>
    /// <exception cref="NullReferenceException"></exception>
    void FromDTOToBO(DAWAAddressDTO dto, DAWAAddress bo);
}
