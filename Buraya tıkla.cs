using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace The_System_That_Knows_You_Better_Than_You___
{
    public partial class Buraya_tıkla : Form
    {
        public Buraya_tıkla()
        {
            InitializeComponent();

            string mesaj = "Merhaba.";

            mesa_txtbox.Text = mesaj;
        }
    }
}
