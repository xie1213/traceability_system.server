using ExcelKit.Core.Attributes;
using ExcelKit.Core.Constraint.Enums;
using ExcelKit.Core.Infrastructure.Converter;

namespace Traceability_System.Entity.ExporteModels
{
    public class ExportedRr
    {

        [ExcelKit(Desc = "上传时间", Converter = typeof(DateTimeFmtConverter), ConverterParam = "yyyy-MM-dd HH:mm:ss", Align = TextAlign.Center)]
        public DateTime? CollectionDate { get; set; }

        [ExcelKit(Desc = "rr盖序列", Align = TextAlign.Center)]
        public string? RrcoverSerial { get; set; }

        [ExcelKit(Desc = "接口No.", Align = TextAlign.Center)]
        public string? InterNo { get; set; }

        [ExcelKit(Desc = "箱体识别", Align = TextAlign.Center)]
        public string? CaseDec { get; set; }

        [ExcelKit(Desc = "Rr盖判别", Align = TextAlign.Center)]
        public string? RrCoverDec { get; set; }

        [ExcelKit(Desc = "停车识别", Align = TextAlign.Center)]
        public string? ParkingDec { get; set; }

        [ExcelKit(Desc = "齿轮识别", Align = TextAlign.Center)]
        public string? GearDec { get; set; }

        [ExcelKit(Desc = "变形判别", Align = TextAlign.Center)]
        public string? DefLingDec { get; set; }

        [ExcelKit(Desc = "Hsg识别", Align = TextAlign.Center)]
        public string? HsgDec { get; set; }

        [ExcelKit(Desc = "MG1定子判別", Align = TextAlign.Center)]
        public string? Mg1statorDec { get; set; }

        [ExcelKit(Desc = "MG2定子判別", Align = TextAlign.Center)]
        public string? Mg2statorDec { get; set; }

        [ExcelKit(Desc = "MG1转子判別", Align = TextAlign.Center)]
        public string? Mg1rotorDec { get; set; }

        [ExcelKit(Desc = "MG2转子判別", Align = TextAlign.Center)]
        public string? Mg2rotorDec { get; set; }

        [ExcelKit(Desc = "线体判別", Align = TextAlign.Center)]
        public string? LineDec { get; set; }

        [ExcelKit(Desc = "DF箱体", Align = TextAlign.Center)]
        public string? Dfcase { get; set; }

        [ExcelKit(Desc = "油泵", Align = TextAlign.Center)]
        public string? OilPump { get; set; }

        [ExcelKit(Desc = "CASE序列", Align = TextAlign.Center)]
        public string? CaseSerial { get; set; }

        [ExcelKit(Desc = "HSG序列", Align = TextAlign.Center)]
        public string? HsgSerial { get; set; }

        [ExcelKit(Desc = "MG1定子序列", Align = TextAlign.Center)]
        public string? Mg1sserial { get; set; }

        [ExcelKit(Desc = "MG2定子序列", Align = TextAlign.Center)]
        public string? Mg2sserial { get; set; }

        [ExcelKit(Desc = "MG1转子序列", Align = TextAlign.Center)]
        public string? Mg1rserial { get; set; }

        [ExcelKit(Desc = "MG2转子序列", Align = TextAlign.Center)]
        public string? Mg2rserial { get; set; }

        [ExcelKit(Desc = "计数器驱动器序列", Align = TextAlign.Center)]
        public string? CoDriveSerial { get; set; }

        [ExcelKit(Desc = "MG2修正序列", Align = TextAlign.Center)]
        public string? MoDriveSerial { get; set; }

        [ExcelKit(Desc = "受驱动序列", Align = TextAlign.Center)]
        public string? DrivenSerial { get; set; }

        [ExcelKit(Desc = "差速器销序列", Align = TextAlign.Center)]
        public string? DorpinSerial { get; set; }

        [ExcelKit(Desc = "齿圈序列", Align = TextAlign.Center)]
        public string? DfringSerial { get; set; }

        [ExcelKit(Desc = "差速器箱序列", Align = TextAlign.Center)]
        public string? DfcaseSerial { get; set; }

