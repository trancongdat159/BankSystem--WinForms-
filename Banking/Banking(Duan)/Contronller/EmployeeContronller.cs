using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Banking.Model;
using Banking.Controller;
using System.Data;
using System.Windows.Forms;

namespace Banking.Controller
{
    internal class EmployeeController : IController
    {
        private string ConnectionString = ConfigurationManager.ConnectionStrings["Connectsql"].ConnectionString;
        private List<IModel> items = new List<IModel>();
        public List<IModel> Items { get; private set; }

        public bool Load()
        {
            try
            {
                List<IModel> employees = new List<IModel>();
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM EMPLOYEE";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                EmployeeModel employee = new EmployeeModel
                                {
                                    id = reader["id"].ToString(),
                                    password = reader["password"].ToString(),
                                    role = reader["role"].ToString()
                                };
                                employees.Add(employee);
                            }
                        }
                    }
                }
                this.Items = employees;  // Gán danh sách đã tải vào thuộc tính Items
                return true;  // Trả về true nếu tải dữ liệu thành công
            }
            catch (Exception ex)
            {
                // Ghi log lỗi hoặc xử lý lỗi tại đây
                MessageBox.Show("Error while loading employee data: " + ex.Message);
                return false;  // Trả về false nếu có lỗi xảy ra
            }
        }




        // Thêm nhân viên mới vào database
        public bool Add(IModel model)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "INSERT INTO EMPLOYEE (id, password, role) VALUES (@id, @password, @role)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    EmployeeModel employee = (EmployeeModel)model;
                    cmd.Parameters.AddWithValue("@id", employee.id);
                    cmd.Parameters.AddWithValue("@password", employee.password);
                    cmd.Parameters.AddWithValue("@role", employee.role);
                    cmd.ExecuteNonQuery();
                }
            }
            return true;
        }

        // Cập nhật thông tin nhân viên
        public bool Update(IModel model)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "UPDATE EMPLOYEE SET password = @password, role = @role WHERE id = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    EmployeeModel employee = (EmployeeModel)model;
                    cmd.Parameters.AddWithValue("@id", employee.id);
                    cmd.Parameters.AddWithValue("@password", employee.password);
                    cmd.Parameters.AddWithValue("@role", employee.role);
                    cmd.ExecuteNonQuery();
                }
            }
            return true;
        }

        // Xóa nhân viên khỏi database
        public bool Delete(IModel model)
        {
            EmployeeModel employee = (EmployeeModel)model;
            return Delete(employee.id);
        }

        public bool Delete(object id)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "DELETE FROM EMPLOYEE WHERE id = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
            return true;
        }

        // Đọc thông tin nhân viên từ database
        public IModel Read(object id)
        {
            EmployeeModel employee = null;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "SELECT * FROM EMPLOYEE WHERE id = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            employee = new EmployeeModel
                            {
                                id = reader["id"].ToString(),
                                password = reader["password"].ToString(),
                                role = reader["role"].ToString()
                            };
                        }
                    }
                }
            }
            return employee;
        }

        // Kiểm tra xem nhân viên có tồn tại trong database hay không
        public bool IsExist(object id)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(1) FROM EMPLOYEE WHERE id = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        //public bool Close (object id)
        //{
        //    this.Close(); // Đóng cửa sổ hiện tại
        //}

    }
}
