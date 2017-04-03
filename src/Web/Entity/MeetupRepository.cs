using System;
using System.Xml.Serialization;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Web.Entity
{
    public class MeetupRepository
    {
        private string filePath;

        public MeetupRepository(string filePath) 
        {
            this.filePath = filePath;
        }

        public void Add(Meetup meetup)
        {
            var meetups = GetPersistedMeetups();

            var id = meetups.Count() + 1;

            meetup.SetId(id);

            PersistMeetups(meetups.Union(new []{meetup}));
        }

        public Meetup GetById(int id)
        {
            var meetups = GetPersistedMeetups();

            var meetup = meetups.SingleOrDefault(x => x.Id == id);

            if(meetup == null)
            {
                throw new ArgumentException("Meetup not found");
            }

            return meetup;
        }

        public IEnumerable<Meetup> GetUpcomingMeetups(DateTime now)
        {
            var meetups = GetPersistedMeetups();

            return meetups.Where(x => x.IsUpcoming(now));
        }

        public IEnumerable<Meetup> GetPastMeetups(DateTime now)
        {
            var meetups = GetPersistedMeetups();

            return meetups.Where(x => !x.IsUpcoming(now));
        }

        private void PersistMeetups(IEnumerable<Meetup> meetups) 
        {
            using(var fileStream = File.OpenWrite(filePath))
            {
                var serializer = new XmlSerializer(typeof(IEnumerable<Meetup>));

                serializer.Serialize(fileStream, meetups);
            }
        }

        private IEnumerable<Meetup> GetPersistedMeetups()
        {
            if(!File.Exists(filePath))
            {
                return Enumerable.Empty<Meetup>();
            }

            using(var fileStream = File.OpenRead(filePath))
            {
                var serializer = new XmlSerializer(typeof(IEnumerable<Meetup>));

                return (IEnumerable<Meetup>)serializer.Deserialize(fileStream);
            }
        }
    }
}