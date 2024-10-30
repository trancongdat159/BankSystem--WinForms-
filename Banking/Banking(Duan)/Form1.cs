using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banking
{
    public partial class Login : UserControl
    {
        public Login()
        {
            InitializeComponent();
            this.Resize += new EventHandler(Form1_Resize);

            // Đặt kích thước ban đầu cho Panel
            //panel1.Width = 448;
            //panel1.Height = 448;

            // Căn giữa panel khi form load
            CenterPanel();
            tableLayoutPanel1.Dock = DockStyle.Fill;
            panel1.Dock = DockStyle.Fill;
            panel2.Dock = DockStyle.Fill;

            //pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            ////panel1.BackColor = Color.LightBlue;
            //panel2.BackColor = Color.LightCoral;
            //panel3.BackColor = Color.BlueViolet;
            panel1.Resize += (s, e) =>
            {
                // Tính toán để đặt Panel3 ở giữa Panel1
                panel3.Left = (panel1.Width - panel3.Width) / 2;
                panel3.Top = (panel1.Height - panel3.Height) / 2;
            };

            panel3.Resize += (s, e) =>
            {
                // Điều chỉnh kích thước của Label và Button theo kích thước của Panel3
                label1.Size = new Size(panel3.Width / 2, panel3.Height / 4);
                button1.Size = new Size(panel3.Width / 2, panel3.Height / 4);

                // Điều chỉnh vị trí của Label và Button để căn giữa
                label1.Location = new Point((panel3.Width - label1.Width) / 2, panel3.Height / 6);
                button1.Location = new Point((panel3.Width - button1.Width) / 2, (panel3.Height / 2));

                // Tính toán tỷ lệ font theo kích thước Panel3
                float fontSize = Math.Min(panel3.Width / 20, panel3.Height / 10);  // Tính kích thước font tương đối

                // Điều chỉnh kích thước font của Label và Button
                label1.Font = new Font(label1.Font.FontFamily, fontSize);
                button1.Font = new Font(button1.Font.FontFamily, fontSize);
            };
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            // Căn giữa panel khi form thay đổi kích thước
            CenterPanel();
            CenterPictureBox();
        }

        private void CenterPanel()
        {
            //// Tính toán vị trí Left và Top để căn giữa panel trong form
            ////panel1.Left = (this.ClientSize.Width - panel1.Width) / 2;
            //panel3. = (this.ClientSize.Height - panel1.Height) / 2;
        }

        private void CenterPictureBox()
        {
            // Tính toán kích thước mới cho PictureBox (ví dụ: chiếm 80% kích thước form)
            //pictureBox1.Width = this.ClientSize.Width - 20;  // Trừ đi một khoảng để có lề
            //pictureBox1.Height = this.ClientSize.Height - 20; // Trừ đi một khoảng để có lề

            // Căn giữa PictureBox
            //pictureBox1.Left = (this.ClientSize.Width - pictureBox1.Width) / 2;
            //pictureBox1.Top = (this.ClientSize.Height - pictureBox1.Height) / 2;
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
