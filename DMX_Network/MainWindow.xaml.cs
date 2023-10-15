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
using System.Drawing;
using System.Timers;
using System.Threading;
using System.Windows.Threading;
using System.Windows.Media.Media3D;

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
            dmxLights = new List<DMX_Light>();
            dmxSequences = new Dictionary<String, DMX_Sequence_Interface>();

            dmxLights.Add(new DMX_Light("Light 1", 10));
            dmxLights.Add(new DMX_Light("Light 2", 20));
            dmxLights.Add(new DMX_Light("Light 3", 30));
            dmxLights.Add(new DMX_Light("Light 4", 40));
            dmxLights.Add(new DMX_Light("Light 5", 50));
            dmxLights.Add(new DMX_Light("Light 6", 60));

            dmxController.AddDmxNode(dmxLights[0]);
            dmxController.AddDmxNode(dmxLights[1]);
            dmxController.AddDmxNode(dmxLights[2]);
            dmxController.AddDmxNode(dmxLights[3]);
            dmxController.AddDmxNode(dmxLights[4]);
            dmxController.AddDmxNode(dmxLights[5]);

            dmxSequences.Add("Fixed Pos Sine", new DMX_Sequence_FixedPos_Sine(dmxLights, 1/ updateFeq));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DateTime timeStart = DateTime.Now;

            SetTimer();
        }

        void SetTimer()
        {
            timeStart = DateTime.Now;

            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(1000/updateFeq);
            dispatcherTimer.Start();
        }

        void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            float dt = (DateTime.Now.Ticks - timeStart.Ticks) / 10000000f;

            dmxSequences.ElementAt(0).Value.Run();

            Indicator1.Fill = new SolidColorBrush(dmxLights[0].GetWindowsRGBColor());
            Indicator2.Fill = new SolidColorBrush(dmxLights[1].GetWindowsRGBColor());
            Indicator3.Fill = new SolidColorBrush(dmxLights[2].GetWindowsRGBColor());
            Indicator4.Fill = new SolidColorBrush(dmxLights[3].GetWindowsRGBColor());
            Indicator5.Fill = new SolidColorBrush(dmxLights[4].GetWindowsRGBColor());
            Indicator6.Fill = new SolidColorBrush(dmxLights[5].GetWindowsRGBColor());

            dmxController.SendDmxArtNetMsg();
        }

        DMX_Controller dmxController;

        List<DMX_Light> dmxLights;

        Dictionary<String, DMX_Sequence_Interface> dmxSequences;
        DMX_Sequence_FixedPos_Sine dmxSeq_FixedPosSine;

        DateTime timeStart;
        System.Windows.Threading.DispatcherTimer dispatcherTimer;

        double updateFeq = 40;
    }
}
