using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppointmentReminders.Domain
{
    public interface ITimeConverter
    {
        DateTime ToLocalTime(DateTime time, string timezone);
    }

    public class TimeConverter : ITimeConverter
    {
        public DateTime ToLocalTime(DateTime time, string timezone)
        {
            return TimeZoneInfo.ConvertTimeToUtc(
                time,
                TimeZoneInfo.FindSystemTimeZoneById(timezone))
                .ToLocalTime();
        }
    }
}