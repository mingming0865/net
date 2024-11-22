using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tcp_serrver
{
    class Cauhoi
    {
        private String Noidung;
        private String Dapan1;
        private String Dapan2;
        private String Dapan3;
        private String Dapan4;
        private String Dapandung;

        public Cauhoi(string noidung, string dapan1, string dapan2, string dapan3, string dapan4, string dapandung)
        {
            Noidung = noidung;
            Dapan1 = dapan1;
            Dapan2 = dapan2;
            Dapan3 = dapan3;
            Dapan4 = dapan4;
            Dapandung = dapandung;
        }
        public string noidungcauhoi()
        {
            string noidungcauhoi = Noidung + "\n" + Dapan1 + "\n" + Dapan2 + "\n" + Dapan3 + "\n" + Dapan4 + "\n";
            return noidungcauhoi;
        }
        public string GetDapandung()
        {
            return Dapandung;
        }
    }
}
