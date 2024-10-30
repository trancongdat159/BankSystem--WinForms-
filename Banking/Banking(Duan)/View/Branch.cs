using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Banking.Controller;
using Banking.Model;
using System.Drawing;
using System.Linq;

namespace Banking.View
{
    public partial class Branch : UserControl, IView
    {
        BranchController controller = new BranchController();

        public Branch()
        {
            InitializeComponent();
            LoadDataGrid();
            dataGridViewbr.CellClick += DataGridViewbr_CellClick;
            Save.Enabled = false;
            Delete.Enabled = false;

            this.Resize += (s, e) =>
            {
                panel1.Location = new Point((this.ClientSize.Width - panel1.Width) / 2,
                                            (this.ClientSize.Height - panel1.Height) / 2);
            };
        }

        private void DataGridViewbr_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewbr.Rows[e.RowIndex];

                textbrid.Text = row.Cells["id"].Value?.ToString();
                textbrname.Text = row.Cells["name"].Value?.ToString();
                textbraddress.Text = row.Cells["house_no"].Value?.ToString();
                textbrcity.Text = row.Cells["city"].Value?.ToString();
            }
        }

        public void GetDataFromText()
        {
            BranchModel branch = new BranchModel
            {
                id = textbrid.Text,
                name = textbrname.Text,
                house_no = textbraddress.Text,
                city = textbrcity.Text
            };

            controller.Add(branch);
            controller.Update(branch);
        }

        public void SetDataToText(object item)
        {
            if (item is BranchModel branch)
            {
                textbrid.Text = branch.id;
                textbrname.Text = branch.name;
                textbraddress.Text = branch.house_no; 
                textbrcity.Text = branch.city;
            }
            else
            {
                throw new ArgumentException("Item must be of type BranchModel");
            }
        }

        private void LoadDataGrid()
        {
            if (controller.Load())  // Nếu Load thành công
            {
                List<BranchModel> list = controller.Items
                    .OfType<BranchModel>()  // Chỉ lấy các đối tượng BranchModel
                    .ToList();

                // Kiểm tra xem danh sách có trống không
                if (list.Count == 0)
                {
                    MessageBox.Show("No branch data found.");
                }
                else
                {
                    dataGridViewbr.DataSource = list;
                    dataGridViewbr.CellClick += DataGridViewbr_CellClick;
                    dataGridViewbr.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            else
            {
                MessageBox.Show("Failed to load branch data.");
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            string id = textbrid.Text;
            string name = textbrname.Text;
            string house_no = textbraddress.Text;
            string city = textbrcity.Text;

            BranchModel branch = new BranchModel{ id = id,name =name,house_no= house_no, city = city};

            var branchExists = controller.IsExist(id);

            if (branchExists)
            {
                controller.Update(branch);
                MessageBox.Show("Branch updated successfully.");
            }
            else
            {
                controller.Add(branch);
                MessageBox.Show("New branch added successfully.");
            }

            LoadDataGrid();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            string id = textbrid.Text;

            if (controller.IsExist(id))
            {
                controller.Delete(id);
                MessageBox.Show("Branch deleted successfully.");
                LoadDataGrid();
                ClearFields();
            }
            else
            {
                MessageBox.Show("Branch not found.");
            }
        }

        public void ClearFields()
        {
            textbrid.Clear();
            textbrname.Clear();
            textbraddress.Clear();
            textbrcity.Clear();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Trangchu mainForm = (Trangchu)this.ParentForm;
            mainForm.Show();
            this.Dispose();
        }

        private void panel1_Paint(object sender, PaintEventArgs e) { }

        private void Branch_Load(object sender, EventArgs e) { }

        private void textbrid_TextChanged(object sender, EventArgs e)
        {
            EnableSubmitButton();
        }

        private void textbrname_TextChanged(object sender, EventArgs e)
        {
            EnableSubmitButton();
        }

        private void textbraddress_TextChanged(object sender, EventArgs e)
        {
            EnableSubmitButton();
        }

        private void textbrcity_TextChanged(object sender, EventArgs e)
        {
            EnableSubmitButton();
        }
        private void EnableSubmitButton()
        {
            // Kiểm tra nếu tất cả các TextBox không rỗng thì bật nút, ngược lại thì tắt
            Save.Enabled = !string.IsNullOrWhiteSpace(textbrid.Text) &&
                                !string.IsNullOrWhiteSpace(textbrname.Text) &&
                                !string.IsNullOrWhiteSpace(textbraddress.Text) &&
                                !string.IsNullOrWhiteSpace(textbrcity.Text);
            Delete.Enabled = !string.IsNullOrWhiteSpace(textbrid.Text);
        }
    }
}
