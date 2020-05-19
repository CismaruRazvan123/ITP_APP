using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ITP_App.ApplicationLogic.DataModel
{
    public class Car
    {
        [Key]
        public Guid Id { set; get; }
        public string CarType { set; get; }
        public string CivSeries { set; get; }
        public string BodySeries { set; get; }
        public int CarMileage { set; get; }
        public int YearOfManufacture { set; get; }
        public string ItpValability { set; get; }
        public Admin Admin { set; get; }
        public Owner Owner { set; get; }
    }
}
