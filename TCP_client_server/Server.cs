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
    // Simulates REST server in TCP
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
                    for (int i = 0; i < k; i++)
                        Console.Write(Convert.ToChar(b[i]));

                    // write the byte array into a new file
                    byte[] data = File.ReadAllBytes("response.txt");
                    s.Send(data);

                    Console.WriteLine("\nSent Acknowledgement");
                    /* clean up */
                    s.Close();
                    myList.Stop();

                }
                catch (Exception e)
                {
                    Console.WriteLine("Error..... " + e.StackTrace);
                }
            }
        }
    }
}
