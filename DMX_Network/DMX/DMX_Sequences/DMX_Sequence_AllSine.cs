using System;
using System.Collections.Generic;
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
            updateDt = update_dt;
            amplitude = 255;
            freq = 0.1;
            numColors = 3;
            phase = 1 / (freq * numColors);

            colorCodes = new List<int>();
            colorCodes.Add(0x0000ff);
            colorCodes.Add(0x00ff00);
            colorCodes.Add(0xff0000);
        }

        public override bool Run()
        {
            double t = updateDt * counter++;

            byte red = (byte)(amplitude / 2 * Math.Sin(2 * Math.PI * freq * (t + phase * 0)) + amplitude / 2);
            byte green = (byte)(amplitude / 2 * Math.Sin(2 * Math.PI * freq * (t + phase * 1)) + amplitude / 2);
            byte blue = (byte)(amplitude / 2 * Math.Sin(2 * Math.PI * freq * (t + phase * 2)) + amplitude / 2);

            dmxLights[0].SetFromRGB(red, green, blue);
            dmxLights[1].SetFromRGB(red, green, blue);
            dmxLights[2].SetFromRGB(red, green, blue);
            dmxLights[3].SetFromRGB(red, green, blue);
            dmxLights[4].SetFromRGB(red, green, blue);
            dmxLights[5].SetFromRGB(red, green, blue);

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
        List<int> colorCodes;

        int counter;

        double updateDt;
        double amplitude;
        double freq;
        double numColors;
        double phase;

    }
}
