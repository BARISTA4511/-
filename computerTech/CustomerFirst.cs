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
    public partial class CustomerFirst : Form
    {
        public string connectionString = "Server=ADCLG1;Database=УП_Мунгалов;Trusted_Connection=True;TrustServerCertificate=true;"; private int clientId; // ID клиента, который авторизовался

        public CustomerFirst(int clientID)
        {
            InitializeComponent();
            this.clientId = clientID;


        }

        private void buttonRequests_Click(object sender, EventArgs e)
        {
            clientRequests customerRequestsForm = new clientRequests(clientId);
            customerRequestsForm.Show();
            this.Hide();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            CustomerMain customerForm = new CustomerMain(clientId);
            customerForm.Show();
            this.Hide();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Autorization autorizationForm = new Autorization();
            autorizationForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QR qrForm = new QR(clientId);
            qrForm.Show();
            this.Hide();
        }
    }
}
