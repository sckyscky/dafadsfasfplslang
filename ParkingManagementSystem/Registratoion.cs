using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingManagementSystem
{
    public partial class Registratoion: Form
    {
        public Registratoion()
        {
            InitializeComponent();
        }

        private void gunaAdvenceButton4_Click(object sender, EventArgs e)
        {
            addmsgbox add = new addmsgbox();
            add.ShowDialog();
        }
    }
}
