public abstract class ENetSocket
{
    public abstract bool NULL();
}

public class ENetBuffer
{
#if !CITO
    internal
#endif
 int dataLength;
#if !CITO
    internal
#endif
 byte[] data;
}

public class ENetSocketTypeEnum
{
    public const int ENET_SOCKET_TYPE_STREAM = 1;
    public const int ENET_SOCKET_TYPE_DATAGRAM = 2;
}

public class ENetSocketOption
{
    public const int ENET_SOCKOPT_NONBLOCK = 1;
    public const int ENET_SOCKOPT_BROADCAST = 2;
    public const int ENET_SOCKOPT_RCVBUF = 3;
    public const int ENET_SOCKOPT_SNDBUF = 4;
    public const int ENET_SOCKOPT_REUSEADDR = 5;
    public const int ENET_SOCKOPT_RCVTIMEO = 6;
    public const int ENET_SOCKOPT_SNDTIMEO = 7;
    public const int ENET_SOCKOPT_ERROR = 8;
    public const int ENET_SOCKOPT_NODELAY = 9;
}

public class ENetSocketShutdown
{
    public const int ENET_SOCKET_SHUTDOWN_READ = 0;
    public const int ENET_SOCKET_SHUTDOWN_WRITE = 1;
    public const int ENET_SOCKET_SHUTDOWN_READ_WRITE = 2;
}


//Portable internet address structure. 

//The host must be specified in network byte-order, and the port must be in host 
//byte-order. The constant ENET_HOST_ANY may be used to specify the default 
//server host. The constant ENET_HOST_BROADCAST may be used to specify the
//broadcast address (255.255.255.255).  This makes sense for enet_host_connect,
//but not for enet_host_create.  Once a server responds to a broadcast, the
//address is updated from ENET_HOST_BROADCAST to the server's actual IP address.

public class ENetAddress
{
#if !CITO
    internal
#endif
 int host;
#if !CITO
    internal
#endif
 int port;

    public static ENetAddress Clone(ENetAddress address)
    {
        ENetAddress other = new ENetAddress();
        other.host = address.host;
        other.port = address.port;
        return other;
    }
}

//Packet flag bit constants.

//The host must be specified in network byte-order, and the port must be in
//host byte-order. The constant ENET_HOST_ANY may be used to specify the
//default server host.

// @sa ENetPacket
public class ENetPacketFlagEnum
{
    // packet must be received by the target peer and resend attempts should be
    // made until the packet is delivered
    public const int ENET_PACKET_FLAG_RELIABLE = (1 << 0);
    // packet will not be sequenced with other packets
    // not supported for reliable packets
    public const int ENET_PACKET_FLAG_UNSEQUENCED = (1 << 1);
    // packet will not allocate data, and user must supply it instead
    public const int ENET_PACKET_FLAG_NO_ALLOCATE = (1 << 2);
    // packet will be fragmented using unreliable (instead of reliable) sends
    // if it exceeds the MTU
    public const int ENET_PACKET_FLAG_UNRELIABLE_FRAGMENT = (1 << 3);

    // whether the packet has been sent from all queues it has been entered into
    public const int ENET_PACKET_FLAG_SENT = (1 << 8);
}

public abstract class ENetPacketFreeCallback
{
    public abstract void Run(ENetPacket packet);
}


// ENet packet structure.
//
// An ENet data packet that may be sent to or received from a peer. The shown 
// fields should only be read and never modified. The data field contains the 
// allocated data for the packet. The dataLength fields specifies the length 
// of the allocated data.  The flags field is either 0 (specifying no flags), 
// or a bitwise-or of any combination of the following flags:
//
//    ENET_PACKET_FLAG_RELIABLE - packet must be received by the target peer
//    and resend attempts should be made until the packet is delivered
//
//    ENET_PACKET_FLAG_UNSEQUENCED - packet will not be sequenced with other packets 
//    (not supported for reliable packets)
//
//    ENET_PACKET_FLAG_NO_ALLOCATE - packet will not allocate data, and user must supply it instead
// @sa ENetPacketFlag
public class ENetPacket
{
#if !CITO
    internal
#endif
 int referenceCount;  ///< internal use only
#if !CITO
    internal
#endif
 int flags;           //< bitwise-or of ENetPacketFlag constants
#if !CITO
    internal
#endif
 byte[] data;            //< allocated data for packet
#if !CITO
    internal
#endif
 int dataLength;      //< length of data
#if !CITO
    internal
#endif
 ENetPacketFreeCallback freeCallback;    //< function to be called when the packet is no longer in use
#if !CITO
    internal
#endif
 UserData userData;        //< application private data, may be freely modified


    public int GetReferenceCount() { return referenceCount; } public void SetReferenceCount(int value) { referenceCount = value; }
    public int GetFlags() { return flags; } public void SetFlags(int value) { flags = value; }
    public byte[] GetData() { return data; } public void SetData(byte[] value) { data = value; }
    public int GetDataLength() { return dataLength; } public void SetDataLength(int value) { dataLength = value; }
    public ENetPacketFreeCallback GetFreeCallback() { return freeCallback; } public void SetFreeCallback(ENetPacketFreeCallback value) { freeCallback = value; }
    public UserData GetUserData() { return userData; } public void SetUserData(UserData value) { userData = value; }
}

public abstract class UserData
{
}

public class ENetAcknowledgement : ENetListNode
{
    public ENetListNode acknowledgementList() { return this; }
#if !CITO
    internal
#endif
 int sentTime;
#if !CITO
    internal
#endif
 ENetProtocol command;
}

public class ENetOutgoingCommand : ENetListNode
{
    //#if !CITO
    //    internal
    //#endif
    public ENetListNode outgoingCommandList() { return this; }
#if !CITO
    internal
#endif
 ushort reliableSequenceNumber;
#if !CITO
    internal
#endif
 ushort unreliableSequenceNumber;
#if !CITO
    internal
#endif
 int sentTime;
#if !CITO
    internal
#endif
 int roundTripTimeout;
#if !CITO
    internal
#endif
 int roundTripTimeoutLimit;
#if !CITO
    internal
#endif
 int fragmentOffset;
#if !CITO
    internal
#endif
 ushort fragmentLength;
#if !CITO
    internal
#endif
 ushort sendAttempts;
#if !CITO
    internal
#endif
 ENetProtocol command;
#if !CITO
    internal
#endif
 ENetPacket packet;
}

public class ENetIncomingCommand : ENetListNode
{
    public ENetListNode incomingCommandList() { return this; }
#if !CITO
    internal
#endif
 ushort reliableSequenceNumber;
#if !CITO
    internal
#endif
 ushort unreliableSequenceNumber;
#if !CITO
    internal
#endif
 ENetProtocol command;
#if !CITO
    internal
#endif
 int fragmentCount;
#if !CITO
    internal
#endif
 int fragmentsRemaining;
#if !CITO
    internal
#endif
 int[] fragments;
#if !CITO
    internal
#endif
 ENetPacket packet;
}

public class ENetPeerState
{
    public const int ENET_PEER_STATE_DISCONNECTED = 0;
    public const int ENET_PEER_STATE_CONNECTING = 1;
    public const int ENET_PEER_STATE_ACKNOWLEDGING_CONNECT = 2;
    public const int ENET_PEER_STATE_CONNECTION_PENDING = 3;
    public const int ENET_PEER_STATE_CONNECTION_SUCCEEDED = 4;
    public const int ENET_PEER_STATE_CONNECTED = 5;
    public const int ENET_PEER_STATE_DISCONNECT_LATER = 6;
    public const int ENET_PEER_STATE_DISCONNECTING = 7;
    public const int ENET_PEER_STATE_ACKNOWLEDGING_DISCONNECT = 8;
    public const int ENET_PEER_STATE_ZOMBIE = 9;
}

public class ENetChannel
{
    public ENetChannel()
    {
        reliableWindows = new int[ENet.ENET_PEER_RELIABLE_WINDOWS];
        incomingReliableCommands = new ENetList();
        incomingUnreliableCommands = new ENetList();
    }
#if !CITO
    internal
#endif
 ushort outgoingReliableSequenceNumber;
#if !CITO
    internal
#endif
 ushort outgoingUnreliableSequenceNumber;
#if !CITO
    internal
#endif
 int usedReliableWindows;
#if !CITO
    internal
#endif
 int[] reliableWindows;
    public const int reliableWindowsLength = ENet.ENET_PEER_RELIABLE_WINDOWS;
#if !CITO
    internal
#endif
 int incomingReliableSequenceNumber;
#if !CITO
    internal
#endif
 int incomingUnreliableSequenceNumber;
#if !CITO
    internal
#endif
 ENetList incomingReliableCommands;
#if !CITO
    internal
#endif
 ENetList incomingUnreliableCommands;
}


// An ENet peer which data packets may be sent or received from. 
//
// No fields should be modified unless otherwise specified. 
public class ENetPeer : ENetList
{
    public ENetPeer()
    {
        acknowledgements = new ENetList();
        sentReliableCommands = new ENetList();
        sentUnreliableCommands = new ENetList();
        outgoingReliableCommands = new ENetList();
        outgoingUnreliableCommands = new ENetList();
        dispatchedCommands = new ENetList();
        unsequencedWindow = new int[ENet.ENET_PEER_UNSEQUENCED_WINDOW_SIZE / 32];
    }
#if !CITO
    internal
#endif
 ENetListNode dispatchList() { return this; }
#if !CITO
    internal
#endif
 ENetHost host;
#if !CITO
    internal
#endif
 ushort outgoingPeerID;
#if !CITO
    internal
#endif
 ushort incomingPeerID;
#if !CITO
    internal
#endif
 int connectID;
#if !CITO
    internal
#endif
 byte outgoingSessionID;
#if !CITO
    internal
#endif
 byte incomingSessionID;
#if !CITO
    internal
#endif
 ENetAddress address;            //< Internet address of the peer
#if !CITO
    internal
#endif
 byte[] data;               //< Application private data, may be freely modified
#if !CITO
    internal
#endif
 int state;
#if !CITO
    internal
#endif
 ENetChannel[] channels;
#if !CITO
    internal
#endif
 int channelCount;       //< Number of channels allocated for communication with peer
#if !CITO
    internal
#endif
 int incomingBandwidth;  //< Downstream bandwidth of the client in bytes/second
#if !CITO
    internal
#endif
 int outgoingBandwidth;  //< Upstream bandwidth of the client in bytes/second
#if !CITO
    internal
#endif
 int incomingBandwidthThrottleEpoch;
#if !CITO
    internal
#endif
 int outgoingBandwidthThrottleEpoch;
#if !CITO
    internal
#endif
 int incomingDataTotal;
#if !CITO
    internal
#endif
 int outgoingDataTotal;
#if !CITO
    internal
#endif
 int lastSendTime;
#if !CITO
    internal
#endif
 int lastReceiveTime;
#if !CITO
    internal
#endif
 int nextTimeout;
#if !CITO
    internal
#endif
 int earliestTimeout;
#if !CITO
    internal
#endif
 int packetLossEpoch;
#if !CITO
    internal
#endif
 int packetsSent;
#if !CITO
    internal
#endif
 int packetsLost;
#if !CITO
    internal
#endif
 int packetLoss;          // < mean packet loss of reliable packets as a ratio with respect to the constant ENET_PEER_PACKET_LOSS_SCALE
#if !CITO
    internal
#endif
 int packetLossVariance;
#if !CITO
    internal
#endif
 int packetThrottle;
#if !CITO
    internal
#endif
 int packetThrottleLimit;
#if !CITO
    internal
#endif
 int packetThrottleCounter;
#if !CITO
    internal
#endif
 int packetThrottleEpoch;
#if !CITO
    internal
#endif
 int packetThrottleAcceleration;
#if !CITO
    internal
#endif
 int packetThrottleDeceleration;
#if !CITO
    internal
#endif
 int packetThrottleInterval;
#if !CITO
    internal
#endif
 int pingInterval;
#if !CITO
    internal
#endif
 int timeoutLimit;
#if !CITO
    internal
#endif
 int timeoutMinimum;
#if !CITO
    internal
#endif
 int timeoutMaximum;
#if !CITO
    internal
#endif
 int lastRoundTripTime;
#if !CITO
    internal
#endif
 int lowestRoundTripTime;
#if !CITO
    internal
#endif
 int lastRoundTripTimeVariance;
#if !CITO
    internal
#endif
 int highestRoundTripTimeVariance;
#if !CITO
    internal
#endif
 int roundTripTime;            // < mean round trip time (RTT), in milliseconds, between sending a reliable packet and receiving its acknowledgement
#if !CITO
    internal
#endif
 int roundTripTimeVariance;
#if !CITO
    internal
#endif
 int mtu;
#if !CITO
    internal
#endif
 int windowSize;
#if !CITO
    internal
#endif
 int reliableDataInTransit;

#if !CITO
    internal
#endif
 ushort outgoingReliableSequenceNumber;
#if !CITO
    internal
#endif
 ENetList acknowledgements;
#if !CITO
    internal
#endif
 ENetList sentReliableCommands;
#if !CITO
    internal
#endif
 ENetList sentUnreliableCommands;
#if !CITO
    internal
#endif
 ENetList outgoingReliableCommands;
#if !CITO
    internal
#endif
 ENetList outgoingUnreliableCommands;
#if !CITO
    internal
#endif
 ENetList dispatchedCommands;
#if !CITO
    internal
#endif
 int needsDispatch;
#if !CITO
    internal
#endif
 int incomingUnsequencedGroup;
#if !CITO
    internal
#endif
 ushort outgoingUnsequencedGroup;
#if !CITO
    internal
#endif
 int[] unsequencedWindow;// [Global.ENET_PEER_UNSEQUENCED_WINDOW_SIZE / 32]; 
    public const int unsequencedWindowLength = ENet.ENET_PEER_UNSEQUENCED_WINDOW_SIZE / 32;
#if !CITO
    internal
#endif
 int eventData;
}

public abstract class ENetCompressorContext
{
}

/// An ENet packet compressor for compressing UDP packets before socket sends or receives.
public abstract class ENetCompressor
{
    // Context data for the compressor. Must be non-NULL.
    //ENetCompressorContext context;
    /// Compresses from inBuffers[0:inBufferCount-1], containing inLimit bytes, to outData, outputting at most outLimit bytes. Should return 0 on failure.
    public abstract int compress(ENetBuffer inBuffers, int inBufferCount, int inLimit, byte[] outData, int outLimit);
    /// Decompresses from inData, containing inLimit bytes, to outData, outputting at most outLimit bytes. Should return 0 on failure.
    public abstract int decompress(byte[] inData, int inLimit, byte[] outData, int outLimit);
    /// Destroys the context when compression is disabled or the host is destroyed. May be NULL.
    public abstract void destroy();
}

public abstract class ENetChecksumCallback
{
    // Callback that computes the checksum of the data held in buffers[0:bufferCount-1]
    public abstract int Run(ENetBuffer buffers, int bufferCount);
}

public abstract class ENetInterceptCallback
{
    // Callback for intercepting received raw UDP packets. Should return 1 to intercept, 0 to ignore, or -1 to propagate an error.
    public abstract int Run(ENetHost host, ENetEvent event_);
}





// An ENet host for communicating with peers.
//
//No fields should be modified unless otherwise stated.

//   @sa enet_host_create()
//   @sa enet_host_destroy()
//   @sa enet_host_connect()
//   @sa enet_host_service()
//   @sa enet_host_flush()
//   @sa enet_host_broadcast()
//   @sa enet_host_compress()
//   @sa enet_host_compress_with_range_coder()
//   @sa enet_host_channel_limit()
//   @sa enet_host_bandwidth_limit()
//   @sa enet_host_bandwidth_throttle()

public class ENetHost
{
    public ENetHost()
    {
        address = new ENetAddress();
        commands = new ENetProtocol[commandsMaxCount];
        for (int i = 0; i < commandsMaxCount; i++)
        {
            commands[i] = new ENetProtocol();
        }
        buffers = new ENetBuffer[buffersMaxCount];
        for (int i = 0; i < buffersMaxCount; i++)
        {
            buffers[i] = new ENetBuffer();
        }
        for (int i = 0; i < buffersMaxCount; i++)
        {
            buffers[i] = new ENetBuffer();
        }
        dispatchQueue = new ENetPeer();
        packetData = new byte[2][];
        packetData[0] = new byte[ENet.ENET_PROTOCOL_MAXIMUM_MTU];
        packetData[1] = new byte[ENet.ENET_PROTOCOL_MAXIMUM_MTU];
    }
#if !CITO
    internal
#endif
 ENetSocket socket;
#if !CITO
    internal
#endif
 ENetAddress address;                     //< Internet address of the host 
#if !CITO
    internal
#endif
 int incomingBandwidth;           //< downstream bandwidth of the host 
#if !CITO
    internal
#endif
 int outgoingBandwidth;           //< upstream bandwidth of the host 
#if !CITO
    internal
#endif
 int bandwidthThrottleEpoch;
#if !CITO
    internal
#endif
 int mtu;
#if !CITO
    internal
#endif
 int randomSeed;
#if !CITO
    internal
#endif
 int recalculateBandwidthLimits;
#if !CITO
    internal
#endif
 ENetPeer[] peers;                       //< array of peers allocated for this host 
#if !CITO
    internal
#endif
 int peerCount;                   //< number of peers allocated for this host 
#if !CITO
    internal
#endif
 int channelLimit;                //< maximum number of channels allowed for connected peers 
#if !CITO
    internal
#endif
 int serviceTime;
#if !CITO
    internal
#endif
 ENetList dispatchQueue;
#if !CITO
    internal
#endif
 int continueSending;
#if !CITO
    internal
#endif
 int packetSize;
#if !CITO
    internal
#endif
 ushort headerFlags;
#if !CITO
    internal
#endif
 ENetProtocol[] commands; //[Global.ENET_PROTOCOL_MAXIMUM_PACKET_COMMANDS];
    public const int commandsMaxCount = ENet.ENET_PROTOCOL_MAXIMUM_PACKET_COMMANDS;
#if !CITO
    internal
#endif
 int commandCount;
#if !CITO
    internal
#endif
 ENetBuffer[] buffers; //[Global.ENET_BUFFER_MAXIMUM];
    public const int buffersMaxCount = ENet.ENET_BUFFER_MAXIMUM;
#if !CITO
    internal
#endif
 int bufferCount;
#if !CITO
    internal
#endif
 ENetChecksumCallback checksum;                    //< callback the user can set to enable packet checksums for this host 
#if !CITO
    internal
#endif
 ENetCompressor compressor;
#if !CITO
    internal
#endif
 byte[][] packetData;// [2][ENET_PROTOCOL_MAXIMUM_MTU];
    public const int packetData0SizeOf = ENet.ENET_PROTOCOL_MAXIMUM_MTU;
#if !CITO
    internal
#endif
 ENetAddress receivedAddress;
#if !CITO
    internal
#endif
 byte[] receivedData;
#if !CITO
    internal
#endif
 int receivedDataLength;
#if !CITO
    internal
#endif
 int totalSentData;               //< total data sent, user should reset to 0 as needed to prevent overflow 
#if !CITO
    internal
#endif
 int totalSentPackets;            //< total UDP packets sent, user should reset to 0 as needed to prevent overflow 
#if !CITO
    internal
#endif
 int totalReceivedData;           //< total data received, user should reset to 0 as needed to prevent overflow 
#if !CITO
    internal
#endif
 int totalReceivedPackets;        //< total UDP packets received, user should reset to 0 as needed to prevent overflow 
#if !CITO
    internal
#endif
 ENetInterceptCallback intercept;                  //< callback the user can set to intercept received raw UDP packets 
#if !CITO
    internal
#endif
 int connectedPeers;
#if !CITO
    internal
#endif
 int bandwidthLimitedPeers;
}


// An ENet event type, as specified in @ref ENetEvent.

public enum ENetEventType
{
    // no event occurred within the specified time limit
    ENET_EVENT_TYPE_NONE,

    // a connection request initiated by enet_host_connect has completed.  
    //The peer field contains the peer which successfully connected. 

    ENET_EVENT_TYPE_CONNECT,

    // a peer has disconnected.  This event is generated on a successful 
    // completion of a disconnect initiated by enet_pper_disconnect, if 
    // a peer has timed out, or if a connection request intialized by 
    // enet_host_connect has timed out.  The peer field contains the peer 
    // which disconnected. The data field contains user supplied data 
    // describing the disconnection, or 0, if none is available.

    ENET_EVENT_TYPE_DISCONNECT,

    // a packet has been received from a peer.  The peer field specifies the
    // peer which sent the packet.  The channelID field specifies the channel
    // number upon which the packet was received.  The packet field contains
    // the packet that was received; this packet must be destroyed with
    // enet_packet_destroy after use.

    ENET_EVENT_TYPE_RECEIVE
}

// An ENet event as returned by enet_host_service().

//  @sa enet_host_service
public class ENetEvent
{
#if !CITO
    internal
#endif
 ENetEventType type;      //< type of the event
#if !CITO
    internal
#endif
 ENetPeer peer;      //< peer that generated a connect, disconnect or receive event
#if !CITO
    internal
#endif
 byte channelID; //< channel on the peer that generated the event, if appropriate
#if !CITO
    internal
#endif
 int data;      //< data associated with the event, if appropriate
#if !CITO
    internal
#endif
 ENetPacket packet;    //< packet associated with the event, if appropriate
}

// @defgroup global ENet global functions
//    @{ 
//


//  Initializes ENet globally.  Must be called prior to using any functions in
//  ENet.
//  @returns 0 on success, < 0 on failure
//ENET_API int enet_initialize (void);


//  Initializes ENet globally and supplies user-overridden callbacks. Must be called prior to using any functions in ENet. Do not use enet_initialize() if you use this variant. Make sure the ENetCallbacks structure is zeroed out so that any additional callbacks added in future versions will be properly ignored.
//
//  @param version the constant ENET_VERSION should be supplied so ENet knows which version of ENetCallbacks struct to use
//  @param inits user-overriden callbacks where any NULL callbacks will use ENet's defaults
//  @returns 0 on success, < 0 on failure
//ENET_API int enet_initialize_with_callbacks (ENetVersion version, const ENetCallbacks * inits);


//  Shuts down ENet globally.  Should be called when a program that has
//  initialized ENet exits.
//ENET_API void enet_deinitialize (void);


//  Gives the linked version of the ENet library.
//  @returns the version number 
//ENET_API ENetVersion enet_linked_version (void);

// @}

// @defgroup private ENet private implementation functions


//  Returns the wall-time in milliseconds.  Its initial value is unspecified
//  unless otherwise set.
//ENET_API int enet_time_get (void);

//  Sets the current wall-time in milliseconds.
//ENET_API void enet_time_set (int);

// @defgroup socket ENet socket functions
//    @{
//ENET_API ENetSocket enet_socket_create (ENetSocketType);
//ENET_API int        enet_socket_bind (ENetSocket, const ENetAddress *);
//ENET_API int        enet_socket_get_address (ENetSocket, ENetAddress *);
//ENET_API int        enet_socket_listen (ENetSocket, int);
//ENET_API ENetSocket enet_socket_accept (ENetSocket, ENetAddress *);
//ENET_API int        enet_socket_connect (ENetSocket, const ENetAddress *);
//ENET_API int        enet_socket_send (ENetSocket, const ENetAddress *, const ENetBuffer *, int);
//ENET_API int        enet_socket_receive (ENetSocket, ENetAddress *, ENetBuffer *, int);
//ENET_API int        enet_socket_wait (ENetSocket, int *, int);
//ENET_API int        enet_socket_set_option (ENetSocket, ENetSocketOption, int);
//ENET_API int        enet_socket_shutdown (ENetSocket, ENetSocketShutdown);
//ENET_API void       enet_socket_destroy (ENetSocket);
//ENET_API int        enet_socketset_select (ENetSocket, ENetSocketSet *, ENetSocketSet *, int);

// @}

// @defgroup Address ENet address functions
//    @{
public class ENet
{
    ENetPlatform p;
    public void SetPlatform(ENetPlatform value) { p = value; }

    public ENet()
    {
        dummyCommand = new ENetIncomingCommand();
        commandSizes = new int[13];
        commandSizes[0] = 0;
        commandSizes[1] = 8;
        commandSizes[2] = 48;
        commandSizes[3] = 44;
        commandSizes[4] = 8;
        commandSizes[5] = 4;
        commandSizes[6] = 6;
        commandSizes[7] = 8;
        commandSizes[8] = 24;
        commandSizes[9] = 8;
        commandSizes[10] = 12;
        commandSizes[11] = 16;
        commandSizes[12] = 24;
    }






    public const int ENET_VERSION_MAJOR = 1;
    public const int ENET_VERSION_MINOR = 3;
    public const int ENET_VERSION_PATCH = 8;
    public static int ENET_VERSION_CREATE(int major, int minor, int patch) { return ((major) << 16) | ((minor) << 8) | (patch); }
    public static int ENET_VERSION_GET_MAJOR(int version) { return ((version) >> 16) & 0xFF; }
    public static int ENET_VERSION_GET_MINOR(int version) { return ((version) >> 8) & 0xFF; }
    public static int ENET_VERSION_GET_PATCH(int version) { return (version) & 0xFF; }
    public static int ENET_VERSION() { return ENET_VERSION_CREATE(ENET_VERSION_MAJOR, ENET_VERSION_MINOR, ENET_VERSION_PATCH); }

    public const int ENET_HOST_ANY = 0;            // < specifies the default server host
    public const int ENET_HOST_BROADCAST = -1; //0xFFFFFFFF;   // < specifies a subnet-wide broadcast

    public const int ENET_PORT_ANY = 0;             // < specifies that a port should be automatically chosen

    //#ifndef ENET_BUFFER_MAXIMUM
    public const int ENET_BUFFER_MAXIMUM = (1 + 2 * ENET_PROTOCOL_MAXIMUM_PACKET_COMMANDS);
    //#endif


    public const int ENET_HOST_RECEIVE_BUFFER_SIZE = 256 * 1024;
    public const int ENET_HOST_SEND_BUFFER_SIZE = 256 * 1024;
    public const int ENET_HOST_BANDWIDTH_THROTTLE_INTERVAL = 1000;
    public const int ENET_HOST_DEFAULT_MTU = 1400;


    public const int ENET_PEER_DEFAULT_ROUND_TRIP_TIME = 500;
    public const int ENET_PEER_DEFAULT_PACKET_THROTTLE = 32;
    public const int ENET_PEER_PACKET_THROTTLE_SCALE = 32;
    public const int ENET_PEER_PACKET_THROTTLE_COUNTER = 7;
    public const int ENET_PEER_PACKET_THROTTLE_ACCELERATION = 2;
    public const int ENET_PEER_PACKET_THROTTLE_DECELERATION = 2;
    public const int ENET_PEER_PACKET_THROTTLE_INTERVAL = 5000;
    public const int ENET_PEER_PACKET_LOSS_SCALE = (1 << 16);
    public const int ENET_PEER_PACKET_LOSS_INTERVAL = 10000;
    public const int ENET_PEER_WINDOW_SIZE_SCALE = 64 * 1024;
    public const int ENET_PEER_TIMEOUT_LIMIT = 32;
    public const int ENET_PEER_TIMEOUT_MINIMUM = 5000;
    public const int ENET_PEER_TIMEOUT_MAXIMUM = 30000;
    public const int ENET_PEER_PING_INTERVAL = 500;
    public const int ENET_PEER_UNSEQUENCED_WINDOWS = 64;
    public const int ENET_PEER_UNSEQUENCED_WINDOW_SIZE = 1024;
    public const int ENET_PEER_FREE_UNSEQUENCED_WINDOWS = 32;
    public const int ENET_PEER_RELIABLE_WINDOWS = 16;
    public const int ENET_PEER_RELIABLE_WINDOW_SIZE = 0x1000;
    public const int ENET_PEER_FREE_RELIABLE_WINDOWS = 8;

    public const int ENET_PROTOCOL_MINIMUM_MTU = 576;
    public const int ENET_PROTOCOL_MAXIMUM_MTU = 4096;
    public const int ENET_PROTOCOL_MAXIMUM_PACKET_COMMANDS = 32;
    public const int ENET_PROTOCOL_MINIMUM_WINDOW_SIZE = 4096;
    public const int ENET_PROTOCOL_MAXIMUM_WINDOW_SIZE = 32768;
    public const int ENET_PROTOCOL_MINIMUM_CHANNEL_COUNT = 1;
    public const int ENET_PROTOCOL_MAXIMUM_CHANNEL_COUNT = 255;
    public const int ENET_PROTOCOL_MAXIMUM_PEER_ID = 0xFFF;
    public const int ENET_PROTOCOL_MAXIMUM_PACKET_SIZE = 1024 * 1024 * 1024;
    public const int ENET_PROTOCOL_MAXIMUM_FRAGMENT_COUNT = 1024 * 1024;



