using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    class Program
    { public static string data = null;
        static void Main(string[] args)
        {
            byte[] bytes = new Byte[1024];
           
                var port = 13000;
                var ipAddress = IPAddress.Parse("127.0.0.1");
                var server = new TcpListener(ipAddress, port);                 
                server.Start();
                Console.WriteLine("Simple server was started");
            try
                {     
                   while (true)

                {
                    Socket socket = server.AcceptSocket();
                    
                    Console.WriteLine("Connection accepted." + DateTime.Now);

                    string responseString = "You have successfully connected";

                    Byte[] sendBytes = Encoding.ASCII.GetBytes(responseString);
                    int i = socket.Send(sendBytes);
                    Console.WriteLine("Message Sent /> : " + responseString);                 
                }

            }
                catch (Exception e)
                {
                
                    Console.WriteLine(e.ToString());
                }
                server.Stop();
                Console.WriteLine("\nPress ENTER to continue...");
                Console.Read();
            
            }
      
    }
}
