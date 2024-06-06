using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traceability_System.Models.DictionaryMapper
{
    public class ExportTableMapper
    {
        //导出数据时根据不同表导出不同列
        public Dictionary<string, string> keyValuePairs = new Dictionary<string, string>()
        {
             {"Motor履历", "ShipmentSerial"},
             {"Ta履历", "ShipmentSerial"},
             {"Rotor履历", "Mg1rserial"},
             {"Gear履历", "DorpinSerial"},
             {"Rr履历", "RrcoverSerial"},
             {"全部履历", "ShipmentSerial"},
             {"出荷履历","SerialNo" }
        };

        //不格式化得列
        public HashSet<string> columns = new HashSet<string>
        {
            "InterNo", "MG1StatorDec", "MG2StatorDec", "MG1RotorDec", "MG2RotorDec",
            "CaseSerial", "HsgSerial", "MG1SSerial", "MG2SSerial", "MG1RSerial",
            "MG2RSerial", "CoDriveSerial", "MoDriveSerial", "DrivenSerial",
            "DorpinSerial", "DFRingSerial", "DFCaseSerial", "RRCoverSerial",
            "ShipmentSerial", "RRopSerial","ProductNo","ReceivingNo"
        };
    }
}
