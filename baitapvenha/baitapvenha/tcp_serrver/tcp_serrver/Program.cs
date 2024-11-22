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
            List<Cauhoi> lst = new List<Cauhoi>
            {
                new Cauhoi("1+1","A.3","B.4","C.2","D.5","C"),
                new Cauhoi("2+1","A.3","B.4","C.2","D.5","A"),
                new Cauhoi("3+1","A.3","B.4","C.2","D.5","B"),
                new Cauhoi("4+1","A.3","B.4","C.2","D.5","D"),
                new Cauhoi("1+1","A.3","B.4","C.2","D.5","C"),
            };
            try
            {
                IPEndPoint ip = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8888);
                Socket server = new Socket(SocketType.Stream, ProtocolType.Tcp);
                server.Bind(ip);
                server.Listen(100);
                Socket client = server.Accept();
                int dem = 0;
                for (int i = 0; i < lst.Count; i++) {
                    
                    String gui = lst[i].noidungcauhoi();
                    byte[] bgui = ASCIIEncoding.ASCII.GetBytes(gui);

                    client.Send(bgui);
                    byte[] bnhan = new byte[255];
                    client.Receive(bnhan);
                    String mess = ASCIIEncoding.ASCII.GetString(bnhan).Trim();
                    string dapan = lst[i].GetDapandung();
                    
                    if (String.Compare(mess, dapan, true) == 0)
                    {
                        Console.WriteLine(mess.ToUpper());
                        dem++;
                    }
                   
                    
                }
                String gui2 = dem.ToString();
                Console.WriteLine(dem);
                byte[] bgui2 = ASCIIEncoding.ASCII.GetBytes(gui2);
                client.Send(bgui2);
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
