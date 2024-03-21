using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLNoCGen
{
    internal interface IRoundLike
    {
        int Calculate_diameter();

        List<List<int>> Generate_ROU_routing();

        List<List<int>> Generate_APO_routing();

        List<List<int>> Generate_APM_routing();

        List<List<int>> Generate_AAO_routing();

        List<List<int>> Generate_Simple_routing();

        double Calculate_efficiency_simple();

        double Calculate_efficiency_ROU();

        double Calculate_efficiency_APM();

        double Calculate_efficiency_APO();
    }
}
