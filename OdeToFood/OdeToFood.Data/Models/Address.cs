using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string StreetName { get; set; }
        public int HouseNumber { get; set; }
        public int ApartamentNumber { get; set; }
        public City City { get; set; }
    }
}