    public const int ENET_PROTOCOL_COMMAND_NONE = 0;
    public const int ENET_PROTOCOL_COMMAND_ACKNOWLEDGE = 1;
    public const int ENET_PROTOCOL_COMMAND_CONNECT = 2;
    public const int ENET_PROTOCOL_COMMAND_VERIFY_CONNECT = 3;
    public const int ENET_PROTOCOL_COMMAND_DISCONNECT = 4;
    public const int ENET_PROTOCOL_COMMAND_PING = 5;
    public const int ENET_PROTOCOL_COMMAND_SEND_RELIABLE = 6;
    public const int ENET_PROTOCOL_COMMAND_SEND_UNRELIABLE = 7;
    public const int ENET_PROTOCOL_COMMAND_SEND_FRAGMENT = 8;
    public const int ENET_PROTOCOL_COMMAND_SEND_UNSEQUENCED = 9;
    public const int ENET_PROTOCOL_COMMAND_BANDWIDTH_LIMIT = 10;
    public const int ENET_PROTOCOL_COMMAND_THROTTLE_CONFIGURE = 11;
    public const int ENET_PROTOCOL_COMMAND_SEND_UNRELIABLE_FRAGMENT = 12;
    public const int ENET_PROTOCOL_COMMAND_COUNT = 13;
    public const int ENET_PROTOCOL_COMMAND_MASK = 15;




    public const int ENET_PROTOCOL_COMMAND_FLAG_ACKNOWLEDGE = (1 << 7);
    public const int ENET_PROTOCOL_COMMAND_FLAG_UNSEQUENCED = (1 << 6);

    public const int ENET_PROTOCOL_HEADER_FLAG_COMPRESSED = (1 << 14);
    public const int ENET_PROTOCOL_HEADER_FLAG_SENT_TIME = (1 << 15);
    public const int ENET_PROTOCOL_HEADER_FLAG_MASK = ENET_PROTOCOL_HEADER_FLAG_COMPRESSED | ENET_PROTOCOL_HEADER_FLAG_SENT_TIME;

    public const int ENET_PROTOCOL_HEADER_SESSION_MASK = (3 << 12);
    public const int ENET_PROTOCOL_HEADER_SESSION_SHIFT = 12;


    public const int ENET_SOCKET_WAIT_NONE = 0;
    public const int ENET_SOCKET_WAIT_SEND = (1 << 0);
    public const int ENET_SOCKET_WAIT_RECEIVE = (1 << 1);
    public const int ENET_SOCKET_WAIT_INTERRUPT = (1 << 2);

    // Attempts to resolve the host named by the parameter hostName and sets
    //    the host field in the address parameter if successful.
    //@param address destination to store resolved address
    //@param hostName host name to lookup
    //@retval 0 on success
    //@retval < 0 on failure
    //@returns the address of the given hostName in address on success
    public int enet_address_set_host(ENetAddress address, string hostName)
    {
        return p.enet_address_set_host(address, hostName);
    }

    // Gives the printable form of the ip address specified in the address parameter.
    //    @param address    address printed
    //    @param hostName   destination for name, must not be NULL
    //    @param nameLength maximum length of hostName.
    //@returns the null-terminated name of the host in hostName on success
    //@retval 0 on success
    //@retval < 0 on failure

    //ENET_API int enet_address_get_host_ip (const ENetAddress * address, char * hostName, int nameLength);

    // Attempts to do a reverse lookup of the host field in the address parameter.
    //@param address    address used for reverse lookup
    //@param hostName   destination for name, must not be NULL
    //@param nameLength maximum length of hostName.
    //@returns the null-terminated name of the host in hostName on success
    //@retval 0 on success
    //@retval < 0 on failure
    //ENET_API int enet_address_get_host (const ENetAddress * address, char * hostName, int nameLength);

    // @}

    /// Creates a packet that may be sent to a peer.
    ///  @returns the packet on success, NULL on failure
    public ENetPacket enet_packet_create(
        /// initial contents of the packet's data; the packet's data will remain uninitialized if dataContents is NULL.
        byte[] data,
        /// size of the data allocated for this packet
        int dataLength,
        /// flags for this packet as described for the ENetPacket structure.
        int flags)
    {
        ENetPacket packet = new ENetPacket();
        if (packet == null)
            return null;

        if ((flags & ENetPacketFlagEnum.ENET_PACKET_FLAG_NO_ALLOCATE) != 0)
            packet.data = data;
        else
            if (dataLength <= 0)
                packet.data = null;
            else
            {
                packet.data = new byte[dataLength];
                if (packet.data == null)
                {
#if CITO
                    delete packet;
#endif
                    return null;
                }

                if (data != null)
                {
                    for (int i = 0; i < dataLength; i++)
                    {
                        packet.data[i] = data[i];
                    }
                }
            }

        packet.referenceCount = 0;
        packet.flags = flags;
        packet.dataLength = dataLength;
        packet.freeCallback = null;
        packet.userData = null;

        return packet;
    }

    /// Destroys the packet and deallocates its data.
    public void
    enet_packet_destroy(
        /// packet to be destroyed
        ENetPacket packet)
    {
        if (packet == null)
            return;

        if (packet.freeCallback != null)
            packet.freeCallback.Run(packet);
#if CITO
        if (((packet.flags & ENetPacketFlagEnum.ENET_PACKET_FLAG_NO_ALLOCATE) == 0) &&
            packet.data != null)
        {
            delete packet.data;
        }
#endif
#if CITO
        delete packet;
#endif
    }

    // Attempts to resize the data in the packet to length specified in the 
    //dataLength parameter 
    //@param packet packet to resize
    //@param dataLength new size for the packet data
    //@returns 0 on success, < 0 on failure
    public int
    enet_packet_resize(ENetPacket packet, int dataLength)
    {
        byte[] newData;

        if (dataLength <= packet.dataLength || ((packet.flags & ENetPacketFlagEnum.ENET_PACKET_FLAG_NO_ALLOCATE) != 0))
        {
            packet.dataLength = dataLength;

            return 0;
        }

        newData = new byte[dataLength];
        if (newData == null)
            return -1;

        memcpy(newData, packet.data, packet.dataLength);
#if CITO
        delete packet.data;
#endif

        packet.data = newData;
        packet.dataLength = dataLength;

        return 0;
    }

    void memcpy(byte[] destination, byte[] source, int num)
    {
        for (int i = 0; i < num; i++)
        {
            destination[i] = source[i];
        }
    }

    bool initializedCRC32;
    int[] crcTable;// [256];

    static int
    reflect_crc(int val, int bits)
    {
        int result = 0;
        int bit;

        for (bit = 0; bit < bits; bit++)
        {
            if ((val & 1) != 0) result |= 1 << (bits - 1 - bit);
            val >>= 1;
        }

        return result;
    }

    void
    initialize_crc32()
    {
        crcTable = new int[256];
        int byte_;

        int c = -2147483647;// 0x80000000;
        c -= 1;

        for (byte_ = 0; byte_ < 256; byte_++)
        {
            int crc = reflect_crc(byte_, 8) << 24;
            int offset;

            for (offset = 0; offset < 8; offset++)
            {
                if ((crc & c) != 0)
                    crc = (crc << 1) ^ 0x04c11db7;
                else
                    crc <<= 1;
            }

            crcTable[byte_] = reflect_crc(crc, 32);
        }

        initializedCRC32 = true;
    }

    public int
enet_crc32(ENetBuffer[] buffers, int bufferCount)
    {
        int crc = -1; //0xFFFFFFFF;

        if (!initializedCRC32) initialize_crc32();
        for (int buf = 0; buf < bufferCount; buf++)
        {
            byte[] data = buffers[buf].data;
            int dataLength = buffers[buf].dataLength;

            //while (data < dataEnd)
            for (int i = 0; i < dataLength; i++)
            {
                crc = (crc >> 8) ^ crcTable[(crc & 0xFF) ^ data[i]];
            }
        }

        return p.ENET_HOST_TO_NET_32(~crc);
    }

    /// Creates a host for communicating to peers.  
    /// @remarks ENet will strategically drop packets on specific sides of a connection between hosts
    /// to ensure the host's bandwidth is not overwhelmed.  The bandwidth parameters also determine
    /// the window size of a connection which limits the amount of reliable packets that may be in transit
    /// at any given time.
    /// @returns the host on success and NULL on failure
    public ENetHost
    enet_host_create(
        /// the address at which other peers may connect to this host.  If NULL, then no peers may connect to the host.
        ENetAddress address,
        /// the maximum number of peers that should be allocated for the host.
        int peerCount,
        /// the maximum number of channels allowed; if 0, then this is equivalent to ENET_PROTOCOL_MAXIMUM_CHANNEL_COUNT
        int channelLimit,
        /// downstream bandwidth of the host in bytes/second; if 0, ENet will assume unlimited bandwidth.
        int incomingBandwidth,
        /// upstream bandwidth of the host in bytes/second; if 0, ENet will assume unlimited bandwidth.
        int outgoingBandwidth)
    {
        ENetHost host;
        ENetPeer currentPeer;

        if (peerCount > ENET_PROTOCOL_MAXIMUM_PEER_ID)
            return null;

        host = new ENetHost();
        if (host == null)
            return null;

        host.peers = new ENetPeer[peerCount];
        if (host.peers == null)
        {
#if CITO
       delete host;
#endif
            return null;
        }
        for (int i = 0; i < peerCount; i++)
        {
            host.peers[i] = new ENetPeer();
        }

        host.socket = p.enet_socket_create(ENetSocketTypeEnum.ENET_SOCKET_TYPE_DATAGRAM);
        if ((host.socket != null && host.socket.NULL()) || (address != null && p.enet_socket_bind(host.socket, address) < 0))
        {
            if (host.socket != null && (!host.socket.NULL()))
                p.enet_socket_destroy(host.socket);

#if CITO
       delete host.peers;
       delete host;
#endif

            return null;
        }

        p.enet_socket_set_option(host.socket, ENetSocketOption.ENET_SOCKOPT_NONBLOCK, 1);
        p.enet_socket_set_option(host.socket, ENetSocketOption.ENET_SOCKOPT_BROADCAST, 1);
        p.enet_socket_set_option(host.socket, ENetSocketOption.ENET_SOCKOPT_RCVBUF, ENET_HOST_RECEIVE_BUFFER_SIZE);
        p.enet_socket_set_option(host.socket, ENetSocketOption.ENET_SOCKOPT_SNDBUF, ENET_HOST_SEND_BUFFER_SIZE);

        if (address != null && p.enet_socket_get_address(host.socket, host.address) < 0)
            host.address = address;

        if ((channelLimit == 0) || channelLimit > ENET_PROTOCOL_MAXIMUM_CHANNEL_COUNT)
            channelLimit = ENET_PROTOCOL_MAXIMUM_CHANNEL_COUNT;
        else
            if (channelLimit < ENET_PROTOCOL_MINIMUM_CHANNEL_COUNT)
                channelLimit = ENET_PROTOCOL_MINIMUM_CHANNEL_COUNT;

        host.randomSeed = 0;// (enet_uint32)(size_t)host;
#if WIN32
    host . randomSeed += (enet_uint32) timeGetTime();
#else
        host.randomSeed += p.time();
#endif
        host.randomSeed = (host.randomSeed << 16) | (host.randomSeed >> 16);
        host.channelLimit = channelLimit;
        host.incomingBandwidth = incomingBandwidth;
        host.outgoingBandwidth = outgoingBandwidth;
        host.bandwidthThrottleEpoch = 0;
        host.recalculateBandwidthLimits = 0;
        host.mtu = ENET_HOST_DEFAULT_MTU;
        host.peerCount = peerCount;
        host.commandCount = 0;
        host.bufferCount = 0;
        host.checksum = null;
        host.receivedAddress = new ENetAddress();
        host.receivedAddress.host = ENET_HOST_ANY;
        host.receivedAddress.port = 0;
        host.receivedData = null;
        host.receivedDataLength = 0;

        host.totalSentData = 0;
        host.totalSentPackets = 0;
        host.totalReceivedData = 0;
        host.totalReceivedPackets = 0;

        host.connectedPeers = 0;
        host.bandwidthLimitedPeers = 0;

        host.compressor = null;

        host.intercept = null;
        host.dispatchQueue = new ENetPeer();
        host.dispatchQueue.SetSentinel(new ENetPeer());
        enet_list_clear(host.dispatchQueue);

        for (int i = 0; i < host.peerCount; i++)
        {
            currentPeer = host.peers[i];
            currentPeer.host = host;
            currentPeer.incomingPeerID = p.IntToUshort(i);
            currentPeer.outgoingSessionID = currentPeer.incomingSessionID = 0xFF;
            currentPeer.data = null;

            enet_list_clear(currentPeer.acknowledgements);
            enet_list_clear(currentPeer.sentReliableCommands);
            enet_list_clear(currentPeer.sentUnreliableCommands);
            enet_list_clear(currentPeer.outgoingReliableCommands);
            enet_list_clear(currentPeer.outgoingUnreliableCommands);
            enet_list_clear(currentPeer.dispatchedCommands);

            enet_peer_reset(currentPeer);
        }

        return host;
    }
    /// Destroys the host and all resources associated with it.
    public void
    enet_host_destroy(
        /// pointer to the host to destroy
        ENetHost host)
    {
        ENetPeer currentPeer;

        if (host == null)
            return;

        p.enet_socket_destroy(host.socket);

        for (int i = 0; i < host.peerCount; i++)
        {
            currentPeer = host.peers[i];
            enet_peer_reset(currentPeer);
        }

        if (host.compressor != null)
            host.compressor.destroy();

#if CITO
        delete host.peers;
        delete host;
#endif
    }
    /// Initiates a connection to a foreign host.
    /// @returns a peer representing the foreign host on success, NULL on failure
    /// @remarks The peer returned will have not completed the connection until enet_host_service()
    /// notifies of an ENET_EVENT_TYPE_CONNECT event for the peer.
    public ENetPeer
    enet_host_connect(
        /// host seeking the connection
        ENetHost host,
        /// destination for the connection
        ENetAddress address,
        /// number of channels to allocate
        int channelCount,
        /// user data supplied to the receiving host 
        int data)
    {
        ENetPeer currentPeer = null;
        ENetChannel channel;
        ENetProtocol command = new ENetProtocol();

        if (channelCount < ENET_PROTOCOL_MINIMUM_CHANNEL_COUNT)
            channelCount = ENET_PROTOCOL_MINIMUM_CHANNEL_COUNT;
        else
            if (channelCount > ENET_PROTOCOL_MAXIMUM_CHANNEL_COUNT)
                channelCount = ENET_PROTOCOL_MAXIMUM_CHANNEL_COUNT;

        for (int i = 0; i < host.peerCount; i++)
        {
            currentPeer = host.peers[i];
            if (currentPeer.state == ENetPeerState.ENET_PEER_STATE_DISCONNECTED)
                break;
        }

        //if (currentPeer >= host . peers [host . peerCount])
        //  return NULL;
        if (host.peerCount == 0)
        {
            return null;
        }

        currentPeer.channels = new ENetChannel[channelCount];
        for (int i = 0; i < channelCount; i++)
        {
            currentPeer.channels[i] = new ENetChannel();
        }
        if (currentPeer.channels == null)
            return null;
        currentPeer.channelCount = channelCount;
        currentPeer.state = ENetPeerState.ENET_PEER_STATE_CONNECTING;
        currentPeer.address = ENetAddress.Clone(address);
        currentPeer.connectID = ++host.randomSeed;

        if (host.outgoingBandwidth == 0)
            currentPeer.windowSize = ENET_PROTOCOL_MAXIMUM_WINDOW_SIZE;
        else
            currentPeer.windowSize = (host.outgoingBandwidth /
                                          ENET_PEER_WINDOW_SIZE_SCALE) *
                                            ENET_PROTOCOL_MINIMUM_WINDOW_SIZE;

        if (currentPeer.windowSize < ENET_PROTOCOL_MINIMUM_WINDOW_SIZE)
            currentPeer.windowSize = ENET_PROTOCOL_MINIMUM_WINDOW_SIZE;
        else
            if (currentPeer.windowSize > ENET_PROTOCOL_MAXIMUM_WINDOW_SIZE)
                currentPeer.windowSize = ENET_PROTOCOL_MAXIMUM_WINDOW_SIZE;

        for (int i = 0; i < channelCount; i++)
        {
            channel = currentPeer.channels[i];

            channel.outgoingReliableSequenceNumber = 0;
            channel.outgoingUnreliableSequenceNumber = 0;
            channel.incomingReliableSequenceNumber = 0;
            channel.incomingUnreliableSequenceNumber = 0;

            enet_list_clear(channel.incomingReliableCommands);
            enet_list_clear(channel.incomingUnreliableCommands);

            channel.usedReliableWindows = 0;
            for (int k = 0; k < ENET_PEER_RELIABLE_WINDOWS; k++)
            {
                channel.reliableWindows[k] = 0;
            }
        }

        command.header = new ENetProtocolCommandHeader();
        command.header.command = ENET_PROTOCOL_COMMAND_CONNECT | ENET_PROTOCOL_COMMAND_FLAG_ACKNOWLEDGE;
        command.header.channelID = 0xFF;
        command.connect = new ENetProtocolConnect();
        command.connect.outgoingPeerID = p.ENET_HOST_TO_NET_16(currentPeer.incomingPeerID);
        command.connect.incomingSessionID = currentPeer.incomingSessionID;
        command.connect.outgoingSessionID = currentPeer.outgoingSessionID;
        command.connect.mtu = p.ENET_HOST_TO_NET_32(currentPeer.mtu);
        command.connect.windowSize = p.ENET_HOST_TO_NET_32(currentPeer.windowSize);
        command.connect.channelCount = p.ENET_HOST_TO_NET_32(channelCount);
        command.connect.incomingBandwidth = p.ENET_HOST_TO_NET_32(host.incomingBandwidth);
        command.connect.outgoingBandwidth = p.ENET_HOST_TO_NET_32(host.outgoingBandwidth);
        command.connect.packetThrottleInterval = p.ENET_HOST_TO_NET_32(currentPeer.packetThrottleInterval);
        command.connect.packetThrottleAcceleration = p.ENET_HOST_TO_NET_32(currentPeer.packetThrottleAcceleration);
        command.connect.packetThrottleDeceleration = p.ENET_HOST_TO_NET_32(currentPeer.packetThrottleDeceleration);
        command.connect.connectID = currentPeer.connectID;
        command.connect.data = p.ENET_HOST_TO_NET_32(data);

        enet_peer_queue_outgoing_command(currentPeer, command, null, 0, 0);

        return currentPeer;
    }
    /// Queues a packet to be sent to all peers associated with the host.
    public void
    enet_host_broadcast(
        /// host on which to broadcast the packet
        ENetHost host,
        /// channel on which to broadcast
        byte channelID,
        /// packet to broadcast
        ENetPacket packet)
    {
        ENetPeer currentPeer;

        for (int i = 0; i < host.peerCount; i++)
        {
            currentPeer = host.peers[i];
            if (currentPeer.state != ENetPeerState.ENET_PEER_STATE_CONNECTED)
                continue;

            enet_peer_send(currentPeer, channelID, packet);
        }

        if (packet.referenceCount == 0)
            enet_packet_destroy(packet);
    }
    /// Sets the packet compressor the host should use to compress and decompress packets.
    public void
    enet_host_compress(
        /// host to enable or disable compression for
        ENetHost host,
        /// callbacks for for the packet compressor; if NULL, then compression is disabled
        ENetCompressor compressor)
    {
        if (host.compressor != null)
            host.compressor.destroy();

        if (compressor != null)
            host.compressor = compressor;
        else
            host.compressor = null;
    }

    /// Limits the maximum allowed channels of future incoming connections.
    public void
    enet_host_channel_limit(
        /// host to limit
        ENetHost host,
        /// the maximum number of channels allowed; if 0, then this is equivalent to ENET_PROTOCOL_MAXIMUM_CHANNEL_COUNT
        int channelLimit)
    {
        if ((channelLimit == 0) || channelLimit > ENET_PROTOCOL_MAXIMUM_CHANNEL_COUNT)
            channelLimit = ENET_PROTOCOL_MAXIMUM_CHANNEL_COUNT;
        else
            if (channelLimit < ENET_PROTOCOL_MINIMUM_CHANNEL_COUNT)
                channelLimit = ENET_PROTOCOL_MINIMUM_CHANNEL_COUNT;

        host.channelLimit = channelLimit;
    }

    /// Adjusts the bandwidth limits of a host.
    /// @remarks the incoming and outgoing bandwidth parameters are identical in function to those
    /// specified in enet_host_create().
    public void
    enet_host_bandwidth_limit(
        /// host to adjust
        ENetHost host,
        /// new incoming bandwidth
        int incomingBandwidth,
        /// new outgoing bandwidth
        int outgoingBandwidth)
    {
        host.incomingBandwidth = incomingBandwidth;
        host.outgoingBandwidth = outgoingBandwidth;
        host.recalculateBandwidthLimits = 1;
    }

    void enet_host_bandwidth_throttle(ENetHost host)
    {
        int timeCurrent = p.enet_time_get();
        int elapsedTime = timeCurrent - host.bandwidthThrottleEpoch;
        int peersRemaining = host.connectedPeers;
        int dataTotal = ~0;
        int bandwidth = ~0;
        int throttle = 0;
        int bandwidthLimit = 0;
        int needsAdjustment = host.bandwidthLimitedPeers > 0 ? 1 : 0;
        ENetPeer peer;
        ENetProtocol command = new ENetProtocol();

        if (elapsedTime < ENET_HOST_BANDWIDTH_THROTTLE_INTERVAL)
            return;

        host.bandwidthThrottleEpoch = timeCurrent;

        if (peersRemaining == 0)
            return;

        if (host.outgoingBandwidth != 0)
        {
            dataTotal = 0;
            bandwidth = (host.outgoingBandwidth * elapsedTime) / 1000;

            for (int i = 0; i < host.peerCount; i++)
            {
                peer = host.peers[i];
                if (peer.state != ENetPeerState.ENET_PEER_STATE_CONNECTED && peer.state != ENetPeerState.ENET_PEER_STATE_DISCONNECT_LATER)
                    continue;

                dataTotal += peer.outgoingDataTotal;
            }
        }

        while (peersRemaining > 0 && needsAdjustment != 0)
        {
            needsAdjustment = 0;

            if (dataTotal <= bandwidth)
                throttle = ENET_PEER_PACKET_THROTTLE_SCALE;
            else
                throttle = (bandwidth * ENET_PEER_PACKET_THROTTLE_SCALE) / dataTotal;

            for (int i = 0; i < host.peerCount; i++)
            {
                peer = host.peers[i];
                int peerBandwidth;

                if ((peer.state != ENetPeerState.ENET_PEER_STATE_CONNECTED && peer.state != ENetPeerState.ENET_PEER_STATE_DISCONNECT_LATER) ||
                    peer.incomingBandwidth == 0 ||
                    peer.outgoingBandwidthThrottleEpoch == timeCurrent)
                    continue;

                peerBandwidth = (peer.incomingBandwidth * elapsedTime) / 1000;
                if ((throttle * peer.outgoingDataTotal) / ENET_PEER_PACKET_THROTTLE_SCALE <= peerBandwidth)
                    continue;

                peer.packetThrottleLimit = (peerBandwidth *
                                             ENET_PEER_PACKET_THROTTLE_SCALE) / peer.outgoingDataTotal;

                if (peer.packetThrottleLimit == 0)
                    peer.packetThrottleLimit = 1;

                if (peer.packetThrottle > peer.packetThrottleLimit)
                    peer.packetThrottle = peer.packetThrottleLimit;

                peer.outgoingBandwidthThrottleEpoch = timeCurrent;

                peer.incomingDataTotal = 0;
                peer.outgoingDataTotal = 0;

                needsAdjustment = 1;
                peersRemaining--;
                bandwidth -= peerBandwidth;
                dataTotal -= peerBandwidth;
            }
        }

        if (peersRemaining > 0)
        {
            if (dataTotal <= bandwidth)
                throttle = ENET_PEER_PACKET_THROTTLE_SCALE;
            else
                throttle = (bandwidth * ENET_PEER_PACKET_THROTTLE_SCALE) / dataTotal;

            for (int i = 0; i < host.peerCount; i++)
            {
                peer = host.peers[i];
                if ((peer.state != ENetPeerState.ENET_PEER_STATE_CONNECTED && peer.state != ENetPeerState.ENET_PEER_STATE_DISCONNECT_LATER) ||
                    peer.outgoingBandwidthThrottleEpoch == timeCurrent)
                    continue;

                peer.packetThrottleLimit = throttle;

                if (peer.packetThrottle > peer.packetThrottleLimit)
                    peer.packetThrottle = peer.packetThrottleLimit;

                peer.incomingDataTotal = 0;
                peer.outgoingDataTotal = 0;
            }
        }

        if (host.recalculateBandwidthLimits != 0)
        {
            host.recalculateBandwidthLimits = 0;

            peersRemaining = host.connectedPeers;
            bandwidth = host.incomingBandwidth;
            needsAdjustment = 1;

            if (bandwidth == 0)
                bandwidthLimit = 0;
            else
                while (peersRemaining > 0 && needsAdjustment != 0)
                {
                    needsAdjustment = 0;
                    bandwidthLimit = bandwidth / peersRemaining;

                    for (int i = 0; i < host.peerCount; i++)
                    {
                        peer = host.peers[i];
                        if ((peer.state != ENetPeerState.ENET_PEER_STATE_CONNECTED && peer.state != ENetPeerState.ENET_PEER_STATE_DISCONNECT_LATER) ||
                            peer.incomingBandwidthThrottleEpoch == timeCurrent)
                            continue;

                        if (peer.outgoingBandwidth > 0 &&
                            peer.outgoingBandwidth >= bandwidthLimit)
                            continue;

                        peer.incomingBandwidthThrottleEpoch = timeCurrent;

                        needsAdjustment = 1;
                        peersRemaining--;
                        bandwidth -= peer.outgoingBandwidth;
                    }
                }

            for (int i = 0; i < host.peerCount; i++)
            {
                peer = host.peers[i];
                if (peer.state != ENetPeerState.ENET_PEER_STATE_CONNECTED && peer.state != ENetPeerState.ENET_PEER_STATE_DISCONNECT_LATER)
                    continue;

                command.header.command = ENET_PROTOCOL_COMMAND_BANDWIDTH_LIMIT | ENET_PROTOCOL_COMMAND_FLAG_ACKNOWLEDGE;
                command.header.channelID = 0xFF;
                command.bandwidthLimit = new ENetProtocolBandwidthLimit();
                command.bandwidthLimit.outgoingBandwidth = p.ENET_HOST_TO_NET_32(host.outgoingBandwidth);

                if (peer.incomingBandwidthThrottleEpoch == timeCurrent)
                    command.bandwidthLimit.incomingBandwidth = p.ENET_HOST_TO_NET_32(peer.outgoingBandwidth);
                else
                    command.bandwidthLimit.incomingBandwidth = p.ENET_HOST_TO_NET_32(bandwidthLimit);

                enet_peer_queue_outgoing_command(peer, command, null, 0, 0);
            }
        }
    }



























    /// @defgroup peer ENet peer functions 
    //@{

    /// Configures throttle parameter for a peer.
    ///Unreliable packets are dropped by ENet in response to the varying conditions
    ///of the Internet connection to the peer.  The throttle represents a probability
    ///that an unreliable packet should not be dropped and thus sent by ENet to the peer.
    ///The lowest mean round trip time from the sending of a reliable packet to the
    ///receipt of its acknowledgement is measured over an amount of time specified by
    ///the interval parameter in milliseconds.  If a measured round trip time happens to
    ///be significantly less than the mean round trip time measured over the interval, 
    ///then the throttle probability is increased to allow more traffic by an amount
    ///specified in the acceleration parameter, which is a ratio to the ENET_PEER_PACKET_THROTTLE_SCALE
    ///constant.  If a measured round trip time happens to be significantly greater than
    ///the mean round trip time measured over the interval, then the throttle probability
    ///is decreased to limit traffic by an amount specified in the deceleration parameter, which
    ///is a ratio to the ENET_PEER_PACKET_THROTTLE_SCALE constant.  When the throttle has
    ///a value of ENET_PEER_PACKET_THROTTLE_SCALE, no unreliable packets are dropped by 
    ///ENet, and so 100% of all unreliable packets will be sent.  When the throttle has a
    ///value of 0, all unreliable packets are dropped by ENet, and so 0% of all unreliable
    ///packets will be sent.  Intermediate values for the throttle represent intermediate
    ///probabilities between 0% and 100% of unreliable packets being sent.  The bandwidth
    ///limits of the local and foreign hosts are taken into account to determine a 
    ///sensible limit for the throttle probability above which it should not raise even in
    ///the best of conditions.
    public void
    enet_peer_throttle_configure(
        /// peer to configure 
        ENetPeer peer,
        /// interval, in milliseconds, over which to measure lowest mean RTT; the default value is ENET_PEER_PACKET_THROTTLE_INTERVAL.
        int interval,
        /// rate at which to increase the throttle probability as mean RTT declines
        int acceleration,
        /// rate at which to decrease the throttle probability as mean RTT increases
        int deceleration)
    {
        ENetProtocol command = new ENetProtocol();

        peer.packetThrottleInterval = interval;
        peer.packetThrottleAcceleration = acceleration;
        peer.packetThrottleDeceleration = deceleration;

        command.header.command = ENET_PROTOCOL_COMMAND_THROTTLE_CONFIGURE | ENET_PROTOCOL_COMMAND_FLAG_ACKNOWLEDGE;
        command.header.channelID = 0xFF;

        command.throttleConfigure.packetThrottleInterval = p.ENET_HOST_TO_NET_32(interval);
        command.throttleConfigure.packetThrottleAcceleration = p.ENET_HOST_TO_NET_32(acceleration);
        command.throttleConfigure.packetThrottleDeceleration = p.ENET_HOST_TO_NET_32(deceleration);

        enet_peer_queue_outgoing_command(peer, command, null, 0, 0);
    }

