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
    public partial class Create_Customer : UserControl, IView
    {
        CustomerController controller = new CustomerController();

        public Create_Customer()
        {
            InitializeComponent();
            LoadDataGrid();
            dataGridViewcus.CellClick += DataGridViewcus_CellClick;
            delete.Enabled = false;
            save.Enabled = false;

            this.Resize += (s, e) =>
            {
                // Căn giữa Panel trong Form
                panel1.Location = new Point((this.ClientSize.Width - panel1.Width) / 2,
                                                (this.ClientSize.Height - panel1.Height) / 2);
            };
        }

        public void GetDataFromText()
        {
            CustomerModel customer = new CustomerModel
            {
                id = textcusid.Text,
                name = textcustenkh.Text,
                phone = textcussdt.Text,
                email = textcusemail.Text,
                house_no = textcusdc.Text,
                city = textcustp.Text,
                pin = textcuspass.Text
            };

            controller.Add(customer); // Thêm khách hàng mới vào database
            controller.Update(customer); // Cập nhật thông tin khách hàng (nếu cần)
        }
        public void SetDataToText(object item)
        {
            if (item is CustomerModel customer)
            {
                textcusid.Text = customer.id;
                textcustenkh.Text = customer.name;
                textcussdt.Text = customer.phone;
                textcusemail.Text = customer.email;
                textcusdc.Text = customer.house_no;
                textcustp.Text = customer.city;
                textcuspass.Text = customer.pin;
            }
            else
            {
                throw new ArgumentException("Item must be of type CustomerModel");
            }
        }
        public void ClearFields()
        {
            textcusid.Clear();
            textcustenkh.Clear();
            textcussdt.Clear();
            textcusemail.Clear();
            textcusdc.Clear();
            textcustp.Clear();
            textcuspass.Clear();
        }



        private void LoadDataGrid()
            {
                if (controller.Load())
                {
                    List<IModel > item = controller.Items;
                dataGridViewcus.DataSource = item.Cast<CustomerModel> ().ToList();

                    //if (list.Count > 0)
                    //{
                    //    dataGridViewcus.DataSource = list;
                    //    dataGridViewcus.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    //}
                    //else
                    //{
                    //    MessageBox.Show("No customer data found.");
                    //}
                }
                else
                {
                    MessageBox.Show("Failed to load customer data.");
                }
            }

            private void DataGridViewcus_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridViewcus.Rows[e.RowIndex];
                textcusid.Text = row.Cells["id"].Value?.ToString();
                    textcustenkh.Text = row.Cells["name"].Value?.ToString();
                    textcussdt.Text = row.Cells["phone"].Value?.ToString();
                    textcusemail.Text = row.Cells["email"].Value?.ToString();
                    textcusdc.Text = row.Cells["house_no"].Value?.ToString();
                    textcustp.Text = row.Cells["city"].Value?.ToString();
                textcuspass.Text = row.Cells["pin"].Value?.ToString();
                }
            }

            private void Save_Click(object sender, EventArgs e)
            {
                CustomerModel customer = new CustomerModel
                {
                    id = textcusid.Text,
                    name = textcustenkh.Text,
                    phone = textcussdt.Text,
                    email = textcusemail.Text,
                    house_no = textcusdc.Text,
                    city = textcustp.Text,
                    pin = textcuspass.Text  // Set a default or retrieved value for PIN
                };

                if (controller.IsExist(customer.id))
                {
                    controller.Update(customer);
                    MessageBox.Show("Customer updated successfully.");
                }
                else
                {
                    controller.Add(customer);
                    MessageBox.Show("New customer added successfully.");
                }

                LoadDataGrid();
            }

            private void Delete_Click(object sender, EventArgs e)
            {
                string id = textcusid.Text;
                if (controller.IsExist(id))
                {
                    controller.Delete(id);
                    MessageBox.Show("Customer deleted successfully.");
                    LoadDataGrid();
                }
                else
                {
                    MessageBox.Show("Customer not found.");
                }
            }

        private void close_Click(object sender, EventArgs e)
        {
            
                Trangchu mainForm = (Trangchu)this.ParentForm;
                mainForm.Show();
                this.Dispose();
           
        }

        private void save_Click_1(object sender, EventArgs e)
        {
            Save_Click(sender, e);
        }

        private void delete_Click_1(object sender, EventArgs e)
        {
            Delete_Click(sender, e);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridViewcus_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewcus_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textcusid_TextChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }

        private void textcustenkh_TextChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }

        private void textcussdt_TextChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }

        private void textcusemail_TextChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }

        private void textcusdc_TextChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }

        private void textcustp_TextChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }

        private void textcuspass_TextChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }

        private void EnableButtons()
        {
            // Bật nút button1 nếu chỉ riêng TextBox textcusid có dữ liệu
            delete.Enabled = !string.IsNullOrWhiteSpace(textcusid.Text);

            // Bật nút button2 nếu tất cả các TextBox đều không rỗng
            save.Enabled = !string.IsNullOrWhiteSpace(textcusid.Text) &&
                              !string.IsNullOrWhiteSpace(textcustenkh.Text) &&
                              !string.IsNullOrWhiteSpace(textcussdt.Text) &&
                              !string.IsNullOrWhiteSpace(textcusemail.Text) &&
                              !string.IsNullOrWhiteSpace(textcusdc.Text) &&
                              !string.IsNullOrWhiteSpace(textcustp.Text) &&
                              !string.IsNullOrWhiteSpace(textcuspass.Text);
        }

    }
}


