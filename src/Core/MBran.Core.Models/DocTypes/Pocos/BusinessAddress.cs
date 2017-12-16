namespace MBran.Core.Models
{
    public partial class BusinessAddress : BasePoco, IBusinessAddress
    {
        public virtual string BusinessAddress1 { get; set;  }
        public virtual string BusinessAddress2 { get; set; }
        public virtual string BusinessAddressCity { get; set; }
        public virtual string BusinessAddressCountry { get; set; }
        public virtual string BusinessAddressState { get; set; }
        public virtual string BusinessAddressZip { get; set; }
    }
}
