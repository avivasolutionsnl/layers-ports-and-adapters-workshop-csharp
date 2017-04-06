using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Shared.Entity
{
    public class Name : IXmlSerializable
    {
        private string text;
        
        internal Name(){}

        private Name(string text)
        {
            this.text = text;
        }
        public static Name FromString(string text)
        {
            return new Name(text);
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