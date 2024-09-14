using ExcelKit.Core.Attributes;
using ExcelKit.Core.Constraint.Enums;
using ExcelKit.Core.Infrastructure.Converter;

namespace Traceability_System.Entity.ExporteModels
{
    public class ExportedMotor
    {

        [ExcelKit(Desc = "采集时间", Align = TextAlign.Center)]
        public DateTime? CollectionDate { get; set; }

        [ExcelKit(Desc = "Motor出荷序列", Align = TextAlign.Center)]
        public string? ShipmentSerial { get; set; }

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

        [ExcelKit(Desc = "Rr盖序列", Align = TextAlign.Center)]
        public string? RrcoverSerial { get; set; }

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

        [ExcelKit(Desc = "防错防误１计测日時", Align = TextAlign.Center)]
        public string? PokayokeDate1 { get; set; }

        [ExcelKit(Desc = "防错防误2计测日時", Align = TextAlign.Center)]
        public string? PokayokeDate2 { get; set; }

        [ExcelKit(Desc = "计测日时", Align = TextAlign.Center)]
        public string? HsgBrgDate { get; set; }

        [ExcelKit(Desc = "拐点行程", Align = TextAlign.Center)]
        public string? HsgBrgStroke { get; set; }

        [ExcelKit(Desc = "変曲点负重", Align = TextAlign.Center)]
        public string? HsgBrgLoad { get; set; }

        [ExcelKit(Desc = "最终行程", Align = TextAlign.Center)]
        public string? HsgBrgFinalStroke { get; set; }

        [ExcelKit(Desc = "最終荷负重", Align = TextAlign.Center)]
        public string? HsgBrgFinalLoad { get; set; }

        [ExcelKit(Desc = "拐点行程", Align = TextAlign.Center)]
        public string? HsgBrgStrokeSec { get; set; }

        [ExcelKit(Desc = "変曲点负重", Align = TextAlign.Center)]
        public string? HsgBrgLoadSec { get; set; }

        [ExcelKit(Desc = "最终行程", Align = TextAlign.Center)]
        public string? HsgBrgFinalStrokeSec { get; set; }

        [ExcelKit(Desc = "最終荷负重", Align = TextAlign.Center)]
        public string? HsgBrgFinalLoadSec { get; set; }

        [ExcelKit(Desc = "主行程", Align = TextAlign.Center)]
        public string? HsgBrgMainStroke { get; set; }

        [ExcelKit(Desc = "A/B", Align = TextAlign.Center)]
        public string? HsgBrgAbvalue { get; set; }

        [ExcelKit(Desc = "计测日时", Align = TextAlign.Center)]
        public string? HsgKnockDate { get; set; }

        [ExcelKit(Desc = "拐点行程", Align = TextAlign.Center)]
        public string? HsgKnockStroke { get; set; }

        [ExcelKit(Desc = "変曲点负重", Align = TextAlign.Center)]
        public string? HsgKnockLoad { get; set; }

        [ExcelKit(Desc = "最终行程", Align = TextAlign.Center)]
        public string? HsgKnockFinalStroke { get; set; }

        [ExcelKit(Desc = "最終荷负重", Align = TextAlign.Center)]
        public string? HsgKnockFinalLoad { get; set; }

        [ExcelKit(Desc = "拐点行程", Align = TextAlign.Center)]
        public string? HsgKnockStrokeSec { get; set; }

        [ExcelKit(Desc = "変曲点负重", Align = TextAlign.Center)]
        public string? HsgKnockLoadSec { get; set; }

        [ExcelKit(Desc = "最终行程", Align = TextAlign.Center)]
        public string? HsgKnockFinalStrokeSec { get; set; }

        [ExcelKit(Desc = "最終荷负重", Align = TextAlign.Center)]
        public string? HsgKnockFinalLoadSec { get; set; }

        [ExcelKit(Desc = "主行程", Align = TextAlign.Center)]
        public string? HsgKnockMainStroke { get; set; }

        [ExcelKit(Desc = "A/B", Align = TextAlign.Center)]
        public string? HsgKnockAbvalue { get; set; }

        [ExcelKit(Desc = "防错防误3计测日時", Align = TextAlign.Center)]
        public string? PokayokeDate3 { get; set; }

        [ExcelKit(Desc = "防错防误4计测日時", Align = TextAlign.Center)]
        public string? PokayokeDate4 { get; set; }

