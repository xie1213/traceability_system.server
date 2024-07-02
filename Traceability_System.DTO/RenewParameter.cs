namespace Traceability_System.DTO
{
    public class RenewParameter
    {
        //表名
        public string tableName { get; set; } = string.Empty;

        //列名
        public List<string> colNameList { get; set; } = new List<string>();

        //数据
        public List<string> valueList { get; set; } = new List<string>();

        //条件
        public List<string>? specify { get; set; }

        //更新时间
        public string? renewTime { get; set; }

        //更新次数
        public int renewNum { get; set; }

    }
}
