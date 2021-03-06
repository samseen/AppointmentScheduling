﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace AppointmentReminders.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ToCustomDateString(this DateTime dateTime)
        {
            return dateTime.ToString("MM/dd/yyyy hh:mm tt", new CultureInfo("en-US"));
        }
    }
}