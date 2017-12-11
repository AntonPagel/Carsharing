using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Carsharing
{
    public partial class CarView : Form
    {
        private Controller controller;

        public CarView(Controller controller)
        {
            this.controller = controller;
            InitializeComponent();
        }

        private void CarViewShown(object sender, EventArgs e)
        {
            foreach (TextBox textBox in Controls.OfType<TextBox>())
            {
                if (!textBox.Name.Equals("searchTextBox"))
                {
                    textBox.ReadOnly = !controller.UserModel.Admin;
                }
            }
            saveButton.Visible = controller.UserModel.Admin;
            addCarButton.Visible = controller.UserModel.Admin;
            foreach (CarModel carModel in controller.GetCars())
            {
                if (!carModel.CurrentlyReserved() && !carModel.CurrentlyBlocked())
                {
                    controller.CarModels.Add(carModel);
                }
                else if (controller.UserModel.Username.Equals(carModel.ReservedBy))
                {
                    controller.CarModels.Add(carModel);
                }
                else if (controller.UserModel.Username.Equals(carModel.BlockedBy))
                {
                    controller.CarModels.Add(carModel);
                }
            }
            carListBox.Items.AddRange(controller.CarModels.ToArray());
        }

        private void SearchTextBoxTextChanged(object sender, EventArgs e)
        {
            string searchText = searchTextBox.Text;
            if (string.IsNullOrWhiteSpace(searchText))
            {
                carListBox.Items.Clear();
                carListBox.Items.AddRange(controller.CarModels.ToArray());
            }
            else
            {
                CarModel[] selectedCarModels = controller.CarModels.Where(x => x.Name.ToUpper().Contains(searchText.ToUpper())).ToArray();
                carListBox.Items.Clear();
                carListBox.Items.AddRange(selectedCarModels);
            }
        }

        private void CarListBoxSelectedValueChanged(object sender, EventArgs e)
        {
            CarModel carModel = carListBox.SelectedItem as CarModel;
            nameTextBox.Text = carModel.Name;
            if (carModel.CurrentlyBlocked())
            {
                nameTextBox.BackColor = Color.Red;
            }
            else if (carModel.CurrentlyReserved())
            {
                nameTextBox.BackColor = Color.Yellow;
            }
            else
            {
                nameTextBox.BackColor = SystemColors.Window;
            }
            makeTextBox.Text = carModel.Make;
            powerTextBox.Text = carModel.Power.ToString();
            seatsTextBox.Text = carModel.Seats.ToString();
            trunksizeTextBox.Text = carModel.Trunksize.ToString();
            classTextBox.Text = carModel.CarClass;
            gearboxTextBox.Text = carModel.Gearbox;
            fuelTextBox.Text = carModel.Fuel;
            couplingTextBox.Text = carModel.Coupling.ToString();
            postcodeTextBox.Text = carModel.Location.Postcode;
            cityTextBox.Text = carModel.Location.City;
            streetTextBox.Text = carModel.Location.Street;
        }

        private void ReserveButtonClick(object sender, EventArgs e)
        {
            CarModel carModel = carListBox.SelectedItem as CarModel;
            if (carModel != null && !carModel.CurrentlyReserved() && !carModel.CurrentlyBlocked())
            {
                carModel.Reserved = DateTime.Now.AddHours(2);
                carModel.ReservedBy = controller.UserModel.Username;
                controller.UpdateCarReserved(carModel.Id, carModel.Reserved, carModel.ReservedBy);
            }
        }

        private void SaveButtonClick(object sender, EventArgs e)
        {
            if (carListBox.SelectedItem == null)
            {
                return;
            }
            foreach (TextBox textBox in Controls.OfType<TextBox>())
            {
                if (textBox.Name.Equals("searchTextBox"))
                {

                }
                else if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    return;
                }
            }
            CarModel carModel = carListBox.SelectedItem as CarModel;
            carModel.Name = nameTextBox.Text;
            carModel.Make = makeTextBox.Text;
            carModel.Power = Convert.ToInt32(powerTextBox.Text);
            carModel.Seats = Convert.ToInt32(seatsTextBox.Text);
            carModel.Trunksize = Convert.ToInt32(trunksizeTextBox.Text);
            carModel.CarClass = classTextBox.Text;
            carModel.Gearbox = gearboxTextBox.Text;
            carModel.Fuel = fuelTextBox.Text;
            carModel.Coupling = Convert.ToBoolean(couplingTextBox.Text);
            carModel.Location = new LocationModel()
            {
                Postcode = postcodeTextBox.Text,
                City = cityTextBox.Text,
                Street = streetTextBox.Text
            };
            carModel.Location.Id = controller.GetLocationId(carModel.Location.Postcode, carModel.Location.City, carModel.Location.Street);
            if (carModel.Location.Id == 0)
            {
                controller.InsertLocation(carModel.Location.Postcode, carModel.Location.City, carModel.Location.Street);
                carModel.Location.Id = controller.GetLocationId(carModel.Location.Postcode, carModel.Location.City, carModel.Location.Street);
            }
            controller.UpdateCar(carModel.Id, carModel.Name, carModel.Make, carModel.Power, carModel.Seats, carModel.Trunksize, carModel.CarClass, carModel.Gearbox, carModel.Fuel, carModel.Coupling, carModel.Location.Id);
        }

        private void AddCarButtonClick(object sender, EventArgs e)
        {
            controller.InsertCar("Neues Auto", "", 0, 0, 0, "", "", "", false, 1, new DateTime(), new DateTime(), "", "");
            carListBox.Items.Clear();
            foreach (CarModel carModel in controller.GetCars())
            {
                if (!carModel.CurrentlyReserved() && !carModel.CurrentlyBlocked())
                {
                    controller.CarModels.Add(carModel);
                }
                else if (controller.UserModel.Username.Equals(carModel.ReservedBy))
                {
                    controller.CarModels.Add(carModel);
                }
                else if (controller.UserModel.Username.Equals(carModel.BlockedBy))
                {
                    controller.CarModels.Add(carModel);
                }
            }
            carListBox.Items.AddRange(controller.CarModels.ToArray());
        }
    }
}