    int
enet_peer_throttle(ENetPeer peer, int rtt)
    {
        if (peer.lastRoundTripTime <= peer.lastRoundTripTimeVariance)
        {
            peer.packetThrottle = peer.packetThrottleLimit;
        }
        else
            if (rtt < peer.lastRoundTripTime)
            {
                peer.packetThrottle += peer.packetThrottleAcceleration;

                if (peer.packetThrottle > peer.packetThrottleLimit)
                    peer.packetThrottle = peer.packetThrottleLimit;

                return 1;
            }
            else
                if (rtt > peer.lastRoundTripTime + 2 * peer.lastRoundTripTimeVariance)
                {
                    if (peer.packetThrottle > peer.packetThrottleDeceleration)
                        peer.packetThrottle -= peer.packetThrottleDeceleration;
                    else
                        peer.packetThrottle = 0;

                    return -1;
                }

        return 0;
    }

    /// Queues a packet to be sent.
    ///@retval 0 on success
    ///@retval < 0 on failure
    public int enet_peer_send(
        /// destination for the packet
        ENetPeer peer,
        /// channel on which to send
        byte channelID,
        /// packet to send
        ENetPacket packet)
    {
        ENetChannel channel = peer.channels[channelID];
        ENetProtocol command = new ENetProtocol();
        int fragmentLength;

        if (peer.state != ENetPeerState.ENET_PEER_STATE_CONNECTED ||
            channelID >= peer.channelCount ||
            packet.dataLength > ENET_PROTOCOL_MAXIMUM_PACKET_SIZE)
            return -1;

        fragmentLength = peer.mtu - ENetProtocolHeader.SizeOf - ENetProtocolSendFragment.SizeOf;
        if (peer.host.checksum != null)
            fragmentLength -= 4;

        if (packet.dataLength > fragmentLength)
        {
            int fragmentCount = (packet.dataLength + fragmentLength - 1) / fragmentLength;
            int fragmentNumber;
            int fragmentOffset;
            byte commandNumber;
            ushort startSequenceNumber;
            ENetList fragments = null;
            ENetOutgoingCommand fragment;

            if (fragmentCount > ENET_PROTOCOL_MAXIMUM_FRAGMENT_COUNT)
                return -1;

            if ((packet.flags & (ENetPacketFlagEnum.ENET_PACKET_FLAG_RELIABLE | ENetPacketFlagEnum.ENET_PACKET_FLAG_UNRELIABLE_FRAGMENT)) == ENetPacketFlagEnum.ENET_PACKET_FLAG_UNRELIABLE_FRAGMENT &&
                channel.outgoingUnreliableSequenceNumber < 0xFFFF)
            {
                commandNumber = ENET_PROTOCOL_COMMAND_SEND_UNRELIABLE_FRAGMENT;
                startSequenceNumber = p.ENET_HOST_TO_NET_16(p.IntToUshort(channel.outgoingUnreliableSequenceNumber + 1));
            }
            else
            {
                commandNumber = ENET_PROTOCOL_COMMAND_SEND_FRAGMENT | ENET_PROTOCOL_COMMAND_FLAG_ACKNOWLEDGE;
                startSequenceNumber = p.ENET_HOST_TO_NET_16(p.IntToUshort(channel.outgoingReliableSequenceNumber + 1));
            }

            enet_list_clear(fragments);

            fragmentNumber = 0;
            fragmentOffset = 0;
            while (
                 fragmentOffset < packet.dataLength
                 )
            {
                if (packet.dataLength - fragmentOffset < fragmentLength)
                    fragmentLength = packet.dataLength - fragmentOffset;

                fragment = new ENetOutgoingCommand();
                if (fragment == null)
                {
                    while (!enet_list_empty(fragments))
                    {
                        fragment = p.CastToENetOutgoingCommand(enet_list_remove(enet_list_begin(fragments)).data);
#if CITO
                        delete fragment;
#endif
                    }

                    return -1;
                }

                fragment.fragmentOffset = fragmentOffset;
                fragment.fragmentLength = p.IntToUshort(fragmentLength);
                fragment.packet = packet;
                fragment.command.header.command = commandNumber;
                fragment.command.header.channelID = channelID;
                fragment.command.sendFragment.startSequenceNumber = startSequenceNumber;
                fragment.command.sendFragment.dataLength = p.ENET_HOST_TO_NET_16(p.IntToUshort(fragmentLength));
                fragment.command.sendFragment.fragmentCount = p.ENET_HOST_TO_NET_32(fragmentCount);
                fragment.command.sendFragment.fragmentNumber = p.ENET_HOST_TO_NET_32(fragmentNumber);
                fragment.command.sendFragment.totalLength = p.ENET_HOST_TO_NET_32(packet.dataLength);
                fragment.command.sendFragment.fragmentOffset = p.ENET_NET_TO_HOST_32(fragmentOffset);

                enet_list_insert(enet_list_end(fragments), fragment);

                fragmentNumber++;
                fragmentOffset += fragmentLength;
            }

            packet.referenceCount += fragmentNumber;

            while (!enet_list_empty(fragments))
            {
                fragment = p.CastToENetOutgoingCommand(enet_list_remove(enet_list_begin(fragments)));

                enet_peer_setup_outgoing_command(peer, fragment);
            }

            return 0;
        }

        command.header.channelID = channelID;

        if ((packet.flags & (ENetPacketFlagEnum.ENET_PACKET_FLAG_RELIABLE | ENetPacketFlagEnum.ENET_PACKET_FLAG_UNSEQUENCED)) == ENetPacketFlagEnum.ENET_PACKET_FLAG_UNSEQUENCED)
        {
            command.header.command = ENET_PROTOCOL_COMMAND_SEND_UNSEQUENCED | ENET_PROTOCOL_COMMAND_FLAG_UNSEQUENCED;
            command.sendUnsequenced.dataLength = p.ENET_HOST_TO_NET_16(p.IntToUshort(packet.dataLength));
        }
        else
            if (((packet.flags & ENetPacketFlagEnum.ENET_PACKET_FLAG_RELIABLE) != 0) || channel.outgoingUnreliableSequenceNumber >= 0xFFFF)
            {
                command.header.command = ENET_PROTOCOL_COMMAND_SEND_RELIABLE | ENET_PROTOCOL_COMMAND_FLAG_ACKNOWLEDGE;
                command.sendReliable = new ENetProtocolSendReliable();
                command.sendReliable.dataLength = p.ENET_HOST_TO_NET_16(p.IntToUshort(packet.dataLength));
            }
            else
            {
                command.header.command = ENET_PROTOCOL_COMMAND_SEND_UNRELIABLE;
                command.sendUnreliable = new ENetProtocolSendUnreliable();
                command.sendUnreliable.dataLength = p.ENET_HOST_TO_NET_16(p.IntToUshort(packet.dataLength));
            }

        if (enet_peer_queue_outgoing_command(peer, command, packet, 0, p.IntToUshort(packet.dataLength)) == null)
            return -1;

        return 0;
    }

    /// Attempts to dequeue any incoming queued packet.
    ///@returns a pointer to the packet, or NULL if there are no available incoming queued packets
    public ENetPacket enet_peer_receive(
        /// peer to dequeue packets from
        ENetPeer peer,
        /// holds the channel ID of the channel the packet was received on success
        Byte channelID)
    {
        ENetIncomingCommand incomingCommand;
        ENetPacket packet;

        if (enet_list_empty(peer.dispatchedCommands))
            return null;

        incomingCommand = p.CastToENetIncomingCommand(enet_list_remove(enet_list_begin(peer.dispatchedCommands)));

        if (channelID != null)
            channelID.value = incomingCommand.command.header.channelID;

        packet = incomingCommand.packet;

        packet.referenceCount--;

        if (incomingCommand.fragments != null)
        {
#if CITO
            delete incomingCommand.fragments;
#endif
        }
#if CITO
        delete incomingCommand;
#endif

        return packet;
    }

    public void enet_peer_reset_outgoing_commands(ENetList queue)
    {
        ENetOutgoingCommand outgoingCommand;

        while (!enet_list_empty(queue))
        {
            outgoingCommand = p.CastToENetOutgoingCommand(enet_list_remove(enet_list_begin(queue)));

            if (outgoingCommand.packet != null)
            {
                outgoingCommand.packet.referenceCount--;

                if (outgoingCommand.packet.referenceCount == 0)
                    enet_packet_destroy(outgoingCommand.packet);
            }
#if CITO
            delete outgoingCommand;
#endif
        }
    }

    public void enet_peer_remove_incoming_commands(ENetList queue, ENetListNode startCommand, ENetListNode endCommand)
    {
        ENetListNode currentCommand;

        for (currentCommand = startCommand; currentCommand != endCommand; )
        {
            ENetIncomingCommand incomingCommand = p.CastToENetIncomingCommand(currentCommand);

            currentCommand = enet_list_next(currentCommand);

            enet_list_remove(incomingCommand.incomingCommandList());

            if (incomingCommand.packet != null)
            {
                incomingCommand.packet.referenceCount--;

                if (incomingCommand.packet.referenceCount == 0)
                    enet_packet_destroy(incomingCommand.packet);
            }

            if (incomingCommand.fragments != null)
            {
#if CITO
                delete incomingCommand.fragments;
#endif
            }
#if CITO
            delete incomingCommand;
#endif
        }
    }

    public void
enet_peer_reset_incoming_commands(ENetList queue)
    {
        enet_peer_remove_incoming_commands(queue, enet_list_begin(queue), enet_list_end(queue));
    }

    public void
     enet_peer_reset_queues(ENetPeer peer)
    {
        ENetChannel channel;

        if (peer.needsDispatch != 0)
        {
            enet_list_remove(peer.dispatchList());

            peer.needsDispatch = 0;
        }

        while (!enet_list_empty(peer.acknowledgements))
        {
            ENetListNode n = enet_list_remove(enet_list_begin(peer.acknowledgements));
#if CITO
            delete n;
#endif
        }

        enet_peer_reset_outgoing_commands(peer.sentReliableCommands);
        enet_peer_reset_outgoing_commands(peer.sentUnreliableCommands);
        enet_peer_reset_outgoing_commands(peer.outgoingReliableCommands);
        enet_peer_reset_outgoing_commands(peer.outgoingUnreliableCommands);
        enet_peer_reset_incoming_commands(peer.dispatchedCommands);

        if (peer.channels != null && peer.channelCount > 0)
        {
            for (int i = 0; i < peer.channelCount; i++)
            {
                channel = peer.channels[i];
                enet_peer_reset_incoming_commands(channel.incomingReliableCommands);
                enet_peer_reset_incoming_commands(channel.incomingUnreliableCommands);
            }
#if CITO
            delete peer.channels;
#endif
        }

        peer.channels = null;
        peer.channelCount = 0;
    }

    void
enet_peer_on_connect(ENetPeer peer)
    {
        if (peer.state != ENetPeerState.ENET_PEER_STATE_CONNECTED && peer.state != ENetPeerState.ENET_PEER_STATE_DISCONNECT_LATER)
        {
            if (peer.incomingBandwidth != 0)
                peer.host.bandwidthLimitedPeers++;

            peer.host.connectedPeers++;
        }
    }

    void
    enet_peer_on_disconnect(ENetPeer peer)
    {
        if (peer.state == ENetPeerState.ENET_PEER_STATE_CONNECTED || peer.state == ENetPeerState.ENET_PEER_STATE_DISCONNECT_LATER)
        {
            if (peer.incomingBandwidth != 0)
                peer.host.bandwidthLimitedPeers--;

            peer.host.connectedPeers--;
        }
    }

    /// Forcefully disconnects a peer.
    /// The foreign host represented by the peer is not notified of the disconnection and will timeout
    /// on its connection to the local host.
    public void
    enet_peer_reset(
        /// peer to forcefully disconnect
        ENetPeer peer)
    {
        enet_peer_on_disconnect(peer);

        peer.outgoingPeerID = ENET_PROTOCOL_MAXIMUM_PEER_ID;
        peer.connectID = 0;

        peer.state = ENetPeerState.ENET_PEER_STATE_DISCONNECTED;

        peer.incomingBandwidth = 0;
        peer.outgoingBandwidth = 0;
        peer.incomingBandwidthThrottleEpoch = 0;
        peer.outgoingBandwidthThrottleEpoch = 0;
        peer.incomingDataTotal = 0;
        peer.outgoingDataTotal = 0;
        peer.lastSendTime = 0;
        peer.lastReceiveTime = 0;
        peer.nextTimeout = 0;
        peer.earliestTimeout = 0;
        peer.packetLossEpoch = 0;
        peer.packetsSent = 0;
        peer.packetsLost = 0;
        peer.packetLoss = 0;
        peer.packetLossVariance = 0;
        peer.packetThrottle = ENET_PEER_DEFAULT_PACKET_THROTTLE;
        peer.packetThrottleLimit = ENET_PEER_PACKET_THROTTLE_SCALE;
        peer.packetThrottleCounter = 0;
        peer.packetThrottleEpoch = 0;
        peer.packetThrottleAcceleration = ENET_PEER_PACKET_THROTTLE_ACCELERATION;
        peer.packetThrottleDeceleration = ENET_PEER_PACKET_THROTTLE_DECELERATION;
        peer.packetThrottleInterval = ENET_PEER_PACKET_THROTTLE_INTERVAL;
        peer.pingInterval = ENET_PEER_PING_INTERVAL;
        peer.timeoutLimit = ENET_PEER_TIMEOUT_LIMIT;
        peer.timeoutMinimum = ENET_PEER_TIMEOUT_MINIMUM;
        peer.timeoutMaximum = ENET_PEER_TIMEOUT_MAXIMUM;
        peer.lastRoundTripTime = ENET_PEER_DEFAULT_ROUND_TRIP_TIME;
        peer.lowestRoundTripTime = ENET_PEER_DEFAULT_ROUND_TRIP_TIME;
        peer.lastRoundTripTimeVariance = 0;
        peer.highestRoundTripTimeVariance = 0;
        peer.roundTripTime = ENET_PEER_DEFAULT_ROUND_TRIP_TIME;
        peer.roundTripTimeVariance = 0;
        peer.mtu = peer.host.mtu;
        peer.reliableDataInTransit = 0;
        peer.outgoingReliableSequenceNumber = 0;
        peer.windowSize = ENET_PROTOCOL_MAXIMUM_WINDOW_SIZE;
        peer.incomingUnsequencedGroup = 0;
        peer.outgoingUnsequencedGroup = 0;
        peer.eventData = 0;

        for (int i = 0; i < ENetPeer.unsequencedWindowLength; i++)
        {
            peer.unsequencedWindow[i] = 0;
        }

        enet_peer_reset_queues(peer);
    }

    /// Sends a ping request to a peer.
    /// ping requests factor into the mean round trip time as designated by the 
    /// roundTripTime field in the ENetPeer structure.  Enet automatically pings all connected
    /// peers at regular intervals, however, this function may be called to ensure more
    /// frequent ping requests.
    public void
    enet_peer_ping(
        /// destination for the ping request
        ENetPeer peer)
    {
        ENetProtocol command = new ENetProtocol();

        if (peer.state != ENetPeerState.ENET_PEER_STATE_CONNECTED)
            return;

        command.header.command = ENET_PROTOCOL_COMMAND_PING | ENET_PROTOCOL_COMMAND_FLAG_ACKNOWLEDGE;
        command.header.channelID = 0xFF;

        enet_peer_queue_outgoing_command(peer, command, null, 0, 0);
    }

    /// Sets the interval at which pings will be sent to a peer. 
    ///    Pings are used both to monitor the liveness of the connection and also to dynamically
    ///    adjust the throttle during periods of low traffic so that the throttle has reasonable
    ///    responsiveness during traffic spikes.
    public void
    enet_peer_ping_interval(
        /// the peer to adjust
        ENetPeer peer,
        /// the interval at which to send pings; defaults to ENET_PEER_PING_INTERVAL if 0
        int pingInterval)
    {
        peer.pingInterval = (pingInterval != 0) ? pingInterval : ENET_PEER_PING_INTERVAL;
    }

    /// Sets the timeout parameters for a peer.
    ///    The timeout parameter control how and when a peer will timeout from a failure to acknowledge
    ///    reliable traffic. Timeout values use an exponential backoff mechanism, where if a reliable
    ///    packet is not acknowledge within some multiple of the average RTT plus a variance tolerance, 
    ///    the timeout will be doubled until it reaches a set limit. If the timeout is thus at this
    ///    limit and reliable packets have been sent but not acknowledged within a certain minimum time 
    ///    period, the peer will be disconnected. Alternatively, if reliable packets have been sent
    ///    but not acknowledged for a certain maximum time period, the peer will be disconnected regardless
    ///    of the current timeout limit value.
    public void
    enet_peer_timeout(
        /// the peer to adjust
        ENetPeer peer,
        /// the timeout limit; defaults to ENET_PEER_TIMEOUT_LIMIT if 0
        int timeoutLimit,
        /// the timeout minimum; defaults to ENET_PEER_TIMEOUT_MINIMUM if 0
        int timeoutMinimum,
        /// the timeout maximum; defaults to ENET_PEER_TIMEOUT_MAXIMUM if 0
        int timeoutMaximum)
    {
        peer.timeoutLimit = (timeoutLimit != 0) ? timeoutLimit : ENET_PEER_TIMEOUT_LIMIT;
        peer.timeoutMinimum = (timeoutMinimum != 0) ? timeoutMinimum : ENET_PEER_TIMEOUT_MINIMUM;
        peer.timeoutMaximum = (timeoutMaximum != 0) ? timeoutMaximum : ENET_PEER_TIMEOUT_MAXIMUM;
    }

    /// Force an immediate disconnection from a peer.
    ///    @remarks No ENET_EVENT_DISCONNECT event will be generated. The foreign peer is not
    ///    guarenteed to receive the disconnect notification, and is reset immediately upon
    ///    return from this function.
    public void
    enet_peer_disconnect_now(
        /// peer to disconnect
        ENetPeer peer,
        /// data describing the disconnection
        int data)
    {
        ENetProtocol command = new ENetProtocol();

        if (peer.state == ENetPeerState.ENET_PEER_STATE_DISCONNECTED)
            return;

        if (peer.state != ENetPeerState.ENET_PEER_STATE_ZOMBIE &&
            peer.state != ENetPeerState.ENET_PEER_STATE_DISCONNECTING)
        {
            enet_peer_reset_queues(peer);

            command.header.command = ENET_PROTOCOL_COMMAND_DISCONNECT | ENET_PROTOCOL_COMMAND_FLAG_UNSEQUENCED;
            command.header.channelID = 0xFF;
            command.disconnect.data = p.ENET_HOST_TO_NET_32(data);

            enet_peer_queue_outgoing_command(peer, command, null, 0, 0);

            enet_host_flush(peer.host);
        }

        enet_peer_reset(peer);
    }

    /// Request a disconnection from a peer.
    /// An ENET_EVENT_DISCONNECT event will be generated by enet_host_service()
    /// once the disconnection is complete.
    public void
    enet_peer_disconnect(
        /// peer to request a disconnection
        ENetPeer peer,
        /// data describing the disconnection
        int data)
    {
        ENetProtocol command = new ENetProtocol();

        if (peer.state == ENetPeerState.ENET_PEER_STATE_DISCONNECTING ||
            peer.state == ENetPeerState.ENET_PEER_STATE_DISCONNECTED ||
            peer.state == ENetPeerState.ENET_PEER_STATE_ACKNOWLEDGING_DISCONNECT ||
            peer.state == ENetPeerState.ENET_PEER_STATE_ZOMBIE)
            return;

        enet_peer_reset_queues(peer);

        command.header.command = ENET_PROTOCOL_COMMAND_DISCONNECT;
        command.header.channelID = 0xFF;
        command.disconnect.data = p.ENET_HOST_TO_NET_32(data);

        if (peer.state == ENetPeerState.ENET_PEER_STATE_CONNECTED || peer.state == ENetPeerState.ENET_PEER_STATE_DISCONNECT_LATER)
            command.header.command |= ENET_PROTOCOL_COMMAND_FLAG_ACKNOWLEDGE;
        else
            command.header.command |= ENET_PROTOCOL_COMMAND_FLAG_UNSEQUENCED;

        enet_peer_queue_outgoing_command(peer, command, null, 0, 0);

        if (peer.state == ENetPeerState.ENET_PEER_STATE_CONNECTED || peer.state == ENetPeerState.ENET_PEER_STATE_DISCONNECT_LATER)
        {
            enet_peer_on_disconnect(peer);

            peer.state = ENetPeerState.ENET_PEER_STATE_DISCONNECTING;
        }
        else
        {
            enet_host_flush(peer.host);
            enet_peer_reset(peer);
        }
    }

    /// Request a disconnection from a peer, but only after all queued outgoing packets are sent.
    /// An ENET_EVENT_DISCONNECT event will be generated by enet_host_service()
    /// once the disconnection is complete.
    public void
    enet_peer_disconnect_later(
        /// peer to request a disconnection
        ENetPeer peer,
        /// data describing the disconnection
        int data)
    {
        if ((peer.state == ENetPeerState.ENET_PEER_STATE_CONNECTED || peer.state == ENetPeerState.ENET_PEER_STATE_DISCONNECT_LATER) &&
            !(enet_list_empty(peer.outgoingReliableCommands) &&
               enet_list_empty(peer.outgoingUnreliableCommands) &&
               enet_list_empty(peer.sentReliableCommands)))
        {
            peer.state = ENetPeerState.ENET_PEER_STATE_DISCONNECT_LATER;
            peer.eventData = data;
        }
        else
            enet_peer_disconnect(peer, data);
    }

    ENetAcknowledgement
    enet_peer_queue_acknowledgement(ENetPeer peer, ENetProtocol command, ushort sentTime)
    {
        ENetAcknowledgement acknowledgement;

        if (command.header.channelID < peer.channelCount)
        {
            ENetChannel channel = peer.channels[command.header.channelID];
            ushort reliableWindow = p.IntToUshort(command.header.reliableSequenceNumber / ENET_PEER_RELIABLE_WINDOW_SIZE);
            ushort currentWindow = p.IntToUshort(channel.incomingReliableSequenceNumber / ENET_PEER_RELIABLE_WINDOW_SIZE);

            if (command.header.reliableSequenceNumber < channel.incomingReliableSequenceNumber)
                reliableWindow += ENET_PEER_RELIABLE_WINDOWS;

            if (reliableWindow >= currentWindow + ENET_PEER_FREE_RELIABLE_WINDOWS - 1 && reliableWindow <= currentWindow + ENET_PEER_FREE_RELIABLE_WINDOWS)
                return null;
        }

        acknowledgement = new ENetAcknowledgement();
        if (acknowledgement == null)
            return null;

        peer.outgoingDataTotal += ENetProtocolAcknowledge.SizeOf;

        acknowledgement.sentTime = sentTime;
        acknowledgement.command = command;

        enet_list_insert(enet_list_end(peer.acknowledgements), acknowledgement);

        return acknowledgement;
    }

    public void enet_peer_setup_outgoing_command(ENetPeer peer, ENetOutgoingCommand outgoingCommand)
    {
        ENetChannel channel = null;

        peer.outgoingDataTotal += enet_protocol_command_size(outgoingCommand.command.header.command) + outgoingCommand.fragmentLength;

        if (outgoingCommand.command.header.channelID == 0xFF)
        {
            peer.outgoingReliableSequenceNumber++;

            outgoingCommand.reliableSequenceNumber = peer.outgoingReliableSequenceNumber;
            outgoingCommand.unreliableSequenceNumber = 0;
        }
        else
        {
            channel = peer.channels[outgoingCommand.command.header.channelID];
            if ((outgoingCommand.command.header.command & ENET_PROTOCOL_COMMAND_FLAG_ACKNOWLEDGE) != 0)
            {
                channel.outgoingReliableSequenceNumber++;
                channel.outgoingUnreliableSequenceNumber = 0;

                outgoingCommand.reliableSequenceNumber = channel.outgoingReliableSequenceNumber;
                outgoingCommand.unreliableSequenceNumber = 0;
            }
            else
                if ((outgoingCommand.command.header.command & ENET_PROTOCOL_COMMAND_FLAG_UNSEQUENCED) != 0)
                {
                    peer.outgoingUnsequencedGroup++;

                    outgoingCommand.reliableSequenceNumber = 0;
                    outgoingCommand.unreliableSequenceNumber = 0;
                }
                else
                {
                    if (outgoingCommand.fragmentOffset == 0)
                        channel.outgoingUnreliableSequenceNumber++;

                    outgoingCommand.reliableSequenceNumber = channel.outgoingReliableSequenceNumber;
                    outgoingCommand.unreliableSequenceNumber = channel.outgoingUnreliableSequenceNumber;
                }
        }
        outgoingCommand.sendAttempts = 0;
        outgoingCommand.sentTime = 0;
        outgoingCommand.roundTripTimeout = 0;
        outgoingCommand.roundTripTimeoutLimit = 0;
        outgoingCommand.command.header.reliableSequenceNumber = p.ENET_HOST_TO_NET_16(outgoingCommand.reliableSequenceNumber);

        switch (outgoingCommand.command.header.command & ENET_PROTOCOL_COMMAND_MASK)
        {
            case ENET_PROTOCOL_COMMAND_SEND_UNRELIABLE:
                outgoingCommand.command.sendUnreliable.unreliableSequenceNumber = p.ENET_HOST_TO_NET_16(outgoingCommand.unreliableSequenceNumber);
                break;

            case ENET_PROTOCOL_COMMAND_SEND_UNSEQUENCED:
                outgoingCommand.command.sendUnsequenced.unsequencedGroup = p.ENET_HOST_TO_NET_16(peer.outgoingUnsequencedGroup);
                break;

            default:
                break;
        }

        if ((outgoingCommand.command.header.command & ENET_PROTOCOL_COMMAND_FLAG_ACKNOWLEDGE) != 0)
            enet_list_insert(enet_list_end(peer.outgoingReliableCommands), outgoingCommand);
        else
            enet_list_insert(enet_list_end(peer.outgoingUnreliableCommands), outgoingCommand);
    }

    ENetOutgoingCommand
    enet_peer_queue_outgoing_command(ENetPeer peer, ENetProtocol command, ENetPacket packet, int offset, ushort length)
    {
        ENetOutgoingCommand outgoingCommand = new ENetOutgoingCommand();
        if (outgoingCommand == null)
            return null;

        outgoingCommand.command = command;
        outgoingCommand.fragmentOffset = offset;
        outgoingCommand.fragmentLength = length;
        outgoingCommand.packet = packet;
        if (packet != null)
            packet.referenceCount++;

        enet_peer_setup_outgoing_command(peer, outgoingCommand);

        return outgoingCommand;
    }

