using System;
using Shared.Command;

namespace ScheduleMeetupConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            new MeetupApplicationConfig().Execute(args);
        }
    }
}
