namespace MBran.Core.Models
{
    public partial class File : BasePoco, IFile
    {
        public virtual string UmbracoBytes { get; set; }
        public virtual string UmbracoExtension { get; set; }
        public virtual string UmbracoFile { get; set; }
    }
}