    void
    enet_peer_dispatch_incoming_unreliable_commands(ENetPeer peer, ENetChannel channel)
    {
        ENetListNode droppedCommand;
        ENetListNode startCommand;
        ENetListNode currentCommand;

        for (droppedCommand = startCommand = currentCommand = enet_list_begin(channel.incomingUnreliableCommands);
             currentCommand != enet_list_end(channel.incomingUnreliableCommands);
             currentCommand = enet_list_next(currentCommand))
        {
            ENetIncomingCommand incomingCommand = p.CastToENetIncomingCommand(currentCommand);

            if ((incomingCommand.command.header.command & ENET_PROTOCOL_COMMAND_MASK) == ENET_PROTOCOL_COMMAND_SEND_UNSEQUENCED)
                continue;

            if (incomingCommand.reliableSequenceNumber == channel.incomingReliableSequenceNumber)
            {
                if (incomingCommand.fragmentsRemaining <= 0)
                {
                    channel.incomingUnreliableSequenceNumber = incomingCommand.unreliableSequenceNumber;
                    continue;
                }

                if (startCommand != currentCommand)
                {
                    enet_list_move(enet_list_end(peer.dispatchedCommands), startCommand, enet_list_previous(currentCommand));

                    if (peer.needsDispatch == 0)
                    {
                        enet_list_insert(enet_list_end(peer.host.dispatchQueue), peer.dispatchList());

                        peer.needsDispatch = 1;
                    }

                    droppedCommand = currentCommand;
                }
                else
                    if (droppedCommand != currentCommand)
                        droppedCommand = enet_list_previous(currentCommand);
            }
            else
            {
                ushort reliableWindow = p.IntToUshort(incomingCommand.reliableSequenceNumber / ENET_PEER_RELIABLE_WINDOW_SIZE);
                ushort currentWindow = p.IntToUshort(channel.incomingReliableSequenceNumber / ENET_PEER_RELIABLE_WINDOW_SIZE);
                if (incomingCommand.reliableSequenceNumber < channel.incomingReliableSequenceNumber)
                    reliableWindow += ENET_PEER_RELIABLE_WINDOWS;
                if (reliableWindow >= currentWindow && reliableWindow < currentWindow + ENET_PEER_FREE_RELIABLE_WINDOWS - 1)
                    break;

                droppedCommand = enet_list_next(currentCommand);

                if (startCommand != currentCommand)
                {
                    enet_list_move(enet_list_end(peer.dispatchedCommands), startCommand, enet_list_previous(currentCommand));

                    if (peer.needsDispatch == 0)
                    {
                        enet_list_insert(enet_list_end(peer.host.dispatchQueue), peer.dispatchList());

                        peer.needsDispatch = 1;
                    }
                }
            }

            startCommand = enet_list_next(currentCommand);
        }

        if (startCommand != currentCommand)
        {
            enet_list_move(enet_list_end(peer.dispatchedCommands), startCommand, enet_list_previous(currentCommand));

            if (peer.needsDispatch == 0)
            {
                enet_list_insert(enet_list_end(peer.host.dispatchQueue), peer.dispatchList());

                peer.needsDispatch = 1;
            }

            droppedCommand = currentCommand;
        }

        enet_peer_remove_incoming_commands(channel.incomingUnreliableCommands, enet_list_begin(channel.incomingUnreliableCommands), droppedCommand);
    }

    void
    enet_peer_dispatch_incoming_reliable_commands(ENetPeer peer, ENetChannel channel)
    {
        ENetListNode currentCommand;

        for (currentCommand = enet_list_begin(channel.incomingReliableCommands);
             currentCommand != enet_list_end(channel.incomingReliableCommands);
             currentCommand = enet_list_next(currentCommand))
        {
            ENetIncomingCommand incomingCommand = p.CastToENetIncomingCommand(currentCommand);

            if (incomingCommand.fragmentsRemaining > 0 ||
                incomingCommand.reliableSequenceNumber != p.IntToUshort(channel.incomingReliableSequenceNumber + 1))
                break;

            channel.incomingReliableSequenceNumber = incomingCommand.reliableSequenceNumber;

            if (incomingCommand.fragmentCount > 0)
                channel.incomingReliableSequenceNumber += incomingCommand.fragmentCount - 1;
        }

        if (currentCommand == enet_list_begin(channel.incomingReliableCommands))
            return;

        channel.incomingUnreliableSequenceNumber = 0;

        enet_list_move(enet_list_end(peer.dispatchedCommands), enet_list_begin(channel.incomingReliableCommands), enet_list_previous(currentCommand));

        if (peer.needsDispatch == 0)
        {
            enet_list_insert(enet_list_end(peer.host.dispatchQueue), peer.dispatchList());

            peer.needsDispatch = 1;
        }

        if (!enet_list_empty(channel.incomingUnreliableCommands))
            enet_peer_dispatch_incoming_unreliable_commands(peer, channel);
    }

    ENetIncomingCommand dummyCommand;

    ENetIncomingCommand
    enet_peer_queue_incoming_command(ENetPeer peer, ENetProtocol command, ENetPacket packet, int fragmentCount)
    {
        ENetChannel channel = peer.channels[command.header.channelID];
        int unreliableSequenceNumber = 0;
        int reliableSequenceNumber = 0;
        int reliableWindow;
        int currentWindow;
        ENetIncomingCommand incomingCommand = null;
        ENetListNode currentCommand;

        if (peer.state == ENetPeerState.ENET_PEER_STATE_DISCONNECT_LATER)
        {
            return freePacket(fragmentCount, packet);
        }

        if ((command.header.command & ENET_PROTOCOL_COMMAND_MASK) != ENET_PROTOCOL_COMMAND_SEND_UNSEQUENCED)
        {
            reliableSequenceNumber = command.header.reliableSequenceNumber;
            reliableWindow = reliableSequenceNumber / ENET_PEER_RELIABLE_WINDOW_SIZE;
            currentWindow = channel.incomingReliableSequenceNumber / ENET_PEER_RELIABLE_WINDOW_SIZE;

            if (reliableSequenceNumber < channel.incomingReliableSequenceNumber)
                reliableWindow += ENET_PEER_RELIABLE_WINDOWS;

            if (reliableWindow < currentWindow || reliableWindow >= currentWindow + ENET_PEER_FREE_RELIABLE_WINDOWS - 1)
            {
                return freePacket(fragmentCount, packet);
            }
        }

        switch (command.header.command & ENET_PROTOCOL_COMMAND_MASK)
        {
            case ENET_PROTOCOL_COMMAND_SEND_FRAGMENT:
            case ENET_PROTOCOL_COMMAND_SEND_RELIABLE:
                if (reliableSequenceNumber == channel.incomingReliableSequenceNumber)
                    return freePacket(fragmentCount, packet);

                for (currentCommand = enet_list_previous(enet_list_end(channel.incomingReliableCommands));
                     currentCommand != enet_list_end(channel.incomingReliableCommands);
                     currentCommand = enet_list_previous(currentCommand))
                {
                    incomingCommand = p.CastToENetIncomingCommand(currentCommand);

                    if (reliableSequenceNumber >= channel.incomingReliableSequenceNumber)
                    {
                        if (incomingCommand.reliableSequenceNumber < channel.incomingReliableSequenceNumber)
                            continue;
                    }
                    else
                        if (incomingCommand.reliableSequenceNumber >= channel.incomingReliableSequenceNumber)
                            break;

                    if (incomingCommand.reliableSequenceNumber <= reliableSequenceNumber)
                    {
                        if (incomingCommand.reliableSequenceNumber < reliableSequenceNumber)
                            break;

                        return freePacket(fragmentCount, packet);
                    }
                }
                break;

            case ENET_PROTOCOL_COMMAND_SEND_UNRELIABLE:
            case ENET_PROTOCOL_COMMAND_SEND_UNRELIABLE_FRAGMENT:
                unreliableSequenceNumber = p.ENET_NET_TO_HOST_16(command.sendUnreliable.unreliableSequenceNumber);

                if (reliableSequenceNumber == channel.incomingReliableSequenceNumber &&
                    unreliableSequenceNumber <= channel.incomingUnreliableSequenceNumber)
                    return freePacket(fragmentCount, packet);

                for (currentCommand = enet_list_previous(enet_list_end(channel.incomingUnreliableCommands));
                     currentCommand != enet_list_end(channel.incomingUnreliableCommands);
                     currentCommand = enet_list_previous(currentCommand))
                {
                    incomingCommand = p.CastToENetIncomingCommand(currentCommand);

                    if ((command.header.command & ENET_PROTOCOL_COMMAND_MASK) == ENET_PROTOCOL_COMMAND_SEND_UNSEQUENCED)
                        continue;

                    if (reliableSequenceNumber >= channel.incomingReliableSequenceNumber)
                    {
                        if (incomingCommand.reliableSequenceNumber < channel.incomingReliableSequenceNumber)
                            continue;
                    }
                    else
                        if (incomingCommand.reliableSequenceNumber >= channel.incomingReliableSequenceNumber)
                            break;

                    if (incomingCommand.reliableSequenceNumber < reliableSequenceNumber)
                        break;

                    if (incomingCommand.reliableSequenceNumber > reliableSequenceNumber)
                        continue;

                    if (incomingCommand.unreliableSequenceNumber <= unreliableSequenceNumber)
                    {
                        if (incomingCommand.unreliableSequenceNumber < unreliableSequenceNumber)
                            break;

                        return freePacket(fragmentCount, packet);
                    }
                }
                break;

            case ENET_PROTOCOL_COMMAND_SEND_UNSEQUENCED:
                currentCommand = enet_list_end(channel.incomingUnreliableCommands);
                break;

            default:
                return freePacket(fragmentCount, packet);
        }

        incomingCommand = new ENetIncomingCommand();
        if (incomingCommand == null)
            return notifyError(packet);

        incomingCommand.reliableSequenceNumber = command.header.reliableSequenceNumber;
        incomingCommand.unreliableSequenceNumber = p.IntToUshort(unreliableSequenceNumber & 0xFFFF);
        incomingCommand.command = command;
        incomingCommand.fragmentCount = fragmentCount;
        incomingCommand.fragmentsRemaining = fragmentCount;
        incomingCommand.packet = packet;
        incomingCommand.fragments = null;

        if (fragmentCount > 0)
        {
            if (fragmentCount <= ENET_PROTOCOL_MAXIMUM_FRAGMENT_COUNT)
                incomingCommand.fragments = new int[(fragmentCount + 31) / 32];
            if (incomingCommand.fragments == null)
            {
#if CITO
                delete incomingCommand;
#endif

                return notifyError(packet);
            }
            for (int i = 0; i < (fragmentCount + 31) / 32; i++)
            {
                incomingCommand.fragments[i] = 0;
            }
        }

        if (packet != null)
            packet.referenceCount++;

        enet_list_insert(enet_list_next(currentCommand), incomingCommand);

        switch (command.header.command & ENET_PROTOCOL_COMMAND_MASK)
        {
            case ENET_PROTOCOL_COMMAND_SEND_FRAGMENT:
            case ENET_PROTOCOL_COMMAND_SEND_RELIABLE:
                enet_peer_dispatch_incoming_reliable_commands(peer, channel);
                break;

            default:
                enet_peer_dispatch_incoming_unreliable_commands(peer, channel);
                break;
        }

        return incomingCommand;


    }

    ENetIncomingCommand freePacket(int fragmentCount, ENetPacket packet)
    {
        if (fragmentCount > 0)
            return notifyError(packet);

        if (packet != null && packet.referenceCount == 0)
            enet_packet_destroy(packet);

        return dummyCommand;

    }

    ENetIncomingCommand notifyError(ENetPacket packet)
    {
        if (packet != null && packet.referenceCount == 0)
            enet_packet_destroy(packet);

        return null;
    }




    // //adaptation constants tuned aggressively for small packet sizes rather than large file compression
    //enum
    //{
    //    ENET_RANGE_CODER_TOP    = 1<<24,
    //    ENET_RANGE_CODER_BOTTOM = 1<<16,

    //    ENET_CONTEXT_SYMBOL_DELTA = 3,
    //    ENET_CONTEXT_SYMBOL_MINIMUM = 1,
    //    ENET_CONTEXT_ESCAPE_MINIMUM = 1,

    //    ENET_SUBCONTEXT_ORDER = 2,
    //    ENET_SUBCONTEXT_SYMBOL_DELTA = 2,
    //    ENET_SUBCONTEXT_ESCAPE_DELTA = 5
    //};

    // //context exclusion roughly halves compression speed, so disable for now
    //#undef ENET_CONTEXT_EXCLUSION

    //typedef struct _ENetRangeCoder
    //{
    //    // only allocate enough symbols for reasonable MTUs, would need to be larger for large file compression
    //    ENetSymbol symbols[4096];
    //} ENetRangeCoder;

    //void *
    //enet_range_coder_create (void)
    //{
    //    ENetRangeCoder * rangeCoder = (ENetRangeCoder *) enet_malloc (sizeof (ENetRangeCoder));
    //    if (rangeCoder == null)
    //      return null;

    //    return rangeCoder;
    //}

    //void
    //enet_range_coder_destroy (void * context)
    //{
    //    ENetRangeCoder * rangeCoder = (ENetRangeCoder *) context;
    //    if (rangeCoder == null)
    //      return;

    //    enet_free (rangeCoder);
    //}

    //#define ENET_SYMBOL_CREATE(symbol, value_, count_) \
    //{ \
    //    symbol = & rangeCoder . symbols [nextSymbol ++]; \
    //    symbol . value = value_; \
    //    symbol . count = count_; \
    //    symbol . under = count_; \
    //    symbol . left = 0; \
    //    symbol . right = 0; \
    //    symbol . symbols = 0; \
    //    symbol . escapes = 0; \
    //    symbol . total = 0; \
    //    symbol . parent = 0; \
    //}

    //#define ENET_CONTEXT_CREATE(context, escapes_, minimum) \
    //{ \
    //    ENET_SYMBOL_CREATE (context, 0, 0); \
    //    (context) . escapes = escapes_; \
    //    (context) . total = escapes_ + 256*minimum; \
    //    (context) . symbols = 0; \
    //}

    //static enet_uint16
    //enet_symbol_rescale (ENetSymbol * symbol)
    //{
    //    enet_uint16 total = 0;
    //    for (;;)
    //    {
    //        symbol . count -= symbol.count >> 1;
    //        symbol . under = symbol . count;
    //        if (symbol . left)
    //          symbol . under += enet_symbol_rescale (symbol + symbol . left);
    //        total += symbol . under;
    //        if (! symbol . right) break;
    //        symbol += symbol . right;
    //    } 
    //    return total;
    //}

    //#define ENET_CONTEXT_RESCALE(context, minimum) \
    //{ \
    //    (context) . total = (context) . symbols ? enet_symbol_rescale ((context) + (context) . symbols) : 0; \
    //    (context) . escapes -= (context) . escapes >> 1; \
    //    (context) . total += (context) . escapes + 256*minimum; \
    //}

    //#define ENET_RANGE_CODER_OUTPUT(value) \
    //{ \
    //    if (outData >= outEnd) \
    //      return 0; \
    //    * outData ++ = value; \
    //}

    //#define ENET_RANGE_CODER_ENCODE(under, count, total) \
    //{ \
    //    encodeRange /= (total); \
    //    encodeLow += (under) * encodeRange; \
    //    encodeRange *= (count); \
    //    for (;;) \
    //    { \
    //        if((encodeLow ^ (encodeLow + encodeRange)) >= ENET_RANGE_CODER_TOP) \
    //        { \
    //            if(encodeRange >= ENET_RANGE_CODER_BOTTOM) break; \
    //            encodeRange = -encodeLow & (ENET_RANGE_CODER_BOTTOM - 1); \
    //        } \
    //        ENET_RANGE_CODER_OUTPUT (encodeLow >> 24); \
    //        encodeRange <<= 8; \
    //        encodeLow <<= 8; \
    //    } \
    //}

    //#define ENET_RANGE_CODER_FLUSH \
    //{ \
    //    while (encodeLow) \
    //    { \
    //        ENET_RANGE_CODER_OUTPUT (encodeLow >> 24); \
    //        encodeLow <<= 8; \
    //    } \
    //}

    //#define ENET_RANGE_CODER_FREE_SYMBOLS \
    //{ \
    //    if (nextSymbol >= sizeof (rangeCoder . symbols) / sizeof (ENetSymbol) - ENET_SUBCONTEXT_ORDER ) \
    //    { \
    //        nextSymbol = 0; \
    //        ENET_CONTEXT_CREATE (root, ENET_CONTEXT_ESCAPE_MINIMUM, ENET_CONTEXT_SYMBOL_MINIMUM); \
    //        predicted = 0; \
    //        order = 0; \
    //    } \
    //}

    //#define ENET_CONTEXT_ENCODE(context, symbol_, value_, under_, count_, update, minimum) \
    //{ \
    //    under_ = value*minimum; \
    //    count_ = minimum; \
    //    if (! (context) . symbols) \
    //    { \
    //        ENET_SYMBOL_CREATE (symbol_, value_, update); \
    //        (context) . symbols = symbol_ - (context); \
    //    } \
    //    else \
    //    { \
    //        ENetSymbol * node = (context) + (context) . symbols; \
    //        for (;;) \
    //        { \
    //            if (value_ < node . value) \
    //            { \
    //                node . under += update; \
    //                if (node . left) { node += node . left; continue; } \
    //                ENET_SYMBOL_CREATE (symbol_, value_, update); \
    //                node . left = symbol_ - node; \
    //            } \
    //            else \
    //            if (value_ > node . value) \
    //            { \
    //                under_ += node . under; \
    //                if (node . right) { node += node . right; continue; } \
    //                ENET_SYMBOL_CREATE (symbol_, value_, update); \
    //                node . right = symbol_ - node; \
    //            } \
    //            else \
    //            { \
    //                count_ += node . count; \
    //                under_ += node . under - node . count; \
    //                node . under += update; \
    //                node . count += update; \
    //                symbol_ = node; \
    //            } \
    //            break; \
    //        } \
    //    } \
    //}

    //#ifdef ENET_CONTEXT_EXCLUSION
    //static const ENetSymbol emptyContext = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

    //#define ENET_CONTEXT_WALK(context, body) \
    //{ \
    //    const ENetSymbol * node = (context) + (context) . symbols; \
    //    const ENetSymbol * stack [256]; \
    //    size_t stackSize = 0; \
    //    while (node . left) \
    //    { \
    //        stack [stackSize ++] = node; \
    //        node += node . left; \
    //    } \
    //    for (;;) \
    //    { \
    //        body; \
    //        if (node . right) \
    //        { \
    //            node += node . right; \
    //            while (node . left) \
    //            { \
    //                stack [stackSize ++] = node; \
    //                node += node . left; \
    //            } \
    //        } \
    //        else \
    //        if (stackSize <= 0) \
    //            break; \
    //        else \
    //            node = stack [-- stackSize]; \
    //    } \
    //}

    //#define ENET_CONTEXT_ENCODE_EXCLUDE(context, value_, under, total, minimum) \
    //ENET_CONTEXT_WALK(context, { \
    //    if (node . value != value_) \
    //    { \
    //        enet_uint16 parentCount = rangeCoder . symbols [node . parent].count + minimum; \
    //        if (node . value < value_) \
    //          under -= parentCount; \
    //        total -= parentCount; \
    //    } \
    //})
    //#endif

    //size_t
    //enet_range_coder_compress (void * context, const ENetBuffer * inBuffers, size_t inBufferCount, size_t inLimit, enet_uint8 * outData, size_t outLimit)
    //{
    //    ENetRangeCoder * rangeCoder = (ENetRangeCoder *) context;
    //    enet_uint8 * outStart = outData, * outEnd = & outData [outLimit];
    //    const enet_uint8 * inData, * inEnd;
    //    enet_uint32 encodeLow = 0, encodeRange = ~0;
    //    ENetSymbol * root;
    //    enet_uint16 predicted = 0;
    //    size_t order = 0, nextSymbol = 0;

    //    if (rangeCoder == null || inBufferCount <= 0 || inLimit <= 0)
    //      return 0;

    //    inData = (const enet_uint8 *) inBuffers . data;
    //    inEnd = & inData [inBuffers . dataLength];
    //    inBuffers ++;
    //    inBufferCount --;

    //    ENET_CONTEXT_CREATE (root, ENET_CONTEXT_ESCAPE_MINIMUM, ENET_CONTEXT_SYMBOL_MINIMUM);

    //    for (;;)
    //    {
    //        ENetSymbol * subcontext, * symbol;
    //#ifdef ENET_CONTEXT_EXCLUSION
    //        const ENetSymbol * childContext = & emptyContext;
    //#endif
    //        enet_uint8 value;
    //        enet_uint16 count, under, * parent = & predicted, total;
    //        if (inData >= inEnd)
    //        {
    //            if (inBufferCount <= 0)
    //              break;
    //            inData = (const enet_uint8 *) inBuffers . data;
    //            inEnd = & inData [inBuffers . dataLength];
    //            inBuffers ++;
    //            inBufferCount --;
    //        }
    //        value = * inData ++;

    //        for (subcontext = & rangeCoder . symbols [predicted]; 
    //             subcontext != root; 
    //#ifdef ENET_CONTEXT_EXCLUSION
    //             childContext = subcontext, 
    //#endif
    //                subcontext = & rangeCoder . symbols [subcontext . parent])
    //        {
    //            ENET_CONTEXT_ENCODE (subcontext, symbol, value, under, count, ENET_SUBCONTEXT_SYMBOL_DELTA, 0);
    //            * parent = symbol - rangeCoder . symbols;
    //            parent = & symbol . parent;
    //            total = subcontext . total;
    //#ifdef ENET_CONTEXT_EXCLUSION
    //            if (childContext . total > ENET_SUBCONTEXT_SYMBOL_DELTA + ENET_SUBCONTEXT_ESCAPE_DELTA)
    //              ENET_CONTEXT_ENCODE_EXCLUDE (childContext, value, under, total, 0);
    //#endif
    //            if (count > 0)
    //            {
    //                ENET_RANGE_CODER_ENCODE (subcontext . escapes + under, count, total);
    //            }
    //            else
    //            {
    //                if (subcontext . escapes > 0 && subcontext . escapes < total) 
    //                    ENET_RANGE_CODER_ENCODE (0, subcontext . escapes, total); 
    //                subcontext . escapes += ENET_SUBCONTEXT_ESCAPE_DELTA;
    //                subcontext . total += ENET_SUBCONTEXT_ESCAPE_DELTA;
    //            }
    //            subcontext . total += ENET_SUBCONTEXT_SYMBOL_DELTA;
    //            if (count > 0xFF - 2*ENET_SUBCONTEXT_SYMBOL_DELTA || subcontext . total > ENET_RANGE_CODER_BOTTOM - 0x100)
    //              ENET_CONTEXT_RESCALE (subcontext, 0);
    //            if (count > 0) goto nextInput;
    //        }

    //        ENET_CONTEXT_ENCODE (root, symbol, value, under, count, ENET_CONTEXT_SYMBOL_DELTA, ENET_CONTEXT_SYMBOL_MINIMUM);
    //        * parent = symbol - rangeCoder . symbols;
    //        parent = & symbol . parent;
    //        total = root . total;
    //#ifdef ENET_CONTEXT_EXCLUSION
    //        if (childContext . total > ENET_SUBCONTEXT_SYMBOL_DELTA + ENET_SUBCONTEXT_ESCAPE_DELTA)
    //          ENET_CONTEXT_ENCODE_EXCLUDE (childContext, value, under, total, ENET_CONTEXT_SYMBOL_MINIMUM); 
    //#endif
    //        ENET_RANGE_CODER_ENCODE (root . escapes + under, count, total);
    //        root . total += ENET_CONTEXT_SYMBOL_DELTA; 
    //        if (count > 0xFF - 2*ENET_CONTEXT_SYMBOL_DELTA + ENET_CONTEXT_SYMBOL_MINIMUM || root . total > ENET_RANGE_CODER_BOTTOM - 0x100)
    //          ENET_CONTEXT_RESCALE (root, ENET_CONTEXT_SYMBOL_MINIMUM);

    //    nextInput:
    //        if (order >= ENET_SUBCONTEXT_ORDER) 
    //          predicted = rangeCoder . symbols [predicted].parent;
    //        else 
    //          order ++;
    //        ENET_RANGE_CODER_FREE_SYMBOLS;
    //    }

    //    ENET_RANGE_CODER_FLUSH;

    //    return (size_t) (outData - outStart);
    //}

    //#define ENET_RANGE_CODER_SEED \
    //{ \
    //    if (inData < inEnd) decodeCode |= * inData ++ << 24; \
    //    if (inData < inEnd) decodeCode |= * inData ++ << 16; \
    //    if (inData < inEnd) decodeCode |= * inData ++ << 8; \
    //    if (inData < inEnd) decodeCode |= * inData ++; \
    //}

    //#define ENET_RANGE_CODER_READ(total) ((decodeCode - decodeLow) / (decodeRange /= (total)))

    //#define ENET_RANGE_CODER_DECODE(under, count, total) \
    //{ \
    //    decodeLow += (under) * decodeRange; \
    //    decodeRange *= (count); \
    //    for (;;) \
    //    { \
    //        if((decodeLow ^ (decodeLow + decodeRange)) >= ENET_RANGE_CODER_TOP) \
    //        { \
    //            if(decodeRange >= ENET_RANGE_CODER_BOTTOM) break; \
    //            decodeRange = -decodeLow & (ENET_RANGE_CODER_BOTTOM - 1); \
    //        } \
    //        decodeCode <<= 8; \
    //        if (inData < inEnd) \
    //          decodeCode |= * inData ++; \
    //        decodeRange <<= 8; \
    //        decodeLow <<= 8; \
    //    } \
    //}

    //#define ENET_CONTEXT_DECODE(context, symbol_, code, value_, under_, count_, update, minimum, createRoot, visitNode, createRight, createLeft) \
    //{ \
    //    under_ = 0; \
    //    count_ = minimum; \
    //    if (! (context) . symbols) \
    //    { \
    //        createRoot; \
    //    } \
    //    else \
    //    { \
    //        ENetSymbol * node = (context) + (context) . symbols; \
    //        for (;;) \
    //        { \
    //            enet_uint16 after = under_ + node . under + (node . value + 1)*minimum, before = node . count + minimum; \
    //            visitNode; \
    //            if (code >= after) \
    //            { \
    //                under_ += node . under; \
    //                if (node . right) { node += node . right; continue; } \
    //                createRight; \
    //            } \
    //            else \
    //            if (code < after - before) \
    //            { \
    //                node . under += update; \
    //                if (node . left) { node += node . left; continue; } \
    //                createLeft; \
    //            } \
    //            else \
    //            { \
    //                value_ = node . value; \
    //                count_ += node . count; \
    //                under_ = after - before; \
    //                node . under += update; \
    //                node . count += update; \
    //                symbol_ = node; \
    //            } \
    //            break; \
    //        } \
    //    } \
    //}

    //#define ENET_CONTEXT_TRY_DECODE(context, symbol_, code, value_, under_, count_, update, minimum, exclude) \
    //ENET_CONTEXT_DECODE (context, symbol_, code, value_, under_, count_, update, minimum, return 0, exclude (node . value, after, before), return 0, return 0)

    //#define ENET_CONTEXT_ROOT_DECODE(context, symbol_, code, value_, under_, count_, update, minimum, exclude) \
    //ENET_CONTEXT_DECODE (context, symbol_, code, value_, under_, count_, update, minimum, \
    //    { \
    //        value_ = code / minimum; \
    //        under_ = code - code%minimum; \
    //        ENET_SYMBOL_CREATE (symbol_, value_, update); \
    //        (context) . symbols = symbol_ - (context); \
    //    }, \
    //    exclude (node . value, after, before), \
    //    { \
    //        value_ = node.value + 1 + (code - after)/minimum; \
    //        under_ = code - (code - after)%minimum; \
    //        ENET_SYMBOL_CREATE (symbol_, value_, update); \
    //        node . right = symbol_ - node; \
    //    }, \
    //    { \
    //        value_ = node.value - 1 - (after - before - code - 1)/minimum; \
    //        under_ = code - (after - before - code - 1)%minimum; \
    //        ENET_SYMBOL_CREATE (symbol_, value_, update); \
    //        node . left = symbol_ - node; \
    //    }) \

    //#ifdef ENET_CONTEXT_EXCLUSION
    //typedef struct _ENetExclude
    //{
    //    enet_uint8 value;
    //    enet_uint16 under;
    //} ENetExclude;

    //#define ENET_CONTEXT_DECODE_EXCLUDE(context, total, minimum) \
    //{ \
    //    enet_uint16 under = 0; \
    //    nextExclude = excludes; \
    //    ENET_CONTEXT_WALK (context, { \
    //        under += rangeCoder . symbols [node . parent].count + minimum; \
    //        nextExclude . value = node . value; \
    //        nextExclude . under = under; \
    //        nextExclude ++; \
    //    }); \
    //    total -= under; \
    //}

    //#define ENET_CONTEXT_EXCLUDED(value_, after, before) \
    //{ \
    //    size_t low = 0, high = nextExclude - excludes; \
    //    for(;;) \
    //    { \
    //        size_t mid = (low + high) >> 1; \
    //        const ENetExclude * exclude = & excludes [mid]; \
    //        if (value_ < exclude . value) \
    //        { \
    //            if (low + 1 < high) \
    //            { \
    //                high = mid; \
    //                continue; \
    //            } \
    //            if (exclude > excludes) \
    //              after -= exclude [-1].under; \
    //        } \
    //        else \
    //        { \
    //            if (value_ > exclude . value) \
    //            { \
    //                if (low + 1 < high) \
    //                { \
    //                    low = mid; \
    //                    continue; \
    //                } \
    //            } \
    //            else \
    //              before = 0; \
    //            after -= exclude . under; \
    //        } \
    //        break; \
    //    } \
    //}
    //#endif

    //#define ENET_CONTEXT_NOT_EXCLUDED(value_, after, before)

    //size_t
    //enet_range_coder_decompress (void * context, const enet_uint8 * inData, size_t inLimit, enet_uint8 * outData, size_t outLimit)
    //{
    //    ENetRangeCoder * rangeCoder = (ENetRangeCoder *) context;
    //    enet_uint8 * outStart = outData, * outEnd = & outData [outLimit];
    //    const enet_uint8 * inEnd = & inData [inLimit];
    //    enet_uint32 decodeLow = 0, decodeCode = 0, decodeRange = ~0;
    //    ENetSymbol * root;
    //    enet_uint16 predicted = 0;
    //    size_t order = 0, nextSymbol = 0;
    //#ifdef ENET_CONTEXT_EXCLUSION
    //    ENetExclude excludes [256];
    //    ENetExclude * nextExclude = excludes;
    //#endif