        [ExcelKit(Desc = "出货序列", Align = TextAlign.Center)]
        public string? ShipmentSerial { get; set; }

        [ExcelKit(Desc = "Rr油泵序列", Align = TextAlign.Center)]
        public string? RropSerial { get; set; }

        [ExcelKit(Desc = "轴移载", Align = TextAlign.Center)]
        public string? RotorShaftTrans { get; set; }

        [ExcelKit(Desc = "铁芯移载", Align = TextAlign.Center)]
        public string? RotorCoreTrans { get; set; }

        [ExcelKit(Desc = "加热", Align = TextAlign.Center)]
        public string? RotorHeating { get; set; }

        [ExcelKit(Desc = "轴圧入", Align = TextAlign.Center)]
        public string? RotorShaftPress { get; set; }

        [ExcelKit(Desc = "螺母紧固", Align = TextAlign.Center)]
        public string? RotorNutTight { get; set; }

        [ExcelKit(Desc = "工序履历(异物吸引)", Align = TextAlign.Center)]
        public string? RotorForeignSuction { get; set; }

        [ExcelKit(Desc = "螺母铆接MG1针压入", Align = TextAlign.Center)]
        public string? RotorNutCrimpMg1press { get; set; }

        [ExcelKit(Desc = "旋转变压器压入", Align = TextAlign.Center)]
        public string? RotorResolverPress { get; set; }

        [ExcelKit(Desc = "排斥", Align = TextAlign.Center)]
        public string? RotorReject { get; set; }

        [ExcelKit(Desc = "磁性磁化", Align = TextAlign.Center)]
        public string? RotorMagnetization { get; set; }

        [ExcelKit(Desc = "工序履历(抽样检查)", Align = TextAlign.Center)]
        public string? RotorExtractionInsp { get; set; }

        [ExcelKit(Desc = "工序履历(转子出厂检查综合判定)", Align = TextAlign.Center)]
        public string? RotorShippingInsp { get; set; }

        [ExcelKit(Desc = "轴移载", Align = TextAlign.Center)]
        public string? RotorTamg2shaftTrans { get; set; }

        [ExcelKit(Desc = "铁芯移载", Align = TextAlign.Center)]
        public string? RotorTamg2coreTrans { get; set; }

        [ExcelKit(Desc = "加热", Align = TextAlign.Center)]
        public string? RotorTamg2heating { get; set; }

        [ExcelKit(Desc = "轴圧入", Align = TextAlign.Center)]
        public string? RotorTamg2shaftPress { get; set; }

        [ExcelKit(Desc = "螺母紧固", Align = TextAlign.Center)]
        public string? RotorTamg2nutTight { get; set; }

        [ExcelKit(Desc = "工序履历(异物吸引)", Align = TextAlign.Center)]
        public string? RotorTamg2foreignSuction { get; set; }

        [ExcelKit(Desc = "螺母铆接MG1针压入", Align = TextAlign.Center)]
        public string? RotorTamg2nutCrimpMg1press { get; set; }

        [ExcelKit(Desc = "旋转变压器压入", Align = TextAlign.Center)]
        public string? RotorTamg2resolverPress { get; set; }

        [ExcelKit(Desc = "排斥", Align = TextAlign.Center)]
        public string? RotorTamg2reject { get; set; }

        [ExcelKit(Desc = "磁性磁化", Align = TextAlign.Center)]
        public string? RotorTamg2magnetization { get; set; }

        [ExcelKit(Desc = "工序履历(抽样检查)", Align = TextAlign.Center)]
        public string? RotorTamg2extractionInsp { get; set; }

        [ExcelKit(Desc = "工序履历(转子出厂检查综合判定)", Align = TextAlign.Center)]
        public string? RotorTamg2shippingInsp { get; set; }

        [ExcelKit(Desc = "ID写入", Align = TextAlign.Center)]
        public string? MotorMtrCode { get; set; }

        [ExcelKit(Desc = "序号发生箱子集", Align = TextAlign.Center)]
        public string? MotorSngen { get; set; }

