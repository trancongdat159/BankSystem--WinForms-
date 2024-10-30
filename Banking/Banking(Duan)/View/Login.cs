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
    
    public partial class Login : UserControl
    {
        private Trangchu _mainForm;
        public Login()
        {
            InitializeComponent();

            _mainForm = new Trangchu();

            this.Resize += (s, e) =>
            {
                // Căn giữa Panel trong Form
                panel1.Location = new Point((this.ClientSize.Width - panel1.Width) / 2,
                                                (this.ClientSize.Height - panel1.Height) / 2);
            };
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userName = textUser.Text;
            string passWord = txtpassword.Text;
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(passWord))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin", "Thông báo");
                return;
            }
            EmployeeController employeeController = new EmployeeController();
            EmployeeModel employeeModel = (EmployeeModel)employeeController.Read(userName);
            if (employeeModel != null && employeeModel.password == passWord)
            {
                // Lưu thông tin đăng nhập vào UserSession
                UserSession.Id = employeeModel.id;
                UserSession.Password = employeeModel.password;
                UserSession.Role = employeeModel.role;
                
                _mainForm.checkRole();
                _mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Thông tin tài khoản không đúng!", "Thông báo");
            }

        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            
        }
    }
}