    //    if (rangeCoder == null || inLimit <= 0)
    //      return 0;

    //    ENET_CONTEXT_CREATE (root, ENET_CONTEXT_ESCAPE_MINIMUM, ENET_CONTEXT_SYMBOL_MINIMUM);

    //    ENET_RANGE_CODER_SEED;

    //    for (;;)
    //    {
    //        ENetSymbol * subcontext, * symbol, * patch;
    //#ifdef ENET_CONTEXT_EXCLUSION
    //        const ENetSymbol * childContext = & emptyContext;
    //#endif
    //        enet_uint8 value = 0;
    //        enet_uint16 code, under, count, bottom, * parent = & predicted, total;

    //        for (subcontext = & rangeCoder . symbols [predicted];
    //             subcontext != root;
    //#ifdef ENET_CONTEXT_EXCLUSION
    //             childContext = subcontext, 
    //#endif
    //                subcontext = & rangeCoder . symbols [subcontext . parent])
    //        {
    //            if (subcontext . escapes <= 0)
    //              continue;
    //            total = subcontext . total;
    //#ifdef ENET_CONTEXT_EXCLUSION
    //            if (childContext . total > 0) 
    //              ENET_CONTEXT_DECODE_EXCLUDE (childContext, total, 0); 
    //#endif
    //            if (subcontext . escapes >= total)
    //              continue;
    //            code = ENET_RANGE_CODER_READ (total);
    //            if (code < subcontext . escapes) 
    //            {
    //                ENET_RANGE_CODER_DECODE (0, subcontext . escapes, total); 
    //                continue;
    //            }
    //            code -= subcontext . escapes;
    //#ifdef ENET_CONTEXT_EXCLUSION
    //            if (childContext . total > 0)
    //            {
    //                ENET_CONTEXT_TRY_DECODE (subcontext, symbol, code, value, under, count, ENET_SUBCONTEXT_SYMBOL_DELTA, 0, ENET_CONTEXT_EXCLUDED); 
    //            }
    //            else
    //#endif
    //            {
    //                ENET_CONTEXT_TRY_DECODE (subcontext, symbol, code, value, under, count, ENET_SUBCONTEXT_SYMBOL_DELTA, 0, ENET_CONTEXT_NOT_EXCLUDED); 
    //            }
    //            bottom = symbol - rangeCoder . symbols;
    //            ENET_RANGE_CODER_DECODE (subcontext . escapes + under, count, total);
    //            subcontext . total += ENET_SUBCONTEXT_SYMBOL_DELTA;
    //            if (count > 0xFF - 2*ENET_SUBCONTEXT_SYMBOL_DELTA || subcontext . total > ENET_RANGE_CODER_BOTTOM - 0x100)
    //              ENET_CONTEXT_RESCALE (subcontext, 0);
    //            goto patchContexts;
    //        }

    //        total = root . total;
    //#ifdef ENET_CONTEXT_EXCLUSION
    //        if (childContext . total > 0)
    //          ENET_CONTEXT_DECODE_EXCLUDE (childContext, total, ENET_CONTEXT_SYMBOL_MINIMUM);  
    //#endif
    //        code = ENET_RANGE_CODER_READ (total);
    //        if (code < root . escapes)
    //        {
    //            ENET_RANGE_CODER_DECODE (0, root . escapes, total);
    //            break;
    //        }
    //        code -= root . escapes;
    //#ifdef ENET_CONTEXT_EXCLUSION
    //        if (childContext . total > 0)
    //        {
    //            ENET_CONTEXT_ROOT_DECODE (root, symbol, code, value, under, count, ENET_CONTEXT_SYMBOL_DELTA, ENET_CONTEXT_SYMBOL_MINIMUM, ENET_CONTEXT_EXCLUDED); 
    //        }
    //        else
    //#endif
    //        {
    //            ENET_CONTEXT_ROOT_DECODE (root, symbol, code, value, under, count, ENET_CONTEXT_SYMBOL_DELTA, ENET_CONTEXT_SYMBOL_MINIMUM, ENET_CONTEXT_NOT_EXCLUDED); 
    //        }
    //        bottom = symbol - rangeCoder . symbols;
    //        ENET_RANGE_CODER_DECODE (root . escapes + under, count, total);
    //        root . total += ENET_CONTEXT_SYMBOL_DELTA;
    //        if (count > 0xFF - 2*ENET_CONTEXT_SYMBOL_DELTA + ENET_CONTEXT_SYMBOL_MINIMUM || root . total > ENET_RANGE_CODER_BOTTOM - 0x100)
    //          ENET_CONTEXT_RESCALE (root, ENET_CONTEXT_SYMBOL_MINIMUM);

    //    patchContexts:
    //        for (patch = & rangeCoder . symbols [predicted];
    //             patch != subcontext;
    //             patch = & rangeCoder . symbols [patch . parent])
    //        {
    //            ENET_CONTEXT_ENCODE (patch, symbol, value, under, count, ENET_SUBCONTEXT_SYMBOL_DELTA, 0);
    //            * parent = symbol - rangeCoder . symbols;
    //            parent = & symbol . parent;
    //            if (count <= 0)
    //            {
    //                patch . escapes += ENET_SUBCONTEXT_ESCAPE_DELTA;
    //                patch . total += ENET_SUBCONTEXT_ESCAPE_DELTA;
    //            }
    //            patch . total += ENET_SUBCONTEXT_SYMBOL_DELTA; 
    //            if (count > 0xFF - 2*ENET_SUBCONTEXT_SYMBOL_DELTA || patch . total > ENET_RANGE_CODER_BOTTOM - 0x100)
    //              ENET_CONTEXT_RESCALE (patch, 0);
    //        }
    //        * parent = bottom;

    //        ENET_RANGE_CODER_OUTPUT (value);

    //        if (order >= ENET_SUBCONTEXT_ORDER)
    //          predicted = rangeCoder . symbols [predicted].parent;
    //        else
    //          order ++;
    //        ENET_RANGE_CODER_FREE_SYMBOLS;
    //    }

    //    return (size_t) (outData - outStart);
    //}

    // @defgroup host ENet host functions
    //    @{
    //

    /// Sets the packet compressor the host should use to the default range coder.
    ///    @returns 0 on success, < 0 on failure
    public int
    enet_host_compress_with_range_coder(
        ///    @param host host to enable the range coder for
        ENetHost host)
    {
        return 0;
        //    ENetCompressor compressor;
        //    memset (& compressor, 0, sizeof (compressor));
        //    compressor.context = enet_range_coder_create();
        //    if (compressor.context == null)
        //      return -1;
        //    compressor.compress = enet_range_coder_compress;
        //    compressor.decompress = enet_range_coder_decompress;
        //    compressor.destroy = enet_range_coder_destroy;
        //    enet_host_compress (host, & compressor);
        //    return 0;
    }

    int enet_protocol_command_size(byte commandNumber)
    {
        return commandSizes[commandNumber & ENET_PROTOCOL_COMMAND_MASK];
    }





    //@defgroup list ENet linked list utility functions
    //@ingroup private
    //@{
    void
    enet_list_clear(ENetList list)
    {
        p.CastToENetListNode(list.GetSentinel()).next = list.GetSentinel();
        p.CastToENetListNode(list.GetSentinel()).previous = list.GetSentinel();
    }

    ENetListNode
    enet_list_insert(ENetListNode position, ENetObject data)
    {
        ENetListNode result = p.CastToENetListNode(data);

        result.previous = position.previous;
        result.next = position;

        p.CastToENetListNode(result.previous).next = result;
        position.previous = result;

        return result;
    }

    ENetListNode
    enet_list_remove(ENetListNode position)
    {
        p.CastToENetListNode(position.previous).next = position.next;
        p.CastToENetListNode(position.next).previous = position.previous;

        return position;
    }

    ENetListNode
    enet_list_move(ENetListNode position, ENetListNode dataFirst, ENetListNode dataLast)
    {
        ENetListNode first = dataFirst;
        ENetListNode last = dataLast;

        p.CastToENetListNode(first.previous).next = last.next;
        p.CastToENetListNode(last.next).previous = first.previous;

        first.previous = position.previous;
        last.next = position;

        p.CastToENetListNode(first.previous).next = first;
        position.previous = last;

        return first;
    }

    int
    enet_list_size(ENetList list)
    {
        int size = 0;
        ENetListNode position;

        for (position = enet_list_begin(list);
             position != enet_list_end(list);
             position = enet_list_next(position))
            size++;

        return size;
    }

    ENetListNode enet_list_begin(ENetList list) { return p.CastToENetListNode(p.CastToENetListNode(list.GetSentinel()).next); }
    ENetListNode enet_list_end(ENetList list) { return p.CastToENetListNode(list.GetSentinel()); }

    bool enet_list_empty(ENetList list) { return enet_list_begin(list) == enet_list_end(list); }

    ENetListNode enet_list_next(ENetListNode iterator) { return p.CastToENetListNode((iterator).next); }
    ENetListNode enet_list_previous(ENetListNode iterator) { return p.CastToENetListNode((iterator).previous); }

    ENetListNode enet_list_front(ENetList list) { return p.CastToENetListNode(p.CastToENetListNode(list.GetSentinel()).next); }
    ENetListNode enet_list_back(ENetList list) { return p.CastToENetListNode(p.CastToENetListNode(list.GetSentinel()).previous); }











































    //
    // @file  protocol.c
    // @brief ENet protocol functions
    //
    int[] commandSizes;
    //const int commandSizes [ENET_PROTOCOL_COMMAND_COUNT] =
    //{
    //    0,
    //    sizeof (ENetProtocolAcknowledge),
    //    sizeof (ENetProtocolConnect),
    //    sizeof (ENetProtocolVerifyConnect),
    //    sizeof (ENetProtocolDisconnect),
    //    sizeof (ENetProtocolPing),
    //    sizeof (ENetProtocolSendReliable),
    //    sizeof (ENetProtocolSendUnreliable),
    //    sizeof (ENetProtocolSendFragment),
    //    sizeof (ENetProtocolSendUnsequenced),
    //    sizeof (ENetProtocolBandwidthLimit),
    //    sizeof (ENetProtocolThrottleConfigure),
    //    sizeof (ENetProtocolSendFragment)
    //};

    //size_t
    //enet_protocol_command_size (enet_uint8 commandNumber)
    //{
    //    return commandSizes [commandNumber & ENET_PROTOCOL_COMMAND_MASK];
    //}

    public void
    enet_protocol_change_state(ENetHost host, ENetPeer peer, int state)
    {
        if (state == ENetPeerState.ENET_PEER_STATE_CONNECTED || state == ENetPeerState.ENET_PEER_STATE_DISCONNECT_LATER)
            enet_peer_on_connect(peer);
        else
            enet_peer_on_disconnect(peer);

        peer.state = state;
    }

    public void
    enet_protocol_dispatch_state(ENetHost host, ENetPeer peer, int state)
    {
        enet_protocol_change_state(host, peer, state);

        if (peer.needsDispatch == 0)
        {
            enet_list_insert(enet_list_end(host.dispatchQueue), peer.dispatchList());

            peer.needsDispatch = 1;
        }
    }

    public int
    enet_protocol_dispatch_incoming_commands(ENetHost host, ENetEvent event_)
    {
        while (!enet_list_empty(host.dispatchQueue))
        {
            ENetPeer peer = p.CastToENetPeer(enet_list_remove(enet_list_begin(host.dispatchQueue)));

            peer.needsDispatch = 0;

            switch (peer.state)
            {
                case ENetPeerState.ENET_PEER_STATE_CONNECTION_PENDING:
                case ENetPeerState.ENET_PEER_STATE_CONNECTION_SUCCEEDED:
                    enet_protocol_change_state(host, peer, ENetPeerState.ENET_PEER_STATE_CONNECTED);

                    event_.type = ENetEventType.ENET_EVENT_TYPE_CONNECT;
                    event_.peer = peer;
                    event_.data = peer.eventData;

                    return 1;

                case ENetPeerState.ENET_PEER_STATE_ZOMBIE:
                    host.recalculateBandwidthLimits = 1;

                    event_.type = ENetEventType.ENET_EVENT_TYPE_DISCONNECT;
                    event_.peer = peer;
                    event_.data = peer.eventData;

                    enet_peer_reset(peer);

                    return 1;

                case ENetPeerState.ENET_PEER_STATE_CONNECTED:
                    if (enet_list_empty(peer.dispatchedCommands))
                        continue;
                    Byte b = new Byte();
                    b.value = event_.channelID;
                    event_.packet = enet_peer_receive(peer, b);
                    event_.channelID = b.value;
                    if (event_.packet == null)
                        continue;

                    event_.type = ENetEventType.ENET_EVENT_TYPE_RECEIVE;
                    event_.peer = peer;

                    if (!enet_list_empty(peer.dispatchedCommands))
                    {
                        peer.needsDispatch = 1;

                        enet_list_insert(enet_list_end(host.dispatchQueue), peer.dispatchList());
                    }

                    return 1;

                default:
                    break;
            }
        }

        return 0;
    }

    public void
    enet_protocol_notify_connect(ENetHost host, ENetPeer peer, ENetEvent event_)
    {
        host.recalculateBandwidthLimits = 1;

        if (event_ != null)
        {
            enet_protocol_change_state(host, peer, ENetPeerState.ENET_PEER_STATE_CONNECTED);

            event_.type = ENetEventType.ENET_EVENT_TYPE_CONNECT;
            event_.peer = peer;
            event_.data = peer.eventData;
        }
        else
            enet_protocol_dispatch_state(host, peer, peer.state == ENetPeerState.ENET_PEER_STATE_CONNECTING ? ENetPeerState.ENET_PEER_STATE_CONNECTION_SUCCEEDED : ENetPeerState.ENET_PEER_STATE_CONNECTION_PENDING);
    }

    public void
    enet_protocol_notify_disconnect(ENetHost host, ENetPeer peer, ENetEvent event_)
    {
        if (peer.state >= ENetPeerState.ENET_PEER_STATE_CONNECTION_PENDING)
            host.recalculateBandwidthLimits = 1;

        if (peer.state != ENetPeerState.ENET_PEER_STATE_CONNECTING && peer.state < ENetPeerState.ENET_PEER_STATE_CONNECTION_SUCCEEDED)
            enet_peer_reset(peer);
        else
            if (event_ != null)
            {
                event_.type = ENetEventType.ENET_EVENT_TYPE_DISCONNECT;
                event_.peer = peer;
                event_.data = 0;

                enet_peer_reset(peer);
            }
            else
            {
                peer.eventData = 0;

                enet_protocol_dispatch_state(host, peer, ENetPeerState.ENET_PEER_STATE_ZOMBIE);
            }
    }

    public void
    enet_protocol_remove_sent_unreliable_commands(ENetPeer peer)
    {
        ENetOutgoingCommand outgoingCommand;

        while (!enet_list_empty(peer.sentUnreliableCommands))
        {
            outgoingCommand = p.CastToENetOutgoingCommand(enet_list_front(peer.sentUnreliableCommands));

            enet_list_remove(outgoingCommand.outgoingCommandList());

            if (outgoingCommand.packet != null)
            {
                outgoingCommand.packet.referenceCount--;

                if (outgoingCommand.packet.referenceCount == 0)
                {
                    outgoingCommand.packet.flags |= ENetPacketFlagEnum.ENET_PACKET_FLAG_SENT;

                    enet_packet_destroy(outgoingCommand.packet);
                }
            }
#if CITO
        delete outgoingCommand;
#endif
        }
    }

    public int
    enet_protocol_remove_sent_reliable_command(ENetPeer peer, ushort reliableSequenceNumber, byte channelID)
    {
        ENetOutgoingCommand outgoingCommand = null;
        ENetListNode currentCommand;
        int commandNumber;
        int wasSent = 1;

        for (currentCommand = enet_list_begin(peer.sentReliableCommands);
             currentCommand != enet_list_end(peer.sentReliableCommands);
             currentCommand = enet_list_next(currentCommand))
        {
            outgoingCommand = p.CastToENetOutgoingCommand(currentCommand);

            if (outgoingCommand.reliableSequenceNumber == reliableSequenceNumber &&
                outgoingCommand.command.header.channelID == channelID)
                break;
        }

        if (currentCommand == enet_list_end(peer.sentReliableCommands))
        {
            for (currentCommand = enet_list_begin(peer.outgoingReliableCommands);
                 currentCommand != enet_list_end(peer.outgoingReliableCommands);
                 currentCommand = enet_list_next(currentCommand))
            {
                outgoingCommand = p.CastToENetOutgoingCommand(currentCommand);

                if (outgoingCommand.sendAttempts < 1) return ENET_PROTOCOL_COMMAND_NONE;

                if (outgoingCommand.reliableSequenceNumber == reliableSequenceNumber &&
                    outgoingCommand.command.header.channelID == channelID)
                    break;
            }

            if (currentCommand == enet_list_end(peer.outgoingReliableCommands))
                return ENET_PROTOCOL_COMMAND_NONE;

            wasSent = 0;
        }

        if (outgoingCommand == null)
            return ENET_PROTOCOL_COMMAND_NONE;

        if (channelID < peer.channelCount)
        {
            ENetChannel channel = peer.channels[channelID];
            ushort reliableWindow = p.IntToUshort(reliableSequenceNumber / ENET_PEER_RELIABLE_WINDOW_SIZE);
            if (channel.reliableWindows[reliableWindow] > 0)
            {
                channel.reliableWindows[reliableWindow]--;
                if (channel.reliableWindows[reliableWindow] == 0)
                    channel.usedReliableWindows &= ~(1 << reliableWindow);
            }
        }

        commandNumber = (outgoingCommand.command.header.command & ENET_PROTOCOL_COMMAND_MASK);

        enet_list_remove(outgoingCommand.outgoingCommandList());

        if (outgoingCommand.packet != null)
        {
            if (wasSent != 0)
                peer.reliableDataInTransit -= outgoingCommand.fragmentLength;

            outgoingCommand.packet.referenceCount--;

            if (outgoingCommand.packet.referenceCount == 0)
            {
                outgoingCommand.packet.flags |= ENetPacketFlagEnum.ENET_PACKET_FLAG_SENT;

                enet_packet_destroy(outgoingCommand.packet);
            }
        }
#if CITO
    delete outgoingCommand;
#endif

        if (enet_list_empty(peer.sentReliableCommands))
            return commandNumber;

        outgoingCommand = p.CastToENetOutgoingCommand(enet_list_front(peer.sentReliableCommands));

        peer.nextTimeout = outgoingCommand.sentTime + outgoingCommand.roundTripTimeout;

        return commandNumber;
    }

    public ENetPeer
    enet_protocol_handle_connect(ENetHost host, ENetProtocolHeader header, ENetProtocol command)
    {
        byte incomingSessionID;
        byte outgoingSessionID;
        int mtu;
        int windowSize;
        ENetChannel channel;
        int channelCount;
        ENetPeer currentPeer = new ENetPeer();
        ENetProtocol verifyCommand = new ENetProtocol();

        channelCount = p.ENET_NET_TO_HOST_32(command.connect.channelCount);

        if (channelCount < ENET_PROTOCOL_MINIMUM_CHANNEL_COUNT ||
            channelCount > ENET_PROTOCOL_MAXIMUM_CHANNEL_COUNT)
            return null;
        int i;
        for (i = 0; i < host.peerCount; i++)
        {
            currentPeer = host.peers[i];
            if (currentPeer.state != ENetPeerState.ENET_PEER_STATE_DISCONNECTED &&
                currentPeer.address.host == host.receivedAddress.host &&
                currentPeer.address.port == host.receivedAddress.port &&
                currentPeer.connectID == command.connect.connectID)
                return null;
        }

        for (i = 0; i < host.peerCount; i++)
        {
            currentPeer = host.peers[i];
            if (currentPeer.state == ENetPeerState.ENET_PEER_STATE_DISCONNECTED)
                break;
        }

        if (i >= host.peerCount)
            return null;

        if (channelCount > host.channelLimit)
            channelCount = host.channelLimit;
        currentPeer.channels = new ENetChannel[channelCount];
        for (int k = 0; k < channelCount; k++)
        {
            currentPeer.channels[k] = new ENetChannel();
        }
        if (currentPeer.channels == null)
            return null;
        currentPeer.channelCount = channelCount;
        currentPeer.state = ENetPeerState.ENET_PEER_STATE_ACKNOWLEDGING_CONNECT;
        currentPeer.connectID = command.connect.connectID;
        currentPeer.address = host.receivedAddress;
        currentPeer.outgoingPeerID = p.ENET_NET_TO_HOST_16(command.connect.outgoingPeerID);
        currentPeer.incomingBandwidth = p.ENET_NET_TO_HOST_32(command.connect.incomingBandwidth);
        currentPeer.outgoingBandwidth = p.ENET_NET_TO_HOST_32(command.connect.outgoingBandwidth);
        currentPeer.packetThrottleInterval = p.ENET_NET_TO_HOST_32(command.connect.packetThrottleInterval);
        currentPeer.packetThrottleAcceleration = p.ENET_NET_TO_HOST_32(command.connect.packetThrottleAcceleration);
        currentPeer.packetThrottleDeceleration = p.ENET_NET_TO_HOST_32(command.connect.packetThrottleDeceleration);
        currentPeer.eventData = p.ENET_NET_TO_HOST_32(command.connect.data);

        incomingSessionID = command.connect.incomingSessionID == 0xFF ? currentPeer.outgoingSessionID : command.connect.incomingSessionID;
        incomingSessionID = ToByte((incomingSessionID + 1) & (ENET_PROTOCOL_HEADER_SESSION_MASK >> ENET_PROTOCOL_HEADER_SESSION_SHIFT));
        if (incomingSessionID == currentPeer.outgoingSessionID)
            incomingSessionID = ToByte((incomingSessionID + 1) & (ENET_PROTOCOL_HEADER_SESSION_MASK >> ENET_PROTOCOL_HEADER_SESSION_SHIFT));
        currentPeer.outgoingSessionID = incomingSessionID;

        outgoingSessionID = command.connect.outgoingSessionID == 0xFF ? currentPeer.incomingSessionID : command.connect.outgoingSessionID;
        outgoingSessionID = ToByte((outgoingSessionID + 1) & (ENET_PROTOCOL_HEADER_SESSION_MASK >> ENET_PROTOCOL_HEADER_SESSION_SHIFT));
        if (outgoingSessionID == currentPeer.incomingSessionID)
            outgoingSessionID = ToByte((outgoingSessionID + 1) & (ENET_PROTOCOL_HEADER_SESSION_MASK >> ENET_PROTOCOL_HEADER_SESSION_SHIFT));
        currentPeer.incomingSessionID = outgoingSessionID;

        for (i = 0; i < currentPeer.channelCount; i++)
        {
            channel = currentPeer.channels[i];
            channel.outgoingReliableSequenceNumber = 0;
            channel.outgoingUnreliableSequenceNumber = 0;
            channel.incomingReliableSequenceNumber = 0;
            channel.incomingUnreliableSequenceNumber = 0;

            enet_list_clear(channel.incomingReliableCommands);
            enet_list_clear(channel.incomingUnreliableCommands);

            channel.usedReliableWindows = 0;
            for (int k = 0; k < ENetChannel.reliableWindowsLength; k++)
            {
                channel.reliableWindows[k] = 0;
            }
        }

        mtu = p.ENET_NET_TO_HOST_32(command.connect.mtu);

        if (mtu < ENET_PROTOCOL_MINIMUM_MTU)
            mtu = ENET_PROTOCOL_MINIMUM_MTU;
        else
            if (mtu > ENET_PROTOCOL_MAXIMUM_MTU)
                mtu = ENET_PROTOCOL_MAXIMUM_MTU;

        currentPeer.mtu = mtu;

        if (host.outgoingBandwidth == 0 &&
            currentPeer.incomingBandwidth == 0)
            currentPeer.windowSize = ENET_PROTOCOL_MAXIMUM_WINDOW_SIZE;
        else
            if (host.outgoingBandwidth == 0 ||
                currentPeer.incomingBandwidth == 0)
                currentPeer.windowSize = (ENET_MAX(host.outgoingBandwidth, currentPeer.incomingBandwidth) /
                                              ENET_PEER_WINDOW_SIZE_SCALE) *
                                                ENET_PROTOCOL_MINIMUM_WINDOW_SIZE;
            else
                currentPeer.windowSize = (ENET_MIN(host.outgoingBandwidth, currentPeer.incomingBandwidth) /
                                              ENET_PEER_WINDOW_SIZE_SCALE) *
                                                ENET_PROTOCOL_MINIMUM_WINDOW_SIZE;

        if (currentPeer.windowSize < ENET_PROTOCOL_MINIMUM_WINDOW_SIZE)
            currentPeer.windowSize = ENET_PROTOCOL_MINIMUM_WINDOW_SIZE;
        else
            if (currentPeer.windowSize > ENET_PROTOCOL_MAXIMUM_WINDOW_SIZE)
                currentPeer.windowSize = ENET_PROTOCOL_MAXIMUM_WINDOW_SIZE;

        if (host.incomingBandwidth == 0)
            windowSize = ENET_PROTOCOL_MAXIMUM_WINDOW_SIZE;
        else
            windowSize = (host.incomingBandwidth / ENET_PEER_WINDOW_SIZE_SCALE) *
                           ENET_PROTOCOL_MINIMUM_WINDOW_SIZE;

        if (windowSize > p.ENET_NET_TO_HOST_32(command.connect.windowSize))
            windowSize = p.ENET_NET_TO_HOST_32(command.connect.windowSize);

        if (windowSize < ENET_PROTOCOL_MINIMUM_WINDOW_SIZE)
            windowSize = ENET_PROTOCOL_MINIMUM_WINDOW_SIZE;
        else
            if (windowSize > ENET_PROTOCOL_MAXIMUM_WINDOW_SIZE)
                windowSize = ENET_PROTOCOL_MAXIMUM_WINDOW_SIZE;

        verifyCommand.header = new ENetProtocolCommandHeader();
        verifyCommand.header.command = ENET_PROTOCOL_COMMAND_VERIFY_CONNECT | ENET_PROTOCOL_COMMAND_FLAG_ACKNOWLEDGE;
        verifyCommand.header.channelID = 0xFF;
        verifyCommand.verifyConnect = new ENetProtocolVerifyConnect();
        verifyCommand.verifyConnect.outgoingPeerID = p.ENET_HOST_TO_NET_16(currentPeer.incomingPeerID);
        verifyCommand.verifyConnect.incomingSessionID = incomingSessionID;
        verifyCommand.verifyConnect.outgoingSessionID = outgoingSessionID;
        verifyCommand.verifyConnect.mtu = p.ENET_HOST_TO_NET_32(currentPeer.mtu);
        verifyCommand.verifyConnect.windowSize = p.ENET_HOST_TO_NET_32(windowSize);
        verifyCommand.verifyConnect.channelCount = p.ENET_HOST_TO_NET_32(channelCount);
        verifyCommand.verifyConnect.incomingBandwidth = p.ENET_HOST_TO_NET_32(host.incomingBandwidth);
        verifyCommand.verifyConnect.outgoingBandwidth = p.ENET_HOST_TO_NET_32(host.outgoingBandwidth);
        verifyCommand.verifyConnect.packetThrottleInterval = p.ENET_HOST_TO_NET_32(currentPeer.packetThrottleInterval);
        verifyCommand.verifyConnect.packetThrottleAcceleration = p.ENET_HOST_TO_NET_32(currentPeer.packetThrottleAcceleration);
        verifyCommand.verifyConnect.packetThrottleDeceleration = p.ENET_HOST_TO_NET_32(currentPeer.packetThrottleDeceleration);
        verifyCommand.verifyConnect.connectID = currentPeer.connectID;

        enet_peer_queue_outgoing_command(currentPeer, verifyCommand, null, 0, 0);

        return currentPeer;
    }

    public static byte ToByte(int a)
    {
#if CITO
    return a.LowByte;
#else
        return (byte)a;
#endif
    }

    int
    enet_protocol_handle_send_reliable(ENetHost host, ENetPeer peer, ENetProtocol command, byte[] currentData, int[] currentDataI)
    {
        ENetPacket packet;
        int dataLength;

        if (command.header.channelID >= peer.channelCount ||
            (peer.state != ENetPeerState.ENET_PEER_STATE_CONNECTED && peer.state != ENetPeerState.ENET_PEER_STATE_DISCONNECT_LATER))
            return -1;

        dataLength = ENET_NET_TO_HOST_16(command.sendReliable.dataLength);
        
        if (dataLength > ENET_PROTOCOL_MAXIMUM_PACKET_SIZE ||
            currentDataI[0] < 0 ||
            currentDataI[0] > host.receivedDataLength)
            return -1;

        command.data = new byte[dataLength];
        for (int i = 0; i < dataLength; i++)
        {
            command.data[i] = currentData[currentDataI[0] + i];
        }
        
        currentDataI[0] += dataLength;

        packet = enet_packet_create(command.data,// + ENetProtocolSendReliable.SizeOf,
                                     dataLength,
                                     ENetPacketFlagEnum.ENET_PACKET_FLAG_RELIABLE);
        if (packet == null ||
            enet_peer_queue_incoming_command(peer, command, packet, 0) == null)
            return -1;

        return 0;
    }

