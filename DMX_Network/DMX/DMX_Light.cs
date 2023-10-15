using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DMX_Network.DMX
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

        public override void Reset()
        {
            Red = 0;
            Green = 0;
            Blue = 0;
            White = 0;
            Amber = 0;
            UV = 0;
        }

        public void SetFromRGBColorCode(string color_code)
        {
            System.Drawing.Color color = ColorTranslator.FromHtml(color_code);
            Red = Convert.ToByte(color.R);
            Green = Convert.ToByte(color.G);
            Blue = Convert.ToByte(color.B);
        }

        public void SetFromRGB(byte r, byte g, byte b)
        {
            Red = Convert.ToByte(r);
            Green = Convert.ToByte(g);
            Blue = Convert.ToByte(b);
        }

        public string GetRGBColorCode()
        {
            System.Drawing.Color color = GetRGBColor();
            return ColorTranslator.ToHtml(color);
        }

        public System.Windows.Media.Color GetWindowsRGBColor()
        {
            System.Drawing.Color color = GetRGBColor();
            System.Windows.Media.Color newColor = System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B);
            return newColor;
        }

        public System.Drawing.Color GetRGBColor()
        {
            //All color code logic exists in this function
            if (White > 0)
            {
                return System.Drawing.Color.FromArgb(Math.Min((byte)255, White), 192, 192, 192);
            }
            else if (Amber > 0)
            {
                return System.Drawing.Color.FromArgb(Math.Min((byte)255, Amber), 255, 255, 33);
            }
            else if (UV > 0)
            {
                return System.Drawing.Color.FromArgb(Math.Min((byte)255, UV), 229, 204, 255);
            }
            else
            {
                return System.Drawing.Color.FromArgb(255, Red, Green, Blue);
            }
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
