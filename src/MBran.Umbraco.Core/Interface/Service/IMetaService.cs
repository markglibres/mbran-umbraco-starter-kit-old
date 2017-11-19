using MBran.Umbraco.Models;

namespace MBran.Umbraco.Core
{
    public interface IMetaService
    {
        MetaTagHeaderComponentModel Header { get; }
        Image Image { get; }
    }
}
