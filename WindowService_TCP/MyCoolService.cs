using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyCoolService
{
    public partial class MyCoolService : ServiceBase
    {
        public MyCoolService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
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

                    // write the byte array into a new file
                    //byte[] data = File.ReadAllBytes("response.txt");
                    //s.Send(data);

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

        protected override void OnStop()
        {
            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = "Application";
                eventLog.WriteEntry("My cool service finished...", EventLogEntryType.Information, 101, 1);
            }
        }
    }
}

