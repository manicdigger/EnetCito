using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Collections;
using System.Runtime.InteropServices;

namespace EnetCito
{
    public class ENetPlatformDotNet : ENetPlatform
    {
        public override int time()
        {
            TimeSpan span = DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1, 0, 0, 0));
            return (int)span.TotalSeconds;
        }

        public override ENetSocket enet_socket_create(int type)
        {
            ENetSocketDotNet socket_ = new ENetSocketDotNet();
            socket_.socket = new Socket(AddressFamily.InterNetwork, type == ENetSocketTypeEnum.ENET_SOCKET_TYPE_DATAGRAM ? SocketType.Dgram : SocketType.Stream, ProtocolType.Udp);
            return socket_;
        }

        public override int enet_socket_bind(ENetSocket socket, ENetAddress address)
        {
            ENetSocketDotNet socket_ = (ENetSocketDotNet)socket;
            try
            {
                socket_.socket.Bind(new IPEndPoint(address.host, address.port));
            }
            catch
            {
                return -1;
            }
            return 0;
        }

        public override int enet_socket_get_address(ENetSocket socket, ENetAddress address)
        {
            ENetSocketDotNet socket_ = (ENetSocketDotNet)socket;
            try
            {
                IPEndPoint endPoint = (IPEndPoint)socket_.socket.RemoteEndPoint;
                address.host = (int)endPoint.Address.Address;
                address.port = endPoint.Port;
            }
            catch
            {
                return -1;
            }
            return 0;
        }

        public override int enet_socket_listen(ENetSocket socket, int backlog)
        {
            ENetSocketDotNet socket_ = (ENetSocketDotNet)socket;
            try
            {
                socket_.socket.Listen(backlog);
            }
            catch
            {
                return -1;
            }
            return 0;
        }

        public override int enet_socket_accept(ENetSocket socket, ENetAddress address)
        {
            ENetSocketDotNet socket_ = (ENetSocketDotNet)socket;
            return 0;
        }

        public override int enet_socket_connect(ENetSocket socket, ENetAddress address)
        {
            ENetSocketDotNet socket_ = (ENetSocketDotNet)socket;
            try
            {
                socket_.socket.Connect(new IPAddress(address.host), address.port);
            }
            catch
            {
                return -1;
            }
            return 0;
        }

        public override int enet_socket_send(ENetSocket socket, ENetAddress address, ENetBuffer[] buffers, int bufferCount)
        {
            int totalLength = 0;
            for (int i = 0; i < bufferCount; i++)
            {
                totalLength += buffers[i].dataLength;
            }
            byte[] totalData = new byte[totalLength];
            int totalLength2 = 0;
            for (int i = 0; i < bufferCount; i++)
            {
                for (int k = 0; k < buffers[i].dataLength; k++)
                {
                    totalData[totalLength2++] = buffers[i].data[k];
                }
            }

            Console.WriteLine("SEND:" + string.Join(" ", totalData.Select(a => a.ToString()).ToArray()));

            int sentLength = 0;
            ENetSocketDotNet socket_ = (ENetSocketDotNet)socket;
            try
            {
                sentLength += socket_.socket.SendTo(totalData, totalLength2, SocketFlags.None, new IPEndPoint(address.host, address.port));
            }
            catch
            {
                return -1;
            }
            return sentLength;
        }

        public override int enet_socket_receive(ENetSocket socket, ENetAddress address, ENetBuffer[] buffers, int bufferCount)
        {
            ENetSocketDotNet socket_ = (ENetSocketDotNet)socket;
            if (bufferCount != 1)
            {
                throw new ArgumentException();
            }
            //EndPoint remoteEP = new IPEndPoint(new IPAddress(address.host), address.port);
            EndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0);
            if (socket_.socket.Available == 0)
            {
                return 0;
            }
            try
            {
                int received = socket_.socket.ReceiveFrom(buffers[0].data, buffers[0].dataLength, SocketFlags.None, ref remoteEP);
                address.host = (int)(((IPEndPoint)remoteEP).Address.Address);
                address.port = (int)(((IPEndPoint)remoteEP).Port);
                byte[] received_ = buffers[0].data.Take(received).ToArray();
                Console.WriteLine("RECEIVED:" + string.Join(" ", received_.Select(a => a.ToString()).ToArray()));
                return received;
            }
            catch
            {
                return 0;
            }
        }

        public override int enet_socket_wait(ENetSocket socket, int[] condition, int timeout)
        {
            ENetSocketDotNet socket_ = (ENetSocketDotNet)socket;
            //int condition_ = condition[0];
            //condition[0] = ENet.ENET_SOCKET_WAIT_NONE;
            //if ((condition_ & ENet.ENET_SOCKET_WAIT_RECEIVE) != 0)
            //{
            //    if (socket_.socket.Poll(timeout, SelectMode.SelectRead))
            //    {
            //        condition[0] |= ENet.ENET_SOCKET_WAIT_RECEIVE;
            //    }
            //}
            //else
            //{
            //}


            ArrayList checkRead = new ArrayList();
            ArrayList checkWrite = new ArrayList();
            ArrayList checkError = new ArrayList();
            if ((condition[0] & ENet.ENET_SOCKET_WAIT_SEND) != 0)
            {
                checkWrite.Add(socket_.socket);
            }
            if ((condition[0] & ENet.ENET_SOCKET_WAIT_RECEIVE) != 0)
            {
                checkRead.Add(socket_.socket);
            }
            try
            {
                Socket.Select(checkRead, checkWrite, checkError, timeout * 1000);
            }
            catch
            {
                return -1;
            }
            if (checkWrite.Contains(socket_.socket))
            {
                condition[0] |= ENet.ENET_SOCKET_WAIT_SEND;
            }
            if (checkRead.Contains(socket_.socket))
            {
                condition[0] |= ENet.ENET_SOCKET_WAIT_RECEIVE;
            }
            return 0;
        }

        public override int enet_socket_set_option(ENetSocket socket, int option, int value)
        {
            ENetSocketDotNet socket_ = (ENetSocketDotNet)socket;
            int result = ENet.SOCKET_ERROR;
            switch (option)
            {
                case ENetSocketOption.ENET_SOCKOPT_NONBLOCK:
                    {
                        //u_long nonBlocking = (u_long)value;
                        //result = ioctlsocket(socket, FIONBIO, &nonBlocking);
                        socket_.socket.Blocking = value == 0;
                        break;
                    }

                case ENetSocketOption.ENET_SOCKOPT_BROADCAST:
                    //result = setsockopt(socket, SOL_SOCKET, SO_BROADCAST, (char*)&value, sizeof(int));
                    socket_.socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, value);
                    break;

                case ENetSocketOption.ENET_SOCKOPT_REUSEADDR:
                    //result = setsockopt(socket, SOL_SOCKET, SO_REUSEADDR, (char*)&value, sizeof(int));
                    socket_.socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, value);
                    break;

                case ENetSocketOption.ENET_SOCKOPT_RCVBUF:
                    //result = setsockopt(socket, SOL_SOCKET, SO_RCVBUF, (char*)&value, sizeof(int));
                    socket_.socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveBuffer, value);
                    break;

                case ENetSocketOption.ENET_SOCKOPT_SNDBUF:
                    //result = setsockopt(socket, SOL_SOCKET, SO_SNDBUF, (char*)&value, sizeof(int));
                    socket_.socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendBuffer, value);
                    break;

                case ENetSocketOption.ENET_SOCKOPT_RCVTIMEO:
                    //result = setsockopt(socket, SOL_SOCKET, SO_RCVTIMEO, (char*)&value, sizeof(int));
                    socket_.socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, value);
                    break;

                case ENetSocketOption.ENET_SOCKOPT_SNDTIMEO:
                    //result = setsockopt(socket, SOL_SOCKET, SO_SNDTIMEO, (char*)&value, sizeof(int));
                    socket_.socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, value);
                    break;

                case ENetSocketOption.ENET_SOCKOPT_NODELAY:
                    //result = setsockopt(socket, IPPROTO_TCP, TCP_NODELAY, (char*)&value, sizeof(int));
                    socket_.socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.NoDelay, value);
                    break;

                default:
                    break;
            }
            return result == ENet.SOCKET_ERROR ? -1 : 0;
        }

        public override int enet_socket_shutdown(ENetSocket socket, ENetSocketShutdown how)
        {
            ENetSocketDotNet socket_ = (ENetSocketDotNet)socket;
            return 0;
        }

        public override void enet_socket_destroy(ENetSocket socket)
        {
            ENetSocketDotNet socket_ = (ENetSocketDotNet)socket;
        }

        public override int ENET_HOST_TO_NET_16(int value)
        {
            return htons(value);
        }

        public override int ENET_HOST_TO_NET_32(int value)
        {
            return htonl(value);
        }

        public override int ENET_NET_TO_HOST_16(int value)
        {
            return ntohs((ushort)value);
        }

        public override int ENET_NET_TO_HOST_32(int value)
        {
            return ntohl(value);
        }

        //int htons(int value)
        //{
        //    return IPAddress.HostToNetworkOrder((short)value);
        //}

        [DllImport("Ws2_32.dll")]
        public static extern int htons(int netshort);

        int htonl(int value)
        {
            return IPAddress.HostToNetworkOrder((int)value);
        }

        //int ntohs(int value)
        //{
        //    return (ushort)IPAddress.NetworkToHostOrder((ushort)value);
        //}

        [DllImport("Ws2_32.dll")]
        public static extern ushort ntohs(ushort netshort);

        int ntohl(int value)
        {
            return IPAddress.NetworkToHostOrder((int)value);
        }

        int timeBase;

        public override int enet_time_get()
        {
            return (int)timeGetTime() - timeBase;
        }

        int timeGetTime()
        {
            return System.Environment.TickCount;
        }

        public override ENetOutgoingCommand CastToENetOutgoingCommand(ENetObject a)
        {
            return (ENetOutgoingCommand)a;
        }

        public override ENetIncomingCommand CastToENetIncomingCommand(ENetObject a)
        {
            return (ENetIncomingCommand)a;
        }

        public override ENetPeer CastToENetPeer(ENetListNode a)
        {
            return (ENetPeer)a;
        }

        public override ENetListNode CastToENetListNode(ENetObject a)
        {
            return (ENetListNode)a;
        }

        public override ENetAcknowledgement CastToENetAcknowledgement(ENetListNode a)
        {
            return (ENetAcknowledgement)a;
        }

        public override int enet_address_set_host(ENetAddress address, string hostName)
        {
            try
            {
                IPAddress[] addresses = Dns.GetHostAddresses(hostName);
                address.host = (int)addresses[0].Address;
                return 0;
            }
            catch
            {
                return -1;
            }
        }
    }

    public class ENetSocketDotNet : ENetSocket
    {
        public Socket socket;

        public override bool NULL()
        {
            return false;
        }
    }
}