    public int
    enet_protocol_handle_send_unsequenced(ENetHost host, ENetPeer peer, ENetProtocol command, byte[] currentData)
    {
        return 0;
        //    ENetPacket * packet;
        //    enet_uint32 unsequencedGroup, index;
        //    size_t dataLength;

        //    if (command . header.channelID >= peer . channelCount ||
        //        (peer . state !=ENetPeerState.ENET_PEER_STATE_CONNECTED && peer . state !=ENetPeerState.ENET_PEER_STATE_DISCONNECT_LATER))
        //      return -1;

        //    dataLength = ENET_NET_TO_HOST_16 (command . sendUnsequenced.dataLength);
        //    * currentData += dataLength;
        //    if (dataLength > ENET_PROTOCOL_MAXIMUM_PACKET_SIZE ||
        //        * currentData < host . receivedData ||
        //        * currentData > & host . receivedData [host . receivedDataLength])
        //      return -1; 

        //    unsequencedGroup = ENET_NET_TO_HOST_16 (command . sendUnsequenced.unsequencedGroup);
        //    index = unsequencedGroup % ENET_PEER_UNSEQUENCED_WINDOW_SIZE;

        //    if (unsequencedGroup < peer . incomingUnsequencedGroup)
        //      unsequencedGroup += 0x10000;

        //    if (unsequencedGroup >= (enet_uint32) peer . incomingUnsequencedGroup + ENET_PEER_FREE_UNSEQUENCED_WINDOWS * ENET_PEER_UNSEQUENCED_WINDOW_SIZE)
        //      return 0;

        //    unsequencedGroup &= 0xFFFF;

        //    if (unsequencedGroup - index != peer . incomingUnsequencedGroup)
        //    {
        //        peer . incomingUnsequencedGroup = unsequencedGroup - index;

        //        memset (peer . unsequencedWindow, 0, sizeof (peer . unsequencedWindow));
        //    }
        //    else
        //    if (peer . unsequencedWindow [index / 32] & (1 << (index % 32)))
        //      return 0;

        //    packet = enet_packet_create ((const enet_uint8 *) command + sizeof (ENetProtocolSendUnsequenced),
        //                                 dataLength,
        //                                 ENET_PACKET_FLAG_UNSEQUENCED);
        //    if (packet == null ||
        //        enet_peer_queue_incoming_command (peer, command, packet, 0) == null)
        //      return -1;

        //    peer . unsequencedWindow [index / 32] |= 1 << (index % 32);

        //    return 0;
    }

    public int
    enet_protocol_handle_send_unreliable(ENetHost host, ENetPeer peer, ENetProtocol command, byte[] currentData, int[] currentDataI)
    {
        ENetPacket packet;
        int dataLength;

        if (command.header.channelID >= peer.channelCount ||
            (peer.state != ENetPeerState.ENET_PEER_STATE_CONNECTED && peer.state != ENetPeerState.ENET_PEER_STATE_DISCONNECT_LATER))
            return -1;

        dataLength = p.ENET_NET_TO_HOST_16(command.sendUnreliable.dataLength);
        currentDataI[0] += dataLength;
        if (dataLength > ENET_PROTOCOL_MAXIMUM_PACKET_SIZE ||
            currentDataI[0] < 0 ||
            currentDataI[0] > host.receivedDataLength)
            return -1;

        command.data = new byte[dataLength];
        for (int i = 0; i < dataLength; i++)
        {
            command.data[i] = currentData[currentDataI[0] - dataLength + i];
        }

        packet = enet_packet_create(command.data, dataLength, 0);

        if (packet == null ||
            enet_peer_queue_incoming_command(peer, command, packet, 0) == null)
            return -1;

        return 0;
    }

    public int
    enet_protocol_handle_send_fragment(ENetHost host, ENetPeer peer, ENetProtocol command, byte[] currentData, int[] currentDataI)
    {
        int fragmentNumber;
        int fragmentCount;
        int fragmentOffset;
        int fragmentLength;
        int startSequenceNumber;
        int totalLength;
        ENetChannel channel;
        ushort startWindow;
        ushort currentWindow;
        ENetListNode currentCommand;
        ENetIncomingCommand startCommand = null;

        if (command.header.channelID >= peer.channelCount ||
            (peer.state != ENetPeerState.ENET_PEER_STATE_CONNECTED && peer.state != ENetPeerState.ENET_PEER_STATE_DISCONNECT_LATER))
            return -1;

        fragmentLength = p.ENET_NET_TO_HOST_16(command.sendFragment.dataLength);
        currentDataI[0] += fragmentLength;
        if (fragmentLength > ENET_PROTOCOL_MAXIMUM_PACKET_SIZE ||
            currentDataI[0] < 0 ||
            currentDataI[0] > host.receivedDataLength)
            return -1;

        channel = peer.channels[command.header.channelID];
        startSequenceNumber = p.ENET_NET_TO_HOST_16(command.sendFragment.startSequenceNumber);
        startWindow = p.IntToUshort(startSequenceNumber / ENET_PEER_RELIABLE_WINDOW_SIZE);
        currentWindow = p.IntToUshort(channel.incomingReliableSequenceNumber / ENET_PEER_RELIABLE_WINDOW_SIZE);

        if (startSequenceNumber < channel.incomingReliableSequenceNumber)
            startWindow += ENET_PEER_RELIABLE_WINDOWS;

        if (startWindow < currentWindow || startWindow >= currentWindow + ENET_PEER_FREE_RELIABLE_WINDOWS - 1)
            return 0;

        fragmentNumber = p.ENET_NET_TO_HOST_32(command.sendFragment.fragmentNumber);
        fragmentCount = p.ENET_NET_TO_HOST_32(command.sendFragment.fragmentCount);
        fragmentOffset = p.ENET_NET_TO_HOST_32(command.sendFragment.fragmentOffset);
        totalLength = p.ENET_NET_TO_HOST_32(command.sendFragment.totalLength);

        if (fragmentCount > ENET_PROTOCOL_MAXIMUM_FRAGMENT_COUNT ||
            fragmentNumber >= fragmentCount ||
            totalLength > ENET_PROTOCOL_MAXIMUM_PACKET_SIZE ||
            fragmentOffset >= totalLength ||
            fragmentLength > totalLength - fragmentOffset)
            return -1;

        for (currentCommand = enet_list_previous(enet_list_end(channel.incomingReliableCommands));
             currentCommand != enet_list_end(channel.incomingReliableCommands);
             currentCommand = enet_list_previous(currentCommand))
        {
            ENetIncomingCommand incomingCommand = p.CastToENetIncomingCommand(currentCommand);

            if (startSequenceNumber >= channel.incomingReliableSequenceNumber)
            {
                if (incomingCommand.reliableSequenceNumber < channel.incomingReliableSequenceNumber)
                    continue;
            }
            else
                if (incomingCommand.reliableSequenceNumber >= channel.incomingReliableSequenceNumber)
                    break;

            if (incomingCommand.reliableSequenceNumber <= startSequenceNumber)
            {
                if (incomingCommand.reliableSequenceNumber < startSequenceNumber)
                    break;

                if ((incomingCommand.command.header.command & ENET_PROTOCOL_COMMAND_MASK) != ENET_PROTOCOL_COMMAND_SEND_FRAGMENT ||
                    totalLength != incomingCommand.packet.dataLength ||
                    fragmentCount != incomingCommand.fragmentCount)
                    return -1;

                startCommand = incomingCommand;
                break;
            }
        }

        if (startCommand == null)
        {
            ENetProtocol hostCommand = command;
            ENetPacket packet = enet_packet_create(null, totalLength, ENetPacketFlagEnum.ENET_PACKET_FLAG_RELIABLE);
            if (packet == null)
                return -1;

            hostCommand.header.reliableSequenceNumber = p.IntToUshort(startSequenceNumber);

            startCommand = enet_peer_queue_incoming_command(peer, hostCommand, packet, fragmentCount);
            if (startCommand == null)
                return -1;
        }

        if ((startCommand.fragments[fragmentNumber / 32] & (1 << (fragmentNumber % 32))) == 0)
        {
            startCommand.fragmentsRemaining--;

            startCommand.fragments[fragmentNumber / 32] |= (1 << (fragmentNumber % 32));

            if (fragmentOffset + fragmentLength > startCommand.packet.dataLength)
                fragmentLength = startCommand.packet.dataLength - fragmentOffset;

            byte[] data = new byte[128];
            SerializeCommand(data, command);

            //memcpy(startCommand.packet.data + fragmentOffset,
            //        (enet_uint8*)command + ENetProtocolSendFragment.SizeOf,
            //        fragmentLength);
            for (int i = 0; i < fragmentLength; i++)
            {
                startCommand.packet.data[i + fragmentOffset] = data[i + ENetProtocolSendFragment.SizeOf];
            }

            if (startCommand.fragmentsRemaining <= 0)
                enet_peer_dispatch_incoming_reliable_commands(peer, channel);
        }

        return 0;
    }

    public int
    enet_protocol_handle_send_unreliable_fragment(ENetHost host, ENetPeer peer, ENetProtocol command, byte[] currentData)
    {
        int fragmentNumber;
        int fragmentCount;
        int fragmentOffset;
        int fragmentLength;
        int reliableSequenceNumber;
        int startSequenceNumber;
        int totalLength;
        ushort reliableWindow;
        ushort currentWindow;
        ENetChannel channel;
        ENetListNode currentCommand;
        ENetIncomingCommand startCommand = null;

        if (command.header.channelID >= peer.channelCount ||
            (peer.state != ENetPeerState.ENET_PEER_STATE_CONNECTED && peer.state != ENetPeerState.ENET_PEER_STATE_DISCONNECT_LATER))
            return -1;

        fragmentLength = ENET_NET_TO_HOST_16(command.sendFragment.dataLength);
        int currentDataI = 0;
        currentDataI += fragmentLength;
        if (fragmentLength > ENET_PROTOCOL_MAXIMUM_PACKET_SIZE ||
            currentDataI < 0 ||
            currentDataI > host.receivedDataLength)
            return -1;

        channel = peer.channels[command.header.channelID];
        reliableSequenceNumber = command.header.reliableSequenceNumber;
        startSequenceNumber = ENET_NET_TO_HOST_16(command.sendFragment.startSequenceNumber);

        reliableWindow = p.IntToUshort(reliableSequenceNumber / ENET_PEER_RELIABLE_WINDOW_SIZE);
        currentWindow = p.IntToUshort(channel.incomingReliableSequenceNumber / ENET_PEER_RELIABLE_WINDOW_SIZE);

        if (reliableSequenceNumber < channel.incomingReliableSequenceNumber)
            reliableWindow += ENET_PEER_RELIABLE_WINDOWS;

        if (reliableWindow < currentWindow || reliableWindow >= currentWindow + ENET_PEER_FREE_RELIABLE_WINDOWS - 1)
            return 0;

        if (reliableSequenceNumber == channel.incomingReliableSequenceNumber &&
            startSequenceNumber <= channel.incomingUnreliableSequenceNumber)
            return 0;

        fragmentNumber = ENET_NET_TO_HOST_32(command.sendFragment.fragmentNumber);
        fragmentCount = ENET_NET_TO_HOST_32(command.sendFragment.fragmentCount);
        fragmentOffset = ENET_NET_TO_HOST_32(command.sendFragment.fragmentOffset);
        totalLength = ENET_NET_TO_HOST_32(command.sendFragment.totalLength);

        if (fragmentCount > ENET_PROTOCOL_MAXIMUM_FRAGMENT_COUNT ||
            fragmentNumber >= fragmentCount ||
            totalLength > ENET_PROTOCOL_MAXIMUM_PACKET_SIZE ||
            fragmentOffset >= totalLength ||
            fragmentLength > totalLength - fragmentOffset)
            return -1;

        for (currentCommand = enet_list_previous(enet_list_end(channel.incomingUnreliableCommands));
             currentCommand != enet_list_end(channel.incomingUnreliableCommands);
             currentCommand = enet_list_previous(currentCommand))
        {
            ENetIncomingCommand incomingCommand = p.CastToENetIncomingCommand(currentCommand);

            if (reliableSequenceNumber >= channel.incomingReliableSequenceNumber)
            {
                if (incomingCommand.reliableSequenceNumber < channel.incomingReliableSequenceNumber)
                    continue;
            }
            else
                if (incomingCommand.reliableSequenceNumber >= channel.incomingReliableSequenceNumber)
                    break;

            if (incomingCommand.reliableSequenceNumber < reliableSequenceNumber)
                break;

            if (incomingCommand.reliableSequenceNumber > reliableSequenceNumber)
                continue;

            if (incomingCommand.unreliableSequenceNumber <= startSequenceNumber)
            {
                if (incomingCommand.unreliableSequenceNumber < startSequenceNumber)
                    break;

                if ((incomingCommand.command.header.command & ENET_PROTOCOL_COMMAND_MASK) != ENET_PROTOCOL_COMMAND_SEND_UNRELIABLE_FRAGMENT ||
                    totalLength != incomingCommand.packet.dataLength ||
                    fragmentCount != incomingCommand.fragmentCount)
                    return -1;

                startCommand = incomingCommand;
                break;
            }
        }

        if (startCommand == null)
        {
            ENetPacket packet = enet_packet_create(null, totalLength, ENetPacketFlagEnum.ENET_PACKET_FLAG_UNRELIABLE_FRAGMENT);
            if (packet == null)
                return -1;

            startCommand = enet_peer_queue_incoming_command(peer, command, packet, fragmentCount);
            if (startCommand == null)
                return -1;
        }

        if ((startCommand.fragments[fragmentNumber / 32] & (1 << (fragmentNumber % 32))) == 0)
        {
            startCommand.fragmentsRemaining--;

            startCommand.fragments[fragmentNumber / 32] |= (1 << (fragmentNumber % 32));

            if (fragmentOffset + fragmentLength > startCommand.packet.dataLength)
                fragmentLength = startCommand.packet.dataLength - fragmentOffset;

            for (int i = 0; i < fragmentLength; i++)
            {
                startCommand.packet.data[fragmentOffset + i] = command.data[i];
            }
            //memcpy(startCommand.packet.data + fragmentOffset,
            //        (enet_uint8*)command + sizeof(ENetProtocolSendFragment),
            //        fragmentLength);

            if (startCommand.fragmentsRemaining <= 0)
                enet_peer_dispatch_incoming_unreliable_commands(peer, channel);
        }

        return 0;
    }

    public int
    enet_protocol_handle_ping(ENetHost host, ENetPeer peer, ENetProtocol command)
    {
        if (peer.state != ENetPeerState.ENET_PEER_STATE_CONNECTED && peer.state != ENetPeerState.ENET_PEER_STATE_DISCONNECT_LATER)
            return -1;

        return 0;
    }

    public int
    enet_protocol_handle_bandwidth_limit(ENetHost host, ENetPeer peer, ENetProtocol command)
    {
        if (peer.state != ENetPeerState.ENET_PEER_STATE_CONNECTED && peer.state != ENetPeerState.ENET_PEER_STATE_DISCONNECT_LATER)
            return -1;

        if (peer.incomingBandwidth != 0)
            host.bandwidthLimitedPeers--;

        peer.incomingBandwidth = p.ENET_NET_TO_HOST_32(command.bandwidthLimit.incomingBandwidth);
        peer.outgoingBandwidth = p.ENET_NET_TO_HOST_32(command.bandwidthLimit.outgoingBandwidth);

        if (peer.incomingBandwidth != 0)
            host.bandwidthLimitedPeers++;

        if (peer.incomingBandwidth == 0 && host.outgoingBandwidth == 0)
            peer.windowSize = ENET_PROTOCOL_MAXIMUM_WINDOW_SIZE;
        else
            peer.windowSize = (ENET_MIN(peer.incomingBandwidth, host.outgoingBandwidth) /
                                   ENET_PEER_WINDOW_SIZE_SCALE) * ENET_PROTOCOL_MINIMUM_WINDOW_SIZE;

        if (peer.windowSize < ENET_PROTOCOL_MINIMUM_WINDOW_SIZE)
            peer.windowSize = ENET_PROTOCOL_MINIMUM_WINDOW_SIZE;
        else
            if (peer.windowSize > ENET_PROTOCOL_MAXIMUM_WINDOW_SIZE)
                peer.windowSize = ENET_PROTOCOL_MAXIMUM_WINDOW_SIZE;

        return 0;
    }

    public int
    enet_protocol_handle_throttle_configure(ENetHost host, ENetPeer peer, ENetProtocol command)
    {
        if (peer.state != ENetPeerState.ENET_PEER_STATE_CONNECTED && peer.state != ENetPeerState.ENET_PEER_STATE_DISCONNECT_LATER)
            return -1;

        peer.packetThrottleInterval = p.ENET_NET_TO_HOST_32(command.throttleConfigure.packetThrottleInterval);
        peer.packetThrottleAcceleration = p.ENET_NET_TO_HOST_32(command.throttleConfigure.packetThrottleAcceleration);
        peer.packetThrottleDeceleration = p.ENET_NET_TO_HOST_32(command.throttleConfigure.packetThrottleDeceleration);

        return 0;
    }

    public int
    enet_protocol_handle_disconnect(ENetHost host, ENetPeer peer, ENetProtocol command)
    {
        if (peer.state == ENetPeerState.ENET_PEER_STATE_DISCONNECTED || peer.state == ENetPeerState.ENET_PEER_STATE_ZOMBIE || peer.state == ENetPeerState.ENET_PEER_STATE_ACKNOWLEDGING_DISCONNECT)
            return 0;

        enet_peer_reset_queues(peer);

        if (peer.state == ENetPeerState.ENET_PEER_STATE_CONNECTION_SUCCEEDED || peer.state == ENetPeerState.ENET_PEER_STATE_DISCONNECTING)
            enet_protocol_dispatch_state(host, peer, ENetPeerState.ENET_PEER_STATE_ZOMBIE);
        else
            if (peer.state != ENetPeerState.ENET_PEER_STATE_CONNECTED && peer.state != ENetPeerState.ENET_PEER_STATE_DISCONNECT_LATER)
            {
                if (peer.state == ENetPeerState.ENET_PEER_STATE_CONNECTION_PENDING) host.recalculateBandwidthLimits = 1;

                enet_peer_reset(peer);
            }
            else
                if ((command.header.command & ENET_PROTOCOL_COMMAND_FLAG_ACKNOWLEDGE) != 0)
                    enet_protocol_change_state(host, peer, ENetPeerState.ENET_PEER_STATE_ACKNOWLEDGING_DISCONNECT);
                else
                    enet_protocol_dispatch_state(host, peer, ENetPeerState.ENET_PEER_STATE_ZOMBIE);

        if (peer.state != ENetPeerState.ENET_PEER_STATE_DISCONNECTED)
            peer.eventData = p.ENET_NET_TO_HOST_32(command.disconnect.data);

        return 0;
    }

    public int
    enet_protocol_handle_acknowledge(ENetHost host, ENetEvent event_, ENetPeer peer, ENetProtocol command)
    {
        int roundTripTime;
        int receivedSentTime;
        int receivedReliableSequenceNumber;
        int commandNumber;

        if (peer.state == ENetPeerState.ENET_PEER_STATE_DISCONNECTED || peer.state == ENetPeerState.ENET_PEER_STATE_ZOMBIE)
            return 0;

        receivedSentTime = p.ENET_NET_TO_HOST_16(command.acknowledge.receivedSentTime);
        receivedSentTime |= host.serviceTime & -65536;// 0xFFFF0000;
        if ((receivedSentTime & 0x8000) > (host.serviceTime & 0x8000))
            receivedSentTime -= 0x10000;

        if (ENET_TIME_LESS(host.serviceTime, receivedSentTime))
            return 0;

        peer.lastReceiveTime = host.serviceTime;
        peer.earliestTimeout = 0;

        roundTripTime = ENET_TIME_DIFFERENCE(host.serviceTime, receivedSentTime);

        enet_peer_throttle(peer, roundTripTime);

        peer.roundTripTimeVariance -= peer.roundTripTimeVariance / 4;

        if (roundTripTime >= peer.roundTripTime)
        {
            peer.roundTripTime += (roundTripTime - peer.roundTripTime) / 8;
            peer.roundTripTimeVariance += (roundTripTime - peer.roundTripTime) / 4;
        }
        else
        {
            peer.roundTripTime -= (peer.roundTripTime - roundTripTime) / 8;
            peer.roundTripTimeVariance += (peer.roundTripTime - roundTripTime) / 4;
        }

        if (peer.roundTripTime < peer.lowestRoundTripTime)
            peer.lowestRoundTripTime = peer.roundTripTime;

        if (peer.roundTripTimeVariance > peer.highestRoundTripTimeVariance)
            peer.highestRoundTripTimeVariance = peer.roundTripTimeVariance;

        if (peer.packetThrottleEpoch == 0 ||
            ENET_TIME_DIFFERENCE(host.serviceTime, peer.packetThrottleEpoch) >= peer.packetThrottleInterval)
        {
            peer.lastRoundTripTime = peer.lowestRoundTripTime;
            peer.lastRoundTripTimeVariance = peer.highestRoundTripTimeVariance;
            peer.lowestRoundTripTime = peer.roundTripTime;
            peer.highestRoundTripTimeVariance = peer.roundTripTimeVariance;
            peer.packetThrottleEpoch = host.serviceTime;
        }

        receivedReliableSequenceNumber = p.ENET_NET_TO_HOST_16(command.acknowledge.receivedReliableSequenceNumber);
        
        commandNumber = enet_protocol_remove_sent_reliable_command(peer, p.IntToUshort(receivedReliableSequenceNumber), command.header.channelID);

        switch (peer.state)
        {
            case ENetPeerState.ENET_PEER_STATE_ACKNOWLEDGING_CONNECT:
                if (commandNumber != ENET_PROTOCOL_COMMAND_VERIFY_CONNECT)
                    return -1;

                enet_protocol_notify_connect(host, peer, event_);
                break;

            case ENetPeerState.ENET_PEER_STATE_DISCONNECTING:
                if (commandNumber != ENET_PROTOCOL_COMMAND_DISCONNECT)
                    return -1;

                enet_protocol_notify_disconnect(host, peer, event_);
                break;

            case ENetPeerState.ENET_PEER_STATE_DISCONNECT_LATER:
                if (enet_list_empty(peer.outgoingReliableCommands) &&
                    enet_list_empty(peer.outgoingUnreliableCommands) &&
                    enet_list_empty(peer.sentReliableCommands))
                    enet_peer_disconnect(peer, peer.eventData);
                break;

            default:
                break;
        }

        return 0;
    }

    public int
    enet_protocol_handle_verify_connect(ENetHost host, ENetEvent event_, ENetPeer peer, ENetProtocol command)
    {
        int mtu;
        int windowSize;
        int channelCount;

        if (peer.state != ENetPeerState.ENET_PEER_STATE_CONNECTING)
            return 0;

        channelCount = p.ENET_NET_TO_HOST_32(command.verifyConnect.channelCount);

        if (channelCount < ENET_PROTOCOL_MINIMUM_CHANNEL_COUNT || channelCount > ENET_PROTOCOL_MAXIMUM_CHANNEL_COUNT ||
        p.ENET_NET_TO_HOST_32(command.verifyConnect.packetThrottleInterval) != peer.packetThrottleInterval ||
       p.ENET_NET_TO_HOST_32(command.verifyConnect.packetThrottleAcceleration) != peer.packetThrottleAcceleration ||
       p.ENET_NET_TO_HOST_32(command.verifyConnect.packetThrottleDeceleration) != peer.packetThrottleDeceleration ||
            command.verifyConnect.connectID != peer.connectID)
        {
            peer.eventData = 0;

            enet_protocol_dispatch_state(host, peer, ENetPeerState.ENET_PEER_STATE_ZOMBIE);

            return -1;
        }

        enet_protocol_remove_sent_reliable_command(peer, 1, 0xFF);

        if (channelCount < peer.channelCount)
            peer.channelCount = channelCount;

        peer.outgoingPeerID = p.ENET_NET_TO_HOST_16(command.verifyConnect.outgoingPeerID);
        peer.incomingSessionID = command.verifyConnect.incomingSessionID;
        peer.outgoingSessionID = command.verifyConnect.outgoingSessionID;

        mtu = p.ENET_NET_TO_HOST_32(command.verifyConnect.mtu);

        if (mtu < ENET_PROTOCOL_MINIMUM_MTU)
            mtu = ENET_PROTOCOL_MINIMUM_MTU;
        else
            if (mtu > ENET_PROTOCOL_MAXIMUM_MTU)
                mtu = ENET_PROTOCOL_MAXIMUM_MTU;

        if (mtu < peer.mtu)
            peer.mtu = mtu;

        windowSize = p.ENET_NET_TO_HOST_32(command.verifyConnect.windowSize);

        if (windowSize < ENET_PROTOCOL_MINIMUM_WINDOW_SIZE)
            windowSize = ENET_PROTOCOL_MINIMUM_WINDOW_SIZE;

        if (windowSize > ENET_PROTOCOL_MAXIMUM_WINDOW_SIZE)
            windowSize = ENET_PROTOCOL_MAXIMUM_WINDOW_SIZE;

        if (windowSize < peer.windowSize)
            peer.windowSize = windowSize;

        peer.incomingBandwidth = p.ENET_NET_TO_HOST_32(command.verifyConnect.incomingBandwidth);
        peer.outgoingBandwidth = p.ENET_NET_TO_HOST_32(command.verifyConnect.outgoingBandwidth);

        enet_protocol_notify_connect(host, peer, event_);
        return 0;
    }
    int test1;
    public int enet_protocol_handle_incoming_commands(ENetHost host, ENetEvent event_)
    {
        ENetProtocolHeader header;
        ENetProtocol command = null;
        ENetPeer peer;
        byte[] currentData = null;
        int headerSize = 0;
        ushort peerID;
        ushort flags;
        int sessionID;

        int[] currentDataI = new int[1];
        currentDataI[0] = 0;

        //if (host . receivedDataLength < ((ENetProtocolHeader *) 0) . sentTime)
        //  return 0;

        header = Deserialize(host.receivedData);

        peerID = ENET_NET_TO_HOST_16(header.peerID);
        sessionID = (peerID & ENET_PROTOCOL_HEADER_SESSION_MASK) >> ENET_PROTOCOL_HEADER_SESSION_SHIFT;
        flags = p.IntToUshort(peerID & ENET_PROTOCOL_HEADER_FLAG_MASK);
        peerID &= p.IntToUshort(~(ENET_PROTOCOL_HEADER_FLAG_MASK | ENET_PROTOCOL_HEADER_SESSION_MASK));

        headerSize = ((flags & ENET_PROTOCOL_HEADER_FLAG_SENT_TIME) != 0) ? ENetProtocolHeader.SizeOf : 2;//todo (size_t) & ((ENetProtocolHeader *) 0) . sentTime);
        if (host.checksum != null)
            headerSize += 4;// sizeof(enet_uint32);

        if (peerID == ENET_PROTOCOL_MAXIMUM_PEER_ID)
            peer = null;
        else
            if (peerID >= host.peerCount)
                return 0;
            else
            {
                peer = host.peers[peerID];

                if (peer.state == ENetPeerState.ENET_PEER_STATE_DISCONNECTED ||
                    peer.state == ENetPeerState.ENET_PEER_STATE_ZOMBIE ||
                    ((host.receivedAddress.host != peer.address.host ||
                      host.receivedAddress.port != peer.address.port) &&
                      peer.address.host != ENET_HOST_BROADCAST) ||
                    (peer.outgoingPeerID < ENET_PROTOCOL_MAXIMUM_PEER_ID &&
                     sessionID != peer.incomingSessionID))
                    return 0;
            }

        if ((flags & ENET_PROTOCOL_HEADER_FLAG_COMPRESSED) != 0)
        {
            int originalSize = 0;
            if (host.compressor == null)
                return 0;

            //originalSize = host . compressor.decompress (host . compressor.context,
            //                            host . receivedData + headerSize, 
            //                            host . receivedDataLength - headerSize, 
            //                            host . packetData [1] + headerSize, 
            //                            ENetHost.packetData0SizeOf - headerSize);
            //if (originalSize <= 0 || originalSize > sizeof (host . packetData [1]) - headerSize)
            //  return 0;

            for (int i = 0; i < headerSize; i++)
            {
                //host.packetData[1][i]=header[i];
            }
            //memcpy (host . packetData [1], header, headerSize);
            host.receivedData = host.packetData[1];
            host.receivedDataLength = headerSize + originalSize;
        }

        if (host.checksum != null)
        {
            int checksum = 0;//(enet_uint32 *) & host . receivedData [headerSize - sizeof (enet_uint32)],
            int desiredChecksum = checksum;
            ENetBuffer buffer = new ENetBuffer();

            checksum = peer != null ? peer.connectID : 0;

            buffer.data = host.receivedData;
            buffer.dataLength = host.receivedDataLength;

            if (host.checksum.Run(buffer, 1) != desiredChecksum)
                return 0;
        }

        if (peer != null)
        {
            peer.address.host = host.receivedAddress.host;
            peer.address.port = host.receivedAddress.port;
            peer.incomingDataTotal += host.receivedDataLength;
        }

        currentDataI[0] += headerSize;
        int test = 0;
        while (currentDataI[0] < host.receivedDataLength)
        {
            byte commandNumber;
            int commandSize;

            if (test > 0)
            {
            }
            test++;

            //command = (ENetProtocol *) currentData;

            if (currentDataI[0] + ENetProtocolCommandHeader.SizeOf > host.receivedDataLength)
                break;

            command = DeserializeProtocolCommandHeader(host.receivedData, currentDataI[0]);

            commandNumber = ToByte(command.header.command & ENET_PROTOCOL_COMMAND_MASK);
            if (commandNumber == 0)
            {
            }
            if (commandNumber >= ENET_PROTOCOL_COMMAND_COUNT)
                break;

            commandSize = commandSizes[commandNumber];
            if (commandSize == 0 || currentDataI[0] + commandSize > host.receivedDataLength)
                break;

            DeserializeProtocolCommandCommand(host.receivedData, currentDataI[0], commandNumber, command);
            currentDataI[0] += commandSize;

            if (peer == null && commandNumber != ENET_PROTOCOL_COMMAND_CONNECT)
                break;

#if !CITO
            System.Console.WriteLine("BEFORE:" + command.header.reliableSequenceNumber);
#endif            
            command.header.reliableSequenceNumber = ENET_NET_TO_HOST_16(command.header.reliableSequenceNumber);
#if !CITO
            System.Console.WriteLine("AFTER:"+command.header.reliableSequenceNumber);
#endif
            if (test1 == 1)
            {
            }
            if (command.header.reliableSequenceNumber == 1)
            {
                test1++;
            }
            switch (commandNumber)
            {
                case ENET_PROTOCOL_COMMAND_ACKNOWLEDGE:
                    if (enet_protocol_handle_acknowledge(host, event_, peer, command) != 0)
                        return commandError(event_);
                    break;

                case ENET_PROTOCOL_COMMAND_CONNECT:
                    if (peer != null)
                        return commandError(event_);
                    peer = enet_protocol_handle_connect(host, header, command);
                    if (peer == null)
                        return commandError(event_);
                    break;

                case ENET_PROTOCOL_COMMAND_VERIFY_CONNECT:
                    if (enet_protocol_handle_verify_connect(host, event_, peer, command) != 0)
                        return commandError(event_);
                    break;

                case ENET_PROTOCOL_COMMAND_DISCONNECT:
                    if (enet_protocol_handle_disconnect(host, peer, command) != 0)
                        return commandError(event_);
                    break;

                case ENET_PROTOCOL_COMMAND_PING:
                    if (enet_protocol_handle_ping(host, peer, command) != 0)
                        return commandError(event_);
                    break;

                case ENET_PROTOCOL_COMMAND_SEND_RELIABLE:
                    if (enet_protocol_handle_send_reliable(host, peer, command, host.receivedData, currentDataI) != 0)
                        return commandError(event_);
                    break;

                case ENET_PROTOCOL_COMMAND_SEND_UNRELIABLE:
                    if (enet_protocol_handle_send_unreliable(host, peer, command, host.receivedData, currentDataI) != 0)
                        return commandError(event_);
                    break;

                case ENET_PROTOCOL_COMMAND_SEND_UNSEQUENCED:
                    if (enet_protocol_handle_send_unsequenced(host, peer, command, currentData) != 0)
                        return commandError(event_);
                    break;

                case ENET_PROTOCOL_COMMAND_SEND_FRAGMENT:
                    if (enet_protocol_handle_send_fragment(host, peer, command, host.receivedData, currentDataI) != 0)
                        return commandError(event_);
                    break;

                case ENET_PROTOCOL_COMMAND_BANDWIDTH_LIMIT:
                    if (enet_protocol_handle_bandwidth_limit(host, peer, command) != 0)
                        return commandError(event_);
                    break;

                case ENET_PROTOCOL_COMMAND_THROTTLE_CONFIGURE:
                    if (enet_protocol_handle_throttle_configure(host, peer, command) != 0)
                        return commandError(event_);
                    break;

                case ENET_PROTOCOL_COMMAND_SEND_UNRELIABLE_FRAGMENT:
                    if (enet_protocol_handle_send_unreliable_fragment(host, peer, command, currentData) != 0)
                        return commandError(event_);
                    break;

                default:
                    return commandError(event_);
            }

            if (peer != null &&
                (command.header.command & ENET_PROTOCOL_COMMAND_FLAG_ACKNOWLEDGE) != 0)
            {
                ushort sentTime;

                if ((flags & ENET_PROTOCOL_HEADER_FLAG_SENT_TIME) == 0)
                    break;

                sentTime = ENET_NET_TO_HOST_16(header.sentTime);

                switch (peer.state)
                {
                    case ENetPeerState.ENET_PEER_STATE_DISCONNECTING:
                    case ENetPeerState.ENET_PEER_STATE_ACKNOWLEDGING_CONNECT:
                    case ENetPeerState.ENET_PEER_STATE_DISCONNECTED:
                    case ENetPeerState.ENET_PEER_STATE_ZOMBIE:
                        break;

                    case ENetPeerState.ENET_PEER_STATE_ACKNOWLEDGING_DISCONNECT:
                        if ((command.header.command & ENET_PROTOCOL_COMMAND_MASK) == ENET_PROTOCOL_COMMAND_DISCONNECT)
                            enet_peer_queue_acknowledgement(peer, command, sentTime);
                        break;

                    default:
                        enet_peer_queue_acknowledgement(peer, command, sentTime);
                        break;
                }
            }
        }
        if (event_ != null && event_.type != ENetEventType.ENET_EVENT_TYPE_NONE)
        {
            return 1;
        }

        return 0;
    }

