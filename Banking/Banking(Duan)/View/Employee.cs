using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SqlClient;
using Banking.Controller;
using Banking.Model;
using System.Linq;
using System.Drawing;


namespace Banking.View
{
    public partial class Employee : UserControl, IView
    {
        EmployeeController controller = new EmployeeController();

        public Employee()
        {
            InitializeComponent();
            LoadDataGrid();
            dataGridView1.CellClick += DataGridView1_CellClick;

            button1.Enabled = false;
            button2.Enabled = false;

            this.Resize += (s, e) =>
            {
                panel1.Location = new Point((this.ClientSize.Width - panel1.Width) / 2,
                                            (this.ClientSize.Height - panel1.Height) / 2);
            };
        }
        public void GetDataFromText()
        {
            EmployeeModel employee = new EmployeeModel
            {
                id = textid.Text,
                password = textpass.Text,
                role = checkadmin.Checked ? "Admin" : "Employee"
            };

            if (controller.IsExist(employee.id))
            {
                controller.Update(employee);
                MessageBox.Show("Employee updated successfully.");
            }
            else
            {
                controller.Add(employee);
                MessageBox.Show("New employee added successfully.");
            }
        }


        public void SetDataToText(object item)
        {
            
            if (item is EmployeeModel employee)
            {
              
                textid.Text = employee.id;        
                textpass.Text = employee.password;
               
                if (employee.role == "Admin")
                {
                    checkadmin.Checked = true;
                    checkemployee.Checked = false;
                }
                else if (employee.role == "Employee")
                {
                    checkemployee.Checked = true;
                    checkadmin.Checked = false;
                }
            }
            else
            {
                throw new ArgumentException("Item must be of type EmployeeModel");
            }
        }

        private void LoadDataGrid()
        {
           
            if (controller.Load())  
            {
                List<EmployeeModel> list = controller.Items
                    .OfType<EmployeeModel>()  
                    .ToList();

               
                if (list.Count > 0)
                {
                    dataGridView1.DataSource = list;  
                    dataGridView1.CellClick += DataGridView1_CellClick;  
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;  
                }
                else
                {
                    MessageBox.Show("No employee data found.");  
                }
            }
            else
            {
                MessageBox.Show("Failed to load employee data."); 
            }
        }


        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                textid.Text = row.Cells["id"].Value?.ToString();
                textpass.Text = row.Cells["password"].Value?.ToString();
                string role = row.Cells["role"].Value?.ToString().ToLower();

                if (role == "admin")
                {
                    checkadmin.Checked = true;
                    checkemployee.Checked = false;
                }
                else if (role == "employee")
                {
                    checkadmin.Checked = false;
                    checkemployee.Checked = true;
                }
            }
        }

         private void Save_Click(object sender, EventArgs e)
        {
            string id = textid.Text;
            string password = textpass.Text;
            string role = checkadmin.Checked ? "admin" : "employee";

            EmployeeModel employee = new EmployeeModel(id, password, role);
            
            var employeeExists = controller.IsExist(id);

            if (employeeExists)
            {
                
                controller.Update(employee);
                MessageBox.Show("Employee updated successfully.");
            }
            else
            {
              
                controller.Add(employee);
                MessageBox.Show("New employee added successfully.");
            }

           
            LoadDataGrid();
        }

       
        private void Delete_Click(object sender, EventArgs e)
        {
            string id = textid.Text;

            if (controller.IsExist(id))
            {
                controller.Delete(id);
                MessageBox.Show("Employee deleted successfully.");
                LoadDataGrid();
                ClearFields();
            }
            else
            {
                MessageBox.Show("Employee not found.");
            }
        }

        // Tìm kiếm nhân viên theo ID
        //private void Search_Click(object sender, EventArgs e)
        //{
        //    string id = textid.Text;
        //    if (!string.IsNullOrEmpty(id))
        //    {
        //        List<EmployeeModel> employees = controller.SearchEmployee(id, "both");
        //        dataGridView1.DataSource = employees;
        //    }
        //    else
        //    {
        //        MessageBox.Show("Please enter an ID to search.");
        //    }
        //}

       
        public void ClearFields()
        {
            textid.Clear();
            textpass.Clear();
            checkadmin.Checked = false;
            checkemployee.Checked = false;
        }

        private void Close_Click(object sender, EventArgs e)
        {
           
            Trangchu mainForm = (Trangchu)this.ParentForm;
            mainForm.Show();
            this.Dispose();
        }

      
        private void checkadmin_CheckedChanged(object sender, EventArgs e)
        {
            if (checkadmin.Checked)
            {
                checkemployee.Checked = false;
            }
            EnableSubmitButton();
        }

        private void checkemployee_CheckedChanged(object sender, EventArgs e)
        {
            if (checkemployee.Checked)
            {
                checkadmin.Checked = false;
            }
            EnableSubmitButton();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Employee_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void textid_TextChanged(object sender, EventArgs e)
        {
            EnableSubmitButton();
            button1.Enabled=!string.IsNullOrWhiteSpace(textid.Text);
        }
        private void EnableSubmitButton()
        {
            // Kiểm tra nếu cả hai TextBox có dữ liệu và một trong hai RadioButton được chọn
            button2.Enabled = !string.IsNullOrWhiteSpace(textid.Text) &&
                                !string.IsNullOrWhiteSpace(textpass.Text) &&
                                (checkadmin.Checked || checkemployee.Checked);
        }

        private void textpass_TextChanged(object sender, EventArgs e)
        {
            EnableSubmitButton();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            button1.Enabled = dataGridView1.SelectedRows.Count > 0;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
