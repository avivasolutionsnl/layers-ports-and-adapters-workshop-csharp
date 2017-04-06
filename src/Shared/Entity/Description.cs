using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Shared.Entity
{
    public class Description : IXmlSerializable
    {
        private string text;

        internal Description(){}
        
        private Description(string text)
        {
            this.text = text;
        }
      

        public static Description FromString(string text)
        {
            return new Description(text);
        }

        public override string ToString()
        {
            return text;
        }
        
        public void WriteXml (XmlWriter writer)
        {
            writer.WriteString(text);
        }

        public void ReadXml (XmlReader reader)
        {
            text = reader.ReadContentAsString();
        }

        public XmlSchema GetSchema()
        {
            return(null);
        }
    }
}