        [ExcelKit(Desc = "计测日时", Align = TextAlign.Center)]
        public string? RrbrgDate { get; set; }

        [ExcelKit(Desc = "拐点行程", Align = TextAlign.Center)]
        public string? RrbrgStroke { get; set; }

        [ExcelKit(Desc = "変曲点负重", Align = TextAlign.Center)]
        public string? RrbrgLoad { get; set; }

        [ExcelKit(Desc = "最终行程", Align = TextAlign.Center)]
        public string? RrbrgFinalStroke { get; set; }

        [ExcelKit(Desc = "最終荷负重", Align = TextAlign.Center)]
        public string? RrbrgFinalLoad { get; set; }

        [ExcelKit(Desc = "拐点行程", Align = TextAlign.Center)]
        public string? RrbrgStrokeSec { get; set; }

        [ExcelKit(Desc = "変曲点负重", Align = TextAlign.Center)]
        public string? RrbrgLoadSec { get; set; }

        [ExcelKit(Desc = "最终行程", Align = TextAlign.Center)]
        public string? RrbrgFinalStrokeSec { get; set; }

        [ExcelKit(Desc = "最終荷负重", Align = TextAlign.Center)]
        public string? RrbrgFinalLoadSec { get; set; }

        [ExcelKit(Desc = "主行程", Align = TextAlign.Center)]
        public string? RrbrgMainStroke { get; set; }

        [ExcelKit(Desc = "A/B", Align = TextAlign.Center)]
        public string? RrbrgAbvalue { get; set; }

        [ExcelKit(Desc = "计测日时", Align = TextAlign.Center)]
        public string? RrknockDate { get; set; }

        [ExcelKit(Desc = "拐点行程", Align = TextAlign.Center)]
        public string? RrknockStroke { get; set; }

        [ExcelKit(Desc = "変曲点负重", Align = TextAlign.Center)]
        public string? RrknockLoad { get; set; }

        [ExcelKit(Desc = "最终行程", Align = TextAlign.Center)]
        public string? RrknockFinalStroke { get; set; }

        [ExcelKit(Desc = "最終荷负重", Align = TextAlign.Center)]
        public string? RrknockFinalLoad { get; set; }

        [ExcelKit(Desc = "拐点行程", Align = TextAlign.Center)]
        public string? RrknockStrokeSec { get; set; }

        [ExcelKit(Desc = "変曲点负重", Align = TextAlign.Center)]
        public string? RrknockLoadSec { get; set; }

        [ExcelKit(Desc = "最终行程", Align = TextAlign.Center)]
        public string? RrknockFinalStrokeSec { get; set; }

        [ExcelKit(Desc = "最終荷负重", Align = TextAlign.Center)]
        public string? RrknockFinalLoadSec { get; set; }

        [ExcelKit(Desc = "主行程", Align = TextAlign.Center)]
        public string? RrknockMainStroke { get; set; }

        [ExcelKit(Desc = "A/B", Align = TextAlign.Center)]
        public string? RrknockAbvalue { get; set; }

        [ExcelKit(Desc = "计测日时", Align = TextAlign.Center)]
        public string? Mg1date { get; set; }

        [ExcelKit(Desc = "紧固角度1轴", Align = TextAlign.Center)]
        public string? Mg1torqAngleAxis1 { get; set; }

        [ExcelKit(Desc = "第1轴判定代码", Align = TextAlign.Center)]
        public string? Mg1codeAxis1 { get; set; }

        [ExcelKit(Desc = "紧固角度2轴", Align = TextAlign.Center)]
        public string? Mg1torqAngleAxis2 { get; set; }

        [ExcelKit(Desc = "第2轴判定代码", Align = TextAlign.Center)]
        public string? Mg1codeAxis2 { get; set; }

        [ExcelKit(Desc = "紧固角度3轴", Align = TextAlign.Center)]
        public string? Mg1torqAngleAxis3 { get; set; }

        [ExcelKit(Desc = "第3轴判定代码", Align = TextAlign.Center)]
        public string? Mg1codeAxis3 { get; set; }

        [ExcelKit(Desc = "计测日时", Align = TextAlign.Center)]
        public string? Mg2date { get; set; }

        [ExcelKit(Desc = "紧固角度1轴", Align = TextAlign.Center)]
        public string? Mg2torqAngleAxis1 { get; set; }

