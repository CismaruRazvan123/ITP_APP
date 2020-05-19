using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ITP_App.ApplicationLogic.DataModel
{
    public class Owner
    {
        [Key]
        public Guid Id { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string CNP { set; get; }
    }
}
