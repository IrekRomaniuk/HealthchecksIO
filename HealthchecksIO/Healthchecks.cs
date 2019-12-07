using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HealthchecksIO
{
    public partial class Healthchecks : ServiceBase
    {
        ILog logger;
        Timer healthcheck;

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
            ConfigureLog4Net();
            int timer = Properties.Settings.Default.Timer;
            logger.Debug(string.Format("Timer is: {0}", timer));
            healthcheck = new Timer(HealthcheckCallback, healthcheck, timer, timer);            
        }

        protected override void OnStop()
        {
            eventLog1.WriteEntry("HealthchecksIO stopped");
        }
        private void ConfigureLog4Net()
        {
            try
            {
                log4net.Config.XmlConfigurator.Configure();
                logger = LogManager.GetLogger("servicelog");
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(ex.Message, EventLogEntryType.Error);
            }
        }

        public void HealthcheckCallback(object objParam)
        {
            //System.Diagnostics.Debug.WriteLine(stri
            
            
            
            ng.Format());
            logger.Debug(string.Format("Calling {0}", "https://hc-ping.com/" + Properties.Settings.Default.API));
            using (var client = new System.Net.WebClient())
            {
                client.DownloadString("https://hc-ping.com/"+ Properties.Settings.Default.API);                
            }

        }
    }
}
