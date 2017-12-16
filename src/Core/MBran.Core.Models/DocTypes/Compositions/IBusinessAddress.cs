namespace MBran.Core.Models
{
    public partial interface IBusinessAddress
    {
        string BusinessAddress1 { get; set; }
        string BusinessAddress2 { get; set; }
        string BusinessAddressCity { get; set; }
        string BusinessAddressCountry { get; set; }
        string BusinessAddressState { get; set; }
        string BusinessAddressZip { get; set; }
    }
}
