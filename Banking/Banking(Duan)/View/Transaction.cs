using Banking.Controller;
using Banking.Model;
using DocumentFormat.OpenXml.Spreadsheet;
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
    public partial class Transaction : UserControl, IView
    {
        private TransactionController transactionController;
        private BranchController branchContronller;
        private AccountController accountController=new AccountController();
        private CustomerController customerController=new CustomerController();
        public Transaction()
        {
            InitializeComponent();
            branchContronller = new BranchController();
            transactionController = new TransactionController();
            accountController.Load();
            branchContronller.Load();
            loadDataComboBoxBr();
            //SetupForm();
            nap.Enabled = false;
            rut.Enabled = false;

            Displaybutton();

            //  loadDataComboBoxAc();
            // loadDataComboBoxBr();
            LoadDataGrid();
            dataGridViewtra.CellClick += DataGridView1_CellClick;

            this.Resize += (s, e) =>
            {
                panel1.Location = new Point((this.ClientSize.Width - panel1.Width) / 2,
                                            (this.ClientSize.Height - panel1.Height) / 2);
            };
        }
        private void Displaybutton()
        {
            if (comgui.Text == comnhan.Text)
            {
                Save1.Enabled = false;
            }
            else
            {
                Save1.Enabled = true;
            }
            
        }
        public void loadDataComboBoxBr()
        {
            List<IModel> items = accountController.Items;
            List<IModel> items2 = branchContronller.Items;
        

            comgui.DataSource = items.Cast<AccountModel>().ToList();
            comgui.DisplayMember = "customerid";
            comgui.ValueMember = "id";
            comnhan.DataSource = items.Cast<AccountModel>().ToList();
            comnhan.DisplayMember = "customerid";
            comnhan.ValueMember = "id";
            combr.DataSource = items2.Cast<BranchModel>().ToList();
            combr.DisplayMember = "name";
            combr.ValueMember = "id";
            tranv.Text = UserSession.Id;

            traid.Text = RamdomID().ToString();

        }

        private int RamdomID()
        {
            Random random = new Random();
            int temp = random.Next();
            if (transactionController.Load())
            {
                
                List<TransactionModel> tran=transactionController.Items.OfType<TransactionModel>().ToList();
                temp = tran.Max(m => m.id);



            }
            return temp+ 1;
        }
        public void ClearFields()
        {

            combr.SelectedIndex = -1; // Đặt lại giá trị ComboBox,
            comgui.SelectedIndex = -1;
            comnhan.SelectedIndex = -1;
            traid.Clear();
            trasotien.Clear();
            trapin.Clear();
            tranv.Clear();
            tranv.Clear();
            trand.Clear();

        }

        public void GetDataFromText()
        {
            
            if (string.IsNullOrWhiteSpace(comgui.Text) ||
                string.IsNullOrWhiteSpace(comnhan.Text) ||
                string.IsNullOrWhiteSpace(trasotien.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin giao dịch.");
                return;
            }

           
            TransactionModel transaction = new TransactionModel
            {
                id = string.IsNullOrEmpty(traid.Text) ? 0 : int.Parse(traid.Text),
                form_account_id = comgui.Text,
                to_account_id = comnhan.Text,
                branch_id = combr.Text,
                employee_id = tranv.Text,
                date_of_trans = dateTimePicker1.Value,
                amount = float.TryParse(trasotien.Text, out var amount) ? amount : 0,
                pin = trapin.Text,
                content = trand.Text

            };

           
            if (transactionController.IsExist(transaction.id))
            {
                transactionController.Update(transaction);
                MessageBox.Show("Giao dịch đã được cập nhật.");
            }
            else
            {
                transactionController.Add(transaction);
                MessageBox.Show("Giao dịch mới đã được thêm.");
            }
        }

        public void SetDataToText(object item)
        {
            if (item is TransactionModel transaction)
            {
                traid.Text = transaction.id.ToString();
                comgui.Text = transaction.form_account_id;
                comnhan.Text = transaction.to_account_id;
                combr.Text = transaction.branch_id;
                tranv.Text = transaction.employee_id;
                dateTimePicker1.Value = transaction.date_of_trans;
                trasotien.Text = transaction.amount.HasValue ? transaction.amount.Value.ToString() : string.Empty;
                trapin.Text = transaction.pin;
                trand.Text = transaction.content;
            }
            else
            {
                throw new ArgumentException("Item must be of type TransactionModel");
            }
        }


        private void SetupForm()
            {
               
                comgui.Items.AddRange(new string[] { "Nạp tiền", "Rút tiền", "Chuyển tiền" });
                comgui.SelectedIndexChanged += Comgui_SelectedIndexChanged;

             
            }

            private void Comgui_SelectedIndexChanged(object sender, EventArgs e)
            {
                string selectedTransaction = comgui.SelectedItem.ToString();
              
            }

        


        private void rut_Click(object sender, EventArgs e)
        {
     
            string accountId = comnhan.SelectedItem?.ToString();
            string branchId = combr.SelectedItem?.ToString();  
            DateTime transactionDate;
            float amount;
            string pin = trapin.Text;
            string employeeId = tranv.Text;
            string note = trand.Text;

            if (string.IsNullOrEmpty(accountId))
            {
                MessageBox.Show("Vui lòng chọn tài khoản.");
                return;
            }

            if (string.IsNullOrEmpty(branchId))
            {
                MessageBox.Show("Vui lòng chọn chi nhánh.");
                return;
            }

           

            if (!float.TryParse(trasotien.Text, out amount))
            {
                MessageBox.Show("Số tiền không hợp lệ.");
                return;
            }

            if (amount <= 0)
            {
                MessageBox.Show("Số tiền phải lớn hơn 0.");
                return;
            }

            if (string.IsNullOrEmpty(pin))
            {
                MessageBox.Show("Vui lòng nhập mã PIN.");
                return;
            }

            if (string.IsNullOrEmpty(employeeId))
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên.");
                return;
            }

            bool success = transactionController.Withdraw(accountId, amount);


            MessageBox.Show(success ? "Rút tiền thành công!" : "Rút tiền thất bại.");
        }


        



        private void Transaction_Load(object sender, EventArgs e)
        {

        }

       

        


        private void nap_Click_1(object sender, EventArgs e)
        {
            string accountId = comnhan.SelectedValue?.ToString();
            string branchId = combr.SelectedValue?.ToString();
            DateTime transactionDate = Convert.ToDateTime(dateTimePicker1.Text);
            float amount = Convert.ToInt32(trasotien.Text);
            string pin = trapin.Text;
            string employeeId = tranv.Text;
            string note = trand.Text;

            if (accountId == null)
            {
                MessageBox.Show("Vui lòng chọn tài khoản.");
                return;
            }

            if (branchId == null)
            {
                MessageBox.Show("Vui lòng chọn chi nhánh.");
                return;
            }

            if (!float.TryParse(trasotien.Text, out amount))
            {
                MessageBox.Show("Số tiền không hợp lệ.");
                return;
            }

            if (string.IsNullOrEmpty(pin))
            {
                MessageBox.Show("Vui lòng nhập mã PIN.");
                return;
            }

            if (string.IsNullOrEmpty(employeeId))
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên.");
                return;
            }

            bool success = transactionController.Deposit(accountId, amount);

            MessageBox.Show(success ? "Nạp tiền thành công!" : "Nạp tiền thất bại.");
            TransactionModel transactionModel = new TransactionModel
            {
                id = Convert.ToInt32(traid.Text),
                form_account_id = accountId,
                branch_id = branchId,
                date_of_trans = transactionDate,
                amount = amount,
                pin = pin,
                to_account_id = accountId,
                employee_id = employeeId,
                content = note
            };


            transactionController.Add(transactionModel);
            LoadDataGrid();
        }

        private void rut_Click_1(object sender, EventArgs e)
        {
            string accountId = comnhan.SelectedValue?.ToString();
            string branchId = combr.SelectedValue?.ToString();
            DateTime transactionDate= Convert.ToDateTime( dateTimePicker1.Text);
            float amount=Convert.ToInt32(trasotien.Text);
            string pin = trapin.Text;
            string employeeId = tranv.Text;
            string note = trand.Text;

            if (string.IsNullOrEmpty(accountId))
            {
                MessageBox.Show("Vui lòng chọn tài khoản.");
                return;
            }

            if (string.IsNullOrEmpty(branchId))
            {
                MessageBox.Show("Vui lòng chọn chi nhánh.");
                return;
            }



            if (!float.TryParse(trasotien.Text, out amount))
            {
                MessageBox.Show("Số tiền không hợp lệ.");
                return;
            }

            if (amount <= 0)
            {
                MessageBox.Show("Số tiền phải lớn hơn 0.");
                return;
            }

            if (string.IsNullOrEmpty(pin))
            {
                MessageBox.Show("Vui lòng nhập mã PIN.");
                return;
            }

            if (string.IsNullOrEmpty(employeeId))
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên.");
                return;
            }

            bool success = transactionController.Withdraw(accountId, amount);


            MessageBox.Show(success ? "Rút tiền thành công!" : "Rút tiền thất bại.");
            TransactionModel transactionModel = new TransactionModel
            {
                id = Convert.ToInt32(traid.Text),
                form_account_id = accountId,
                branch_id = branchId,
                date_of_trans = transactionDate,
                amount = amount,
                pin = pin,
                to_account_id = accountId,
                employee_id = employeeId,
                content = note
            };


            transactionController.Add(transactionModel);
            LoadDataGrid();

            //ClearFields();
        }


        private void combr_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comgui_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            customerController.Load();
            List<CustomerModel> customers= customerController.Items.OfType<CustomerModel>().ToList();
            var customerItem= customers.FirstOrDefault(i=>i.id==comgui.Text);
            trapin.Text = customerItem.pin;
            Displaybutton();


        }

        private void Save1_Click(object sender, EventArgs e)
        {

            TransactionModel tra = new TransactionModel
            {
                id = Convert.ToInt32(traid.Text),
                form_account_id = comgui.SelectedValue.ToString(),
                to_account_id = comnhan.SelectedValue.ToString(),
                branch_id = combr.SelectedValue.ToString(),
                amount = (float)Convert.ToInt32(trasotien.Text),
                employee_id = tranv.Text,
                content = trand.Text,
                pin = trapin.Text,
                date_of_trans = dateTimePicker1.Value
            };

            string Id = traid.Text;
            string fromAccountId = comgui.SelectedValue.ToString();
            string toAccountId = comnhan.SelectedValue.ToString();
            float amount = Convert.ToInt32(trasotien.Text);
            string employeeId = tranv.Text;
            string note = trand.Text;


            if (string.IsNullOrEmpty(fromAccountId) || string.IsNullOrEmpty(toAccountId))
            {
                MessageBox.Show("Vui lòng chọn tài khoản nguồn và tài khoản đích.");
                return;
            }

            if (fromAccountId == toAccountId)
            {
                MessageBox.Show("Tài khoản nguồn và tài khoản đích không được trùng nhau.");
                return;
            }

            if (!float.TryParse(trasotien.Text, out amount))
            {
                MessageBox.Show("Số tiền không hợp lệ.");
                return;
            }

            if (amount <= 0)
            {
                MessageBox.Show("Số tiền phải lớn hơn 0.");
                return;
            }

            if (string.IsNullOrEmpty(employeeId))
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên.");
                return;
            }

            bool success = transactionController.Transfer(tra);

            MessageBox.Show(success ? "Chuyển tiền thành công!" : "Chuyển tiền thất bại. Kiểm tra tài khoản hoặc số dư.");
            LoadDataGrid();
        }

        private void LoadDataGrid()
        {
            if (transactionController.Load())
            {
                List<TransactionModel> list = transactionController.Items
                    .OfType<TransactionModel>()
                    .ToList();

                if (list.Count > 0)
                {
                    dataGridViewtra.DataSource = list;

                    //foreach (DataGridViewColumn column in dataGridViewtra.Columns)
                    //{
                    //    MessageBox.Show(column.Name); // In ra tên cột
                    //}
                    dataGridViewtra.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                else
                {
                    MessageBox.Show("No transaction data found.");
                }
            }
            else
            {
                MessageBox.Show("Failed to load transaction data.");
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewtra.Rows[e.RowIndex];  
               

                // Gán giá trị từ ô vào các điều khiển tương ứng
                traid.Text = row.Cells["Id"].Value?.ToString();  
                comgui.Text = row.Cells["form_account_id"].Value?.ToString();  
                comnhan.Text = row.Cells["to_account_id"].Value?.ToString(); 
                combr.Text = row.Cells["branch_id"].Value.ToString();
                trasotien.Text = row.Cells["amount"].Value?.ToString(); 
                dateTimePicker1.Value = Convert.ToDateTime( row.Cells["date_of_trans"].Value);
                trand.Text = row.Cells["content"].Value?.ToString();
                trapin.Text = row.Cells["pin"].Value?.ToString();
                tranv.Text = row.Cells["employee_id"].Value?.ToString();



            }
        }

        private void dataGridViewtra_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tranv_TextChanged(object sender, EventArgs e)
        {

        }

        private void comnhan_SelectedIndexChanged(object sender, EventArgs e)
        {
            Displaybutton();
        }

        private void traid_TextChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }

        private void trasotien_TextChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem giá trị nhập vào có phải là số hay không
            if (!decimal.TryParse(trasotien.Text, out _))
            {
                // Nếu không phải số, bạn có thể xóa giá trị trong TextBox hoặc thông báo
                MessageBox.Show("Vui lòng nhập số hợp lệ cho số tiền.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                trasotien.Clear(); // Xóa giá trị không hợp lệ
            }
            else
            {
                // Gọi hàm EnableButtons để kiểm tra điều kiện bật nút
                EnableButtons();
            }
        }

        private void trapin_TextChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }

        private void trand_TextChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }

        private void EnableButtons()
        {
            // Bật nút button1 nếu chỉ riêng TextBox traid có dữ liệu
           

            // Bật nút button2 nếu tất cả các TextBox đều không rỗng
            nap.Enabled = !string.IsNullOrWhiteSpace(traid.Text) &&
                              !string.IsNullOrWhiteSpace(trasotien.Text) &&
                              !string.IsNullOrWhiteSpace(trapin.Text) &&
                              !string.IsNullOrWhiteSpace(trand.Text);
            rut.Enabled = !string.IsNullOrWhiteSpace(traid.Text) &&
                             !string.IsNullOrWhiteSpace(trasotien.Text) &&
                             !string.IsNullOrWhiteSpace(trapin.Text) &&
                             !string.IsNullOrWhiteSpace(trand.Text);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

