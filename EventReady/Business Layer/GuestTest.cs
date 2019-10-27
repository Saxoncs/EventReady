using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventReady.Business_Layer
{
    public class GuestTest
    {
       
        public GuestTest(string email, int status)
        {
            Email = email;
            Status = status;

        }
        public string Email { get; set; }
        public int Status { get; set; }
    }
    

 
 
}