namespace MBran.Umbraco.Core
{
    public interface IMetaService
    {
        string Title { get; }
        string Description { get; }
        Image Image { get; }
    }
}