        [ExcelKit(Desc = "第一轴判定代码", Align = TextAlign.Center)]
        public string? Mg2codeAxis1 { get; set; }

        [ExcelKit(Desc = "紧固角度2軸", Align = TextAlign.Center)]
        public string? Mg2torqAngleAxis2 { get; set; }

        [ExcelKit(Desc = "第2轴判定代码", Align = TextAlign.Center)]
        public string? Mg2codeAxis2 { get; set; }

        [ExcelKit(Desc = "紧固角度3軸", Align = TextAlign.Center)]
        public string? Mg2torqAngleAxis3 { get; set; }

        [ExcelKit(Desc = "第3轴判定代码", Align = TextAlign.Center)]
        public string? Mg2codeAxis3 { get; set; }

        [ExcelKit(Desc = "防错防误５计测日時", Align = TextAlign.Center)]
        public string? PokayokeDate5 { get; set; }

        [ExcelKit(Desc = "计测日时", Align = TextAlign.Center)]
        public string? StatorDate { get; set; }

        [ExcelKit(Desc = "紧固角度1軸", Align = TextAlign.Center)]
        public string? TorqAngleAxis1 { get; set; }

        [ExcelKit(Desc = "第1轴判定代码", Align = TextAlign.Center)]
        public string? CodeAxis1 { get; set; }

        [ExcelKit(Desc = "紧固角度2軸", Align = TextAlign.Center)]
        public string? TorqAngleAxis2 { get; set; }

        [ExcelKit(Desc = "第2轴判定代码", Align = TextAlign.Center)]
        public string? CodeAxis2 { get; set; }

        [ExcelKit(Desc = "紧固角度3軸1", Align = TextAlign.Center)]
        public string? TorqAngleAxis3 { get; set; }

        [ExcelKit(Desc = "第3轴1判定代码", Align = TextAlign.Center)]
        public string? CodeAxis3 { get; set; }

        [ExcelKit(Desc = "紧固角度1軸", Align = TextAlign.Center)]
        public string? AngleAxis1Sec { get; set; }

        [ExcelKit(Desc = "第一轴判定代码", Align = TextAlign.Center)]
        public string? AxisCode1Sec { get; set; }

        [ExcelKit(Desc = "紧固角度2軸", Align = TextAlign.Center)]
        public string? AngleAxis2Sec { get; set; }

        [ExcelKit(Desc = "第2轴判定代码", Align = TextAlign.Center)]
        public string? AxisCode2Sec { get; set; }

        [ExcelKit(Desc = "紧固角度3軸", Align = TextAlign.Center)]
        public string? AngleAxis3Sec { get; set; }

        [ExcelKit(Desc = "第3轴判定代码", Align = TextAlign.Center)]
        public string? AxisCode3Sec { get; set; }

        [ExcelKit(Desc = "MG1定子1軸塑性区紧固扭矩", Align = TextAlign.Center)]
        public string? Mg1stator1 { get; set; }

        [ExcelKit(Desc = "MG1定子2軸塑性区紧固扭矩", Align = TextAlign.Center)]
        public string? Mg1stator2 { get; set; }

        [ExcelKit(Desc = "MG1定子3軸塑性区紧固扭矩", Align = TextAlign.Center)]
        public string? Mg1stator3 { get; set; }

        [ExcelKit(Desc = "MG2定子1軸塑性区紧固扭矩", Align = TextAlign.Center)]
        public string? Mg2stator1 { get; set; }

        [ExcelKit(Desc = "MG2定子2軸塑性区紧固扭矩", Align = TextAlign.Center)]
        public string? Mg2stator2 { get; set; }

        [ExcelKit(Desc = "MG2定子3軸塑性区紧固扭矩", Align = TextAlign.Center)]
        public string? Mg2stator3 { get; set; }

        [ExcelKit(Desc = "防错防误6计测日時", Align = TextAlign.Center)]
        public string? PokayokeDate6 { get; set; }

        [ExcelKit(Desc = "防错防误7计测日時", Align = TextAlign.Center)]
        public string? PokayokeDate7 { get; set; }

        [ExcelKit(Desc = "计测日时", Align = TextAlign.Center)]
        public string? MeasDate { get; set; }

        [ExcelKit(Desc = "MG1工件温度", Align = TextAlign.Center)]
        public string? Mg1workTemp { get; set; }

        [ExcelKit(Desc = "MG1通量值", Align = TextAlign.Center)]
        public string? Mg1fluxValue { get; set; }