    void DeserializeProtocolCommandCommand(byte[] readBuf, int currentDataI, byte commandNumber, ENetProtocol command)
    {
        int pos = currentDataI + ENetProtocolCommandHeader.SizeOf;
        switch (commandNumber)
        {
            case ENET_PROTOCOL_COMMAND_ACKNOWLEDGE:
                command.acknowledge = new ENetProtocolAcknowledge();
                command.acknowledge.receivedReliableSequenceNumber = ReadShort(readBuf, pos); pos += 2;
                command.acknowledge.receivedSentTime = ReadShort(readBuf, pos); pos += 2;
                break;

            case ENET_PROTOCOL_COMMAND_CONNECT:
                command.connect = new ENetProtocolConnect();
                command.connect.outgoingPeerID = ReadShort(readBuf, pos); pos += 2;
                command.connect.incomingSessionID = ReadByte(readBuf, pos); pos += 1;
                command.connect.outgoingSessionID = ReadByte(readBuf, pos); pos += 1;
                command.connect.mtu = ReadInt(readBuf, pos); pos += 4;
                command.connect.windowSize = ReadInt(readBuf, pos); pos += 4;
                command.connect.channelCount = ReadInt(readBuf, pos); pos += 4;
                command.connect.incomingBandwidth = ReadInt(readBuf, pos); pos += 4;
                command.connect.outgoingBandwidth = ReadInt(readBuf, pos); pos += 4;
                command.connect.packetThrottleInterval = ReadInt(readBuf, pos); pos += 4;
                command.connect.packetThrottleAcceleration = ReadInt(readBuf, pos); pos += 4;
                command.connect.packetThrottleDeceleration = ReadInt(readBuf, pos); pos += 4;
                command.connect.connectID = ReadInt(readBuf, pos); pos += 4;
                command.connect.data = ReadInt(readBuf, pos); pos += 4;
                break;

            case ENET_PROTOCOL_COMMAND_VERIFY_CONNECT:
                command.verifyConnect = new ENetProtocolVerifyConnect();
                command.verifyConnect.outgoingPeerID = ReadShort(readBuf, pos); pos += 2;
                command.verifyConnect.incomingSessionID = ReadByte(readBuf, pos); pos += 1;
                command.verifyConnect.outgoingSessionID = ReadByte(readBuf, pos); pos += 1;
                command.verifyConnect.mtu = ReadInt(readBuf, pos); pos += 4;
                command.verifyConnect.windowSize = ReadInt(readBuf, pos); pos += 4;
                command.verifyConnect.channelCount = ReadInt(readBuf, pos); pos += 4;
                command.verifyConnect.incomingBandwidth = ReadInt(readBuf, pos); pos += 4;
                command.verifyConnect.outgoingBandwidth = ReadInt(readBuf, pos); pos += 4;
                command.verifyConnect.packetThrottleInterval = ReadInt(readBuf, pos); pos += 4;
                command.verifyConnect.packetThrottleAcceleration = ReadInt(readBuf, pos); pos += 4;
                command.verifyConnect.packetThrottleDeceleration = ReadInt(readBuf, pos); pos += 4;
                command.verifyConnect.connectID = ReadInt(readBuf, pos); pos += 4;
                break;

            case ENET_PROTOCOL_COMMAND_DISCONNECT:
                command.disconnect = new ENetProtocolDisconnect();
                command.disconnect.data = ReadInt(readBuf, pos); pos += 4;
                break;

            case ENET_PROTOCOL_COMMAND_PING:
                command.ping = new ENetProtocolPing();
                break;

            case ENET_PROTOCOL_COMMAND_SEND_RELIABLE:
                command.sendReliable = new ENetProtocolSendReliable();
                command.sendReliable.dataLength = ReadShort(readBuf, pos); pos += 2;
                break;

            case ENET_PROTOCOL_COMMAND_SEND_UNRELIABLE:
                command.sendUnreliable = new ENetProtocolSendUnreliable();
                command.sendUnreliable.unreliableSequenceNumber = ReadShort(readBuf, pos); pos += 2;
                command.sendUnreliable.dataLength = ReadShort(readBuf, pos); pos += 2;
                break;

            case ENET_PROTOCOL_COMMAND_SEND_UNSEQUENCED:
                command.sendUnsequenced = new ENetProtocolSendUnsequenced();
                command.sendUnsequenced.unsequencedGroup = ReadShort(readBuf, pos); pos += 2;
                command.sendUnsequenced.dataLength = ReadShort(readBuf, pos); pos += 2;
                break;

            case ENET_PROTOCOL_COMMAND_SEND_FRAGMENT:
                command.sendFragment = new ENetProtocolSendFragment();
                command.sendFragment.startSequenceNumber = ReadShort(readBuf, pos); pos += 2;
                command.sendFragment.dataLength = ReadShort(readBuf, pos); pos += 2;
                command.sendFragment.fragmentCount = ReadInt(readBuf, pos); pos += 4;
                command.sendFragment.fragmentNumber = ReadInt(readBuf, pos); pos += 4;
                command.sendFragment.totalLength = ReadInt(readBuf, pos); pos += 4;
                command.sendFragment.fragmentOffset = ReadInt(readBuf, pos); pos += 4;
                break;

            case ENET_PROTOCOL_COMMAND_BANDWIDTH_LIMIT:
                command.bandwidthLimit = new ENetProtocolBandwidthLimit();
                command.bandwidthLimit.incomingBandwidth = ReadInt(readBuf, pos); pos += 4;
                command.bandwidthLimit.outgoingBandwidth = ReadInt(readBuf, pos); pos += 4;
                break;

            case ENET_PROTOCOL_COMMAND_THROTTLE_CONFIGURE:
                command.throttleConfigure = new ENetProtocolThrottleConfigure();
                command.throttleConfigure.packetThrottleInterval = ReadInt(readBuf, pos); pos += 4;
                command.throttleConfigure.packetThrottleAcceleration = ReadInt(readBuf, pos); pos += 4;
                command.throttleConfigure.packetThrottleDeceleration = ReadInt(readBuf, pos); pos += 4;
                break;

            case ENET_PROTOCOL_COMMAND_SEND_UNRELIABLE_FRAGMENT:
                command.sendFragment = new ENetProtocolSendFragment();
                command.sendFragment.startSequenceNumber = ReadShort(readBuf, pos); pos += 2;
                command.sendFragment.dataLength = ReadShort(readBuf, pos); pos += 2;
                command.sendFragment.fragmentCount = ReadInt(readBuf, pos); pos += 4;
                command.sendFragment.fragmentNumber = ReadInt(readBuf, pos); pos += 4;
                command.sendFragment.totalLength = ReadInt(readBuf, pos); pos += 4;
                command.sendFragment.fragmentOffset = ReadInt(readBuf, pos); pos += 4;
                break;

            default:
                break;
        }
    }

    ENetProtocol DeserializeProtocolCommandHeader(byte[] currentData, int currentDataI)
    {
        int pos = currentDataI;
        ENetProtocol a = new ENetProtocol();
        a.header = new ENetProtocolCommandHeader();
        a.header.command = ReadByte(currentData, pos); pos += 1;
        a.header.channelID = ReadByte(currentData, pos); pos += 1;
        a.header.reliableSequenceNumber = ReadShort(currentData, pos); pos += 2;
        return a;
    }

    void SerializeCommand(byte[] buf, ENetProtocol a)
    {
        if (a == null)
        {
            a = new ENetProtocol();
        }
        int[] pos = new int[1];
        pos[0] = 0;
        WriteByte(buf, pos, a.header.command);
        WriteByte(buf, pos, a.header.channelID);
        WriteShort(buf, pos, a.header.reliableSequenceNumber);
        switch (a.header.command & ENET_PROTOCOL_COMMAND_MASK)
        {
            case ENet.ENET_PROTOCOL_COMMAND_ACKNOWLEDGE:
                {
                    WriteShort(buf, pos, a.acknowledge.receivedReliableSequenceNumber);
                    WriteShort(buf, pos, a.acknowledge.receivedSentTime);
                    break;
                }
            case ENet.ENET_PROTOCOL_COMMAND_CONNECT:
                {
                    WriteShort(buf, pos, a.connect.outgoingPeerID);
                    WriteByte(buf, pos, a.connect.incomingSessionID);
                    WriteByte(buf, pos, a.connect.outgoingSessionID);
                    WriteInt(buf, pos, a.connect.mtu);
                    WriteInt(buf, pos, a.connect.windowSize);
                    WriteInt(buf, pos, a.connect.channelCount);
                    WriteInt(buf, pos, a.connect.incomingBandwidth);
                    WriteInt(buf, pos, a.connect.outgoingBandwidth);
                    WriteInt(buf, pos, a.connect.packetThrottleInterval);
                    WriteInt(buf, pos, a.connect.packetThrottleAcceleration);
                    WriteInt(buf, pos, a.connect.packetThrottleDeceleration);
                    WriteInt(buf, pos, a.connect.connectID);
                    WriteInt(buf, pos, a.connect.data);
                    break;
                }
            case ENet.ENET_PROTOCOL_COMMAND_VERIFY_CONNECT:
                {
                    WriteInt(buf, pos, a.connect.outgoingPeerID);
                    WriteByte(buf, pos, a.connect.incomingSessionID);
                    WriteByte(buf, pos, a.connect.outgoingSessionID);
                    WriteInt(buf, pos, a.connect.mtu);
                    WriteInt(buf, pos, a.connect.windowSize);
                    WriteInt(buf, pos, a.connect.channelCount);
                    WriteInt(buf, pos, a.connect.incomingBandwidth);
                    WriteInt(buf, pos, a.connect.outgoingBandwidth);
                    WriteInt(buf, pos, a.connect.packetThrottleInterval);
                    WriteInt(buf, pos, a.connect.packetThrottleAcceleration);
                    WriteInt(buf, pos, a.connect.packetThrottleDeceleration);
                    WriteInt(buf, pos, a.connect.connectID);
                    break;
                }
            case ENet.ENET_PROTOCOL_COMMAND_DISCONNECT:
                {
                    WriteInt(buf, pos, a.disconnect.data);
                    break;
                }
            case ENet.ENET_PROTOCOL_COMMAND_PING:
                {
                    break;
                }
            case ENet.ENET_PROTOCOL_COMMAND_SEND_RELIABLE:
                {
                    WriteShort(buf, pos, a.sendReliable.dataLength);
                    break;
                }
            case ENet.ENET_PROTOCOL_COMMAND_SEND_UNRELIABLE:
                {
                    WriteShort(buf, pos, a.sendUnreliable.unreliableSequenceNumber);
                    WriteShort(buf, pos, a.sendUnreliable.dataLength);
                    break;
                }
            case ENet.ENET_PROTOCOL_COMMAND_SEND_FRAGMENT:
            case ENet.ENET_PROTOCOL_COMMAND_SEND_UNRELIABLE_FRAGMENT:
                {
                    WriteShort(buf, pos, a.sendFragment.startSequenceNumber);
                    WriteShort(buf, pos, a.sendFragment.dataLength);
                    WriteInt(buf, pos, a.sendFragment.fragmentCount);
                    WriteInt(buf, pos, a.sendFragment.fragmentNumber);
                    WriteInt(buf, pos, a.sendFragment.totalLength);
                    WriteInt(buf, pos, a.sendFragment.fragmentOffset);
                    break;
                }
            case ENet.ENET_PROTOCOL_COMMAND_SEND_UNSEQUENCED:
                {
                    WriteShort(buf, pos, a.sendUnsequenced.unsequencedGroup);
                    WriteShort(buf, pos, a.sendUnsequenced.dataLength);
                    break;
                }
            case ENet.ENET_PROTOCOL_COMMAND_BANDWIDTH_LIMIT:
                {
                    WriteInt(buf, pos, a.bandwidthLimit.incomingBandwidth);
                    WriteInt(buf, pos, a.bandwidthLimit.outgoingBandwidth);
                    break;
                }
            case ENet.ENET_PROTOCOL_COMMAND_THROTTLE_CONFIGURE:
                {
                    WriteInt(buf, pos, a.throttleConfigure.packetThrottleInterval);
                    WriteInt(buf, pos, a.throttleConfigure.packetThrottleAcceleration);
                    WriteInt(buf, pos, a.throttleConfigure.packetThrottleDeceleration);
                    break;
                }
        }
    }

    void WriteByte(byte[] data, int[] pos, int value)
    {
        int pos_ = pos[0];
        data[pos_] = ToByte(value);
        pos[0] += 1;
    }

    void WriteShort(byte[] data, int[] pos, int value)
    {
        int pos_ = pos[0];
        data[pos_] = ToByte(value & 0xFF);
        data[pos_ + 1] = ToByte((value >> 8) & 0xFF);
        pos[0] += 2;
    }

    void WriteInt(byte[] data, int[] pos, int n)
    {
        int pos_ = pos[0];
        data[pos_ + 3] = ToByte((n >> 24) & 0xFF);
        data[pos_ + 2] = ToByte((n >> 16) & 0xFF);
        data[pos_ + 1] = ToByte((n >> 8) & 0xFF);
        data[pos_ + 0] = ToByte(n & 0xFF);
        pos[0] += 4;
    }

    byte ReadByte(byte[] currentData, int currentDataI)
    {
        return currentData[currentDataI];
    }

    int commandError(ENetEvent event_)
    {
        if (event_ != null && event_.type != ENetEventType.ENET_EVENT_TYPE_NONE)
            return 1;

        return 0;
    }

    ENetProtocolHeader Deserialize(byte[] a)
    {
        ENetProtocolHeader h = new ENetProtocolHeader();
        h.peerID = ReadShort(a, 0);
        h.sentTime = ReadShort(a, 2);
        return h;
    }

    ushort ReadShort(byte[] readBuf, int readPos)
    {
        int n = readBuf[readPos + 1] << 8;
        n |= readBuf[readPos + 0];
        readPos += 2;
        return p.IntToUshort(n);
    }

    int ReadInt(byte[] readBuf, int readPos)
    {
        int n = readBuf[readPos + 3] << 24;
        n |= readBuf[readPos + 2] << 16;
        n |= readBuf[readPos + 1] << 8;
        n |= readBuf[readPos + 0];
        return n;
    }

    public int
    enet_protocol_receive_incoming_commands(ENetHost host, ENetEvent event_)
    {
        for (; ; )
        {
            int receivedLength;
            ENetBuffer buffer = new ENetBuffer();

            buffer.data = host.packetData[0];
            buffer.dataLength = ENetHost.packetData0SizeOf;
            ENetBuffer[] buffers = new ENetBuffer[1];
            buffers[0] = buffer;

            receivedLength = p.enet_socket_receive(host.socket,
                                                   host.receivedAddress,
                                                    buffers,
                                                  1);

            if (receivedLength < 0)
                return -1;

            if (receivedLength == 0)
                return 0;

            host.receivedData = host.packetData[0];
            host.receivedDataLength = receivedLength;

            host.totalReceivedData += receivedLength;
            host.totalReceivedPackets++;

            if (host.intercept != null)
            {
                switch (host.intercept.Run(host, event_))
                {
                    case 1:
                        if (event_ != null && event_.type != ENetEventType.ENET_EVENT_TYPE_NONE)
                            return 1;

                        continue;

                    case -1:
                        return -1;

                    default:
                        break;
                }
            }

            switch (enet_protocol_handle_incoming_commands(host, event_))
            {
                case 1:
                    return 1;

                case -1:
                    return -1;

                default:
                    break;
            }
        }

        //return -1;
    }

    void
    enet_protocol_send_acknowledgements(ENetHost host, ENetPeer peer)
    {
        int commandI = host.commandCount;
        int bufferI = host.bufferCount;
        ENetAcknowledgement acknowledgement;
        ENetListNode currentAcknowledgement;
        ushort reliableSequenceNumber;

        currentAcknowledgement = enet_list_begin(peer.acknowledgements);

        while (currentAcknowledgement != enet_list_end(peer.acknowledgements))
        {
            if (commandI >= ENetHost.commandsMaxCount ||
                bufferI >= ENetHost.buffersMaxCount ||
                peer.mtu - host.packetSize < ENetProtocolAcknowledge.SizeOf)
            {
                host.continueSending = 1;

                break;
            }

            acknowledgement = p.CastToENetAcknowledgement(currentAcknowledgement);

            currentAcknowledgement = enet_list_next(currentAcknowledgement);

            if (test1 == 1)
            {
            }
            reliableSequenceNumber = ENET_HOST_TO_NET_16(acknowledgement.command.header.reliableSequenceNumber);

            host.commands[commandI].header.command = ENET_PROTOCOL_COMMAND_ACKNOWLEDGE;
            host.commands[commandI].header.channelID = acknowledgement.command.header.channelID;
            host.commands[commandI].header.reliableSequenceNumber = reliableSequenceNumber;
            host.commands[commandI].acknowledge = new ENetProtocolAcknowledge();
            host.commands[commandI].acknowledge.receivedReliableSequenceNumber = reliableSequenceNumber;
            host.commands[commandI].acknowledge.receivedSentTime = ENET_HOST_TO_NET_16(p.IntToUshort(acknowledgement.sentTime));

            byte[] buf = new byte[128]; // ENetProtocolAcknowledge.SizeOf];
            SerializeCommand(buf, host.commands[commandI]);
            host.buffers[bufferI].data = buf;
            host.buffers[bufferI].dataLength = ENetProtocolAcknowledge.SizeOf;

            host.packetSize += host.buffers[bufferI].dataLength;

            if ((acknowledgement.command.header.command & ENET_PROTOCOL_COMMAND_MASK) == ENET_PROTOCOL_COMMAND_DISCONNECT)
                enet_protocol_dispatch_state(host, peer, ENetPeerState.ENET_PEER_STATE_ZOMBIE);

            enet_list_remove(acknowledgement.acknowledgementList());
#if CITO
       delete acknowledgement;
#endif

            commandI++;
            bufferI++;
        }

        host.commandCount = commandI;
        host.bufferCount = bufferI;
    }

    public void
    enet_protocol_send_unreliable_outgoing_commands(ENetHost host, ENetPeer peer)
    {
        //    ENetProtocol * command = & host . commands [host . commandCount];
        //    ENetBuffer * buffer = & host . buffers [host . bufferCount];
        //    ENetOutgoingCommand * outgoingCommand;
        //    ENetListIterator currentCommand;

        //    currentCommand = enet_list_begin (& peer . outgoingUnreliableCommands);

        //    while (currentCommand != enet_list_end (& peer . outgoingUnreliableCommands))
        //    {
        //       size_t commandSize;

        //       outgoingCommand = (ENetOutgoingCommand *) currentCommand;
        //       commandSize = commandSizes [outgoingCommand . command.header.command & ENET_PROTOCOL_COMMAND_MASK];

        //       if (command >= & host . commands [sizeof (host . commands) / sizeof (ENetProtocol)] ||
        //           buffer + 1 >= & host . buffers [sizeof (host . buffers) / sizeof (ENetBuffer)] ||
        //           peer . mtu - host . packetSize < commandSize ||
        //           (outgoingCommand . packet != null &&
        //             peer . mtu - host . packetSize < commandSize + outgoingCommand . fragmentLength))
        //       {
        //          host . continueSending = 1;

        //          break;
        //       }

        //       currentCommand = enet_list_next (currentCommand);

        //       if (outgoingCommand . packet != null && outgoingCommand . fragmentOffset == 0)
        //       {
        //          peer . packetThrottleCounter += ENET_PEER_PACKET_THROTTLE_COUNTER;
        //          peer . packetThrottleCounter %= ENET_PEER_PACKET_THROTTLE_SCALE;

        //          if (peer . packetThrottleCounter > peer . packetThrottle)
        //          {
        //             enet_uint16 reliableSequenceNumber = outgoingCommand . reliableSequenceNumber,
        //                         unreliableSequenceNumber = outgoingCommand . unreliableSequenceNumber;
        //             for (;;)
        //             {
        //                -- outgoingCommand . packet . referenceCount;

        //                if (outgoingCommand . packet . referenceCount == 0)
        //                  enet_packet_destroy (outgoingCommand . packet);

        //                enet_list_remove (& outgoingCommand . outgoingCommandList);
        //                enet_free (outgoingCommand);

        //                if (currentCommand == enet_list_end (& peer . outgoingUnreliableCommands))
        //                  break;

        //                outgoingCommand = (ENetOutgoingCommand *) currentCommand;
        //                if (outgoingCommand . reliableSequenceNumber != reliableSequenceNumber ||
        //                    outgoingCommand . unreliableSequenceNumber != unreliableSequenceNumber)
        //                  break;

        //                currentCommand = enet_list_next (currentCommand);
        //             }

        //             continue;
        //          }
        //       }

        //       buffer . data = command;
        //       buffer . dataLength = commandSize;

        //       host . packetSize += buffer . dataLength;

        //       * command = outgoingCommand . command;

        //       enet_list_remove (& outgoingCommand . outgoingCommandList);

        //       if (outgoingCommand . packet != null)
        //       {
        //          ++ buffer;

        //          buffer . data = outgoingCommand . packet . data + outgoingCommand . fragmentOffset;
        //          buffer . dataLength = outgoingCommand . fragmentLength;

        //          host . packetSize += buffer . dataLength;

        //          enet_list_insert (enet_list_end (& peer . sentUnreliableCommands), outgoingCommand);
        //       }
        //       else
        //         enet_free (outgoingCommand);

        //       ++ command;
        //       ++ buffer;
        //    } 

        //    host . commandCount = command - host . commands;
        //    host . bufferCount = buffer - host . buffers;

        //    if (peer . state ==ENetPeerState.ENET_PEER_STATE_DISCONNECT_LATER && 
        //        enet_list_empty (& peer . outgoingReliableCommands) &&
        //        enet_list_empty (& peer . outgoingUnreliableCommands) && 
        //        enet_list_empty (& peer . sentReliableCommands))
        //      enet_peer_disconnect (peer, peer . eventData);
    }

    public int
    enet_protocol_check_timeouts(ENetHost host, ENetPeer peer, ENetEvent event_)
    {
        ENetOutgoingCommand outgoingCommand = null;
        ENetListNode currentCommand;
        ENetListNode insertPosition;

        currentCommand = enet_list_begin(peer.sentReliableCommands);
        insertPosition = enet_list_begin(peer.outgoingReliableCommands);

        while (currentCommand != enet_list_end(peer.sentReliableCommands))
        {
            outgoingCommand = p.CastToENetOutgoingCommand(currentCommand);

            currentCommand = enet_list_next(currentCommand);

            if (ENET_TIME_DIFFERENCE(host.serviceTime, outgoingCommand.sentTime) < outgoingCommand.roundTripTimeout)
                continue;

            if (peer.earliestTimeout == 0 ||
                ENET_TIME_LESS(outgoingCommand.sentTime, peer.earliestTimeout))
                peer.earliestTimeout = outgoingCommand.sentTime;

            if (peer.earliestTimeout != 0 &&
                  (ENET_TIME_DIFFERENCE(host.serviceTime, peer.earliestTimeout) >= peer.timeoutMaximum ||
                    (outgoingCommand.roundTripTimeout >= outgoingCommand.roundTripTimeoutLimit &&
                      ENET_TIME_DIFFERENCE(host.serviceTime, peer.earliestTimeout) >= peer.timeoutMinimum)))
            {
                enet_protocol_notify_disconnect(host, peer, event_);

                return 1;
            }

            if (outgoingCommand.packet != null)
                peer.reliableDataInTransit -= outgoingCommand.fragmentLength;

            peer.packetsLost++;

            outgoingCommand.roundTripTimeout *= 2;

            enet_list_insert(insertPosition, enet_list_remove(outgoingCommand.outgoingCommandList()));

            if (currentCommand == enet_list_begin(peer.sentReliableCommands) &&
                !enet_list_empty(peer.sentReliableCommands))
            {
                outgoingCommand = p.CastToENetOutgoingCommand(currentCommand);

                peer.nextTimeout = outgoingCommand.sentTime + outgoingCommand.roundTripTimeout;
            }
        }

        return 0;
    }

