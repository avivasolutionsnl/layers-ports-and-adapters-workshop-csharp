using System;
using System.IO;
using Xunit;
using FluentAssertions;

using Shared.Entity;

using Meetup.Util;

namespace Meetup
{
    public class MeetupRepositoryTest
    {
        private string filePath;
        private MeetupRepository meetupRepository;

        public MeetupRepositoryTest() 
        {
            filePath = Path.GetTempFileName() + ".txt";
            meetupRepository = new MeetupRepository(filePath);
        }

        [Fact]
        public void It_persists_and_retrieves_meetups()
        {
            var originalMeetup = MeetupFactory.SomeMeetup();
            meetupRepository.Add(originalMeetup);

            originalMeetup.Id.Should().BeGreaterThan(0);

            var restoredMeetup = meetupRepository.GetById(originalMeetup.Id);
            restoredMeetup.ShouldBeEquivalentTo(originalMeetup);
        }
        
        [Fact]        
        public void Its_initial_state_is_valid()
        {
            var upcomingMeetups = meetupRepository.GetUpcomingMeetups(DateTime.Now);

            upcomingMeetups.ShouldBeEquivalentTo(new Shared.Entity.Meetup[0]);
        }

        [Fact]        
        public void Its_lists_upcoming_meetups()
        {
            var pastMeetup = MeetupFactory.PastMeetup();
            meetupRepository.Add(pastMeetup);

            var upcomingMeetup = MeetupFactory.UpcomingMeetup();
            meetupRepository.Add(upcomingMeetup);

            var upcomingMeetups = meetupRepository.GetUpcomingMeetups(DateTime.Now);

            upcomingMeetups.ShouldBeEquivalentTo(new []{upcomingMeetup});
        }   

        [Fact]        
        public void Its_lists_past_meetups()
        {
            var pastMeetup = MeetupFactory.PastMeetup();
            meetupRepository.Add(pastMeetup);

            var upcomingMeetup = MeetupFactory.UpcomingMeetup();
            meetupRepository.Add(upcomingMeetup);

            var pastMeetups = meetupRepository.GetPastMeetups(DateTime.Now);

            pastMeetups.ShouldBeEquivalentTo(new []{pastMeetup});
        }              
    }
}
