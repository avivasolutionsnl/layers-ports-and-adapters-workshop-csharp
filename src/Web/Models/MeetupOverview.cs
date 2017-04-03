using System.Collections.Generic;

using Web.Entity;

namespace Web.Models
{
    public class MeetupOverview
    {
        public IEnumerable<Meetup> UpcomingMeetups{get;set;}
        public IEnumerable<Meetup> PastMeetups{get;set;}
    }
}