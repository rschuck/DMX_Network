using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Haukcode.ArtNet.IO;
using Haukcode.ArtNet.Packets;

namespace DMX_Network
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //const int DmxMaxSize = 512;
            //List<byte> dataArray = new List<byte>(DmxMaxSize);
            //for (int x=0; x< DmxMaxSize; x++) { dataArray.Insert(x,0); }

            //DMX_Light light1 = new DMX_Light("First Light", 0);
            //light1.Green = 225;
            //light1.InsertData(dataArray);
            //byte[] bytes = dataArray.ToArray();


            /////////////////////////////////////////////////////////////////////////////

            //ArtNetDmxPacket dmxPacket = new ArtNetDmxPacket();
            //dmxPacket.DmxData = bytes;

            //var stream = new MemoryStream();
            //var artBinaryWriter = new ArtNetBinaryWriter(stream);

            //Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            //IPAddress serverAddr = IPAddress.Parse("192.168.1.144");
            //IPEndPoint endPoint = new IPEndPoint(serverAddr, 6454);

            //stream.SetLength(0);
            //stream.Flush();

            //dmxPacket.Sequence = 0;

            //dmxPacket.WriteData(artBinaryWriter);
            //sock.SendTo(stream.GetBuffer(), endPoint);


        }
    }
}