        [ExcelKit(Desc = "MG1判定", Align = TextAlign.Center)]
        public string? Mg1dec { get; set; }

        [ExcelKit(Desc = "MG2工件温度", Align = TextAlign.Center)]
        public string? Mg2workTemp { get; set; }

        [ExcelKit(Desc = "MG2通量值", Align = TextAlign.Center)]
        public string? Mg2fluxValue { get; set; }

        [ExcelKit(Desc = "MG2判定", Align = TextAlign.Center)]
        public string? Mg2dec { get; set; }

        [ExcelKit(Desc = "计测日时", Align = TextAlign.Center)]
        public string? RrFigpdate { get; set; }

        [ExcelKit(Desc = "画像判定結果", Align = TextAlign.Center)]
        public string? ImgResult { get; set; }

        [ExcelKit(Desc = "计测日時", Align = TextAlign.Center)]
        public string? RrcoverDate { get; set; }

        [ExcelKit(Desc = "计测日时合体", Align = TextAlign.Center)]
        public string? TotalDate1 { get; set; }

        [ExcelKit(Desc = "紧固角度1軸", Align = TextAlign.Center)]
        public string? Total1AngleAxis1 { get; set; }

        [ExcelKit(Desc = "第1轴判定代码", Align = TextAlign.Center)]
        public string? Total1Axis1Code { get; set; }

        [ExcelKit(Desc = "紧固角度2軸", Align = TextAlign.Center)]
        public string? Total1AngleAxis2 { get; set; }

        [ExcelKit(Desc = "第2轴判定代码", Align = TextAlign.Center)]
        public string? Total1Axis2Code { get; set; }

        [ExcelKit(Desc = "紧固角度3軸", Align = TextAlign.Center)]
        public string? Total1AngleAxis3 { get; set; }

        [ExcelKit(Desc = "第3轴判定代码", Align = TextAlign.Center)]
        public string? Total1Axis3Code { get; set; }

        [ExcelKit(Desc = "紧固角度4軸", Align = TextAlign.Center)]
        public string? Total1AngleAxis4 { get; set; }

        [ExcelKit(Desc = "第4轴判定代码", Align = TextAlign.Center)]
        public string? Total1Axis4Code { get; set; }

        [ExcelKit(Desc = "紧固角度5軸", Align = TextAlign.Center)]
        public string? Total1AngleAxis5 { get; set; }

        [ExcelKit(Desc = "5軸目判定代码", Align = TextAlign.Center)]
        public string? Total1Axis5Code { get; set; }

        [ExcelKit(Desc = "紧固角度6軸", Align = TextAlign.Center)]
        public string? Total1AngleAxis6 { get; set; }

        [ExcelKit(Desc = "6軸目判定代码", Align = TextAlign.Center)]
        public string? Total1Axis6Code { get; set; }

        [ExcelKit(Desc = "紧固角度7軸", Align = TextAlign.Center)]
        public string? Total1AngleAxis7 { get; set; }

        [ExcelKit(Desc = "7軸目判定代码", Align = TextAlign.Center)]
        public string? Total1Axis7Code { get; set; }

        [ExcelKit(Desc = "紧固角度8軸", Align = TextAlign.Center)]
        public string? Total1AngleAxis8 { get; set; }

        [ExcelKit(Desc = "8軸目判定代码", Align = TextAlign.Center)]
        public string? Total1Axis8Code { get; set; }

        [ExcelKit(Desc = "紧固角度9軸", Align = TextAlign.Center)]
        public string? Total1AngleAxis9 { get; set; }

        [ExcelKit(Desc = "9軸目判定代码", Align = TextAlign.Center)]
        public string? Total1Axis9Code { get; set; }

        [ExcelKit(Desc = "紧固角度10軸", Align = TextAlign.Center)]
        public string? Total1AngleAxis10 { get; set; }

        [ExcelKit(Desc = "10軸目判定代码", Align = TextAlign.Center)]
        public string? Total1Axis10Code { get; set; }

        [ExcelKit(Desc = "紧固角度11軸", Align = TextAlign.Center)]
        public string? Total1AngleAxis11 { get; set; }

        [ExcelKit(Desc = "第1轴判定代码", Align = TextAlign.Center)]
        public string? Total1Axis11Code { get; set; }