        [ExcelKit(Desc = "Hsg面箱体BrgAM", Align = TextAlign.Center)]
        public string? MotorHsgSrfBrgAm { get; set; }

        [ExcelKit(Desc = "Hsg面定位压入AM", Align = TextAlign.Center)]
        public string? MotorHsgSrfKnockPam { get; set; }

        [ExcelKit(Desc = "冷却管手工作业", Align = TextAlign.Center)]
        public string? MotorCoolPipeMw { get; set; }

        [ExcelKit(Desc = "端子台手工作业", Align = TextAlign.Center)]
        public string? MotorTermBoardMw { get; set; }

        [ExcelKit(Desc = "Rr罩面外BrgAM", Align = TextAlign.Center)]
        public string? MotorRrCoverSrfOutBrgAm { get; set; }

        [ExcelKit(Desc = "Rr罩面定位压入AM", Align = TextAlign.Center)]
        public string? MotorRrCoverSrfKnockPam { get; set; }

        [ExcelKit(Desc = "MG1定子插入AM", Align = TextAlign.Center)]
        public string? MotorMg1statorInsAm { get; set; }

        [ExcelKit(Desc = "MG2定子插入AM", Align = TextAlign.Center)]
        public string? MotorMg2statorInsAm { get; set; }

        [ExcelKit(Desc = "线束释放手工作业", Align = TextAlign.Center)]
        public string? MotorHarnEscMw { get; set; }

        [ExcelKit(Desc = "MG1、2定子紧固AM", Align = TextAlign.Center)]
        public string? MotorMg12statorTightAm { get; set; }

        [ExcelKit(Desc = "热敏电阻手工作业", Align = TextAlign.Center)]
        public string? MotorThermMw { get; set; }

        [ExcelKit(Desc = "冷却管手工作业", Align = TextAlign.Center)]
        public string? MotorCoolPipeMw2 { get; set; }

        [ExcelKit(Desc = "G1、2转子组装", Align = TextAlign.Center)]
        public string? MotorMg12rotorAssem { get; set; }

        [ExcelKit(Desc = "FIPG涂布", Align = TextAlign.Center)]
        public string? MotorFipgapp { get; set; }

        [ExcelKit(Desc = "安装Rr罩子", Align = TextAlign.Center)]
        public string? MotorRrCoverAssem { get; set; }

        [ExcelKit(Desc = "Rr罩子紧固1", Align = TextAlign.Center)]
        public string? MotorRrCoverTight1 { get; set; }

        [ExcelKit(Desc = "Rr罩子紧固2", Align = TextAlign.Center)]
        public string? MotorRrCoverTight2 { get; set; }

        [ExcelKit(Desc = "翻转机", Align = TextAlign.Center)]
        public string? MotorInvMw { get; set; }

        [ExcelKit(Desc = "手动作业１", Align = TextAlign.Center)]
        public string? MotorMw1 { get; set; }

        [ExcelKit(Desc = "手动作业2", Align = TextAlign.Center)]
        public string? MotorMw2 { get; set; }

        [ExcelKit(Desc = "前st", Align = TextAlign.Center)]
        public string? MotorPrevStn { get; set; }

        [ExcelKit(Desc = "手动作业Co0", Align = TextAlign.Center)]
        public string? MotorMwco0 { get; set; }

        [ExcelKit(Desc = "手作業Co1", Align = TextAlign.Center)]
        public string? MotorMwco1 { get; set; }

        [ExcelKit(Desc = "手动作业Co2", Align = TextAlign.Center)]
        public string? MotorMwco2 { get; set; }

        [ExcelKit(Desc = "手动作业Co3", Align = TextAlign.Center)]
        public string? MotorMwco3 { get; set; }

        [ExcelKit(Desc = "拒绝确认", Align = TextAlign.Center)]
        public string? MotorReject { get; set; }

        [ExcelKit(Desc = "备用ID组合", Align = TextAlign.Center)]
        public string? CoverSubIdsetSpare { get; set; }

        [ExcelKit(Desc = "Rr盖组合 DM读取", Align = TextAlign.Center)]
        public string? CoverSubRrCovSetDmread { get; set; }

