using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ITP_App.ApplicationLogic.DataModel
{
    public class Review
    {
        [Key]
        public Guid Id { set; get; }
        public string Rating { set; get; }
        public string Title { set; get; }
        public string Text { set; get; }
        public Client Client { set; get; }
    }
}

