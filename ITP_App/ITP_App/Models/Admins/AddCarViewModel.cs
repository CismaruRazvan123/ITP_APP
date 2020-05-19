using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITP_App.Models.Admins
{
    public class AddCarViewModel
    {
        public string CarType { set; get; }
        public string CivSeries { set; get; }
        public string BodySeries { set; get; }
        public int CarMileage { set; get; }
        public int YearOfManufacture { set; get; }
        public string ItpValability { set; get; }
        public string OwnerFirstName { set; get; }
        public string OwnerLastName { set; get; }
        public string OwnerCNP { set; get; }
    }
}
