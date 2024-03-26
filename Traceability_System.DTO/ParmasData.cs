namespace Traceability_System.DTO
{

    public class SelTableRequest
    {
        public string? TableName { get; set; }
        public List<string> ? TimeDate { get; set; }
       
        public List<string>? selColName { get; set; }

        public string ? SerialNo { get; set; }
    }

}
