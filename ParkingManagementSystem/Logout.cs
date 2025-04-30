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
    public partial class Logout: Form
    {

        private Dashboard1 _dashboardInstance;
        public Logout(Dashboard1 dashboardInstance)
        {
            InitializeComponent();
            _dashboardInstance = dashboardInstance;
        }

        private void gunaLabel1_Click(object sender, EventArgs e)
        {

        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();

            // 2. Dispose the referenced Dashboard instance
            if (_dashboardInstance != null && !_dashboardInstance.IsDisposed)
            {
                _dashboardInstance.Dispose();
            }

            // 3. Dispose the current Logout form
            this.Dispose();
        }

        private void Logout_Load(object sender, EventArgs e)
        {

        }
    }
}
