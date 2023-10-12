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

            dmxController = new DMX_Controller();

            dmxLight1 = new DMX_Light("Light 1", 10);
            dmxLight2 = new DMX_Light("Light 2", 20);
            dmxLight3 = new DMX_Light("Light 3", 30);
            dmxLight4 = new DMX_Light("Light 4", 40);
            dmxLight5 = new DMX_Light("Light 5", 50);
            dmxLight6 = new DMX_Light("Light 6", 60);

            dmxController.AddDmxNode(dmxLight1);
            dmxController.AddDmxNode(dmxLight2);
            dmxController.AddDmxNode(dmxLight3);
            dmxController.AddDmxNode(dmxLight4);
            dmxController.AddDmxNode(dmxLight5);
            dmxController.AddDmxNode(dmxLight6);
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

            DateTime timeStart = DateTime.Now;

            while (true)
            {
                float dt = (DateTime.Now.Ticks - timeStart.Ticks) / 10000000f;

                double amplitude = 255;
                double freq = 0.5;
                double numLights = 6;
                double phase = 1 / (freq * numLights);

                byte cmd1 = (byte)((amplitude / 2) * Math.Sin(2 * Math.PI * freq * (dt + (phase * 0))) + amplitude / 2);
                byte cmd2 = (byte)((amplitude / 2) * Math.Sin(2 * Math.PI * freq * (dt + (phase * 1))) + amplitude / 2);
                byte cmd3 = (byte)((amplitude / 2) * Math.Sin(2 * Math.PI * freq * (dt + (phase * 2))) + amplitude / 2);
                byte cmd4 = (byte)((amplitude / 2) * Math.Sin(2 * Math.PI * freq * (dt + (phase * 3))) + amplitude / 2);
                byte cmd5 = (byte)((amplitude / 2) * Math.Sin(2 * Math.PI * freq * (dt + (phase * 4))) + amplitude / 2);
                byte cmd6 = (byte)((amplitude / 2) * Math.Sin(2 * Math.PI * freq * (dt + (phase * 5))) + amplitude / 2);

                int routine = 2;

                switch(routine)
                {
                    case 0:
                        break;
                    case 1:
                        dmxLight1.Red = cmd1;
                        dmxLight2.Green = cmd2;
                        dmxLight3.Blue = cmd3;
                        dmxLight4.White = cmd4;
                        dmxLight5.Amber = cmd5;
                        dmxLight6.UV = cmd6;
                        break;
                    case 2:
                        dmxLight1.UV = cmd1;
                        dmxLight2.UV = cmd2;
                        dmxLight3.UV = cmd3;
                        dmxLight4.UV = cmd4;
                        dmxLight5.UV = cmd5;
                        dmxLight6.UV = cmd6;
                        break;
                }

                dmxController.SendDmxArtNetMsg();
                System.Threading.Thread.Sleep(100);
            }
        }

        DMX_Controller dmxController;

        DMX_Light dmxLight1;
        DMX_Light dmxLight2;
        DMX_Light dmxLight3;
        DMX_Light dmxLight4;
        DMX_Light dmxLight5;
        DMX_Light dmxLight6;
    }
}
