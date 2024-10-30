using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Banking.Model;
using System.Windows.Forms;

namespace Banking.Controller
{
    internal class CustomerController : IController
    {
        private string ConnectionString = ConfigurationManager.ConnectionStrings["Connectsql"].ConnectionString;
        private List<IModel> items = new List<IModel>();
        public List<IModel> Items { get; private set; }

        // Load danh sách khách hàng từ database
        public bool Load()
        {
            try
            {
                List<IModel> customers = new List<IModel>();
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM CUSTOMER";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomerModel customer = new CustomerModel
                                {
                                    id = reader["id"].ToString(),
                                    name = reader["name"].ToString(),
                                    phone = reader["phone"].ToString(),
                                    email = reader["email"].ToString(),
                                    house_no = reader["house_no"].ToString(),
                                    city = reader["city"].ToString(),
                                    pin = reader["pin"].ToString()
                                };
                                customers.Add(customer);
                            }
                        }
                    }
                }
                this.Items = customers;  // Gán danh sách đã tải vào thuộc tính Items
                return true;  // Trả về true nếu tải dữ liệu thành công
            }
            catch (Exception ex)
            {
                // Ghi log lỗi hoặc xử lý lỗi tại đây
                MessageBox.Show("Error while loading customer data: " + ex.Message);
                return false;  // Trả về false nếu có lỗi xảy ra
            }
        }

        // Thêm khách hàng mới vào database
        public bool Add(IModel model)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO CUSTOMER (id, name, phone, email, house_no, city, pin) VALUES (@id, @name, @phone, @email, @house_no, @city, @pin)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        CustomerModel customer = (CustomerModel)model;
                        cmd.Parameters.AddWithValue("@id", customer.id);
                        cmd.Parameters.AddWithValue("@name", customer.name);
                        cmd.Parameters.AddWithValue("@phone", customer.phone);
                        cmd.Parameters.AddWithValue("@email", customer.email);
                        cmd.Parameters.AddWithValue("@house_no", customer.house_no);
                        cmd.Parameters.AddWithValue("@city", customer.city);
                        cmd.Parameters.AddWithValue("@pin", customer.pin);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while adding customer: " + ex.Message);
                return false;
            }
        }

        // Cập nhật thông tin khách hàng trong database
        public bool Update(IModel model)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "UPDATE CUSTOMER SET name = @name, phone = @phone, email = @email, house_no = @house_no, city = @city, pin = @pin WHERE id = @id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        CustomerModel customer = (CustomerModel)model;
                        cmd.Parameters.AddWithValue("@id", customer.id);
                        cmd.Parameters.AddWithValue("@name", customer.name);
                        cmd.Parameters.AddWithValue("@phone", customer.phone);
                        cmd.Parameters.AddWithValue("@email", customer.email);
                        cmd.Parameters.AddWithValue("@house_no", customer.house_no);
                        cmd.Parameters.AddWithValue("@city", customer.city);
                        cmd.Parameters.AddWithValue("@pin", customer.pin);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while updating customer: " + ex.Message);
                return false;
            }
        }

        // Xóa khách hàng khỏi database
        public bool Delete(IModel model)
        {
            CustomerModel customer = (CustomerModel)model;
            return Delete(customer.id);
        }

        public bool Delete(object id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM CUSTOMER WHERE id = @id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while deleting customer: " + ex.Message);
                return false;
            }
        }

        // Đọc thông tin khách hàng từ database
        public IModel Read(object id)
        {
            CustomerModel customer = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM CUSTOMER WHERE id = @id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                customer = new CustomerModel
                                {
                                    id = reader["id"].ToString(),
                                    name = reader["name"].ToString(),
                                    phone = reader["phone"].ToString(),
                                    email = reader["email"].ToString(),
                                    house_no = reader["house_no"].ToString(),
                                    city = reader["city"].ToString(),
                                    pin = reader["pin"].ToString()
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while reading customer: " + ex.Message);
            }
            return customer;
        }

        // Kiểm tra xem khách hàng có tồn tại trong database không
        public bool IsExist(object id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(1) FROM CUSTOMER WHERE id = @id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while checking if customer exists: " + ex.Message);
                return false;
            }
        }
    }
}
