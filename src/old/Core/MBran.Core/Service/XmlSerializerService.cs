using System.Xml.Serialization;

namespace MBran.Core
{
    public class XmlSerializerService : IXmlSerializerService
    {
        public XmlSerializerService()
        {

        }
        public string ToXmlString(object objectToSerialize)
        {
            string xmlString;

            var xmlSerializer = new XmlSerializer(objectToSerialize.GetType());

            using (var textWriter = new StringWriterUtf8())
            {
                xmlSerializer.Serialize(textWriter, objectToSerialize);
                xmlString = textWriter.ToString();
            }

            return xmlString;
        }
    }
}
