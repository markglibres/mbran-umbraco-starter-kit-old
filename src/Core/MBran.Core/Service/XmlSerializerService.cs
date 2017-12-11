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
            string xmlString = string.Empty;

            XmlSerializer xmlSerializer = new XmlSerializer(objectToSerialize.GetType());

            using (StringWriterUTF8 textWriter = new StringWriterUTF8())
            {
                xmlSerializer.Serialize(textWriter, objectToSerialize);
                xmlString = textWriter.ToString();
            }

            return xmlString;
        }
    }
}
