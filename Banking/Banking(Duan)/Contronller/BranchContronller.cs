using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows;
using System.Xml.Linq;
using Banking.Model;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Wordprocessing;

namespace Banking.Controller
{
    internal class BranchController : IController
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["Connectsql"].ConnectionString;
        private List<IModel> items = new List<IModel>();
        public List<IModel> Items { get; private set; }

        public List<IModel> Itemss
        {
            get { return items; }
        }

        // Tải danh sách chi nhánh từ database
        public bool Load()
        {
            try
            {
                List<IModel> branches = new List<IModel>();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM BRANCH";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                BranchModel branch = new BranchModel
                                {
                                    id = reader["id"].ToString(),
                                    name = reader["name"].ToString(),
                                    house_no = reader["house_no"].ToString(),
                                    city = reader["city"].ToString()
                                };
                                branches.Add(branch);
                            }
                        }
                    }
                }
                this.Items = branches;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while loading branch data: " + ex.Message);
                return false;
            }
        }

        // Thêm chi nhánh mới vào database
        public bool Add(IModel model)
        {
            BranchModel branch = model as BranchModel;
            if (branch == null)
            {
                return false; // Trả về false nếu model không phải là BranchModel
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO BRANCH (id, name, house_no, city) VALUES (@id, @name, @house_no, @city)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", branch.id);
                    cmd.Parameters.AddWithValue("@name", branch.name);
                    cmd.Parameters.AddWithValue("@house_no", branch.house_no);
                    cmd.Parameters.AddWithValue("@city", branch.city);
                    cmd.ExecuteNonQuery();
                }
            }
            return true;
        }

        // Cập nhật thông tin chi nhánh
        public bool Update(IModel model)
        {
            BranchModel branch = model as BranchModel;
            if (branch == null)
            {
                return false; // Trả về false nếu model không phải là BranchModel
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE BRANCH SET name = @name, house_no = @house_no, city = @city WHERE id = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", branch.id);
                    cmd.Parameters.AddWithValue("@name", branch.name);
                    cmd.Parameters.AddWithValue("@house_no", branch.house_no);
                    cmd.Parameters.AddWithValue("@city", branch.city);
                    cmd.ExecuteNonQuery();
                }
            }
            return true;
        }

        // Xóa chi nhánh khỏi database
        public bool Delete(IModel model)
        {
            BranchModel branch = model as BranchModel;
            if (branch == null)
            {
                return false; // Trả về false nếu model không phải là BranchModel
            }
            return Delete(branch.id);
        }

        public bool Delete(object id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM BRANCH WHERE id = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
            return true;
        }

        // Đọc thông tin chi nhánh từ database
        public IModel Read(object id)
        {
            BranchModel branch = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM BRANCH WHERE id = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            branch = new BranchModel
                            {
                                id = reader["id"].ToString(),
                                name = reader["name"].ToString(),
                                house_no = reader["house_no"].ToString(),
                                city = reader["city"].ToString()
                            };
                        }
                    }
                }
            }
            return branch;
        }
        public IModel ReadBranchBuyName(object Name)
        {
            BranchModel branch = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM BRANCH WHERE name = @Name";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", Name);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            branch = new BranchModel
                            {
                                id = reader["id"].ToString(),
                                name = reader["name"].ToString(),
                                house_no = reader["house_no"].ToString(),
                                city = reader["city"].ToString()
                            };
                        }
                    }
                }
            }
            return branch;
        }
        // Kiểm tra xem chi nhánh có tồn tại trong database hay không
        public bool IsExist(object id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(1) FROM BRANCH WHERE id = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
    }
}
