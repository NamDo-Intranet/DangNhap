using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace DangNhapUsers
{
    static class KetNoi
    {
        static SqlConnection conn;
        static SqlCommand cmd;
        static SqlDataAdapter da;

        static public void moketnoi()
        {
            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["kn"].ConnectionString.ToString();
            try
            {
                conn.Open();
            }
            catch
            {

            }
        }
        static public void dongketnoi()
        {
            conn.Close();
        }
        static public DataTable getData(string sql)
        {
            DataTable dt = new DataTable();
            da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            return dt;
        }
        static public void upDate(string sql, object[] value, string[] name, int thamso)
        {
            cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Clear();
            for (int i = 0; i < thamso; i++)
                cmd.Parameters.AddWithValue(name[i], value[i]);
            cmd.ExecuteNonQuery();
        }
    }
}