        [ExcelKit(Desc = "Rr罩子Brg压入设备", Align = TextAlign.Center)]
        public string? CoverSubRrCovBrgPressEquip { get; set; }

        [ExcelKit(Desc = "手动作业１", Align = TextAlign.Center)]
        public string? CoverSubMw1 { get; set; }

        [ExcelKit(Desc = "手动作业2", Align = TextAlign.Center)]
        public string? CoverSubMw2 { get; set; }

        [ExcelKit(Desc = "手动作业３", Align = TextAlign.Center)]
        public string? CoverSubMw3 { get; set; }

        [ExcelKit(Desc = "手动作业４", Align = TextAlign.Center)]
        public string? CoverSubMw4 { get; set; }

        [ExcelKit(Desc = "RR反转设备", Align = TextAlign.Center)]
        public string? CoverSubRrRevEquip { get; set; }

        [ExcelKit(Desc = "防水连接器紧固", Align = TextAlign.Center)]
        public string? CoverSubWaterConnTighten { get; set; }

        [ExcelKit(Desc = "拒绝", Align = TextAlign.Center)]
        public string? CoverSubReject { get; set; }

        [ExcelKit(Desc = "差速器内部组装DF盒读取", Align = TextAlign.Center)]
        public string? DefDfcaseRead { get; set; }

        [ExcelKit(Desc = "DF小齿轮轴组装设备", Align = TextAlign.Center)]
        public string? DefDfpinionShaftEquip { get; set; }

        [ExcelKit(Desc = "差速器动作、位移量测量设备", Align = TextAlign.Center)]
        public string? DefDiffOperMeasureEquip { get; set; }

        [ExcelKit(Desc = "插针式手动作业", Align = TextAlign.Center)]
        public string? DefTweezersMw { get; set; }

        [ExcelKit(Desc = "差速器销铆接", Align = TextAlign.Center)]
        public string? DefDiffPinionPress { get; set; }

        [ExcelKit(Desc = "DM读入", Align = TextAlign.Center)]
        public string? Dmread { get; set; }

        [ExcelKit(Desc = "齿轮压入１", Align = TextAlign.Center)]
        public string? GearPressIn1 { get; set; }

        [ExcelKit(Desc = "齿轮压入２", Align = TextAlign.Center)]
        public string? GearPressIn2 { get; set; }

        [ExcelKit(Desc = "Co从动螺母紧固", Align = TextAlign.Center)]
        public string? Slnffastening { get; set; }

        [ExcelKit(Desc = "Co从动螺母铆接", Align = TextAlign.Center)]
        public string? Slnfriveting { get; set; }

        [ExcelKit(Desc = "差速器Brg压入", Align = TextAlign.Center)]
        public string? DiffBrgPressIn { get; set; }

        [ExcelKit(Desc = "差速器螺栓紧固1", Align = TextAlign.Center)]
        public string? DiffBoltTight1 { get; set; }

        [ExcelKit(Desc = "差速器螺栓紧固2", Align = TextAlign.Center)]
        public string? DiffBoltTight2 { get; set; }

        [ExcelKit(Desc = "反转铆接确认", Align = TextAlign.Center)]
        public string? RevRivetConfirm { get; set; }

        [ExcelKit(Desc = "ダンパー画像", Align = TextAlign.Center)]
        public string? DamperImage { get; set; }

        [ExcelKit(Desc = "リジェクト", Align = TextAlign.Center)]
        public string? Reject { get; set; }

        [ExcelKit(Desc = "ID写入,Hsg集", Align = TextAlign.Center)]
        public string? Idwrite { get; set; }

        [ExcelKit(Desc = "垫片选择", Align = TextAlign.Center)]
        public string? HsgSubShimSel { get; set; }

        [ExcelKit(Desc = "HsgBrg圧入1", Align = TextAlign.Center)]
        public string? HsgBrgPressIn1 { get; set; }

        [ExcelKit(Desc = "HsgBrg圧入2", Align = TextAlign.Center)]
        public string? HsgBrgPressIn2 { get; set; }

