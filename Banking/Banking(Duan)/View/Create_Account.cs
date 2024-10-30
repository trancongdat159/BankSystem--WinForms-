using Banking.Controller;
using Banking.Model;
using DocumentFormat.OpenXml.Drawing.Charts;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Windows.Forms;

namespace Banking.View
{
    public partial class Create_Account : UserControl, IView
    {
        private AccountController accountController = new AccountController();

        public Create_Account()
        {
            InitializeComponent();
            LoadAccountData();
            SetupUI();
            button1.Enabled = false;
            addacc.Enabled = false;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public void GetDataFromText()
        {
            
        }

        public void ClearFields()
        {
            textidacc.Clear();
            textidcus.Clear();
           
            textbalance.Clear();
        }

        private void SetupUI()
        {
            // Sự kiện thay đổi kích thước để căn giữa panel
            this.Resize += (s, e) =>
            {
                panel1.Location = new Point(
                    (this.ClientSize.Width - panel1.Width) / 2,
                    (this.ClientSize.Height - panel1.Height) / 2);
            };
        }

        private void LoadAccountData()
        {
            // Gọi phương thức Load từ AccountController để tải dữ liệu từ database
            if (accountController.Load())  // Nếu Load thành công
            {
                // Lấy danh sách các Account từ controller.Items
                List<AccountModel> list = accountController.Items
                    .OfType<AccountModel>()  // Chỉ lấy các đối tượng AccountModel
                    .ToList();

                // Kiểm tra nếu danh sách không rỗng
                if (list.Count > 0)
                {
                    dataGridView1.DataSource = list;  // Gán danh sách cho DataGridView
                    dataGridView1.CellClick += DataGridView1_CellClick;  // Đăng ký sự kiện click
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;  // Tự động điều chỉnh cột
                }
                else
                {
                    MessageBox.Show("No account data found.");  // Thông báo nếu không có dữ liệu
                }
            }
            else
            {
                MessageBox.Show("Failed to load account data.");  // Thông báo nếu không tải được dữ liệu
            }
        }


        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo người dùng click vào dòng hợp lệ
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Hiển thị thông tin tài khoản vào các TextBox
                textidacc.Text = row.Cells["id"]?.Value?.ToString() ?? string.Empty;
                textidcus.Text = row.Cells["customerid"]?.Value?.ToString() ?? string.Empty;
                DateTime dateTime= (DateTime)row.Cells["date_opened"].Value;
                dateTimePicker1.Value = dateTime;
                

                textbalance.Text = row.Cells["balance"]?.Value?.ToString() ?? "0.00";
            }
        }

        private void addacc_Click(object sender, EventArgs e)
        {

            try
            {
                

                if (!float.TryParse(textbalance.Text, out float balanceValue))
                {
                    MessageBox.Show("Invalid balance value. Please enter a valid number.");
                    return;
                }

                AccountModel account = new AccountModel
                {
                    id = textidacc.Text,
                    customerid = textidcus.Text,
                    date_opened = dateTimePicker1.Value,
                    balance =Convert.ToInt32( textbalance.Text)
                };

                // Kiểm tra xem tài khoản đã tồn tại
                if (accountController.IsExist(account.id))
                {
                    accountController.Update(account); // Cập nhật tài khoản
                    MessageBox.Show("Account updated successfully.");
                }
                else
                {
                    accountController.Add(account); // Thêm tài khoản mới
                    MessageBox.Show("New account added successfully.");
                }

               
                LoadAccountData(); // Tải lại dữ liệu tài khoản
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while getting data: " + ex.Message);
            } // Gọi phương thức để lấy dữ liệu từ TextBox
        }

        //private void buttonImport_Click(object sender, EventArgs e)
        //{
        //    using (OpenFileDialog openFileDialog = new OpenFileDialog()
        //    {
        //        Filter = "Excel 97-2003 Workbook|*.xls|Excel Workbook|*.xlsx"
        //    })
        //    {
        //        if (openFileDialog.ShowDialog() == DialogResult.OK)
        //        {
        //            string filePath = openFileDialog.FileName;
        //            txtFilePath.Text = filePath;

        //            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
        //            {
        //                using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
        //                {
        //                    DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
        //                    {
        //                        ConfigureDataTable = _ => new ExcelDataTableConfiguration() { UseHeaderRow = true }
        //                    });

        //                    DataTable selectedTable = result.Tables[0]; // Lấy bảng đầu tiên
        //                    dataGridView1.DataSource = selectedTable;  // Hiển thị dữ liệu trong DataGridView
        //                }
        //            }
        //        }
        //    }
        //}

        private void Create_Account_Load(object sender, EventArgs e)
        {
            // Có thể thêm mã khởi tạo hoặc xử lý gì đó nếu cần
        }

        public void SetDataToText(object item)
        {
            throw new NotImplementedException();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AccountController accountController = new AccountController();
            string id = textidacc.Text;
            if (accountController.IsExist(id))
            {
                accountController.Delete(id);
                MessageBox.Show("Customer deleted successfully.");
                LoadAccountData();
            }
            else
            {
                MessageBox.Show("Customer not found.");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textidacc_TextChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }

        private void textidcus_TextChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }

        private void textbalance_TextChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }

        private void EnableButtons()
        {
            // Bật nút button1 nếu chỉ riêng TextBox textidacc có dữ liệu
            button1.Enabled = !string.IsNullOrWhiteSpace(textidacc.Text);

            // Bật nút button2 nếu tất cả các TextBox đều không rỗng
            addacc.Enabled = !string.IsNullOrWhiteSpace(textidacc.Text) &&
                              !string.IsNullOrWhiteSpace(textidcus.Text) &&
                              !string.IsNullOrWhiteSpace(textbalance.Text);
        }

    }
}
