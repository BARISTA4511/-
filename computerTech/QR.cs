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
    public partial class QR : Form
    {
        public string connectionString = "Server=ADCLG1;Database=УП_Мунгалов;Trusted_Connection=True;TrustServerCertificate=true;"; private int clientId; // ID клиента, который авторизовался

        public QR(int clientId)
        {
            InitializeComponent();
            this.clientId = clientId;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            CustomerFirst customerForm = new CustomerFirst(clientId);
            customerForm.Show();
            this.Close();
        }
    }
}
