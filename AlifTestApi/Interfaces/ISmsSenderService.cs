using AlifTestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlifTestApi.Interfaces
{
    public interface ISmsSenderService
    {
        public SmsSenderResponse SubmitSms(string phoneNumber, string smsText, string smsSenderName);
    }
}
