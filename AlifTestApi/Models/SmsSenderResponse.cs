using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlifTestApi.Models
{
    public class SmsSenderResponse 
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public int ErrorCode { get; set; }

    }
}
