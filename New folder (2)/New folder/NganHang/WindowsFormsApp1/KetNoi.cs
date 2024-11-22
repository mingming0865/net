using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;//phải thêm vào class đầu tiên
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    class KetNoi
    {

        string con_str = "Data Source=DESKTOP-DJOM7GH\\SQLEXPRESS;Initial Catalog=NganHang;Integrated Security=True";

        public DataTable LayDuLieu(string truy_van)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(con_str);
            SqlDataAdapter da = new SqlDataAdapter(truy_van, conn);
            da.Fill(dt);
            return dt;
        }

        public bool ThucThi(string truy_van)
        {
            SqlConnection conn = new SqlConnection(con_str);
            conn.Open();
            SqlCommand cmd = new SqlCommand(truy_van, conn);
            int kt = cmd.ExecuteNonQuery();
            conn.Close();
            return kt > 0;
        }
      
    }
}
