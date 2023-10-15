using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Ink;
using DMX_Network.DMX;

namespace DMX_Network.DMX.DMX_Sequences
{
    public class DMX_Sequence_FixedPos_Sine : DMX_Sequence_Interface
    {
        public DMX_Sequence_FixedPos_Sine(List<DMX_Light> dmx_lights, double update_dt)
        {
            name = "Fixed Position Sine";
            dmxLights = dmx_lights;
            updateDt = update_dt;
            amplitude = 255;
            freq = 1;
            numLights = 6;
            phase = 1 / (freq * numLights);
        }

        public override bool Run()
        {
            double t = updateDt * counter++;

            double cmd0 = (1 - Math.Cos(2 * Math.PI * freq * (t + phase * 0))) / 2;
            double cmd1 = (1 - Math.Cos(2 * Math.PI * freq * (t + phase * 1))) / 2;
            double cmd2 = (1 - Math.Cos(2 * Math.PI * freq * (t + phase * 2))) / 2;
            double cmd3 = (1 - Math.Cos(2 * Math.PI * freq * (t + phase * 3))) / 2;
            double cmd4 = (1 - Math.Cos(2 * Math.PI * freq * (t + phase * 4))) / 2;
            double cmd5 = (1 - Math.Cos(2 * Math.PI * freq * (t + phase * 5))) / 2;

            int routine = 1;

            switch (routine)
            {
                case 0:
                    dmxLights[0].Reset();
                    dmxLights[1].Reset();
                    dmxLights[2].Reset();
                    dmxLights[3].Reset();
                    dmxLights[4].Reset();
                    dmxLights[5].Reset();
                    break;
                case 1:
                    dmxLights[0].Red = (byte)(amplitude * cmd0);
                    dmxLights[1].Green = (byte)(amplitude * cmd1);
                    dmxLights[2].Blue = (byte)(amplitude * cmd2);
                    dmxLights[3].White = (byte)(amplitude * cmd3);
                    dmxLights[4].Amber = (byte)(amplitude * cmd4);
                    dmxLights[5].UV = (byte)(amplitude * cmd5);
                    break;
                case 2:
                    dmxLights[0].UV = (byte)(amplitude * cmd0); ;
                    dmxLights[1].UV = (byte)(amplitude * cmd1); ;
                    dmxLights[2].UV = (byte)(amplitude * cmd2); ;
                    dmxLights[3].UV = (byte)(amplitude * cmd3); ;
                    dmxLights[4].UV = (byte)(amplitude * cmd4); ;
                    dmxLights[5].UV = (byte)(amplitude * cmd5); ;
                    break;
            }

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
        double numLights;
        double phase;
    }
}
