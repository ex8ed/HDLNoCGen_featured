using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLNoCGen
{
    internal interface IRectangleLike
    {
        List<List<int>> Generate_XY_routing();

        List<List<int>> Get_ways_routing_XY();

        void createRouterXY(string project_name, string project_path);
    }
}
