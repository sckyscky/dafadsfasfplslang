using Guna.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ParkingManagementSystem
{

   
    public partial class Dashboard1 : Form
    {
        private bool[] isSlotOccupied = { false, false, false }; // Array to track slot occupancy
        private Image occupiedSlotImage;
        private Image[] originalSlotImages = new Image[3];

        // Update the access modifier of gunaPictureBox1, gunaPictureBox2, and gunaPictureBox3 to public  
       

        public Dashboard1()
        {
            InitializeComponent();
            InitializeTimer();
            occupiedSlotImage = Properties.Resources.OCCUPIED__1_;
            originalSlotImages[0] = gunaPictureBox1.Image;
            originalSlotImages[1] = gunaPictureBox2.Image;
            originalSlotImages[2] = gunaPictureBox3.Image;

        }

       

        private void gunaPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            gunaLabel3.Text = DateTime.Now.ToString("hh:mm tt");
            gunaLabel4.Text = DateTime.Now.ToString("dd/MM/yy");
        }

        private void InitializeTimer()
        {
            this.timer1 = new Timer();
            this.timer1.Interval = 1000;
            this.timer1.Tick += new EventHandler(this.timer1_Tick);
            this.timer1.Start();
        }

        private void gunaAdvenceButton4_Click(object sender, EventArgs e)
        {
         

            if (isSlotOccupied.All(occupied => occupied))
            {
                MessageBox.Show("No more slots available.");
            }
            else
            {
                Tickets ticket = new Tickets(this);
                ticket.ShowDialog();
            }
        }

        public void UpdateSlotImage(int slotNumber) /* other ticket details if needed */
        {
            if (slotNumber == 1)
            {
                gunaPictureBox1.Image = occupiedSlotImage;
                isSlotOccupied[0] = true;
            }
            else if (slotNumber == 2)
            {
                gunaPictureBox2.Image = occupiedSlotImage;
                isSlotOccupied[1] = true;
            }
            else if (slotNumber == 3)
            {
                gunaPictureBox3.Image = occupiedSlotImage;
                isSlotOccupied[2] = true;
            }
        }
        private void LogOutBtn_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Dispose();
        }
        private void CheckAvailableSlots()
        {
            int occupiedCount = 0;
            foreach (bool occupied in isSlotOccupied)
            {
                if (occupied)
                {
                    occupiedCount++;
                }
            }

            if (occupiedCount == isSlotOccupied.Length)
            {
                AllSlotsTaken all  = new AllSlotsTaken();
                all.ShowDialog();
                // Optionally disable the button to open the ticketing form
            }
            // You might also want to update the UI to reflect the available slots
        }

    // You'll need a way to open the TicketingForm (e.g., a button click event)

        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {
            OccupancyForm occupancyForm = new OccupancyForm();
            occupancyForm.ShowDialog(); // Use ShowDialog to keep the occupancy form modal
        }

        private void gunaAdvenceButton5_Click(object sender, EventArgs e)
        {
            RemoveTicket removeTicket = new RemoveTicket(this); 
            removeTicket.ShowDialog(); // Use ShowDialog to keep the remove ticket form modal
        }

        private void gunaPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
        public void OccupySlot(int slotNumber)
        {
            if (slotNumber >= 1 && slotNumber <= isSlotOccupied.Length)
            {
                isSlotOccupied[slotNumber - 1] = true;
                if (slotNumber == 1) gunaPictureBox1.Image = occupiedSlotImage;
                else if (slotNumber == 2) gunaPictureBox2.Image = occupiedSlotImage;
                else if (slotNumber == 3) gunaPictureBox3.Image = occupiedSlotImage;
            }
        }

        public void ReleaseSlot(int slotNumber)
        {
            if (slotNumber >= 1 && slotNumber <= isSlotOccupied.Length)
            {
                isSlotOccupied[slotNumber - 1] = false;
                if (slotNumber == 1) gunaPictureBox1.Image = originalSlotImages[0];
                else if (slotNumber == 2) gunaPictureBox2.Image = originalSlotImages[1];
                else if (slotNumber == 3) gunaPictureBox3.Image = originalSlotImages[2];

                // Enable the corresponding button in any open TicketingForms
                foreach (Form openForm in Application.OpenForms)
                {
                    if (openForm is Tickets ticketingForm)
                    {
                        ticketingForm.EnableSlotButton(slotNumber);
                    }
                }
            }


        }

        public bool IsSlotOccupied(int slotNumber)
        {
            if (slotNumber >= 1 && slotNumber <= isSlotOccupied.Length)
            {
                return isSlotOccupied[slotNumber - 1];
            }
            return false;
        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            OccupancyForm occupancyForm = new OccupancyForm();
            occupancyForm.ShowDialog();
        }

        private void gunaAdvenceButton3_Click(object sender, EventArgs e)
        {
            OccupancyForm occupancyForm = new OccupancyForm();
            occupancyForm.ShowDialog();
        }
    }
}
