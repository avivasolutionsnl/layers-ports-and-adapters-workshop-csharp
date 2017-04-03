using System;

namespace Web.Entity
{
    public class Meetup 
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
    }
}


