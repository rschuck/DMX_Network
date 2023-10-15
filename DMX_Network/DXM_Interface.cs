using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMX_Network
{
    public abstract class DXM_Interface
    {
        public abstract bool InsertData(List<byte> data);

        public abstract void Reset();
    }

    public abstract class DMX_Sequence_Interface
    {
        public abstract bool Run();

        public abstract bool Reset();

        public string name = "n/a";
    }

}
