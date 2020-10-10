using AppointmentReminders.Models;
using AppointmentReminders.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppointmentReminders.Domain
{
    public class AppointmentsFinder
    {
        private readonly IAppointmentRepository _repository;
        private readonly ITimeConverter _timeConverter;

        public AppointmentsFinder(IAppointmentRepository repository, ITimeConverter timeConverter)
        {
            _repository = repository;
            _timeConverter = timeConverter;
        }

        public IList<Appointment> FindAvailableAppointments(DateTime currentTime)
        {
            var appts = _repository.FindAll();
            var availableAppointments = _repository.FindAll()
                .Where(appointment =>
                    new AppointmentsNotificationPolicy(
                        appointment, _timeConverter)
                    .NeedsToBeSent(currentTime));


            return availableAppointments.ToList();
        }
    }
}