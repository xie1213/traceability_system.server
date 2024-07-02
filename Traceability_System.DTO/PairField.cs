using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traceability_System.DTO
{
    public class PairField
    {
        Dictionary<string, string> fields { get; set; }
    }

    public class PiarObject
    {
        string pairKey { get; set; }
        public object pairObj { get; set; }
    }
}
