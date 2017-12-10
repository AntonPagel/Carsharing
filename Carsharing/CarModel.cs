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

        private int locationId;
        public int LocationId
        {
            get { return locationId; }
            set { locationId = value; }
        }

        private string postcode;
        public string Postcode
        {
            get { return postcode; }
            set { postcode = value; }
        }

        private string city;
        public string City
        {
            get { return city; }
            set { city = value; }
        }

        private string street;
        public string Street
        {
            get { return street; }
            set { street = value; }
        }

        private LocationModel location;
        public LocationModel Location
        {
            get { return location; }
            set { location = value; }
        }

        public CarModel()
        {

        }
    }
}