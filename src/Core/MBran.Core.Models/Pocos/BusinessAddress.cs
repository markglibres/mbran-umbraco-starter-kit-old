namespace MBran.Core.Models
{
    public partial class BusinessAddress : IBusinessAddress
    {
        public string BusinessAddress1 { get; set;  }

        public string BusinessAddress2 { get; set; }
        public string BusinessAddressCity { get; set; }
        public string BusinessAddressCountry { get; set; }
        public string BusinessAddressState { get; set; }
        public string BusinessAddressZip { get; set; }
    }
}
