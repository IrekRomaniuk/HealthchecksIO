using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace HealthchecksIO
{
    public partial class Healthchecks : ServiceBase
    {
        public Healthchecks()
        {
            InitializeComponent();
            eventLog1 = new System.Diagnostics.EventLog();
            if (!System.Diagnostics.EventLog.SourceExists("HealthchecksIOSource"))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    "HealthchecksIOSource", "HealthchecksIOLog");
            }
            eventLog1.Source = "HealthchecksIOSource";
            eventLog1.Log = "HealthchecksIOLog";
        }

        protected override void OnStart(string[] args)
        {
            eventLog1.WriteEntry("HealthchecksIO started");
        }

        protected override void OnStop()
        {
            eventLog1.WriteEntry("HealthchecksIO stopped");
        }
    }
}
