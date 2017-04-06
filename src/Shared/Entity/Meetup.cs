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
        public DateTimeOffset ScheduledFor {get; private set;}

        public static Meetup Schedule(Name name, Description description, DateTimeOffset scheduledFor)
        {
            return new Meetup
            {
                Name = name,
                Description = description,
                ScheduledFor = scheduledFor
            };
        }   

        public bool IsUpcoming(DateTimeOffset now)
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
            reader.ReadStartElement();
            reader.ReadStartElement("Id");
            Id = reader.ReadContentAsLong();
            reader.ReadEndElement();

            reader.ReadStartElement("Name");
            var name = new Name();
            name.ReadXml(reader);
            Name = name;
            reader.ReadEndElement();

            reader.ReadStartElement("Description");
            var description = new Description();
            description.ReadXml(reader);
            Description = description;
            reader.ReadEndElement();

            reader.ReadStartElement("ScheduledFor");
            ScheduledFor = reader.ReadContentAsDateTimeOffset();
            reader.ReadEndElement();
            reader.ReadEndElement();
        }

        public XmlSchema GetSchema()
        {
            return(null);
        }
    }
}


