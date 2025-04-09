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
    public partial class RemoveTicket: Form
    {
        private int selectedSlot = 0;
        private Dashboard1 mainFormInstance;
        public RemoveTicket(Dashboard1 dashboard)
        {
            InitializeComponent();
            mainFormInstance = dashboard;
        }

        private void RemoveTicket_Load(object sender, EventArgs e)
        {

        }

        private void gunaAdvenceTileButton1_Click(object sender, EventArgs e)
        {
            selectedSlot = 1; // Set selectedSlot when Slot 1 is clicked
        }

        private void gunaAdvenceTileButton2_Click(object sender, EventArgs e)
        {
            selectedSlot = 2; // Set selectedSlot when Slot 2 is clicked
        }

        private void gunaAdvenceTileButton3_Click(object sender, EventArgs e)
        {
            selectedSlot = 3; // Set selectedSlot when Slot 3 is clicked
        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            this.Close(); // Assuming this is your "Cancel" or "Close" button
            this.Dispose();
        }

        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {
            if (selectedSlot > 0)
            {
                // Update the Main Form
                if (mainFormInstance != null)
                {
                    mainFormInstance.ReleaseSlot(selectedSlot);
                }
                this.Close();
                this.Dispose();
            }
            else
            {
                SelectSlot selectSlot = new SelectSlot();
                selectSlot.ShowDialog();
                // You might need to handle data returned from SelectSlot here to update selectedSlot
            }
        }
    }
}