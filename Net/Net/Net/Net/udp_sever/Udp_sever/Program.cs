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
                    if (mess.Trim().Equals("thoat"))
                    {
                        break;
                    }
                    Console.WriteLine(mess);
                    String gui;
                    gui=Console.ReadLine();
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

    }
}
