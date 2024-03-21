using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLNoCGen
{
    internal interface IWestFirst
    {
        List<List<int>> Generate_westFirst_routing();
    }
}
