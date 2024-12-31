using ExcelKit.Core.Attributes;
using ExcelKit.Core.Constraint.Enums;

namespace Traceability_System.Entity.ExporteModels
{
    public class ExportedShip
    {

        [ExcelKit(Desc = "序列号", Align = TextAlign.Center)]
        public string? SerialNo { get; set; }

        [ExcelKit(Desc = "品番", Align = TextAlign.Center)]
        public string? ProductNo { get; set; }

        [ExcelKit(Desc = "印字标识", Align = TextAlign.Center)]
        public string? Printing { get; set; }

        [ExcelKit(Desc = "先行时间", Align = TextAlign.Center)]
        public DateTime? LeadTimeDate { get; set; }

        [ExcelKit(Desc = "出荷时间", Align = TextAlign.Center)]
        public DateTime? ShippingTimeDate { get; set; }

        [ExcelKit(Desc = "出荷目的地", Align = TextAlign.Center)]
        public string? Destination { get; set; }

        [ExcelKit(Desc = "目的地工区", Align = TextAlign.Center)]
        public string? DestinationArea { get; set; }

        [ExcelKit(Desc = "受入口", Align = TextAlign.Center)]
        public string? ReceivingPoint { get; set; }

        [ExcelKit(Desc = "背番号", Align = TextAlign.Center)]
        public string? BackNo { get; set; }

        [ExcelKit(Desc = "订单号", Align = TextAlign.Center)]
        public string? OrderNo { get; set; }

        [ExcelKit(Desc = "Pline号", Align = TextAlign.Center)]
        public string? PlineNo { get; set; }

        [ExcelKit(Desc = "受领书编号", Align = TextAlign.Center)]
        public string? ReceivingNo { get; set; }

        [ExcelKit(Desc = "出荷作业者", Align = TextAlign.Center)]
        public string? Operator { get; set; }

    }
}
