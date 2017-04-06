using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Shared.Entity 
{
    public class Meetup : IXmlSerializable
    {
        public long Id {get; private set;}
        public Name Name {get; private set;}
        public Description Description {get; private set;}
        public DateTime ScheduledFor {get; private set;}

        public static Meetup Schedule(Name name, Description description, DateTime scheduledFor)
        {
            return new Meetup
            {
                Name = name,
                Description = description,
                ScheduledFor = scheduledFor
            };
        }   

        public bool IsUpcoming(DateTime now)
        {
            return now < ScheduledFor;
        }

        public void SetId(long id)
        {
            Id = id;
        }

        public void WriteXml (XmlWriter writer)
        {
            writer.WriteStartElement("Id");
            writer.WriteValue(Id);
            writer.WriteEndElement();
            writer.WriteStartElement("Name");
            Name.WriteXml(writer);
            writer.WriteEndElement();   
            writer.WriteStartElement("Description");
            Description.WriteXml(writer);
            writer.WriteEndElement();        
            writer.WriteStartElement("ScheduledFor");
            writer.WriteValue(ScheduledFor);
            writer.WriteEndElement();                                        
        }

        public void ReadXml (XmlReader reader)
        {
            Id = reader.ReadContentAsLong();
            Name = (Name)reader.ReadElementContentAs(typeof(Name), null);
            Description = (Description)reader.ReadElementContentAs(typeof(Description), null);
        }

        public XmlSchema GetSchema()
        {
            return(null);
        }
    }
}


