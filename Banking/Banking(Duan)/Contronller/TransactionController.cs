using Banking.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Banking.Controller
{
    internal class TransactionController : IController
    {
        private readonly List<IModel> items = new List<IModel>();
        private readonly string ConnectionString = ConfigurationManager.ConnectionStrings["Connectsql"].ConnectionString;

        public List<IModel> Items => items;

        // Kiểm tra giao dịch có tồn tại trong cơ sở dữ liệu hay không
        public bool IsExist(object id)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    const string query = "SELECT COUNT(1) FROM TRANSACTIONN WHERE id = @id";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                        return (int)command.ExecuteScalar() > 0;
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Lỗi kiểm tra giao dịch: {ex.Message}");
                    return false;
                }
            }
        }

        // Tạo mới giao dịch
        public bool Add(IModel model)
        {
            var transaction = model as TransactionModel;
            if (transaction == null || IsExist(transaction.id)) return false;

            using (var conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    const string query = "INSERT INTO TRANSACTIONN (id, from_account_id, branch_id, date_of_trans, amount, pin, to_account_id, employee_id, content_trans) " +
                        "VALUES (@id, @form_account_id, @branch_id, @date_of_trans, @amount, @pin, @to_account_id, @employee_id, @content)";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", transaction.id);
                        cmd.Parameters.AddWithValue("@form_account_id", transaction.form_account_id);
                        cmd.Parameters.AddWithValue("@branch_id", transaction.branch_id);
                        cmd.Parameters.AddWithValue("@date_of_trans", transaction.date_of_trans);
                        cmd.Parameters.AddWithValue("@amount", transaction.amount);
                        cmd.Parameters.AddWithValue("@pin", transaction.pin);
                        cmd.Parameters.AddWithValue("@to_account_id", transaction.to_account_id);
                        cmd.Parameters.AddWithValue("@employee_id", transaction.employee_id);
                        cmd.Parameters.AddWithValue("@content", transaction.content);
                        cmd.ExecuteNonQuery();
                    }
                    items.Add(transaction);
                    return true;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Lỗi thêm giao dịch: {ex.Message}");
                    return false;
                }
            }
        }

        // Cập nhật giao dịch
        public bool Update(IModel model)
        {
            var transaction = model as TransactionModel;
            if (transaction == null || !IsExist(transaction.id)) return false;

            using (var conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    const string query = "UPDATE TRANSACTIONN SET form_account_id = @form_account_id, branch_id = @branch_id, date_of_trans = @date_of_trans, amount = @amount, pin = @pin, to_account_id = @to_account_id, employee_id = @employee_id, content = @content WHERE id = @id";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", transaction.id);
                        cmd.Parameters.AddWithValue("@form_account_id", transaction.form_account_id);
                        cmd.Parameters.AddWithValue("@branch_id", transaction.branch_id);
                        cmd.Parameters.AddWithValue("@date_of_trans", transaction.date_of_trans);
                        cmd.Parameters.AddWithValue("@amount", transaction.amount);
                        cmd.Parameters.AddWithValue("@pin", transaction.pin);
                        cmd.Parameters.AddWithValue("@to_account_id", transaction.to_account_id);
                        cmd.Parameters.AddWithValue("@employee_id", transaction.employee_id);
                        cmd.Parameters.AddWithValue("@content", transaction.content);
                        cmd.ExecuteNonQuery();
                    }
                    return true;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Lỗi cập nhật giao dịch: {ex.Message}");
                    return false;
                }
            }
        }

        // Xóa giao dịch
        public bool Delete(IModel model)
        {
            return model is TransactionModel transaction && Delete(transaction.id);
        }

        // Xóa giao dịch theo ID
        public bool Delete(object id)
        {
            if (!IsExist(id)) return false;

            using (var conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    const string query = "DELETE FROM TRANSACTIONN WHERE id = @id";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                    var transaction = Read(id) as TransactionModel;
                    if (transaction != null)
                    {
                        items.Remove(transaction);
                    }
                    return true;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Lỗi xóa giao dịch: {ex.Message}");
                    return false;
                }
            }
        }

        // Đọc thông tin giao dịch theo ID
        public IModel Read(object id)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    const string query = "SELECT * FROM TRANSACTIONN WHERE id = @id";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new TransactionModel
                                {
                                    id = Convert.ToInt32(reader["id"]),
                                    form_account_id = reader["from_account_id"].ToString(),
                                    branch_id = reader["branch_id"].ToString(),
                                    date_of_trans = Convert.ToDateTime(reader["date_of_trans"]),
                                    amount = Convert.ToSingle(reader["amount"]),
                                    pin = reader["pin"].ToString(),
                                    to_account_id = reader["to_account_id"].ToString(),
                                    employee_id = reader["employee_id"].ToString(),
                                    content = reader["content"].ToString()
                                };
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Lỗi đọc giao dịch: {ex.Message}");
                }
                return null;
            }
        }

        // Tải dữ liệu giao dịch từ cơ sở dữ liệu
        public bool Load()
        {
            items.Clear();
            using (var conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    
                    conn.Open();
                    const string query = "SELECT * FROM TRANSACTIONN";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var transaction = new TransactionModel
                                {
                                    id = Convert.ToInt32(reader["id"]),
                                    form_account_id = reader["from_account_id"].ToString(),
                                    branch_id = reader["branch_id"].ToString(),
                                    date_of_trans = Convert.ToDateTime(reader["date_of_trans"]),
                                    amount = Convert.ToSingle(reader["amount"]),
                                    pin = reader["pin"].ToString(),
                                    to_account_id = reader["to_account_id"].ToString(),
                                    employee_id = reader["employee_id"].ToString(),
                                    content = reader["content_trans"].ToString()
                                };
                                items.Add(transaction);
                            }
                        }
                    }
                    return true;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Lỗi tải dữ liệu giao dịch: {ex.Message}");
                    return false;
                }
            }
        }
        public bool IsExist(string accountId)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM ACCOUNT WHERE id = @accountId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@accountId", accountId);

                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
        public bool Deposit(string accountId, float amount)
        {
            // Kiểm tra xem tài khoản có tồn tại không
            if (!IsExist(accountId))
            {
                MessageBox.Show("Tài khoản không tồn tại.");
                return false;
            }

            // Kết nối với cơ sở dữ liệu
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();

                    // Kiểm tra tài khoản có tồn tại và có hợp lệ không trước khi thực hiện nạp tiền
                    string checkAccountQuery = "SELECT COUNT(*) FROM ACCOUNT WHERE id = @accountId";
                    SqlCommand checkAccountCmd = new SqlCommand(checkAccountQuery, conn);
                    checkAccountCmd.Parameters.AddWithValue("@accountId", accountId);
                    int accountCount = (int)checkAccountCmd.ExecuteScalar();

                    if (accountCount == 0)
                    {
                        MessageBox.Show("Không tìm thấy tài khoản hợp lệ.");
                        return false;
                    }

                    // Thực hiện câu lệnh cập nhật số dư
                    string query = "UPDATE ACCOUNT SET balance = balance + @amount WHERE id = @accountId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@amount", amount);
                    cmd.Parameters.AddWithValue("@accountId", accountId);

                    // Kiểm tra số hàng bị ảnh hưởng bởi câu lệnh UPDATE
                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
                catch (SqlException ex)
                {
                    // Bắt lỗi và xử lý ngoại lệ SQL
                    MessageBox.Show($"Lỗi khi nạp tiền vào tài khoản: {ex.Message}");
                    return false;
                }
            }
        }


        public bool Withdraw(string accountId, float amount)
        {
            if (!IsExist(accountId))
                return false;

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                // Truy vấn số dư hiện tại
                string checkBalanceQuery = "SELECT balance FROM ACCOUNT WHERE id = @accountId";
                SqlCommand checkBalanceCmd = new SqlCommand(checkBalanceQuery, conn);
                checkBalanceCmd.Parameters.AddWithValue("@accountId", accountId);

                // Sử dụng kiểu Nullable<float> để tránh lỗi nếu kết quả là null
                object result = checkBalanceCmd.ExecuteScalar();
                if (result == null || result == DBNull.Value)
                {
                    MessageBox.Show("Không tìm thấy tài khoản hoặc tài khoản không hợp lệ.");
                    return false;
                }

                float currentBalance = Convert.ToSingle(result);

                // Kiểm tra nếu số dư nhỏ hơn số tiền cần rút
                if (currentBalance < amount)
                {
                    MessageBox.Show("Số dư không đủ để thực hiện giao dịch.");
                    return false;
                }

                // Cập nhật số dư sau khi rút
                string query = "UPDATE ACCOUNT SET balance = balance - @amount WHERE id = @accountId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@amount", amount);
                cmd.Parameters.AddWithValue("@accountId", accountId);

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }


        // Chuyển tiền giữa hai tài khoản
        public bool Transfer( IModel model)
        {
            var transactions  = model as TransactionModel;

            if (!IsExist(transactions.form_account_id) || !IsExist(transactions.to_account_id))
                return false;

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // Kiểm tra số dư tài khoản nguồn
                    string checkBalanceQuery = "SELECT balance FROM ACCOUNT WHERE id = @fromAccountId";
                    SqlCommand checkBalanceCmd = new SqlCommand(checkBalanceQuery, conn, transaction);
                    checkBalanceCmd.Parameters.AddWithValue("@fromAccountId", transactions.form_account_id);
                    float currentBalance =Convert.ToInt32( checkBalanceCmd.ExecuteScalar());

                    if (currentBalance < transactions.amount)
                    {
                        transaction.Rollback();
                        return false; 
                    }

                    // Trừ tiền tài khoản nguồn
                    string withdrawQuery = "UPDATE ACCOUNT SET balance = balance - @amount WHERE id = @fromAccountId";
                    SqlCommand withdrawCmd = new SqlCommand(withdrawQuery, conn, transaction);
                    withdrawCmd.Parameters.AddWithValue("@amount", transactions.amount);
                    withdrawCmd.Parameters.AddWithValue("@fromAccountId", transactions.form_account_id);
                    withdrawCmd.ExecuteNonQuery();

                    // Nạp tiền vào tài khoản đích
                    string depositQuery = "UPDATE ACCOUNT SET balance = balance + @amount WHERE id = @toAccountId";
                    SqlCommand depositCmd = new SqlCommand(depositQuery, conn, transaction);
                    depositCmd.Parameters.AddWithValue("@amount", transactions.amount);
                    depositCmd.Parameters.AddWithValue("@toAccountId", transactions.to_account_id);
                    depositCmd.ExecuteNonQuery();

                    // Lưu lịch sử giao dịch
                    string historyQuery = @"
                INSERT INTO TRANSACTIONN ( id ,from_account_id, to_account_id,branch_id,  amount, date_of_trans, content_trans, pin,employee_id )
                VALUES (@Id,@fromAccountId, @toAccountId,@branch_id, @amount, @transactionDate, @note,@pin, @employeeId)";

                    SqlCommand historyCmd = new SqlCommand(historyQuery, conn, transaction);
                    historyCmd.Parameters.AddWithValue("@Id", transactions.id);
                    historyCmd.Parameters.AddWithValue("@fromAccountId", transactions.form_account_id);
                    historyCmd.Parameters.AddWithValue("@toAccountId", transactions.to_account_id);
                    historyCmd.Parameters.AddWithValue("@amount", transactions.amount);
                    historyCmd.Parameters.AddWithValue("@transactionDate", transactions.date_of_trans.Date);  
                    historyCmd.Parameters.AddWithValue("@employeeId",transactions.employee_id);
                    historyCmd.Parameters.AddWithValue("@branch_id", transactions.branch_id);

                    historyCmd.Parameters.AddWithValue("@note", transactions.content);
                    historyCmd.Parameters.AddWithValue("@pin", transactions.pin);
                    historyCmd.ExecuteNonQuery();

                    // Commit transaction
                    transaction.Commit();
                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }



    }
}
