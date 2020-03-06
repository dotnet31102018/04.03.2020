using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TCP_client_server
{
    class Program
    {
       

        static void Main(string[] args)
        {
            //Task.Run(() => Listen());

            //Listen();
            /*
            // Console.ReadLine();
            //Thread.Sleep(100000000);

            try
            {
                TcpClient tcpclnt = new TcpClient();
                Console.WriteLine("Connecting.....");

                //tcpclnt.Connect("127.0.0.1", 8001);
                tcpclnt.Connect("104.28.11.45", 80);
                // use the ipaddress as in the server program

                Console.WriteLine("Connected");
                Console.Write("Enter the string to be transmitted : ");

                //String str = Console.ReadLine();
                Stream stm = tcpclnt.GetStream();

                ASCIIEncoding asen = new ASCIIEncoding();
                // Console.WriteLine("Tran'smitting.....");
                //byte[] ba = asen.GetBytes("aaa");
                FileStream f1 = new FileStream("test.txt", FileMode.Open, FileAccess.Read);
                byte[] ba = new byte[257];
                f1.Read(ba, 0, 257);
                f1.Close();
                stm.Write(ba, 0, ba.Length);

                byte[] bb = new byte[100000];
                int k = stm.Read(bb, 0, 3000);

                for (int i = 0; i < k; i++)
                    Console.Write(Convert.ToChar(bb[i]));

                tcpclnt.Close();
            }

            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
            }
            */
            Console.ReadLine();
        }
    }
}