using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Carsharing
{
    public partial class LoginView : Form
    {
        private Controller controller;
        private SignUpView signUpView;
        private CarView carView;

        public LoginView(Controller controller)
        {
            this.controller = controller;
            signUpView = new SignUpView(controller);
            carView = new CarView(controller);
            carView.FormClosed += CarViewFormClosed;
            InitializeComponent();
        }

        private void CarViewFormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        private void LoginButtonClick(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;
            string passwordSha = Encoding.UTF8.GetString(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(password)));
            controller.UserModel = controller.GetUser(username);
            if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password) && controller.UserModel != null && controller.UserModel.Check(username, passwordSha))
            {
                controller.UserModel.Admin &= adminModeCheckBox.Checked;
                Hide();
                carView.Show();
            }
        }

        private void SignUpButtonClick(object sender, EventArgs e)
        {
            signUpView.ShowDialog();
        }
    }
}