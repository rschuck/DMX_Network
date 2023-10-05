using Haukcode.ArtNet.IO;
using Haukcode.ArtNet.Packets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Haukcode.Rdm;

namespace DMX_Network
{
    public class DMX_Controller
    {
        public DMX_Controller()
        {
            dataArray = new List<byte>(dmxMaxNodes);
            for (int x = 0; x < dmxMaxNodes; x++) { dataArray.Insert(x, 0); }

            dmxPacket = new ArtNetDmxPacket();
            stream = new MemoryStream();
            artBinaryWriter = new ArtNetBinaryWriter(stream);

            sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            serverAddr = IPAddress.Parse("192.168.1.144");
            endPoint = new IPEndPoint(serverAddr, 6454);

            dmxNodes = new List<DXM_Interface>(dmxMaxNodes);
        }

        public void SendDmxArtNetMsg()
        {
            stream.SetLength(0);
            stream.Flush();

            dmxPacket.Sequence = msgConter++;


            foreach (DXM_Interface node in dmxNodes)
            {
                node.InsertData()
            }

            dmxPacket.DmxData = dataArray.ToArray();

            dmxPacket.WriteData(artBinaryWriter);
            sock.SendTo(stream.GetBuffer(), endPoint);
        }

        public void AddDmxNodeToList(DXM_Interface node)
        {
            dmxNodes.Add(node);
        }

        const int dmxMaxNodes = 512;

        byte msgConter = 0;

        List<DXM_Interface> dmxNodes;
        List<byte> dataArray;
        public ArtNetDmxPacket dmxPacket;

        MemoryStream stream;
        ArtNetBinaryWriter artBinaryWriter;

        Socket sock;
        IPAddress serverAddr;
        IPEndPoint endPoint;
    }
}
