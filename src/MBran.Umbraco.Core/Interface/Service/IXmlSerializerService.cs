namespace MBran.Umbraco.Core
{
    public interface IXmlSerializerService
    {
        string ToXmlString(object objectToSerialize);
    }
}
