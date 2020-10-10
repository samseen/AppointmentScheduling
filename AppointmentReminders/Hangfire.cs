using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hangfire;
using System.Web.Http;

namespace AppointmentReminders
{
    public class Hangfire
    {
        public static void ConfigureHangFire(IAppBuilder app)
        {
            GlobalConfiguration.Configuration.UseSqlServerStorage("DefaultConnection");

            app.UseHangfireDashboard("/jobs");
            app.UseHangfireServer();
        }

        public static void InitiateJobs()
        {
            RecurringJob.AddOrUpdate<Workers.SendNotificationsJob>(job => job.Execute(), Cron.Minutely);
        }
    }
}