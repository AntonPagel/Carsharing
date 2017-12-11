using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carsharing
{
    public class CarModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Make { get; set; }
        public int Power { get; set; }
        public int Seats { get; set; }
        public int Trunksize { get; set; }
        public string CarClass { get; set; }
        public string Gearbox { get; set; }
        public string Fuel { get; set; }
        public bool Coupling { get; set; }
        public DateTime Reserved { get; set; }
        public DateTime Blocked { get; set; }
        public LocationModel Location { get; set; }
        public string ReservedBy { get; set; }
        public string BlockedBy { get; set; }

        public CarModel()
        {

        }

        public bool CurrentlyReserved()
        {
            return (Reserved - DateTime.Now).CompareTo(TimeSpan.Zero) >= 0;
        }

        public bool CurrentlyBlocked()
        {
            return (Blocked - DateTime.Now).CompareTo(TimeSpan.Zero) >= 0;
        }
    }
}