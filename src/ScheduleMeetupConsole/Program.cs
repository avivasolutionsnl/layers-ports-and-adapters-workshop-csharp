using System;

using Shared.Entity;

namespace ScheduleMeetupConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var meetupRepository = new MeetupRepository("//app//var//meetup.txt");

            meetupRepository.Add(Meetup.Schedule(Name.FromString("Helix workshop"), Description.FromString("Mooi"), DateTime.Now));
        }
    }
}
