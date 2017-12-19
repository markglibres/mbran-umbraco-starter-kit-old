using System.IO;
using System.Text;

namespace MBran.Core
{
    public class StringWriterUtf8 : StringWriter
    {
        public override Encoding Encoding => Encoding.UTF8;
    }
}
