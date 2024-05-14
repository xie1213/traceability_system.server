namespace Traceability_System.DTO
{

    public class SelTableRequest
    {
        public string? TableName { get; set; }
        public List<string> ? TimeDate { get; set; }
       
        public List<string>? selColName { get; set; }

        public string ? SerialNo { get; set; }
    }

    public class ParameterData
    {
        //开始时间
        public string? startDateTime { get; set; }

        //结束时间
        public string? endDateTime { get; set; }

        //序列号
        public string? serialDateNumber { get; set; }

        public selectFactor? selectFactor { get; set; }

        //表名
        public string? tableName { get; set; }

    }

    public class selectFactor
    {
        public string? selectName { get; set;}
        public string ? topLimit { get; set; }
        public string? lowerLimit { get; set; }
        public string? startDateTime { get; set; }
        public string? endDateTime { get; set;}
    }
}
