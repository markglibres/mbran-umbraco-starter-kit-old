namespace MBran.Core.Models
{
    public partial class ContentHeader : BasePoco, IContentHeader
    {
        public virtual string ContentSummary { get; set; }
        public virtual string ContentTitle { get; set; }
    }
}
