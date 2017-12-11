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
    public partial class SignUpView : Form
    {
        private Controller controller;

        public SignUpView(Controller controller)
        {
            this.controller = controller;
            InitializeComponent();
        }

        private void SignUpButtonClick(object sender, EventArgs e)
        {
            foreach (TextBox textBox in Controls.OfType<TextBox>())
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    return;
                }
            }
            if (controller.InsertUser(usernameTextBox.Text,
                Encoding.UTF8.GetString(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(passwordTextBox.Text))),
                emailTextBox.Text, firstnameTextBox.Text, lastnameTextBox.Text,
                birthdayDateTimePicker.Value.ToShortDateString(), ibanTextBox.Text, false))
            {
                Close();
            }
        }
    }
}