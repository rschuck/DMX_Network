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
            freq = 0.5;
            numLights = 6;
            phase = 1 / (freq * numLights);
        }

        public override bool Run()
        {
            double t = updateDt * counter++;

            byte cmd1 = (byte)(amplitude / 2 * Math.Sin(2 * Math.PI * freq * (t + phase * 0)) + amplitude / 2);
            byte cmd2 = (byte)(amplitude / 2 * Math.Sin(2 * Math.PI * freq * (t + phase * 1)) + amplitude / 2);
            byte cmd3 = (byte)(amplitude / 2 * Math.Sin(2 * Math.PI * freq * (t + phase * 2)) + amplitude / 2);
            byte cmd4 = (byte)(amplitude / 2 * Math.Sin(2 * Math.PI * freq * (t + phase * 3)) + amplitude / 2);
            byte cmd5 = (byte)(amplitude / 2 * Math.Sin(2 * Math.PI * freq * (t + phase * 4)) + amplitude / 2);
            byte cmd6 = (byte)(amplitude / 2 * Math.Sin(2 * Math.PI * freq * (t + phase * 5)) + amplitude / 2);

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
                    dmxLights[0].Red = cmd1;
                    dmxLights[1].Green = cmd2;
                    dmxLights[2].Blue = cmd3;
                    dmxLights[3].White = cmd4;
                    dmxLights[4].Amber = cmd5;
                    dmxLights[5].UV = cmd6;
                    break;
                case 2:
                    dmxLights[0].UV = cmd1;
                    dmxLights[1].UV = cmd2;
                    dmxLights[2].UV = cmd3;
                    dmxLights[3].UV = cmd4;
                    dmxLights[4].UV = cmd5;
                    dmxLights[5].UV = cmd6;
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
