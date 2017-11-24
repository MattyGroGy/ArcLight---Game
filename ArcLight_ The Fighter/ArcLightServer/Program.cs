using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ArcLightServer
{
    class Program
    {

        public static void Main()
        {
            List<NetPeer> clients;
            NetServer server;

            var config = new NetPeerConfiguration("Login") { Port = 18051 };
            server = new NetServer(config);
            server.Start();

            if (server.Status == NetPeerStatus.Running)
            {
                Console.WriteLine("Server is running on port " + config.Port);
            }
            else
            {
                Console.WriteLine("Server is not started...");
            }
            clients = new List<NetPeer>();

            while (true)
            {
                ReadMessages(server,clients);
            }

        }


        public static void ReadMessages(NetServer server, List<NetPeer> clients)
        {
            NetIncomingMessage message;
            while(true)
            {

                while ((message = server.ReadMessage()) != null)
                {
                switch (message.MessageType)
                {
                    case NetIncomingMessageType.Data:
                        Console.WriteLine("i got smth!");
                        var data = message.ReadString();
                        Console.WriteLine(data);
                        break;
                    case NetIncomingMessageType.DebugMessage:
                        Console.WriteLine(message.ReadString());
                        break;
                    case NetIncomingMessageType.StatusChanged:
                        Console.WriteLine(message.SenderConnection.Status);
                        if (message.SenderConnection.Status == NetConnectionStatus.Connected)
                        {
                            clients.Add(message.SenderConnection.Peer);
                            Console.WriteLine($"{message.SenderConnection.Peer.Configuration.LocalAddress} has connected.");
                        }
                        if (message.SenderConnection.Status == NetConnectionStatus.Disconnected)
                        {
                            clients.Remove(message.SenderConnection.Peer);
                            Console.WriteLine($"{message.SenderConnection.Peer.Configuration.LocalAddress} has disconnected.");
                        }
                        break;
                    default:
                        Console.WriteLine($"Unhandled message type: {message.MessageType}");
                        break;
                }
                server.Recycle(message);

                }
            }
        }
    }
}
