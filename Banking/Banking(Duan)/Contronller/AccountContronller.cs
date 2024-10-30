using Banking.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Banking.Controller
{
    internal class AccountController : IController
    {
        private readonly List<IModel> items = new List<IModel>();
        private readonly string ConnectionString = ConfigurationManager.ConnectionStrings["Connectsql"].ConnectionString;

        public List<IModel> Items => items;

        // Kiểm tra tài khoản có tồn tại trong cơ sở dữ liệu hay không
        public bool IsExist(object id)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    const string query = "SELECT COUNT(1) FROM account WHERE id = @id";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
                        return (int)command.ExecuteScalar() > 0;
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Lỗi kiểm tra tài khoản: {ex.Message}");
                    return false;
                }
            }
        }

        // Tạo mới tài khoản
        public bool Add(IModel model)
        {
            var account = model as AccountModel;
            if (account == null || IsExist(account.id)) return false;

            using (var conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    const string query = "INSERT INTO ACCOUNT (id, customerid, date_opened, balance) VALUES (@id, @customerid, @date_opened, @balance)";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", account.id);
                        cmd.Parameters.AddWithValue("@customerid", account.customerid);
                        cmd.Parameters.AddWithValue("@date_opened", account.date_opened);
                        cmd.Parameters.AddWithValue("@balance", account.balance);
                        cmd.ExecuteNonQuery();
                    }
                    items.Add(account);
                    return true;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Lỗi thêm tài khoản: {ex.Message}");
                    return false;
                }
            }
        }

        // Cập nhật tài khoản
        public bool Update(IModel model)
        {
            var account = model as AccountModel;
            if (account == null || !IsExist(account.id)) return false;

            using (var conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    const string query = "UPDATE ACCOUNT SET customerid = @customerid, date_opened = @date_opened, balance = @balance WHERE id = @id";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", account.id);
                        cmd.Parameters.AddWithValue("@customerid", account.customerid);
                        cmd.Parameters.AddWithValue("@date_opened", account.date_opened);
                        cmd.Parameters.AddWithValue("@balance", account.balance);
                        cmd.ExecuteNonQuery();
                    }
                    return true;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Lỗi cập nhật tài khoản: {ex.Message}");
                    return false;
                }
            }
        }

        // Xóa tài khoản
        public bool Delete(IModel model)
        {
            return model is AccountModel account && Delete(account.id);
        }

        // Xóa tài khoản theo ID
        public bool Delete(object id)
        {
            if (!IsExist(id)) return false;

            using (var conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    const string query = "DELETE FROM ACCOUNT WHERE id = @id";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id.ToString());
                        cmd.ExecuteNonQuery();
                    }
                    var account = Read(id) as AccountModel;
                    if (account != null)
                    {
                        items.Remove(account);
                    }
                    return true;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Lỗi xóa tài khoản: {ex.Message}");
                    return false;
                }
            }
        }

        // Đọc thông tin tài khoản theo ID
        public IModel Read(object id)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    const string query = "SELECT * FROM ACCOUNT WHERE id = @id";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id.ToString());
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new AccountModel
                                {
                                    id = reader["id"].ToString(),
                                    customerid = reader["customerid"].ToString(),
                                    date_opened = Convert.ToDateTime(reader["date_opened"]),
                                    balance = Convert.ToSingle(reader["balance"])
                                };
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Lỗi đọc tài khoản: {ex.Message}");
                }
                return null;
            }
        }

        // Tải dữ liệu tài khoản từ cơ sở dữ liệu
        public bool Load()
        {
            items.Clear();
            using (var conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    const string query = "SELECT * FROM ACCOUNT";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var account = new AccountModel
                                {
                                    id = reader["id"].ToString(),
                                    customerid = reader["customerid"].ToString(),
                                    date_opened = Convert.ToDateTime(reader["date_opened"]),
                                    balance = Convert.ToSingle(reader["balance"])
                                };
                                items.Add(account);
                            }
                        }
                    }
                    return true;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Lỗi tải dữ liệu tài khoản: {ex.Message}");
                    return false;
                }
            }
        }
    }
}
