using ConsoleApp12;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventViewerDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = "Application";
                eventLog.WriteEntry("Log message example", EventLogEntryType.Information, 101, 1);
            }
        }

    }
}
