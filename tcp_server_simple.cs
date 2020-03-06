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
    class Server
    {
        public static void Listen()
        {
            while (true)
            {
                try
                {
                    IPAddress ipAd = IPAddress.Parse("127.0.0.1");
                    // use local m/c IP address, and 
                    // use the same in the client

                    /* Initializes the Listener */
                    TcpListener myList = new TcpListener(ipAd, 8001);

                    /* Start Listeneting at the specified port */
                    myList.Start();

                    Console.WriteLine("The server is running at port 8001...");
                    Console.WriteLine("The local End point is  :" +
                                      myList.LocalEndpoint);
                    Console.WriteLine("Waiting for a connection.....");

                    Socket s = myList.AcceptSocket();
                    Console.WriteLine("Connection accepted from " + s.RemoteEndPoint);

                    byte[] b = new byte[10000];
                    int k = s.Receive(b);
                    Console.WriteLine("Recieved...");
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < k; i++)
                    {
                        Console.Write(Convert.ToChar(b[i]));
                        sb.Append(Convert.ToChar(b[i]).ToString());
                    }

                    ASCIIEncoding asen = new ASCIIEncoding();
                    s.Send(asen.GetBytes($"The string {sb} was recieved by the server."));
                    Console.WriteLine("\nSent Acknowledgement");

                    Console.WriteLine("\nSent Acknowledgement");
                    /* clean up */
                    s.Close();
                    myList.Stop();

                    Thread.Sleep(1000);

                }
                catch (Exception e)
                {
                    Console.WriteLine("Error..... " + e.StackTrace);
                }
            }
        }
    }
}
