using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carsharing
{
    public class LocationModel
    {
        public int Id { get; set; }
        public string Postcode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }

        public LocationModel()
        {
            Id = 0;
        }
    }
}