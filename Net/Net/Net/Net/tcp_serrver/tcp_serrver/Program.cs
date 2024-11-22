using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
namespace tcp_serrver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IPEndPoint ip = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8888);
                Socket server = new Socket(SocketType.Stream, ProtocolType.Tcp);
                server.Bind(ip);
                server.Listen(100);
                Socket client = server.Accept();
                while (true)
                {
                    byte[] bnhan = new byte[255];
                    client.Receive(bnhan);
                    String mess = ASCIIEncoding.ASCII.GetString(bnhan);
                    if (mess.Trim().Equals("thoat"))
                    {
                        break;
                    }
                    Console.WriteLine(mess);
                    String gui = Console.ReadLine();
                    byte[] bgui = ASCIIEncoding.ASCII.GetBytes(gui);
                   
                    client.Send(bgui);

                }
                client.Close();
                server.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
           
        }
    }
}
