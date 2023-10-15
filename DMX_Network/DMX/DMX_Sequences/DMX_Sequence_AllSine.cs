using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMX_Network.DMX.DMX_Sequences
{
    internal class DMX_Sequence_AllSine : DMX_Sequence_Interface
    {
        public DMX_Sequence_AllSine(List<DMX_Light> dmx_lights, double update_dt)
        {
            name = "Fixed Position Sine";
            dmxLights = dmx_lights;
            amplitude = 1;
            freq = 0.2;
            updateDt = update_dt * freq;
            numColors = 3;
            countsToCycleColor = (int)(1/ updateDt);

            colorCodes = new List<string>();
            colorCodes.Add("#0000ff");
            colorCodes.Add("#00ff00");
            colorCodes.Add("#ff0000");
        }

        public override bool Run()
        {
            //double t = updateDt * counter++;

            double t = (double)counter++ / (double)countsToCycleColor;
            int index = (int)(t % colorCodes.Count);

            double cmd = (1 - Math.Cos(2 * Math.PI * t)) / 2;

            System.Drawing.Color color = ColorTranslator.FromHtml(colorCodes[index]);
            dmxLights[0].SetFromRGB((byte)(color.R * cmd), (byte)(color.G * cmd), (byte)(color.B * cmd));
            dmxLights[1].SetFromRGB((byte)(color.R * cmd), (byte)(color.G * cmd), (byte)(color.B * cmd));
            dmxLights[2].SetFromRGB((byte)(color.R * cmd), (byte)(color.G * cmd), (byte)(color.B * cmd));
            dmxLights[3].SetFromRGB((byte)(color.R * cmd), (byte)(color.G * cmd), (byte)(color.B * cmd));
            dmxLights[4].SetFromRGB((byte)(color.R * cmd), (byte)(color.G * cmd), (byte)(color.B * cmd));
            dmxLights[5].SetFromRGB((byte)(color.R * cmd), (byte)(color.G * cmd), (byte)(color.B * cmd));

            return true;
        }

        public override bool Reset()
        {
            foreach (var light in dmxLights)
            {
                light.Reset();
            }
            counter = 0;
            return true;
        }

        List<DMX_Light> dmxLights;
        List<string> colorCodes;

        int counter;

        int countsToCycleColor;

        double updateDt;
        double amplitude;
        double freq;
        double numColors;
        double phase;

    }
}
