using AlifTestApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using AlifTestApi.Interfaces;

namespace AlifTestApi.Services
{
    public class SmsSenderService : ISmsSenderService
    {
        private const string ApiEndPoint = "https://127.0.0.1:8682/sendSms/";
        private SmsSenderResponse response;
        

        public SmsSenderService()
        {
            response = new SmsSenderResponse();
        }


        public SmsSenderResponse SubmitSms(string phoneNumber, string smsText,string smsSenderName)
        {
            try
            {

                var uri = $"?msisdn={phoneNumber}&smsText={smsText}&smsSenderName={smsSenderName}";
       
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(ApiEndPoint + uri);

                request.ContentType = "application/json";
                request.Method = "GET";
                request.Timeout = 6000;
               
                var webResponse = request.GetResponse();

                var webStream = webResponse.GetResponseStream();

                string jsonResponse;

                using (StreamReader responseReader = new StreamReader(webStream))
                {
                     jsonResponse = responseReader.ReadToEnd();
                }

                var result = JsonConvert.DeserializeObject<SmsApiResponse>(jsonResponse);
                

                response.IsSuccess = false;
                response.Message = result.ErrorMessage;
                response.ErrorCode = result.ErrorCode;

                if (result.ErrorCode == 1)
                {
                    response.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
