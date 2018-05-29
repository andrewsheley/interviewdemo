using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewDemo.Mobile
{
    public class TokenResponse
    {
        public string token { get; set; }
        public int alive { get; set; }
    }


    public class TokenRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
