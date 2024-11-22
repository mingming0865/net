using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
namespace Udp_sever
{
    
    internal class Program
    {
       
        static void Main(string[] args)
        {
            try
            {
                IPEndPoint s_ipe = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8888);
                Socket sever=new Socket( SocketType.Dgram, ProtocolType.Udp);
                sever.Bind(s_ipe);
                Console.WriteLine("nhan tep tin tu client\n");
                while (true)
                {
                    byte[] bnhan = new byte[225];
                    EndPoint c_ipe = new IPEndPoint(IPAddress.None, 0);
                    sever.ReceiveFrom(bnhan, ref c_ipe);
                    String mess=ASCIIEncoding.ASCII.GetString(bnhan);
                    int songuyen = Convert.ToInt32(mess.Trim());
                    /* if (mess.Trim().Equals("thoat"))
                     {
                         break;
                     }*/
                    String gui;
                    Console.WriteLine(mess);
                   if (ktra(songuyen) == true)
                    {
                        gui = songuyen + " la so nguyen to";
                    }
                    else
                    {
                        gui = songuyen + " không  la so nguyen to";
                    }
                    
                   // gui=Console.ReadLine();
                    byte[] bgui = ASCIIEncoding.ASCII.GetBytes(gui);
                    sever.SendTo(bgui, c_ipe);
                }
                sever.Close();

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }

        private static bool ktra(int a)
        {

            for (int i = 2; i < Math.Sqrt(a); i++)
            {
                if (a % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
