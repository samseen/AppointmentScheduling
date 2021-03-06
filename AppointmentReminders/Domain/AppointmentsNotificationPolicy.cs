﻿using AppointmentReminders.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppointmentReminders.Domain
{
    public class AppointmentsNotificationPolicy
    {
        private readonly Appointment _appointment;
        private readonly ITimeConverter _timeConverter;

        public AppointmentsNotificationPolicy(Appointment appointment, ITimeConverter timeConverter)
        {
            _appointment = appointment;
            _timeConverter = timeConverter;
        }

        public bool NeedsToBeSent(DateTime currentTime)
        {
            var reminderLocalTime = GetAppointmentLocalTime()
                .AddMinutes(-Appointment.ReminderTime); // Notify our appointment attendee
                                                        // X minutes before the appointment time

            string formattedCurrentTime = currentTime.ToString("MM/dd/yyyy HH:mm");
            string formattedLocalTime = reminderLocalTime.ToString("MM/dd/yyyy HH:mm");
            return formattedCurrentTime == formattedLocalTime;
        }

        private DateTime GetAppointmentLocalTime()
        {
            return _timeConverter.ToLocalTime(_appointment.Time, _appointment.Timezone);
        }
    }
}