using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guna.UI.WinForms;
using System.Windows.Forms;

namespace ParkingManagementSystem
{
    public partial class Tickets : Form
    {
        private int selectedSlot = 0;
        private Guna.UI.WinForms.GunaAdvenceTileButton selectedSlotButton = null; // Updated type to match GunaAdvenceTileButton
        private Dashboard1 mainFormInstance;

        public Tickets(Dashboard1 dashboard)
        {
            InitializeComponent();
            mainFormInstance = dashboard;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (mainFormInstance != null)
            {
                if (mainFormInstance.IsSlotOccupied(1)) gunaAdvenceTileButton1.Enabled = false;
                if (mainFormInstance.IsSlotOccupied(2)) gunaAdvenceTileButton2.Enabled = false;
                if (mainFormInstance.IsSlotOccupied(3)) gunaAdvenceTileButton3.Enabled = false;
            }
        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            if (selectedSlot > 0)
            {
                // Update the Main Form
                if (mainFormInstance != null && selectedSlotButton != null)
                {
                    mainFormInstance.UpdateSlotImage(selectedSlot /* other ticket details */);
                }

                this.Close();
            }
            else
            {
                SelectSlot selectSlotForm = new SelectSlot();
                selectSlotForm.ShowDialog();
            }
            this.Dispose();
        }

        private void gunaAdvenceTileButton1_Click(object sender, EventArgs e)
        {
            selectedSlot = 1;
            selectedSlotButton = gunaAdvenceTileButton1; // No error now as the type matches
            DisableAllSlotButtons(); // Disable other buttons
            gunaAdvenceTileButton1.Enabled = false; // Disable the clicked button
        }

        private void gunaAdvenceTileButton2_Click(object sender, EventArgs e)
        {
            selectedSlot = 2;
            selectedSlotButton = gunaAdvenceTileButton2; // No error now as the type matches
            DisableAllSlotButtons(); // Disable other buttons
            gunaAdvenceTileButton2.Enabled = false;
        }

        private void gunaAdvenceTileButton3_Click(object sender, EventArgs e)
        {
            selectedSlot = 3;
            selectedSlotButton = gunaAdvenceTileButton3; // No error now as the type matches
            DisableAllSlotButtons(); // Disable other buttons
            gunaAdvenceTileButton3.Enabled = false;
        }

        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DisableAllSlotButtons()
        {
            gunaAdvenceTileButton1.Enabled = true; // Temporarily enable all to ensure the selected one stays disabled
            gunaAdvenceTileButton2.Enabled = true;
            gunaAdvenceTileButton3.Enabled = true;
        }

        public void EnableSlotButton(int slotNumber)
        {
            if (slotNumber == 1) gunaAdvenceTileButton1.Enabled = true;
            else if (slotNumber == 2) gunaAdvenceTileButton2.Enabled = true;
            else if (slotNumber == 3) gunaAdvenceTileButton3.Enabled = true;
        }
    }
}
