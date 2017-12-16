namespace MBran.Core.Models
{ 
    public partial class MetaTagHeader : BasePoco, IMetaTagHeader
    {
        public virtual string MetaDescription { get; set; }
        public virtual string MetaTitle { get; set; }
    }
}
