using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyCoolService
{
    public partial class MyCoolService : ServiceBase
    {
        public MyCoolService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = "Application";
                eventLog.WriteEntry("My cool service started ...", EventLogEntryType.Information, 101, 1);
            }
}
        }

        protected override void OnStop()
        {
            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = "Application";
                eventLog.WriteEntry("My cool service finished...", EventLogEntryType.Information, 101, 1);
            }
        }
    }
}

