

using System;
using Twilio.Rest.Api.V2010.Account;

namespace AlAl3abProject.Services
{
    public interface ISMSService
    {
        MessageResource Send(string mobileNumber, string body);
    }
}