using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMX_Network.DMX.DMX_Sequences
{
    internal class DMX_Sequence_AllSineRGB : DMX_Sequence_Interface
    {
        public DMX_Sequence_AllSineRGB(List<DMX_Light> dmx_lights, double update_dt)
        {
            name = "Fixed Position Sine";
            dmxLights = dmx_lights;
            updateDt = update_dt;
            amplitude = 255;
            freq = 0.2;
            numColors = 3;
            phase = 1 / (freq * numColors);
        }

        public override bool Run()
        {
            double t = updateDt * counter++;

            double cmd0 = (1 - Math.Cos(2 * Math.PI * freq * (t + phase * 0))) / 2;
            double cmd1 = (1 - Math.Cos(2 * Math.PI * freq * (t + phase * 1))) / 2;
            double cmd2 = (1 - Math.Cos(2 * Math.PI * freq * (t + phase * 2))) / 2;

            byte red = (byte)(amplitude * cmd0);
            byte green = (byte)(amplitude * cmd1);
            byte blue = (byte)(amplitude * cmd2);

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

        int counter;

        double updateDt;
        double amplitude;
        double freq;
        double numColors;
        double phase;

    }
}
