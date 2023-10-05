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
            Red = 0;
            Green = 0;
            Blue = 0;
            White = 0;
            Amber = 0;
            UV = 0;
        }

        public override bool InsertData(List<byte> data)
        {
            //data.Insert(Address, Red);
            //data.Insert(Address+1, Green);
            //data.Insert(Address+2, Blue);
            //data.Insert(Address+3, White);
            //data.Insert(Address+4, Amber);
            //data.Insert(Address+5, UV);

            data[Address] = Red;
            data[Address + 1] = Green;
            data[Address + 2] = Blue;
            data[Address + 3] = White;
            data[Address + 4] = Amber;
            data[Address + 5] = UV;
            return true; 
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
