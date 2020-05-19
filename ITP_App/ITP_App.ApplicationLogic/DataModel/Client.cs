using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ITP_App.ApplicationLogic.DataModel
{
    public class Client
    {
        public Guid Id { set; get; }
        public Guid UserId { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Email { set; get; }
    }
}
