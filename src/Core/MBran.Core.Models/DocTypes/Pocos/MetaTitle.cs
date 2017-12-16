namespace MBran.Core.Models
{
    public class MetaTitle : BasePoco, IMetaTitle
    {
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
    }
}
