using System;
using System.Collections.Generic;

using Shared.Entity;

namespace Web.Models
{
    public class ScheduleMeetup
    {
        public string Name {get;set;}
        public string Description {get;set;}
        public DateTimeOffset ScheduledFor {get;set;}
    }
}