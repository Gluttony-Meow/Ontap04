using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Ontap04
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            groupBox1.Enabled = false;
            btnDel.Enabled = false;
            btnUpdate.Enabled = false;
        }
        SqlConnection cnn = new SqlConnection(@"Data Source=DESKTOP-GBBCS2R;Initial Catalog=ontap;Integrated Security=True");
        private void ketnoicsdl()
        {
            cnn.Open();
            string sql = "select * from tblMatHang";  // lay het du lieu trong bang sinh vien
            SqlCommand com = new SqlCommand(sql, cnn); //bat dau truy van
            SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
            DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
            da.Fill(dt);  // đổ dữ liệu vào kho
            cnn.Close();  // đóng kết nối
            dataGridView1.DataSource = dt; //đổ dữ liệu vào datagridview
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void add()
        {
            string sqlInsert = "INSERT INTO tblMatHang(MaSP,TenSP ,MaNH, NgaySX, NgayHH, DonVi,DonGia,GhiChu) values (@MaSP,@TenSP,@MaNH,@NgaySX,@NgayHH, @DonVi,@DonGia,@GhiChu) ";
            SqlCommand com = new SqlCommand(sqlInsert, cnn);
            com.Parameters.AddWithValue("@MaSP", tbMaSP.Text);
            com.Parameters.AddWithValue("@TenSP", tbName.Text);
            com.Parameters.AddWithValue("@MaNH", cbNH.Text);
            com.Parameters.AddWithValue("@NgaySX", dtpNgaySX.Value );
            com.Parameters.AddWithValue("@NgayHH", dtpNgayHH.Value);
            com.Parameters.AddWithValue("@DonVi", tbDonVi.Text);
            com.Parameters.AddWithValue("@DonGia",Decimal.Parse (tbPrice.Text));
            com.Parameters.AddWithValue("@GhiChu", listBox1.Text);

            cnn.Open();
            com.ExecuteNonQuery();
            cnn.Close();
        }
        void ClearAllText(Control con)
        {
            foreach (Control c in con.Controls)
            {
                if (c is TextBox)
                    ((TextBox)c).Clear();
                else
                    ClearAllText(c);
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            ClearAllText(this);
            btnUpdate.Enabled = false;
            btnDel.Enabled = false;
            groupBox1.Enabled = true;

            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            add();
            ketnoicsdl();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearAllText(this);
            groupBox1.Enabled = false;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}

