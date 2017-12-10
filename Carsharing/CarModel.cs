using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carsharing
{
    class CarModel
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string make;
        public string Make
        {
            get { return make; }
            set { make = value; }
        }

        private int power;
        public int Power
        {
            get { return power; }
            set { power = value; }
        }

        private int seats;
        public int Seats
        {
            get { return seats; }
            set { seats = value; }
        }

        private int trunksize;
        public int Trunksize
        {
            get { return trunksize; }
            set { trunksize = value; }
        }

        private string carClass;
        public string CarClass
        {
            get { return carClass; }
            set { carClass = value; }
        }

        private string gearbox;
        public string Gearbox
        {
            get { return gearbox; }
            set { gearbox = value; }
        }

        private string fuel;
        public string Fuel
        {
            get { return fuel; }
            set { fuel = value; }
        }

        private bool coupling;
        public bool Coupling
        {
            get { return coupling; }
            set { coupling = value; }
        }

        private DateTime reserved;
        public DateTime Reserved
        {
            get { return reserved; }
            set { reserved = value; }
        }

        private DateTime blocked;
        public DateTime Blocked
        {
            get { return blocked; }
            set { blocked = value; }
        }

        private LocationModel location;
        public LocationModel Location
        {
            get { return location; }
            set { location = value; }
        }

        private string reservedBy;
        public string ReservedBy
        {
            get { return reservedBy; }
            set { reservedBy = value; }
        }

        private string blockedBy;
        public string BlockedBy
        {
            get { return blockedBy; }
            set { blockedBy = value; }
        }

        public CarModel()
        {

        }
    }
}