using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DangNhapUsers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        #region
        public void loadData()
        {
            string sql = "Select * from NguoiDung";
            datagridview.DataSource = KetNoi.getData(sql);
            this.datagridview.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.datagridview.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        #endregion
        private void Form1_Load(object sender, EventArgs e)
        {
            KetNoi.moketnoi();
            loadData();
        }

        private void btthem_Click(object sender, EventArgs e)
        {
            string sql = "Insert into Nguoidung Values(@Tendangnhap, @Matkhau)";
            string[] name = { "@Tendangnhap", "@Matkhau" };
            object[] value = { tbtaikhoan.Text, tbmatkhau.Text };
            KetNoi.moketnoi();
            KetNoi.upDate(sql, value, name, 2);
            loadData();
            KetNoi.dongketnoi();
            MessageBox.Show("Đã thêm thành công vào cơ sở dữ liệu");
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = new DialogResult();
            dr = MessageBox.Show("Bạn có chắc chắn là muốn xóa tài khoản này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(dr == DialogResult.Yes)
            {
                string username = tbtaikhoan.Text;
                string sql = "Delete from Nguoidung where Tendangnhap='" + username + "' ";
                string[] name = { };
                object[] value = { };
                KetNoi.moketnoi();
                KetNoi.upDate(sql, value, name, 0);
                KetNoi.dongketnoi();
                MessageBox.Show("Bạn đã xóa tài khoản thành công!");
                loadData();
            }
        }

        private void btsua_Click(object sender, EventArgs e)
        {
            int i = datagridview.CurrentCell.RowIndex;
            string user = tbtaikhoan.Text;
            string sql = "Update Nguoidung set Tendangnhap = @Tendangnhap, Matkhau = @Matkhau where Tendangnhap = '" + user + "' ";
            string[] name = { "@Tendangnhap", "@Matkhau" };
            object[] value = { tbtaikhoan.Text, tbmatkhau.Text };
            KetNoi.moketnoi();
            KetNoi.upDate(sql, value, name, 2);
            KetNoi.dongketnoi();
            MessageBox.Show("Bạn đã sửa thông tin thành công");
            loadData();
        }

        private void datagridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = datagridview.CurrentCell.RowIndex;
            tbtaikhoan.Text = datagridview.Rows[i].Cells[0].Value.ToString();
            tbmatkhau.Text = datagridview.Rows[i].Cells[1].Value.ToString();
        }

        private void btlammoi_Click(object sender, EventArgs e)
        {
            tbtaikhoan.Text = "";
            tbmatkhau.Text = "";
        }
    }
}