        [ExcelKit(Desc = "A/B", Align = TextAlign.Center)]
        public string? Total1Abvalue { get; set; }

        [ExcelKit(Desc = "计测日时", Align = TextAlign.Center)]
        public string? Total2Date { get; set; }

        [ExcelKit(Desc = "紧固角度1軸", Align = TextAlign.Center)]
        public string? Angle1Axis { get; set; }

        [ExcelKit(Desc = "第1轴判定代码", Align = TextAlign.Center)]
        public string? Axis1Code { get; set; }

        [ExcelKit(Desc = "紧固角度2軸", Align = TextAlign.Center)]
        public string? Angle2Axis { get; set; }

        [ExcelKit(Desc = "第2轴判定代码", Align = TextAlign.Center)]
        public string? Axis2Code { get; set; }

        [ExcelKit(Desc = "紧固角度3軸", Align = TextAlign.Center)]
        public string? Angle3Axis { get; set; }

        [ExcelKit(Desc = "第3轴判定代码", Align = TextAlign.Center)]
        public string? Axis3Code { get; set; }

        [ExcelKit(Desc = "紧固角度4軸", Align = TextAlign.Center)]
        public string? Angle4Axis { get; set; }

        [ExcelKit(Desc = "第4轴判定代码", Align = TextAlign.Center)]
        public string? Axis4Code { get; set; }

        [ExcelKit(Desc = "紧固角度5軸", Align = TextAlign.Center)]
        public string? Angle5Axis { get; set; }

        [ExcelKit(Desc = "5軸目判定代码", Align = TextAlign.Center)]
        public string? Axis5Code { get; set; }

        [ExcelKit(Desc = "紧固角度6軸", Align = TextAlign.Center)]
        public string? Angle6Axis { get; set; }

        [ExcelKit(Desc = "6軸目判定代码", Align = TextAlign.Center)]
        public string? Axis6Code { get; set; }

        [ExcelKit(Desc = "紧固角度7軸", Align = TextAlign.Center)]
        public string? Angle7Axis { get; set; }

        [ExcelKit(Desc = "第7轴判定代码", Align = TextAlign.Center)]
        public string? Axis7Code { get; set; }

        [ExcelKit(Desc = "紧固角度8軸", Align = TextAlign.Center)]
        public string? Angle8Axis { get; set; }

        [ExcelKit(Desc = "第8轴判定代码", Align = TextAlign.Center)]
        public string? Axis8Code { get; set; }

        [ExcelKit(Desc = "紧固角度9軸", Align = TextAlign.Center)]
        public string? Angle9Axis { get; set; }

        [ExcelKit(Desc = "第9轴判定代码", Align = TextAlign.Center)]
        public string? Axis9Code { get; set; }

        [ExcelKit(Desc = "紧固角度10軸", Align = TextAlign.Center)]
        public string? Angle10Axis { get; set; }

        [ExcelKit(Desc = "第10轴判定代码", Align = TextAlign.Center)]
        public string? Axis10Code { get; set; }

        [ExcelKit(Desc = "A/B", Align = TextAlign.Center)]
        public string? Ab { get; set; }

        [ExcelKit(Desc = "计测日時", Align = TextAlign.Center)]
        public string? ReDate { get; set; }

        [ExcelKit(Desc = "防错防误预备计测日時", Align = TextAlign.Center)]
        public string? PokayokeDateBas { get; set; }

        [ExcelKit(Desc = "防错防误8计测日時", Align = TextAlign.Center)]
        public string? PokayokeDate8 { get; set; }

        [ExcelKit(Desc = "防错防误9计测日時", Align = TextAlign.Center)]
        public string? PokayokeDate9 { get; set; }

        [ExcelKit(Desc = "防错防误10计测日時", Align = TextAlign.Center)]
        public string? PokayokeDate10 { get; set; }

        [ExcelKit(Desc = "防错防误11计测日時", Align = TextAlign.Center)]
        public string? PokayokeDate11 { get; set; }

        [ExcelKit(Desc = "防错防误12计测日時", Align = TextAlign.Center)]
        public string? PokayokeDate12 { get; set; }

        [ExcelKit(Desc = "防错防误13计测日時", Align = TextAlign.Center)]
        public string? PokayokeDate13 { get; set; }

        [ExcelKit(Desc = "防错防误14计测日時", Align = TextAlign.Center)]
        public string? PokayokeDate14 { get; set; }

    }
}
