//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Traceability_System.DTO;

//namespace Traceability_System.Models.SelectDB
//{
//    public class EstablishSql
//    {

//        // 创建包含表名和 SQL 语句模板的 Dictionary
//        Dictionary<string, string> sqlTemplates = new Dictionary<string, string>
//        {
//            { "出荷履历", "\tSerialNo like '%{0}%'\t" },
//            { "全部履历", "\tShipmentSerial like '%{0}%'\t" },
//            { "Motor履历", "\tShipmentSerial like '%{0}%'\t" },
//            { "Ta履历", "\tShipmentSerial like '%{0}%'\t" },
//            { "Rotor履历", "\tMG1RSerial like '%{0}%'\t" },
//            { "Gear履历", "\tDorpinSerial like '%{0}%'\t" },
//            { "Rr履历", "\tRRCoverSerial like '%{0}%'\t" }
//        };


//        public string CreateSelSql(ParameterData parameter)
//        {
//            string commonSqlPart = $"'{parameter.serialDateNumber}'";
//            string serialSql, timeSql, selectSql;
//            // 获取序列号
//            if (!string.IsNullOrEmpty(commonSqlPart) && sqlTemplates.TryGetValue(parameter.tableName, out string template))
//            {
//                serialSql = string.Format(template, commonSqlPart);
//            }

//            //获取时间条件
//            if (!string.IsNullOrEmpty(parameter.startDateTime) && !string.IsNullOrEmpty(parameter.endDateTime))
//            {
//                timeSql = $"\tbetween '{parameter.startDateTime}' and '{parameter.endDateTime}'\t ";
//            }
//            //获取下拉条件
//            if (!string.IsNullOrEmpty(parameter.selectName))
//            {

//                if (!string.IsNullOrEmpty(parameter.selectTop) && !string.IsNullOrEmpty(parameter.selectLower))
//                {
//                    selectSql = parameter.selectTop == parameter.selectLower
//                    ? $"\tlike '%{parameter.selectTop}%'" // 如果相等则使用 like 条件
//                    : $"\tbetween '{parameter.selectTop}' and '{parameter.selectLower}'\t"; // 否则使用 between 条件
//                }
//                if (!string.IsNullOrEmpty(parameter.selStartTime) && !string.IsNullOrEmpty(parameter.selEndTime))
//                {
//                    selectSql = $"\tbetween '{parameter.selStartTime}' and '{parameter.selEndTime}'\t";
//                }
//            }

//            return serialSql;



//        }
//    }
//}