    public int
    enet_protocol_send_reliable_outgoing_commands(ENetHost host, ENetPeer peer)
    {
        //ENetProtocol commandI = host.commands[host.commandCount];
        //ENetBuffer bufferI = host.buffers[host.bufferCount];
        int commandI = host.commandCount;
        int bufferI = host.bufferCount;
        ENetOutgoingCommand outgoingCommand;
        ENetListNode currentCommand;
        ENetChannel channel;
        ushort reliableWindow;
        int commandSize;
        int windowExceeded = 0;
        int windowWrap = 0;
        int canPing = 1;

        currentCommand = enet_list_begin(peer.outgoingReliableCommands);
        if (test1 == 1)
        {
            test1 = test1;
        }
        while (currentCommand != enet_list_end(peer.outgoingReliableCommands))
        {
            outgoingCommand = p.CastToENetOutgoingCommand(currentCommand);

            channel = outgoingCommand.command.header.channelID < peer.channelCount ? peer.channels[outgoingCommand.command.header.channelID] : null;
            reliableWindow = p.IntToUshort(outgoingCommand.reliableSequenceNumber / ENET_PEER_RELIABLE_WINDOW_SIZE);
            if (channel != null)
            {
                if ((windowWrap == 0) &&
                    outgoingCommand.sendAttempts < 1 &&
                    ((outgoingCommand.reliableSequenceNumber % ENET_PEER_RELIABLE_WINDOW_SIZE) == 0) &&
                    (channel.reliableWindows[(reliableWindow + ENET_PEER_RELIABLE_WINDOWS - 1) % ENET_PEER_RELIABLE_WINDOWS] >= ENET_PEER_RELIABLE_WINDOW_SIZE ||
                      ((channel.usedReliableWindows & ((((1 << ENET_PEER_FREE_RELIABLE_WINDOWS) - 1) << reliableWindow) |
                        (((1 << ENET_PEER_FREE_RELIABLE_WINDOWS) - 1) >> (ENET_PEER_RELIABLE_WINDOW_SIZE - reliableWindow)))) != 0)))
                    windowWrap = 1;
                if (windowWrap != 0)
                {
                    currentCommand = enet_list_next(currentCommand);

                    continue;
                }
            }

            if (outgoingCommand.packet != null)
            {
                if (windowExceeded == 0)
                {
                    int windowSize = (peer.packetThrottle * peer.windowSize) / ENET_PEER_PACKET_THROTTLE_SCALE;

                    if (peer.reliableDataInTransit + outgoingCommand.fragmentLength > ENET_MAX(windowSize, peer.mtu))
                        windowExceeded = 1;
                }
                if (windowExceeded != 0)
                {
                    currentCommand = enet_list_next(currentCommand);

                    continue;
                }
            }

            canPing = 0;

            commandSize = commandSizes[outgoingCommand.command.header.command & ENET_PROTOCOL_COMMAND_MASK];
            if (commandI > host.commandCount ||
                bufferI > host.bufferCount ||
                peer.mtu - host.packetSize < commandSize ||
                (outgoingCommand.packet != null &&
                  ToUint16(peer.mtu - host.packetSize) < ToUint16(commandSize + outgoingCommand.fragmentLength)))
            {
                host.continueSending = 1;

                break;
            }

            currentCommand = enet_list_next(currentCommand);

            if (channel != null && outgoingCommand.sendAttempts < 1)
            {
                channel.usedReliableWindows |= 1 << reliableWindow;
                channel.reliableWindows[reliableWindow]++;
            }

            outgoingCommand.sendAttempts++;

            if (outgoingCommand.roundTripTimeout == 0)
            {
                outgoingCommand.roundTripTimeout = peer.roundTripTime + 4 * peer.roundTripTimeVariance;
                outgoingCommand.roundTripTimeoutLimit = peer.timeoutLimit * outgoingCommand.roundTripTimeout;
            }

            if (enet_list_empty(peer.sentReliableCommands))
                peer.nextTimeout = host.serviceTime + outgoingCommand.roundTripTimeout;

            enet_list_insert(enet_list_end(peer.sentReliableCommands),
                              enet_list_remove(outgoingCommand.outgoingCommandList()));

            outgoingCommand.sentTime = host.serviceTime;

            ENetProtocol command = outgoingCommand.command;
            host.commands[commandI] = command; // ?

            host.buffers[bufferI].data = new byte[commandSize];
            SerializeCommand(host.buffers[bufferI].data, host.commands[commandI]);
            host.buffers[bufferI].dataLength = commandSize;

            host.packetSize += host.buffers[bufferI].dataLength;
            host.headerFlags |= ENET_PROTOCOL_HEADER_FLAG_SENT_TIME;

            if (outgoingCommand.packet != null)
            {
                bufferI++;

                //host.buffers[bufferI].data = outgoingCommand.packet.data + outgoingCommand.fragmentOffset;
                //todo: pass offset
                byte[] data = new byte[outgoingCommand.packet.dataLength];
                for (int i = 0; i < outgoingCommand.packet.dataLength - outgoingCommand.fragmentOffset; i++)
                {
                    data[i] = outgoingCommand.packet.data[i + outgoingCommand.fragmentOffset];
                }
                host.buffers[bufferI].data = data;
                host.buffers[bufferI].dataLength = outgoingCommand.fragmentLength;

                host.packetSize += outgoingCommand.fragmentLength;

                peer.reliableDataInTransit += outgoingCommand.fragmentLength;
            }

            peer.packetsSent++;

            commandI++;
            bufferI++;
        }

        host.commandCount = commandI;//command - host.commands;
        host.bufferCount = bufferI;//buffer - host.buffers;

        return canPing;
    }

    int ToUint16(int a)
    {
        return p.IntToUshort(a);
    }

    public int
    enet_protocol_send_outgoing_commands(ENetHost host, ENetEvent event_, int checkForTimeouts)
    {
        byte[] headerData = new byte[ENetProtocolHeader.SizeOf + 4];
        ENetProtocolHeader header = new ENetProtocolHeader();
        ENetPeer currentPeer;
        int sentLength;
        int shouldCompress = 0;

        host.continueSending = 1;

        while (host.continueSending != 0)
        {
            host.continueSending = 0;
            //for (host . continueSending = 0,
            //currentPeer = host . peers;
            //currentPeer < & host . peers [host . peerCount];
            //++ currentPeer)
            for (int i = 0; i < host.peerCount; i++)
            {
                if (test1 == 1)
                {
                }
                currentPeer = host.peers[i];

                if (currentPeer.state == ENetPeerState.ENET_PEER_STATE_DISCONNECTED ||
                    currentPeer.state == ENetPeerState.ENET_PEER_STATE_ZOMBIE)
                    continue;

                host.headerFlags = 0;
                host.commandCount = 0;
                host.bufferCount = 1;
                host.packetSize = ENetProtocolHeader.SizeOf;

                if (!enet_list_empty(currentPeer.acknowledgements))
                    enet_protocol_send_acknowledgements(host, currentPeer);

                if (checkForTimeouts != 0 &&
                    !enet_list_empty(currentPeer.sentReliableCommands) &&
                    ENET_TIME_GREATER_EQUAL(host.serviceTime, currentPeer.nextTimeout) &&
                    enet_protocol_check_timeouts(host, currentPeer, event_) == 1)
                {
                    if (event_ != null && event_.type != ENetEventType.ENET_EVENT_TYPE_NONE)
                        return 1;
                    else
                        continue;
                }

                if ((enet_list_empty(currentPeer.outgoingReliableCommands) ||
                      (enet_protocol_send_reliable_outgoing_commands(host, currentPeer) != 0)) &&
                    enet_list_empty(currentPeer.sentReliableCommands) &&
                    ENET_TIME_DIFFERENCE(host.serviceTime, currentPeer.lastReceiveTime) >= currentPeer.pingInterval &&
                    currentPeer.mtu - host.packetSize >= ENetProtocolPing.SizeOf)
                {
                    enet_peer_ping(currentPeer);
                    enet_protocol_send_reliable_outgoing_commands(host, currentPeer);
                }

                if (!enet_list_empty(currentPeer.outgoingUnreliableCommands))
                    enet_protocol_send_unreliable_outgoing_commands(host, currentPeer);

                if (host.commandCount == 0)
                    continue;

                if (currentPeer.packetLossEpoch == 0)
                    currentPeer.packetLossEpoch = host.serviceTime;
                else
                    if (ENET_TIME_DIFFERENCE(host.serviceTime, currentPeer.packetLossEpoch) >= ENET_PEER_PACKET_LOSS_INTERVAL &&
                        currentPeer.packetsSent > 0)
                    {
                        int packetLoss = currentPeer.packetsLost * ENET_PEER_PACKET_LOSS_SCALE / currentPeer.packetsSent;

#if ENET_DEBUG
#if WIN32
                   //printf (
#else
                   //fprintf (stderr, 
#endif
                   //         "peer %u: %f%%+-%f%% packet loss, %u+-%u ms round trip time, %f%% throttle, %u/%u outgoing, %u/%u incoming\n", currentPeer . incomingPeerID, currentPeer . packetLoss / (float) ENET_PEER_PACKET_LOSS_SCALE, currentPeer . packetLossVariance / (float) ENET_PEER_PACKET_LOSS_SCALE, currentPeer . roundTripTime, currentPeer . roundTripTimeVariance, currentPeer . packetThrottle / (float) ENET_PEER_PACKET_THROTTLE_SCALE, enet_list_size (& currentPeer . outgoingReliableCommands), enet_list_size (& currentPeer . outgoingUnreliableCommands), currentPeer . channels != null ? enet_list_size (& currentPeer . channels . incomingReliableCommands) : 0, currentPeer . channels != null ? enet_list_size (& currentPeer . channels . incomingUnreliableCommands) : 0);
#endif

                        currentPeer.packetLossVariance -= currentPeer.packetLossVariance / 4;

                        if (packetLoss >= currentPeer.packetLoss)
                        {
                            currentPeer.packetLoss += (packetLoss - currentPeer.packetLoss) / 8;
                            currentPeer.packetLossVariance += (packetLoss - currentPeer.packetLoss) / 4;
                        }
                        else
                        {
                            currentPeer.packetLoss -= (currentPeer.packetLoss - packetLoss) / 8;
                            currentPeer.packetLossVariance += (currentPeer.packetLoss - packetLoss) / 4;
                        }

                        currentPeer.packetLossEpoch = host.serviceTime;
                        currentPeer.packetsSent = 0;
                        currentPeer.packetsLost = 0;
                    }

                host.buffers[0].data = headerData;
                if ((host.headerFlags & ENET_PROTOCOL_HEADER_FLAG_SENT_TIME) != 0)
                {
                    header.sentTime = ENET_HOST_TO_NET_16(p.IntToUshort(host.serviceTime & 0xFFFF));

                    host.buffers[0].dataLength = ENetProtocolHeader.SizeOf;
                }
                else
                {
                    //host.buffers.dataLength = (size_t) & ((ENetProtocolHeader*)0).sentTime;
                    host.buffers[0].dataLength = 2;
                }

                shouldCompress = 0;
                if (host.compressor != null)
                {
                    //            size_t originalSize = host . packetSize - sizeof(ENetProtocolHeader),
                    //                   compressedSize = host . compressor.compress (host . compressor.context,
                    //                                        & host . buffers [1], host . bufferCount - 1,
                    //                                        originalSize,
                    //                                        host . packetData [1],
                    //                                        originalSize);
                    //            if (compressedSize > 0 && compressedSize < originalSize)
                    //            {
                    //                host . headerFlags |= ENET_PROTOCOL_HEADER_FLAG_COMPRESSED;
                    //                shouldCompress = compressedSize;
                    //#if ENET_DEBUG_COMPRESS
                    //#if WIN32
                    //           //printf (
                    //#else
                    //           //fprintf (stderr,
                    //#endif
                    //           //         "peer %u: compressed %u . %u (%u%%)\n", currentPeer . incomingPeerID, originalSize, compressedSize, (compressedSize * 100) / originalSize);
                    //#endif
                    //            }
                }

                if (currentPeer.outgoingPeerID < ENET_PROTOCOL_MAXIMUM_PEER_ID)
                    host.headerFlags |= p.IntToUshort(currentPeer.outgoingSessionID << ENET_PROTOCOL_HEADER_SESSION_SHIFT);
                header.peerID = ENET_HOST_TO_NET_16(p.IntToUshort(currentPeer.outgoingPeerID | host.headerFlags));
                SerializeHeader(headerData, header);
                if (host.checksum != null)
                {
                    //enet_uint32 * checksum = (enet_uint32 *) & headerData [host . buffers . dataLength];
                    //* checksum = currentPeer . outgoingPeerID < ENET_PROTOCOL_MAXIMUM_PEER_ID ? currentPeer . connectID : 0;
                    //host . buffers . dataLength += sizeof (enet_uint32);
                    //* checksum = host . checksum (host . buffers, host . bufferCount);
                }

                if (shouldCompress > 0)
                {
                    host.buffers[1].data = host.packetData[1];
                    host.buffers[1].dataLength = shouldCompress;
                    host.bufferCount = 2;
                }

                currentPeer.lastSendTime = host.serviceTime;
                sentLength = p.enet_socket_send(host.socket, currentPeer.address, host.buffers, host.bufferCount);

                enet_protocol_remove_sent_unreliable_commands(currentPeer);

                if (sentLength < 0)
                    return -1;

                host.totalSentData += sentLength;
                host.totalSentPackets++;
            }
        }

        return 0;
    }

    void SerializeHeader(byte[] headerData, ENetProtocolHeader header)
    {
        int[] pos = new int[1];
        pos[0] = 0;
        WriteShort(headerData, pos, header.peerID);
        WriteShort(headerData, pos, header.sentTime);
    }

    /// Sends any queued packets on the host specified to its designated peers.
    ///   @remarks this function need only be used in circumstances where one wishes to send queued packets earlier than in a call to enet_host_service().
    ///    @ingroup host
    public void
    enet_host_flush(
        ///host to flush
        ENetHost host)
    {
        host.serviceTime = p.enet_time_get();

        enet_protocol_send_outgoing_commands(host, null, 0);
    }

    /// Checks for any queued events on the host and dispatches one if available.
    ///    @retval > 0 if an event was dispatched
    ///    @retval 0 if no events are available
    ///    @retval < 0 on failure
    ///    @ingroup host
    public int
    enet_host_check_events(
        /// host to check for events
        ENetHost host,
        /// an event structure where event details will be placed if available
        ENetEvent event_)
    {
        if (event_ == null) return -1;

        event_.type = ENetEventType.ENET_EVENT_TYPE_NONE;
        event_.peer = null;
        event_.packet = null;

        return enet_protocol_dispatch_incoming_commands(host, event_);
    }

    /// Waits for events on the host specified and shuttles packets between the host and its peers.
    /// enet_host_service should be called fairly regularly for adequate performance
    /// @ingroup host
    /// @retval > 0 if an event occurred within the specified time limit
    /// @retval 0 if no event occurred
    /// @retval < 0 on failure
    public int
    enet_host_service(
        ///host to service
        ENetHost host,
        ///an event structure where event details will be placed if one occurs
        /// if event == null then no events will be delivered
        ENetEvent event_,
        ///number of milliseconds that ENet should wait for events
        int timeout)
    {
        int[] waitCondition = new int[1];

        if (event_ != null)
        {
            event_.type = ENetEventType.ENET_EVENT_TYPE_NONE;
            event_.peer = null;
            event_.packet = null;

            switch (enet_protocol_dispatch_incoming_commands(host, event_))
            {
                case 1:
                    return 1;

                case -1:
#if ENET_DEBUG
            perror ("Error dispatching incoming packets");
#endif

                    return -1;

                default:
                    break;
            }
        }

        host.serviceTime = p.enet_time_get();

        timeout += host.serviceTime;

        do
        {
            if (ENET_TIME_DIFFERENCE(host.serviceTime, host.bandwidthThrottleEpoch) >= ENET_HOST_BANDWIDTH_THROTTLE_INTERVAL)
                enet_host_bandwidth_throttle(host);

            switch (enet_protocol_send_outgoing_commands(host, event_, 1))
            {
                case 1:
                    return 1;

                case -1:
#if ENET_DEBUG
          perror ("Error sending outgoing packets");
#endif

                    return -1;

                default:
                    break;
            }

            switch (enet_protocol_receive_incoming_commands(host, event_))
            {
                case 1:
                    return 1;

                case -1:
#if ENET_DEBUG
          perror ("Error receiving incoming packets");
#endif

                    return -1;

                default:
                    break;
            }

            switch (enet_protocol_send_outgoing_commands(host, event_, 1))
            {
                case 1:
                    return 1;

                case -1:
#if ENET_DEBUG
          perror ("Error sending outgoing packets");
#endif

                    return -1;

                default:
                    break;
            }

            if (event_ != null)
            {
                switch (enet_protocol_dispatch_incoming_commands(host, event_))
                {
                    case 1:
                        return 1;

                    case -1:
#if ENET_DEBUG
             perror ("Error dispatching incoming packets");
#endif

                        return -1;

                    default:
                        break;
                }
            }

            do
            {
                host.serviceTime = p.enet_time_get();

                if (ENET_TIME_GREATER_EQUAL(host.serviceTime, timeout))
                    return 0;

                waitCondition[0] = ENET_SOCKET_WAIT_RECEIVE | ENET_SOCKET_WAIT_INTERRUPT;

                if (p.enet_socket_wait(host.socket, waitCondition, ENET_TIME_DIFFERENCE(timeout, host.serviceTime)) != 0)
                    return -1;
            }
            while ((waitCondition[0] & ENET_SOCKET_WAIT_INTERRUPT) != 0);

            host.serviceTime = p.enet_time_get();
        } while ((waitCondition[0] & ENET_SOCKET_WAIT_RECEIVE) != 0);

        return 0;
    }




    int ENET_MAX(int x, int y) { return (x) > (y) ? (x) : (y); }
    int ENET_MIN(int x, int y) { return (x) < (y) ? (x) : (y); }

    const int ENET_TIME_OVERFLOW = 86400000;

    bool ENET_TIME_LESS(int a, int b) { return (a) - (b) < 0; }//>= ENET_TIME_OVERFLOW; }
    bool ENET_TIME_GREATER(int a, int b) { return (b) - (a) < 0; }//>= ENET_TIME_OVERFLOW; }
    bool ENET_TIME_LESS_EQUAL(int a, int b) { return !ENET_TIME_GREATER(a, b); }
    bool ENET_TIME_GREATER_EQUAL(int a, int b) { return !ENET_TIME_LESS(a, b); }

    int ENET_TIME_DIFFERENCE(int a, int b) { return (a) - (b) < 0 ? (b) - (a) : (a) - (b); } //>= ENET_TIME_OVERFLOW


    ushort ENET_HOST_TO_NET_16(ushort a) { return p.ENET_HOST_TO_NET_16(a); }
    int ENET_HOST_TO_NET_32(int a) { return p.ENET_HOST_TO_NET_32(a); }
    ushort ENET_NET_TO_HOST_16(ushort a) { return p.ENET_NET_TO_HOST_16(a); }
    int ENET_NET_TO_HOST_32(int a) { return p.ENET_NET_TO_HOST_32(a); }

    public int enet_initialize()
    {
        return 0;
    }

    public void enet_deinitialize()
    {
    }

    public const int SOCKET_ERROR = -1;
}

public class ENetObject
{
}

public abstract class ENetPlatform
{
    public abstract int time();
    public abstract ENetSocket enet_socket_create(int type);
    public abstract int enet_socket_bind(ENetSocket socket, ENetAddress address);
    public abstract int enet_socket_get_address(ENetSocket socket, ENetAddress address);
    public abstract int enet_socket_listen(ENetSocket socket, int backlog);
    public abstract int enet_socket_accept(ENetSocket socket, ENetAddress address);
    public abstract int enet_socket_connect(ENetSocket socket, ENetAddress address);
    public abstract int enet_socket_send(ENetSocket socket, ENetAddress address, ENetBuffer[] buffers, int bufferCount);
    public abstract int enet_socket_receive(ENetSocket socket, ENetAddress address, ENetBuffer[] buffers, int bufferCount);
    public abstract int enet_socket_wait(ENetSocket socket, int[] condition, int timeout);
    public abstract int enet_socket_set_option(ENetSocket socket, int option, int value);
    public abstract int enet_socket_shutdown(ENetSocket socket, ENetSocketShutdown how);
    public abstract void enet_socket_destroy(ENetSocket socket);
    //enet_socketset_select
    public abstract ushort ENET_HOST_TO_NET_16(ushort p);
    public abstract int ENET_HOST_TO_NET_32(int p);
    public abstract ushort ENET_NET_TO_HOST_16(ushort p);
    public abstract int ENET_NET_TO_HOST_32(int fragmentOffset);
    public abstract int enet_time_get();
    public abstract ENetOutgoingCommand CastToENetOutgoingCommand(ENetObject a);
    public abstract ENetIncomingCommand CastToENetIncomingCommand(ENetObject a);
    public abstract ENetPeer CastToENetPeer(ENetListNode a);
    public abstract ENetListNode CastToENetListNode(ENetObject a);
    public abstract ENetAcknowledgement CastToENetAcknowledgement(ENetListNode a);
    public abstract int enet_address_set_host(ENetAddress address, string hostName);
    public abstract ushort IntToUshort(int p);
}

public class Math
{
    public static bool isLessThanUnsigned(int n1, int n2)
    {
        bool comp = (n1 < n2);
        if ((n1 < 0) != (n2 < 0))
        {
            comp = !comp;
        }
        return comp;
    }
}

public class Byte
{
#if !CITO
    internal
#endif
 byte value;
}


public class ENetSymbol
{
    // binary indexed tree of symbols
#if !CITO
    internal
#endif
 byte value;
#if !CITO
    internal
#endif
 byte count;
#if !CITO
    internal
#endif
 int under;
#if !CITO
    internal
#endif
 int left;
#if !CITO
    internal
#endif
 int right;

    // context defined by this symbol
#if !CITO
    internal
#endif
 int symbols;
#if !CITO
    internal
#endif
 int escapes;
#if !CITO
    internal
#endif
 int total;
#if !CITO
    internal
#endif
 int parent;
}

public class ENetListNode : ENetObject
{
#if !CITO
    internal
#endif
 ENetObject next; //ENetListNode
#if !CITO
    internal
#endif
 ENetObject previous; //ENetListNode


#if !CITO
    internal
#endif
 ENetObject data;
}

public class ENetList : ENetListNode
{
    public ENetList()
    {
        SetSentinel(new ENetListNode());
    }
    //#if !CITO
    //    internal
    //#endif
    // ENetListNode sentinel;
    public ENetObject GetSentinel() { return next; }
    public void SetSentinel(ENetObject value) { next = value; }
}


public class ENetProtocolHeader
{
#if !CITO
    internal
#endif
 ushort peerID;
#if !CITO
    internal
#endif
 ushort sentTime;
    public const int SizeOf = 4;
}

public class ENetProtocolCommandHeader
{
#if !CITO
    internal
#endif
 byte command;
#if !CITO
    internal
#endif
 byte channelID;
#if !CITO
    internal
#endif
 ushort reliableSequenceNumber;

    public const int SizeOf = 4;
}

public class ENetProtocolAcknowledge
{
#if !CITO
    internal
#endif
 ushort receivedReliableSequenceNumber;
#if !CITO
    internal
#endif
 ushort receivedSentTime;
    public const int SizeOf = 8;
}

public class ENetProtocolConnect
{
#if !CITO
    internal
#endif
 ushort outgoingPeerID;
#if !CITO
    internal
#endif
 byte incomingSessionID;
#if !CITO
    internal
#endif
 byte outgoingSessionID;
#if !CITO
    internal
#endif
 int mtu;
#if !CITO
    internal
#endif
 int windowSize;
#if !CITO
    internal
#endif
 int channelCount;
#if !CITO
    internal
#endif
 int incomingBandwidth;
#if !CITO
    internal
#endif
 int outgoingBandwidth;
#if !CITO
    internal
#endif
 int packetThrottleInterval;
#if !CITO
    internal
#endif
 int packetThrottleAcceleration;
#if !CITO
    internal
#endif
 int packetThrottleDeceleration;
#if !CITO
    internal
#endif
 int connectID;
#if !CITO
    internal
#endif
 int data;
}

public class ENetProtocolVerifyConnect
{
#if !CITO
    internal
#endif
 ushort outgoingPeerID;
#if !CITO
    internal
#endif
 byte incomingSessionID;
#if !CITO
    internal
#endif
 byte outgoingSessionID;
#if !CITO
    internal
#endif
 int mtu;
#if !CITO
    internal
#endif
 int windowSize;
#if !CITO
    internal
#endif
 int channelCount;
#if !CITO
    internal
#endif
 int incomingBandwidth;
#if !CITO
    internal
#endif
 int outgoingBandwidth;
#if !CITO
    internal
#endif
 int packetThrottleInterval;
#if !CITO
    internal
#endif
 int packetThrottleAcceleration;
#if !CITO
    internal
#endif
 int packetThrottleDeceleration;
#if !CITO
    internal
#endif
 int connectID;
}

public class ENetProtocolBandwidthLimit
{
#if !CITO
    internal
#endif
 int incomingBandwidth;
#if !CITO
    internal
#endif
 int outgoingBandwidth;
}

public class ENetProtocolThrottleConfigure
{
#if !CITO
    internal
#endif
 int packetThrottleInterval;
#if !CITO
    internal
#endif
 int packetThrottleAcceleration;
#if !CITO
    internal
#endif
 int packetThrottleDeceleration;
}

public class ENetProtocolDisconnect
{
#if !CITO
    internal
#endif
 int data;
}

public class ENetProtocolPing
{
    public const int SizeOf = ENetProtocolCommandHeader.SizeOf;
}

public class ENetProtocolSendReliable
{
#if !CITO
    internal
#endif
 ushort dataLength;
    public const int SizeOf = 6;
}

public class ENetProtocolSendUnreliable
{
#if !CITO
    internal
#endif
 ushort unreliableSequenceNumber;
#if !CITO
    internal
#endif
 ushort dataLength;
    public const int SizeOf = 12;
}

public class ENetProtocolSendUnsequenced
{
#if !CITO
    internal
#endif
 ushort unsequencedGroup;
#if !CITO
    internal
#endif
 ushort dataLength;
}

public class ENetProtocolSendFragment
{
#if !CITO
    internal
#endif
 ushort startSequenceNumber;
#if !CITO
    internal
#endif
 ushort dataLength;
#if !CITO
    internal
#endif
 int fragmentCount;
#if !CITO
    internal
#endif
 int fragmentNumber;
#if !CITO
    internal
#endif
 int totalLength;
#if !CITO
    internal
#endif
 int fragmentOffset;

    public const int SizeOf = ENetProtocolCommandHeader.SizeOf + 24;
}

public class ENetProtocol
{
    public ENetProtocol()
    {
        header = new ENetProtocolCommandHeader();
    }
#if !CITO
    internal
#endif
 ENetProtocolCommandHeader header;
#if !CITO
    internal
#endif
 ENetProtocolAcknowledge acknowledge;
#if !CITO
    internal
#endif
 ENetProtocolConnect connect;
#if !CITO
    internal
#endif
 ENetProtocolVerifyConnect verifyConnect;
#if !CITO
    internal
#endif
 ENetProtocolDisconnect disconnect;
#if !CITO
    internal
#endif
 ENetProtocolPing ping;
#if !CITO
    internal
#endif
 ENetProtocolSendReliable sendReliable;
#if !CITO
    internal
#endif
 ENetProtocolSendUnreliable sendUnreliable;
#if !CITO
    internal
#endif
 ENetProtocolSendUnsequenced sendUnsequenced;
#if !CITO
    internal
#endif
 ENetProtocolSendFragment sendFragment;
#if !CITO
    internal
#endif
 ENetProtocolBandwidthLimit bandwidthLimit;
#if !CITO
    internal
#endif
 ENetProtocolThrottleConfigure throttleConfigure;
#if !CITO
    internal
#endif
 byte[] data;
}
