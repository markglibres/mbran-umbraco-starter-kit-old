namespace MBran.Core.Models.Pocos
{
    public partial class Folder : BasePoco, IFolder
    {
        public virtual object Contents { get; set; }
    }
}
