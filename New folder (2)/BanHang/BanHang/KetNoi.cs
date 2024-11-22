using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BanHang
{
    class KetNoi
    {
        string con_str = "Data Source=DESKTOP-NA94OOD\\SQLEXPRESS;Initial Catalog=BanHang;Integrated Security=True";

        public DataTable LayDuLieu(string truy_van)
        {
            DataTable tb = new DataTable();
            SqlConnection conn = new SqlConnection(con_str);
            SqlDataAdapter da = new SqlDataAdapter(truy_van, conn);
            da.Fill(tb);
            return tb;
        }

        public bool ThucThi(string truy_van)
        {
            SqlConnection conn = new SqlConnection(con_str);
            conn.Open();
            SqlCommand cmd = new SqlCommand(truy_van, conn);
            int ck = cmd.ExecuteNonQuery();
            return ck > 0;
        }
    }
}
