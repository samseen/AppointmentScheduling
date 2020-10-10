using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Twilio.Clients;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using System.Web.Configuration;

namespace AppointmentReminders.Domain.Twilio
{
    public class RestClient
    {
        private readonly ITwilioRestClient _client;
        private readonly string _accountSid = WebConfigurationManager.AppSettings["AccountSid"];
        private readonly string _authToken = WebConfigurationManager.AppSettings["AuthToken"];
        private readonly string _twilioNumber = WebConfigurationManager.AppSettings["TwilioNumber"];

        public RestClient()
        {
            _client = new TwilioRestClient(_accountSid, _authToken);
        }

        public RestClient(ITwilioRestClient client)
        {
            _client = client;
        }

        public void SendSmsMessage(string phoneNumber, string message)
        {
            var to = new PhoneNumber(phoneNumber);
            MessageResource.Create(
                to,
                from: new PhoneNumber(_twilioNumber),
                body: message,
                client: _client);
        }
    }
}