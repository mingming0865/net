using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
namespace tcp_client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IPEndPoint ip = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8888);
                Socket client= new Socket( SocketType.Stream, ProtocolType.Tcp);
                client.Connect(ip);
                Console.WriteLine("ket noi thanh cong");
                while (true)
                {
                    byte[] bnhan = new byte[225];
                    client.Receive(bnhan);
                    String nhan = ASCIIEncoding.ASCII.GetString(bnhan);
                    Console.WriteLine(nhan);
                    String gui=Console.ReadLine(); 
                    byte[] bgui= ASCIIEncoding.ASCII.GetBytes(gui);
                    client.Send(bgui);
                    if (gui.Equals("thoat"))
                    {
                        break;
                    }
                    

                }
                client.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();  
        }
    }
}
