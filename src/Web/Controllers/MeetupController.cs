using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Shared.Entity;
using Web.Models;

namespace Web.Controllers
{
    public class MeetupController : Controller
    {
        private MeetupRepository meetupRepository;

        public MeetupController(MeetupRepository meetupRepository)
        {
            this.meetupRepository = meetupRepository;
        }

        public IActionResult Index()
        {
            var now = DateTime.Now;

            var upcomingMeetups = meetupRepository.GetUpcomingMeetups(now);
            var pastMeetups = meetupRepository.GetPastMeetups(now);

            return View(new MeetupOverview{
                UpcomingMeetups = upcomingMeetups,
                PastMeetups = pastMeetups
            });
        }

        public IActionResult Details(long id)
        {
            var meetup = meetupRepository.GetById(id);

            return View(meetup);
        }

        [HttpGet]
        public IActionResult Schedule()
        {
            return View(new ScheduleMeetup());
        }

        [HttpPost]
        public IActionResult Schedule(ScheduleMeetup meetup)
        {
            meetupRepository.Add(Meetup.Schedule(
                Name.FromString(meetup.Name),
                Description.FromString(meetup.Description), 
                meetup.ScheduledFor));  

            return Ok();
        }
    }
}
