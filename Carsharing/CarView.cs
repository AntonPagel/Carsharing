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
        public CarView()
        {
            InitializeComponent();
        }

        public Control Control(string key)
        {
            return Controls.Find(key, false).First();
        }
    }
}