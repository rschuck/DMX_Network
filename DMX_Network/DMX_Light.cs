using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMX_Network
{
    public class DMX_Light : DXM_Interface
    {
        public DMX_Light(string name, byte address) 
        {
            Name = name;
            Address = address;
            Reset();
        }

        public override bool InsertData(List<byte> data)
        {
            //SHEDS Lights are not zero indexed
            data[Address - 1] = Red;
            data[Address + 0] = Green;
            data[Address + 1] = Blue;
            data[Address + 2] = White;
            data[Address + 3] = Amber;
            data[Address + 4] = UV;
            return true; 
        }

        public void Reset ()
        {
            Red = 0;
            Green = 0;
            Blue = 0;
            White = 0;
            Amber = 0;
            UV = 0;
        }

        public string Name { get; set; }

        public byte Address { get; set; }

        public byte Red { get; set; }
        public byte Green { get; set; }
        public byte Blue { get; set; }
        public byte White { get; set; }
        public byte Amber { get; set; }
        public byte UV { get; set; }

    }
}
