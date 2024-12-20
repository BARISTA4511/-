using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace computerTech
{
    public partial class MasterFirst : Form
    {
        public string connectionString = "Server=ADCLG1;Database=УП_Мунгалов;Trusted_Connection=True;TrustServerCertificate=true;";
        private int userId;
        public MasterFirst(int userID)
        {
            InitializeComponent();
            this.userId = userID;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Autorization autorizationForm = new Autorization();
            autorizationForm.Show();
            this.Hide();
        }

        private void buttonRequests_Click(object sender, EventArgs e)
        {
            TechnicianMain techForm = new TechnicianMain(userId);
            techForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Materials materialsForm = new Materials(userId);
            materialsForm.Show();
            this.Hide();
        }
    }
}