        [ExcelKit(Desc = "4种齿轮组装", Align = TextAlign.Center)]
        public string? GearAssembly1 { get; set; }

        [ExcelKit(Desc = "油泵组装", Align = TextAlign.Center)]
        public string? OilPumpAssembly { get; set; }

        [ExcelKit(Desc = "垫片选择", Align = TextAlign.Center)]
        public string? SubShimSel { get; set; }

        [ExcelKit(Desc = "垫片组", Align = TextAlign.Center)]
        public string? ShimSet { get; set; }

        [ExcelKit(Desc = "润滑管组装", Align = TextAlign.Center)]
        public string? LubPipeAssem { get; set; }

        [ExcelKit(Desc = "外壳FIPG涂敷", Align = TextAlign.Center)]
        public string? CaseFipgapp { get; set; }

        [ExcelKit(Desc = "合体组装", Align = TextAlign.Center)]
        public string? AssemJoining1 { get; set; }

        [ExcelKit(Desc = "合体紧固１", Align = TextAlign.Center)]
        public string? AssemTight1 { get; set; }

        [ExcelKit(Desc = "合体紧固２", Align = TextAlign.Center)]
        public string? AssemTight2 { get; set; }

        [ExcelKit(Desc = "排水塞紧固", Align = TextAlign.Center)]
        public string? DrainPlugTight { get; set; }

        [ExcelKit(Desc = "差速器油封压入1", Align = TextAlign.Center)]
        public string? DiffOilsealPress1 { get; set; }

        [ExcelKit(Desc = "差速器油封压入2", Align = TextAlign.Center)]
        public string? DiffOilsealPress2 { get; set; }

        [ExcelKit(Desc = "フィラー締付", Align = TextAlign.Center)]
        public string? FillerTight { get; set; }

        [ExcelKit(Desc = "Assy正立", Align = TextAlign.Center)]
        public string? AssyUpright { get; set; }

        [ExcelKit(Desc = "ID交换", Align = TextAlign.Center)]
        public string? Idexchange { get; set; }

        [ExcelKit(Desc = "油冷却器组装", Align = TextAlign.Center)]
        public string? OilCoolerAssem { get; set; }

        [ExcelKit(Desc = "心轴安装", Align = TextAlign.Center)]
        public string? MandrelAttach { get; set; }

        [ExcelKit(Desc = "前期准备", Align = TextAlign.Center)]
        public string? Preprocessing { get; set; }

        [ExcelKit(Desc = "Assy泄漏测试", Align = TextAlign.Center)]
        public string? AssyLeakTest { get; set; }

        [ExcelKit(Desc = "绝缘", Align = TextAlign.Center)]
        public string? Insulation { get; set; }

        [ExcelKit(Desc = "油注入", Align = TextAlign.Center)]
        public string? OilInjection { get; set; }

        [ExcelKit(Desc = "Assy噪声测试", Align = TextAlign.Center)]
        public string? AssyNoiseTest { get; set; }

        [ExcelKit(Desc = "手动作业①", Align = TextAlign.Center)]
        public string? Mw1 { get; set; }

        [ExcelKit(Desc = "手动作业②", Align = TextAlign.Center)]
        public string? Mw2 { get; set; }

        [ExcelKit(Desc = "手动作业③", Align = TextAlign.Center)]
        public string? Mw3 { get; set; }

        [ExcelKit(Desc = "序列刻印", Align = TextAlign.Center)]
        public string? SerialStamping { get; set; }

        [ExcelKit(Desc = "发货步骤1", Align = TextAlign.Center)]
        public string? ShippingPrep1 { get; set; }

        [ExcelKit(Desc = "发货步骤2", Align = TextAlign.Center)]
        public string? ShippingPrep2 { get; set; }

        [ExcelKit(Desc = "外观检查", Align = TextAlign.Center)]
        public string? VisualInsp { get; set; }

        [ExcelKit(Desc = "拒绝", Align = TextAlign.Center)]
        public string? Fipgreject { get; set; }

        [ExcelKit(Desc = "标签发行", Align = TextAlign.Center)]
        public string? LabelPrinting { get; set; }

