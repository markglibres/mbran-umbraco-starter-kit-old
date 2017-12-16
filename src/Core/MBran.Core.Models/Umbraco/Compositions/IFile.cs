namespace MBran.Core.Models
{
    public partial interface IFile
    {
        string UmbracoBytes { get; set; }
        string UmbracoExtension { get; set; }
        string UmbracoFile { get; set; }
    }
}
