using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ITP_App.ApplicationLogic.DataModel
{
    public class Rules
    {
        [Key]
        public Guid Id { set; get; }
        public string Name { set; get; }
        public string Text { set; get; }
        public Admin Admin { set; get; }
    }
}
