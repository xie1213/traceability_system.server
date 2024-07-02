namespace Traceability_System.Entity.Models
{
    public partial class Shipping
    {
        public int Id { get; set; }
        public string? SerialNo { get; set; }
        public string? ProductNo { get; set; }
        public string? Printing { get; set; }
        public DateTime? LeadTimeDate { get; set; }
        public DateTime? ShippingTimeDate { get; set; }
        public string? Destination { get; set; }
        public string? DestinationArea { get; set; }
        public string? ReceivingPoint { get; set; }
        public string? BackNo { get; set; }
        public string? OrderNo { get; set; }
        public string? PlineNo { get; set; }
        public string? ReceivingNo { get; set; }
        public string? Operator { get; set; }
    }
}
