using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;

namespace Carsharing
{
    class Controller
    {
        private LoginView loginView = new LoginView();
        private SignUpView signUpView = new SignUpView();
        private CarView carView = new CarView();
        private List<CarModel> carModels = new List<CarModel>();

        public Controller()
        {
            loginView.Control("loginButton").Click += loginViewLoginButtonClick;
            loginView.Control("signUpButton").Click += loginViewSignUpButtonClick;
            carView.Control("searchTextBox").TextChanged += carViewSearchTextBoxTextChanged;
            carView.Shown += carViewShown;
            signUpView.Control("signUpButton").Click += signUpViewSignUpButtonClick;
            signUpView.FormClosing += signUpViewFormClosing;
            loginView.ShowDialog();
        }

        private void signUpViewSignUpButtonClick(object sender, EventArgs e)
        {
            TextBox usernameTextBox = (TextBox)signUpView.Control("usernameTextBox");
            bool validInput = true;
            foreach (TextBox textBox in signUpView.Controls.OfType<TextBox>())
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    validInput = false;
                }
            }
            if (!string.IsNullOrWhiteSpace(usernameTextBox.Text) && Database.CheckUser(usernameTextBox.Text))
            {
                usernameTextBox.BackColor = System.Drawing.Color.Red;
            }
            else if (validInput)
            {
                try
                {
                    Database.InsertUser(signUpView.Control("usernameTextBox").Text,
                                        Encoding.UTF8.GetString(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(signUpView.Control("passwordTextBox").Text))),
                                        signUpView.Control("emailTextBox").Text,
                                        signUpView.Control("firstnameTextBox").Text, signUpView.Control("lastnameTextBox").Text,
                                        ((DateTimePicker)signUpView.Control("birthdayDateTimePicker")).Value.ToShortDateString(), signUpView.Control("ibanTextBox").Text, false);
                    signUpView.Close();
                }
                catch (Exception)
                {

                }
            }
        }

        private void signUpViewFormClosing(object sender, FormClosingEventArgs e)
        {
            loginView.Show();
        }

        private void loginViewSignUpButtonClick(object sender, EventArgs e)
        {
            loginView.Hide();
            signUpView.ShowDialog();
        }

        private void carViewShown(object sender, EventArgs e)
        {
            carModels = Database.GetCars();
            ((ListBox)carView.Control("carListBox")).Items.AddRange(carModels.ToArray());
        }

        private void carViewSearchTextBoxTextChanged(object sender, EventArgs e)
        {
            string searchText = ((TextBox)sender).Text;
            if (string.IsNullOrWhiteSpace(searchText))
            {
                ((ListBox)carView.Control("carListBox")).Items.Clear();
                ((ListBox)carView.Control("carListBox")).Items.AddRange(carModels.ToArray());
            }
            else
            {
                ((ListBox)carView.Control("carListBox")).Items.Clear();
                var a = carModels.Where(x => x.Name.Contains(searchText));
                ((ListBox)carView.Control("carListBox")).Items.AddRange(a.ToArray());
            }
        }

        private void loginViewLoginButtonClick(object sender, EventArgs e)
        {
            string username = loginView.Control("usernameTextBox").Text;
            string password = loginView.Control("passwordTextBox").Text;
            string passwordSha = Encoding.UTF8.GetString(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(password)));
            bool adminMode = false;
            if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(passwordSha) && Database.CheckUser(username, passwordSha))
            {
                adminMode = ((CheckBox)loginView.Control("adminModeCheckBox")).Checked && Database.CheckAdmin(username);
                loginView.Hide();
                foreach (TextBox textBox in carView.Controls.OfType<TextBox>())
                {
                    if (!textBox.Name.Equals("searchTextBox"))
                    {
                        textBox.ReadOnly = !adminMode;
                    }
                }
                carView.ShowDialog();
            }
        }
    }
}