        [ExcelKit(Desc = "修改历史记录", Align = TextAlign.Center)]
        public string? Reshuffle { get; set; }

        [ExcelKit(Desc = "防错防误39计测日時", Converter = typeof(DateTimeFmtConverter), ConverterParam = "yyyy-MM-dd HH:mm:ss", Align = TextAlign.Center)]
        public string? PokayokeDate39 { get; set; }

        [ExcelKit(Desc = "防错防误40计测日時", Converter = typeof(DateTimeFmtConverter), ConverterParam = "yyyy-MM-dd HH:mm:ss", Align = TextAlign.Center)]
        public string? PokayokeDate40 { get; set; }

        [ExcelKit(Desc = "RrBrg圧入计测日时", Align = TextAlign.Center)]
        public string? HsgBrgMdate { get; set; }

        [ExcelKit(Desc = "RrBrg圧入拐点行程1", Align = TextAlign.Center)]
        public string? HsgBrgStroke { get; set; }

        [ExcelKit(Desc = "RrBrg圧入拐点负重1", Align = TextAlign.Center)]
        public string? HsgBrgLoad { get; set; }

        [ExcelKit(Desc = "RrBrg圧入最终行程1", Align = TextAlign.Center)]
        public string? HsgBrgFinalStroke { get; set; }

        [ExcelKit(Desc = "RrBrg圧入最终负重1", Align = TextAlign.Center)]
        public string? HsgBrgFinalLoad { get; set; }

        [ExcelKit(Desc = "RrBrg圧入拐点行程2", Align = TextAlign.Center)]
        public string? HsgBrgStrokeSec { get; set; }

        [ExcelKit(Desc = "RrBrg圧入拐点负重2", Align = TextAlign.Center)]
        public string? HsgBrgLoadSec { get; set; }

        [ExcelKit(Desc = "RrBrg圧入最终行程2", Align = TextAlign.Center)]
        public string? HsgBrgFinalStrokeSec { get; set; }

        [ExcelKit(Desc = "RrBrg圧入最终负重2", Align = TextAlign.Center)]
        public string? HsgBrgFinalLoadSec { get; set; }

        [ExcelKit(Desc = "RrBrg圧入主行程", Align = TextAlign.Center)]
        public string? HsgBrgMainStroke { get; set; }

        [ExcelKit(Desc = "防错防误41计测日時", Converter = typeof(DateTimeFmtConverter), ConverterParam = "yyyy-MM-dd HH:mm:ss", Align = TextAlign.Center)]
        public string? PokayokeDate41 { get; set; }

        [ExcelKit(Desc = "防错防误42计测日時", Converter = typeof(DateTimeFmtConverter), ConverterParam = "yyyy-MM-dd HH:mm:ss", Align = TextAlign.Center)]
        public string? PokayokeDate42 { get; set; }

        [ExcelKit(Desc = "防错防误43计测日時", Converter = typeof(DateTimeFmtConverter), ConverterParam = "yyyy-MM-dd HH:mm:ss", Align = TextAlign.Center)]
        public string? PokayokeDate43 { get; set; }

        [ExcelKit(Desc = "防错防误44计测日時", Converter = typeof(DateTimeFmtConverter), ConverterParam = "yyyy-MM-dd HH:mm:ss", Align = TextAlign.Center)]
        public string? PokayokeDate44 { get; set; }

        [ExcelKit(Desc = "反転機计测日時", Converter = typeof(DateTimeFmtConverter), ConverterParam = "yyyy-MM-dd HH:mm:ss", Align = TextAlign.Center)]
        public string? UpenderDate { get; set; }

        [ExcelKit(Desc = "防错防误45计测日時", Converter = typeof(DateTimeFmtConverter), ConverterParam = "yyyy-MM-dd HH:mm:ss", Align = TextAlign.Center)]
        public string? PokayokeDate45 { get; set; }

        [ExcelKit(Desc = "拒绝计测日時", Converter = typeof(DateTimeFmtConverter), ConverterParam = "yyyy-MM-dd HH:mm:ss", Align = TextAlign.Center)]
        public string? RejectTimeDate { get; set; }

    }
}
