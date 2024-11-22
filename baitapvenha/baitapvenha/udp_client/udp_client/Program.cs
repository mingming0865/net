using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
namespace udp_client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IPEndPoint s_ipe = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8888);
                Socket client = new Socket(SocketType.Dgram, ProtocolType.Udp);
                
                    int  so =Convert.ToInt32( Console.ReadLine());
                    string gui = so.ToString();
                    byte[] bgui = ASCIIEncoding.ASCII.GetBytes(gui);
                    client.SendTo(bgui, s_ipe);
                    /*if (gui.Equals("thoat"))
                    {
                        break;
                    }*/
                    byte[] bnhan = new byte[255];
                    EndPoint ipe = new IPEndPoint(IPAddress.None, 0);
                    client.ReceiveFrom(bnhan,ref ipe);
                    String nhan = ASCIIEncoding.ASCII.GetString(bnhan);
                    Console.WriteLine(nhan);
                
                client.Close();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();  
        }
    }
}
