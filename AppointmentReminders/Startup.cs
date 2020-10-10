using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(AppointmentReminders.Startup))]
namespace AppointmentReminders
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Hangfire.ConfigureHangFire(app);
            Hangfire.InitiateJobs();
        }
    }
}