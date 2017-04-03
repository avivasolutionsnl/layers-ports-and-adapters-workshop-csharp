using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Web.Entity;
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

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
