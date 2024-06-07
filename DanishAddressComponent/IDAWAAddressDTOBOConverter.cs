namespace DanishAddressComponent;

public interface IDAWAAddressDTOBOConverter
{
    DAWAAddress FromDTOToBO(DAWAAddressDTO dto);
    void FromDTOToBO(DAWAAddressDTO dto, DAWAAddress bo);
}
