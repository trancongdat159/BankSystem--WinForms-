using Banking.Controller;
using Banking.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banking.View
{
    public partial class transactionLog : UserControl
    {
        TransactionController transactionController=new TransactionController();
        TransactionModel transactionModel = new TransactionModel();
        public transactionLog()
        {
            InitializeComponent();
            LoadDataGridview();
            // Sự kiện thay đổi kích thước để căn giữa panel
            this.Resize += (s, e) =>
            {
                panel1.Location = new Point(
                    (this.ClientSize.Width - panel1.Width) / 2,
                    (this.ClientSize.Height - panel1.Height) / 2);
            };
        }
        private void LoadDataGridview()
        {
            transactionController.Load();
            List<TransactionModel> transactions = transactionController.Items.OfType<TransactionModel>().ToList();
            dataGridView1.DataSource = transactions;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
