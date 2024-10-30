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
    public partial class blanceAccount : UserControl
    {
        AccountController accountController=new AccountController();
        AccountModel AccountModel = new AccountModel();
        public blanceAccount()
        {
            InitializeComponent();
            loadData();
            this.Resize += (s, e) =>
            {
                panel1.Location = new Point((this.ClientSize.Width - panel1.Width) / 2,
                                            (this.ClientSize.Height - panel1.Height) / 2);
            };
        }
        private void loadData()
        {
            accountController.Load();
            List<AccountModel> list = accountController.Items.OfType<AccountModel>().ToList();
            dataGridView1.DataSource = list;

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id= textBox1.Text;
            accountController.Load();
            List<AccountModel> list = accountController.Items.OfType<AccountModel>().ToList();
            List<AccountModel>AcIDs=list.Where(i=>i.id.ToLower().Contains(id.ToLower())).ToList();
            dataGridView1.DataSource = AcIDs;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
