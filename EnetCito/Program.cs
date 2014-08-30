using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace EnetCito
{
    class Program
    {
        static void Main(string[] args)
        {
            ENetHost client;
            ENetAddress address = new ENetAddress();
            ENetEvent e = new ENetEvent();
            ENetPeer peer;

            ENet enet = new ENet();
            enet.SetPlatform(new ENetPlatformDotNet());
            if (enet.enet_initialize() != 0)
            {
                Console.WriteLine("An error occurred while initializing ENet.\n");
                return;
            }

            client = enet.enet_host_create(null /* create a client host */,
            1 /* only allow 1 outgoing connection */,
            2 /* allow up 2 channels to be used, 0 and 1 */,
            57600 / 8 /* 56K modem with 56 Kbps downstream bandwidth */,
            14400 / 8 /* 56K modem with 14 Kbps upstream bandwidth */);
            if (client == null)
            {
                Console.WriteLine("An error occurred while trying to create an ENet client host.\n");
                return;
            }

            /* Connect to some.server.net:1234. */
            enet.enet_address_set_host(address, "localhost");
            address.port = 12345;
            /* Initiate the connection, allocating the two channels 0 and 1. */
            peer = enet.enet_host_connect(client, address, 2, 0);
            if (peer == null)
            {
                Console.WriteLine("No available peers for initiating an ENet connection.\n");
            }
            /* Wait up to 5 seconds for the connection attempt to succeed. */
            if (enet.enet_host_service(client, e, 5000) > 0 &&
                e.type == ENetEventType.ENET_EVENT_TYPE_CONNECT)
            {
                Console.WriteLine("Connection to some.server.net:1234 succeeded.");
            }
            else
            {
                /* Either the 5 seconds are up or a disconnect event was */
                /* received. Reset the peer in the event the 5 seconds   */
                /* had run out without any significant event.            */
                enet.enet_peer_reset(peer);
                Console.WriteLine("Connection to some.server.net:1234 failed.");
                Console.ReadLine();
                return;
            }
            int i = 0;
            //for (int i = 0; i < 10; i++)
            {
                byte[] data = new byte[100];
                data[0] = 67;
                data[1] = 68;
                var packet = enet.enet_packet_create(data, 2, ENetPacketFlagEnum.ENET_PACKET_FLAG_RELIABLE);
                enet.enet_peer_send(peer, 0, packet);
                enet.enet_host_flush(client);

                for (; ; )
                    /* Wait up to 1000 milliseconds for an event. */
                    while (enet.enet_host_service(client, e, 0) > 0)
                    {
                        switch (e.type)
                        {
                            case ENetEventType.ENET_EVENT_TYPE_CONNECT:
                                Console.WriteLine("A new client connected from {0}:{1}.\n",
                                        e.peer.address.host,
                                        e.peer.address.port);
                                /* Store any relevant client information here. */
                                e.peer.data = Encoding.ASCII.GetBytes("Client information");
                                break;
                            case ENetEventType.ENET_EVENT_TYPE_RECEIVE:
                                Console.WriteLine("A packet of length {0} containing {1} was received from {2} on channel {3}.\n",
                                        e.packet.dataLength,
                                        Encoding.ASCII.GetString(e.packet.data),
                                        e.peer.data,
                                        e.channelID);
                                /* Clean up the packet now that we're done using it. */
                                enet.enet_packet_destroy(e.packet);

                                //byte[] data2 = Encoding.ASCII.GetBytes((i++).ToString());
                                byte[] data2 = new byte[2] { 65, 66 };
                                var packet2 = enet.enet_packet_create(data2, data2.Length, ENetPacketFlagEnum.ENET_PACKET_FLAG_RELIABLE);
                                enet.enet_peer_send(peer, 0, packet2);
                                enet.enet_host_flush(client);

                                i++;
                                if (i > 5)
                                {
                                    //return;
                                }
                                break;

                            case ENetEventType.ENET_EVENT_TYPE_DISCONNECT:
                                Console.WriteLine("%s disconnected.\n", e.peer.data);
                                /* Reset the peer's client information. */
                                e.peer.data = null;
                                Console.ReadLine();
                                return;
                                break;
                        }
                    }
            }
            Console.ReadLine();
        }
    }
}
