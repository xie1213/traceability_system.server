using ExcelKit.Core.Attributes;
using ExcelKit.Core.Constraint.Enums;
using ExcelKit.Core.Infrastructure.Converter;

namespace Traceability_System.Entity.ExporteModels
{
    public class ExportedTa
    {
        [ExcelKit(Desc = "上传时间", Converter = typeof(DateTimeFmtConverter), ConverterParam = "yyyy/MM/dd hh:mm:ss")]
        public DateTime? CollectionDate { get; set; }

        [ExcelKit(Desc = "ta出荷", Align = TextAlign.Center)]
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
        public string? MotorFipgapp { get; set; }

        [ExcelKit(Desc = "FIPG涂布", Align = TextAlign.Center)]
        public string? MotorMg12rotorAssem { get; set; }
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

        [ExcelKit(Desc = "防错防误15计测日時", Align = TextAlign.Center)]
        public string? PokayokeDate15 { get; set; }

        [ExcelKit(Desc = "防错防误16计测日時", Align = TextAlign.Center)]
        public string? PokayokeDate16 { get; set; }

        [ExcelKit(Desc = "ラベル発券计测日時", Align = TextAlign.Center)]
        public string? TagMeasDate { get; set; }

        [ExcelKit(Desc = "防错防误18计测日時", Align = TextAlign.Center)]
        public string? PokayokeDate18 { get; set; }

        [ExcelKit(Desc = "防错防误19计测日時", Align = TextAlign.Center)]
        public string? PokayokeDate19 { get; set; }

        [ExcelKit(Desc = "计测日时", Align = TextAlign.Center)]
        public string? ShimMeasDate { get; set; }

        [ExcelKit(Desc = "Hsg侧差速器轴深度t7", Align = TextAlign.Center)]
        public string? ShimHsgt7 { get; set; }

        [ExcelKit(Desc = "Hsg侧转向销轴深度t5", Align = TextAlign.Center)]
        public string? ShimHsgt5 { get; set; }

        [ExcelKit(Desc = "Hsg侧马达计数器轴深度t3", Align = TextAlign.Center)]
        public string? ShimHsgt3 { get; set; }

        [ExcelKit(Desc = "Hsg侧输入轴深度t1", Align = TextAlign.Center)]
        public string? ShimHsgt1 { get; set; }

        [ExcelKit(Desc = "壳体侧差速器轴高度t8", Align = TextAlign.Center)]
        public string? ShimShellt8 { get; set; }

        [ExcelKit(Desc = "壳体侧干销轴高度t6", Align = TextAlign.Center)]
        public string? ShimShellt6 { get; set; }

        [ExcelKit(Desc = "箱侧马达计数器轴高度t4", Align = TextAlign.Center)]
        public string? ShimCaset4 { get; set; }

        [ExcelKit(Desc = "箱侧输入轴深度t2", Align = TextAlign.Center)]
        public string? ShimCaset2 { get; set; }

        [ExcelKit(Desc = "垫片滑块（差速器轴）", Align = TextAlign.Center)]
        public string? ShimSlider { get; set; }

        [ExcelKit(Desc = "垫片等级（转向销轴）", Align = TextAlign.Center)]
        public string? ShimGrade { get; set; }

        [ExcelKit(Desc = "垫片等级（马达Co轴)", Align = TextAlign.Center)]
        public string? ShimGradeCo { get; set; }

        [ExcelKit(Desc = "垫片等级（输入轴）", Align = TextAlign.Center)]
        public string? ShimGradeIn { get; set; }

        [ExcelKit(Desc = "垫片实测值（差速器轴）", Align = TextAlign.Center)]
        public string? ShimValueDiff { get; set; }

        [ExcelKit(Desc = "垫片实测值（多拉销轴）", Align = TextAlign.Center)]
        public string? ShimValuePin { get; set; }

        [ExcelKit(Desc = "垫片实测值（马达Co轴）", Align = TextAlign.Center)]
        public string? ShimValueCo { get; set; }

        [ExcelKit(Desc = "垫片实测值（输入轴）", Align = TextAlign.Center)]
        public string? ShimValueIn { get; set; }

        [ExcelKit(Desc = "齿轮直径判定", Align = TextAlign.Center)]
        public string? ShimGear { get; set; }

        [ExcelKit(Desc = "α１（t1 - t2） 修正值", Align = TextAlign.Center)]
        public string? Shimt1t2 { get; set; }

        [ExcelKit(Desc = "α２（t3 - t4） 修正值", Align = TextAlign.Center)]
        public string? Shimt3t4 { get; set; }

        [ExcelKit(Desc = "α３（t5 - t6） 修正值", Align = TextAlign.Center)]
        public string? Shimt5t6 { get; set; }

        [ExcelKit(Desc = "α４（t7 - t8） 修正值", Align = TextAlign.Center)]
        public string? Shimt7t8 { get; set; }

        [ExcelKit(Desc = "t1主值", Align = TextAlign.Center)]
        public string? Shimt1Main { get; set; }

        [ExcelKit(Desc = "t3主值", Align = TextAlign.Center)]
        public string? Shimt3Main { get; set; }

        [ExcelKit(Desc = "t5主值", Align = TextAlign.Center)]
        public string? Shimt5Main { get; set; }

        [ExcelKit(Desc = "t7主值", Align = TextAlign.Center)]
        public string? Shimt7Main { get; set; }

        [ExcelKit(Desc = "t2主值", Align = TextAlign.Center)]
        public string? Shimt2Main { get; set; }

        [ExcelKit(Desc = "t4主值", Align = TextAlign.Center)]
        public string? Shimt4Main { get; set; }

        [ExcelKit(Desc = "t6主值", Align = TextAlign.Center)]
        public string? Shimt6Main { get; set; }

        [ExcelKit(Desc = "t８主值", Align = TextAlign.Center)]
        public string? Shimt8Main { get; set; }

        [ExcelKit(Desc = "计测日时", Align = TextAlign.Center)]
        public string? Hsg1MeasDate { get; set; }

        [ExcelKit(Desc = "拐点行程", Align = TextAlign.Center)]
        public string? Hsg1Stroke { get; set; }

        [ExcelKit(Desc = "変曲点负重", Align = TextAlign.Center)]
        public string? Hsg1PtLoad { get; set; }

        [ExcelKit(Desc = "最终行程", Align = TextAlign.Center)]
        public string? Hsg1FinalStroke { get; set; }

        [ExcelKit(Desc = "最終荷负重", Align = TextAlign.Center)]
        public string? Hsg1FinalLoad { get; set; }

        [ExcelKit(Desc = "拐点行程", Align = TextAlign.Center)]
        public string? Hsg1StrokeSec { get; set; }

        [ExcelKit(Desc = "変曲点负重", Align = TextAlign.Center)]
        public string? Hsg1PtLoadSec { get; set; }

        [ExcelKit(Desc = "最终行程", Align = TextAlign.Center)]
        public string? Hsg1FinalStrokeSec { get; set; }

        [ExcelKit(Desc = "最終荷负重", Align = TextAlign.Center)]
        public string? Hsg1FinalLoadSec { get; set; }

        [ExcelKit(Desc = "主行程", Align = TextAlign.Center)]
        public string? Hsg1MainStroke { get; set; }

        [ExcelKit(Desc = "A/B", Align = TextAlign.Center)]
        public string? Hsg1Abvalue { get; set; }


        [ExcelKit(Desc = "计测日时", Align = TextAlign.Center)]
        public string? Hsg2Date { get; set; }

        [ExcelKit(Desc = "拐点行程", Align = TextAlign.Center)]
        public string? Hsg2Stroke { get; set; }

        [ExcelKit(Desc = "変曲点负重", Align = TextAlign.Center)]
        public string? Hsg2PtLoad { get; set; }

        [ExcelKit(Desc = "最终行程", Align = TextAlign.Center)]
        public string? Hsg2FinalStroke { get; set; }

        [ExcelKit(Desc = "最終荷负重", Align = TextAlign.Center)]
        public string? Hsg2FinalLoad { get; set; }

        [ExcelKit(Desc = "拐点行程", Align = TextAlign.Center)]
        public string? Hsg2StrokeSec { get; set; }

        [ExcelKit(Desc = "変曲点负重", Align = TextAlign.Center)]
        public string? Hsg2PtLoadSec { get; set; }

        [ExcelKit(Desc = "最终行程", Align = TextAlign.Center)]
        public string? Hsg2FinalStrokeSec { get; set; }

        [ExcelKit(Desc = "最終荷负重", Align = TextAlign.Center)]
        public string? Hsg2FinalLoadSec { get; set; }

        [ExcelKit(Desc = "主行程", Align = TextAlign.Center)]
        public string? Hsg2MainStroke { get; set; }

        [ExcelKit(Desc = "A/B", Align = TextAlign.Center)]
        public string? Hsg2Abvalue { get; set; }


        [ExcelKit(Desc = "防错防误20计测日時", Align = TextAlign.Center)]
        public string? PokayokeDate20 { get; set; }

        [ExcelKit(Desc = "HSG FIGP计测日時", Align = TextAlign.Center)]
        public string? HsgFigpDate { get; set; }

        [ExcelKit(Desc = "画像判定結果", Align = TextAlign.Center)]
        public string? HsgFigpportrait { get; set; }

        [ExcelKit(Desc = "计测日時", Align = TextAlign.Center)]
        public string? HsgFitDate { get; set; }

        [ExcelKit(Desc = "HSG合体紧固①计测日時", Align = TextAlign.Center)]
        public string? Hsg1Date { get; set; }

        [ExcelKit(Desc = "HSG合体紧固①紧固角度1軸", Align = TextAlign.Center)]
        public string? Hsg1AngleAxis1 { get; set; }

        [ExcelKit(Desc = "HSG合体紧固①第1轴 判定代码", Align = TextAlign.Center)]
        public string? Hsg1CodeAxis1 { get; set; }

        [ExcelKit(Desc = "HSG合体紧固①紧固角度2軸", Align = TextAlign.Center)]
        public string? Hsg1AngleAxis2 { get; set; }

        [ExcelKit(Desc = "HSG合体紧固①第2轴 判定代码", Align = TextAlign.Center)]
        public string? Hsg1CodeAxis2 { get; set; }

        [ExcelKit(Desc = "HSG合体紧固①紧固角度3軸", Align = TextAlign.Center)]
        public string? Hsg1AngleAxis3 { get; set; }

        [ExcelKit(Desc = "HSG合体紧固①第3轴 判定代码", Align = TextAlign.Center)]
        public string? Hsg1CodeAxis3 { get; set; }

        [ExcelKit(Desc = "HSG合体紧固①紧固角度4軸", Align = TextAlign.Center)]
        public string? Hsg1AngleAxis4 { get; set; }

        [ExcelKit(Desc = "HSG合体紧固①第4轴 判定代码", Align = TextAlign.Center)]
        public string? Hsg1CodeAxis4 { get; set; }

        [ExcelKit(Desc = "HSG合体紧固①紧固角度5軸", Align = TextAlign.Center)]
        public string? Hsg1AngleAxis5 { get; set; }

        [ExcelKit(Desc = "HSG合体紧固①第5轴 判定代码", Align = TextAlign.Center)]
        public string? Hsg1CodeAxis5 { get; set; }

        [ExcelKit(Desc = "HSG合体紧固①紧固角度6軸", Align = TextAlign.Center)]
        public string? Hsg1AngleAxis6 { get; set; }

        [ExcelKit(Desc = "HSG合体紧固①第6轴 判定代码", Align = TextAlign.Center)]
        public string? Hsg1CodeAxis6 { get; set; }

        [ExcelKit(Desc = "HSG合体紧固①紧固角度7軸", Align = TextAlign.Center)]
        public string? Hsg1AngleAxis7 { get; set; }

        [ExcelKit(Desc = "HSG合体紧固①第7轴 判定代码", Align = TextAlign.Center)]
        public string? Hsg1CodeAxis7 { get; set; }

        [ExcelKit(Desc = "HSG合体紧固①紧固角度8軸", Align = TextAlign.Center)]
        public string? Hsg1AngleAxis8 { get; set; }

        [ExcelKit(Desc = "HSG合体紧固①第8轴 判定代码", Align = TextAlign.Center)]
        public string? Hsg1CodeAxis8 { get; set; }

        [ExcelKit(Desc = "HSG合体紧固①紧固角度9軸", Align = TextAlign.Center)]
        public string? Hsg1AngleAxis9 { get; set; }

        [ExcelKit(Desc = "HSG合体紧固①第9轴 判定代码", Align = TextAlign.Center)]
        public string? Hsg1CodeAxis9 { get; set; }

        [ExcelKit(Desc = "HSG合体紧固①紧固角度10軸", Align = TextAlign.Center)]
        public string? Hsg1AngleAxis10 { get; set; }

        [ExcelKit(Desc = "HSG合体紧固①第10轴 判定代码", Align = TextAlign.Center)]
        public string? Hsg1CodeAxis10 { get; set; }

        [ExcelKit(Desc = "HSG合体紧固①紧固角度11軸", Align = TextAlign.Center)]
        public string? Hsg1AngleAxis11 { get; set; }

        [ExcelKit(Desc = "HSG合体紧固①第11轴 判定代码", Align = TextAlign.Center)]
        public string? Hsg1CodeAxis11 { get; set; }

        [ExcelKit(Desc = "HSG合体紧固①A/B", Align = TextAlign.Center)]
        public string? Hsg1Ab { get; set; }

        [ExcelKit(Desc = "HSG合体紧固②计测日時", Align = TextAlign.Center)]
        public string? Hsg2MaesDate { get; set; }

        [ExcelKit(Desc = "HSG合体紧固②紧固角度1軸", Align = TextAlign.Center)]
        public string? Hsg2AngleAxis1 { get; set; }

        [ExcelKit(Desc = "HSG合体紧固②第1轴 判定代码", Align = TextAlign.Center)]
        public string? Hsg2CodeAxis1 { get; set; }

        [ExcelKit(Desc = "HSG合体紧固②紧固角度2軸", Align = TextAlign.Center)]
        public string? Hsg2AngleAxis2 { get; set; }

        [ExcelKit(Desc = "HSG合体紧固②第2轴 判定代码", Align = TextAlign.Center)]
        public string? Hsg2CodeAxis2 { get; set; }

        [ExcelKit(Desc = "HSG合体紧固②紧固角度3軸", Align = TextAlign.Center)]
        public string? Hsg2AngleAxis3 { get; set; }

        [ExcelKit(Desc = "HSG合体紧固②第3轴 判定代码", Align = TextAlign.Center)]
        public string? Hsg2CodeAxis3 { get; set; }

        [ExcelKit(Desc = "HSG合体紧固②紧固角度4軸", Align = TextAlign.Center)]
        public string? Hsg2AngleAxis4 { get; set; }

        [ExcelKit(Desc = "HSG合体紧固②第4轴 判定代码", Align = TextAlign.Center)]
        public string? Hsg2CodeAxis4 { get; set; }

        [ExcelKit(Desc = "HSG合体紧固②紧固角度5軸", Align = TextAlign.Center)]
        public string? Hsg2AngleAxis5 { get; set; }

        [ExcelKit(Desc = "HSG合体紧固②第5轴 判定代码", Align = TextAlign.Center)]
        public string? Hsg2CodeAxis5 { get; set; }

        [ExcelKit(Desc = "HSG合体紧固②紧固角度6軸", Align = TextAlign.Center)]
        public string? Hsg2AngleAxis6 { get; set; }

        [ExcelKit(Desc = "HSG合体紧固②第6轴 判定代码", Align = TextAlign.Center)]
        public string? Hsg2CodeAxis6 { get; set; }

        [ExcelKit(Desc = "HSG合体紧固②紧固角度7軸", Align = TextAlign.Center)]
        public string? Hsg2AngleAxis7 { get; set; }

        [ExcelKit(Desc = "HSG合体紧固②第7轴 判定代码", Align = TextAlign.Center)]
        public string? Hsg2CodeAxis7 { get; set; }

        [ExcelKit(Desc = "HSG合体紧固②紧固角度8軸", Align = TextAlign.Center)]
        public string? Hsg2AngleAxis8 { get; set; }

        [ExcelKit(Desc = "HSG合体紧固②第8轴 判定代码", Align = TextAlign.Center)]
        public string? Hsg2CodeAxis8 { get; set; }

        [ExcelKit(Desc = "HSG合体紧固②紧固角度9軸", Align = TextAlign.Center)]
        public string? Hsg2AngleAxis9 { get; set; }

        [ExcelKit(Desc = "HSG合体紧固②第9轴 判定代码", Align = TextAlign.Center)]
        public string? Hsg2CodeAxis9 { get; set; }

        [ExcelKit(Desc = "HSG合体紧固②紧固角度10軸", Align = TextAlign.Center)]
        public string? Hsg2AngleAxis10 { get; set; }

        [ExcelKit(Desc = "HSG合体紧固②第10轴 判定代码", Align = TextAlign.Center)]
        public string? Hsg2CodeAxis10 { get; set; }

        [ExcelKit(Desc = "HSG合体紧固②紧固角度11軸", Align = TextAlign.Center)]
        public string? Hsg2AngleAxis11 { get; set; }

        [ExcelKit(Desc = "HSG合体紧固②第11轴 判定代码", Align = TextAlign.Center)]
        public string? Hsg2CodeAxis11 { get; set; }

        [ExcelKit(Desc = "HSG合体紧固②A/B", Align = TextAlign.Center)]
        public string? Hsg2Ab { get; set; }

        [ExcelKit(Desc = "防错防误27计测日時", Align = TextAlign.Center)]
        public string? PokayokeDate27 { get; set; }

        [ExcelKit(Desc = "OS圧入1计测日时", Align = TextAlign.Center)]
        public string? Os1date { get; set; }

        [ExcelKit(Desc = "差速器LH OS拐点行程", Align = TextAlign.Center)]
        public string? Os1lhstroke { get; set; }

        [ExcelKit(Desc = "差速器LH OS拐点负重", Align = TextAlign.Center)]
        public string? Os1lhload { get; set; }

        [ExcelKit(Desc = "差速器LH OS最终行程", Align = TextAlign.Center)]
        public string? Os1lhfinalStroke { get; set; }

        [ExcelKit(Desc = "差速器LH OS最终负重", Align = TextAlign.Center)]
        public string? Os1lhfinalLoad { get; set; }

        [ExcelKit(Desc = "差速器RH OS拐点行程", Align = TextAlign.Center)]
        public string? Os1rhstroke { get; set; }

        [ExcelKit(Desc = "差速器RH OS拐点负重", Align = TextAlign.Center)]
        public string? Os1rhload { get; set; }

        [ExcelKit(Desc = "差速器RH OS最终行程", Align = TextAlign.Center)]
        public string? Os1rhfinalStroke { get; set; }

        [ExcelKit(Desc = "差速器RH OS最终负重", Align = TextAlign.Center)]
        public string? Os1rhfinalLoad { get; set; }

        [ExcelKit(Desc = "主行程", Align = TextAlign.Center)]
        public string? Os1mainStroke { get; set; }

        [ExcelKit(Desc = "A/B", Align = TextAlign.Center)]
        public string? Os1abvalue { get; set; }


        [ExcelKit(Desc = "OS圧入2计测日时", Align = TextAlign.Center)]
        public string? Os2date { get; set; }

        [ExcelKit(Desc = "I/P OS拐点行程", Align = TextAlign.Center)]
        public string? Os2stroke { get; set; }

        [ExcelKit(Desc = "I/P OS拐点负重", Align = TextAlign.Center)]
        public string? Os2ptLoad { get; set; }

        [ExcelKit(Desc = "I/P OS最终行程", Align = TextAlign.Center)]
        public string? Os2finalStroke { get; set; }

        [ExcelKit(Desc = "I/P OS最终负重", Align = TextAlign.Center)]
        public string? Os2finalLoad { get; set; }

        [ExcelKit(Desc = "主行程", Align = TextAlign.Center)]
        public string? Os2mainStroke { get; set; }

        [ExcelKit(Desc = "A/B", Align = TextAlign.Center)]
        public string? Os2abvalue { get; set; }

        [ExcelKit(Desc = "防错防误21计测日時", Align = TextAlign.Center)]
        public string? PokayokeDate21 { get; set; }

        [ExcelKit(Desc = "Assy正立计测日時", Align = TextAlign.Center)]
        public string? AssyDate { get; set; }

        [ExcelKit(Desc = "防错防误22计测日時", Align = TextAlign.Center)]
        public string? PokayokeDate22 { get; set; }

        [ExcelKit(Desc = "防错防误23计测日時", Align = TextAlign.Center)]
        public string? PokayokeDate23 { get; set; }

        [ExcelKit(Desc = "防错防误24计测日時", Align = TextAlign.Center)]
        public string? PokayokeDate24 { get; set; }

        [ExcelKit(Desc = "防错防误25计测日時", Align = TextAlign.Center)]
        public string? PokayokeDate25 { get; set; }

        [ExcelKit(Desc = "计测日时", Align = TextAlign.Center)]
        public string? LeakDate { get; set; }

        [ExcelKit(Desc = "齿轮室泄漏量", Align = TextAlign.Center)]
        public string? LeakGear { get; set; }

        [ExcelKit(Desc = "泄露修正值", Align = TextAlign.Center)]
        public string? LeakCorrect { get; set; }

        [ExcelKit(Desc = "温度情报", Align = TextAlign.Center)]
        public string? LeakTempDec { get; set; }

        [ExcelKit(Desc = "主值泄漏量", Align = TextAlign.Center)]
        public string? LeakMain { get; set; }

        [ExcelKit(Desc = "給油前重量", Align = TextAlign.Center)]
        public string? LeakFrontOil { get; set; }

        [ExcelKit(Desc = "e-TAF注油完了", Align = TextAlign.Center)]
        public string? LeakEtaf { get; set; }

        [ExcelKit(Desc = "給油後重量", Align = TextAlign.Center)]
        public string? LeakLastOil { get; set; }

        [ExcelKit(Desc = "气氛温度", Align = TextAlign.Center)]
        public string? LeakTemp { get; set; }

        [ExcelKit(Desc = "湿度", Align = TextAlign.Center)]
        public string? LeakHumidity { get; set; }

        [ExcelKit(Desc = "油温传感器判定", Align = TextAlign.Center)]
        public string? LeakOilTempDec { get; set; }

        [ExcelKit(Desc = "絶縁电阻MG1 Ω", Align = TextAlign.Center)]
        public string? LeakMg1mohm { get; set; }

        [ExcelKit(Desc = "絶縁电阻MG1判定", Align = TextAlign.Center)]
        public string? LeakMg1dec { get; set; }

        [ExcelKit(Desc = "絶縁电阻MG2 Ω", Align = TextAlign.Center)]
        public string? LeakMg2mohm { get; set; }

        [ExcelKit(Desc = "絶縁电阻MG2判定", Align = TextAlign.Center)]
        public string? LeakMg2dec { get; set; }

        [ExcelKit(Desc = "絶縁耐圧MG1", Align = TextAlign.Center)]
        public string? LeakMg1dielectric { get; set; }

        [ExcelKit(Desc = "絶縁耐圧MG1判定", Align = TextAlign.Center)]
        public string? LeakMg1dielectricDec { get; set; }

        [ExcelKit(Desc = "絶縁耐圧MG2", Align = TextAlign.Center)]
        public string? LeakMg2dielectric { get; set; }

        [ExcelKit(Desc = "絶縁耐圧MG2判定", Align = TextAlign.Center)]
        public string? LeakMg2dielectricDec { get; set; }

        [ExcelKit(Desc = "热敏电阻絶縁电阻 Ω", Align = TextAlign.Center)]
        public string? LeakThermistor { get; set; }

        [ExcelKit(Desc = "热敏电阻絶縁电阻判定", Align = TextAlign.Center)]
        public string? LeakThermistorDec { get; set; }

        [ExcelKit(Desc = "旋转变压器絶縁电阻 Ω", Align = TextAlign.Center)]
        public string? LeakResolver { get; set; }

        [ExcelKit(Desc = "旋转变压器絶縁电阻判定", Align = TextAlign.Center)]
        public string? LeakResolverDec { get; set; }

        [ExcelKit(Desc = "油温传感器絶縁电阻判定", Align = TextAlign.Center)]
        public string? LeakOilTempMohmDec { get; set; }

        [ExcelKit(Desc = "线间电阻MG1U-V Ω", Align = TextAlign.Center)]
        public string? LeakMg1uv { get; set; }

        [ExcelKit(Desc = "线间电阻MG1U-V判定", Align = TextAlign.Center)]
        public string? LeakMg1uvdec { get; set; }

        [ExcelKit(Desc = "线间电阻MG1V-W Ω", Align = TextAlign.Center)]
        public string? LeakMg1uw { get; set; }

        [ExcelKit(Desc = "线间电阻MG1V-W判定", Align = TextAlign.Center)]
        public string? LeakMg1uwdec { get; set; }

        [ExcelKit(Desc = "线间电阻MG1W-U Ω", Align = TextAlign.Center)]
        public string? LeakMg1wu { get; set; }

        [ExcelKit(Desc = "线间电阻MG1W-U判定", Align = TextAlign.Center)]
        public string? LeakMg1wudec { get; set; }

        [ExcelKit(Desc = "线间电阻MG2U-V Ω", Align = TextAlign.Center)]
        public string? LeakMg2uv { get; set; }

        [ExcelKit(Desc = "线间电阻MG2U-V判定", Align = TextAlign.Center)]
        public string? LeakMg2uvdec { get; set; }

        [ExcelKit(Desc = "线间电阻MG2V-W Ω", Align = TextAlign.Center)]
        public string? LeakMg2uw { get; set; }

        [ExcelKit(Desc = "线间电阻MG2V-W判定", Align = TextAlign.Center)]
        public string? LeakMg2uwdec { get; set; }

        [ExcelKit(Desc = "线间电阻MG2W-U Ω", Align = TextAlign.Center)]
        public string? LeakMg2wu { get; set; }

        [ExcelKit(Desc = "线间电阻MG2W-U判定", Align = TextAlign.Center)]
        public string? LeakMg2wudec { get; set; }

        [ExcelKit(Desc = "热敏电阻线间电阻MG1 Ω", Align = TextAlign.Center)]
        public string? LeakThermistorMg1 { get; set; }

        [ExcelKit(Desc = "热敏电阻线间电阻MG1判定", Align = TextAlign.Center)]
        public string? LeakThermistorMg1dec { get; set; }

        [ExcelKit(Desc = "热敏电阻线间电阻MG2 Ω", Align = TextAlign.Center)]
        public string? LeakThermistorMg2 { get; set; }

        [ExcelKit(Desc = "热敏电阻线间电阻MG2判定", Align = TextAlign.Center)]
        public string? LeakThermistorMg2dec { get; set; }

        [ExcelKit(Desc = "油温传感器絶縁电阻", Align = TextAlign.Center)]
        public string? LeakOilLine { get; set; }

        [ExcelKit(Desc = "油温传感器絶縁电阻判定", Align = TextAlign.Center)]
        public string? LeakOilLineDec { get; set; }

        [ExcelKit(Desc = "MG1旋转变压器连接器内相关短路判定", Align = TextAlign.Center)]
        public string? LeakMg1rotateDec { get; set; }

        [ExcelKit(Desc = "MG2旋转变压器连接器内相关短路判定", Align = TextAlign.Center)]
        public string? LeakMg2rotateDec { get; set; }

        [ExcelKit(Desc = "MG1W相×MG2V相短路判定", Align = TextAlign.Center)]
        public string? LeakMg1wmg2v { get; set; }

        [ExcelKit(Desc = "油温传感器絶縁电阻", Align = TextAlign.Center)]
        public string? LeakOil { get; set; }

        [ExcelKit(Desc = "旋转变压器线间电阻MG1 GRFG-GRF(9-6間)（Ω）", Align = TextAlign.Center)]
        public string? LeakMg196 { get; set; }

        [ExcelKit(Desc = "旋转变压器线间电阻MG1 GRFG-GRF(9-6間)判定", Align = TextAlign.Center)]
        public string? LeakMg196dec { get; set; }

        [ExcelKit(Desc = "旋转变压器线间电阻MG1 GCSG-GCS(14-10間)（Ω）", Align = TextAlign.Center)]
        public string? LeakMg11410 { get; set; }

        [ExcelKit(Desc = "旋转变压器线间电阻MG1 GCSG-GCS(14-10間)判定", Align = TextAlign.Center)]
        public string? LeakMg11410dec { get; set; }

        [ExcelKit(Desc = "旋转变压器线间电阻MG1 GSN-GSNG(13-5間)（Ω）", Align = TextAlign.Center)]
        public string? LeakMg1135 { get; set; }

        [ExcelKit(Desc = "旋转变压器线间电阻MG1 GSN-GSNG(13-5間)判定", Align = TextAlign.Center)]
        public string? LeakMg1135dec { get; set; }

        [ExcelKit(Desc = "旋转变压器线间电阻MG2 MRFG-MRF(8-1間)（Ω）", Align = TextAlign.Center)]
        public string? LeakMg281 { get; set; }

        [ExcelKit(Desc = "旋转变压器线间电阻MG2 MRFG-MRF(8-1間)判定", Align = TextAlign.Center)]
        public string? LeakMg281dec { get; set; }

        [ExcelKit(Desc = "旋转变压器线间电阻MG2 MCSG-MCS(11-7間)（Ω）", Align = TextAlign.Center)]
        public string? LeakMg2117 { get; set; }

        [ExcelKit(Desc = "旋转变压器线间电阻MG2 MCSG-MCS(11-7間)判定", Align = TextAlign.Center)]
        public string? LeakMg2117dec { get; set; }

        [ExcelKit(Desc = "旋转变压器线间电阻MG2 MSN-MSNG(3-2間)（Ω）", Align = TextAlign.Center)]
        public string? LeakMg232 { get; set; }

        [ExcelKit(Desc = "旋转变压器线间电阻MG2 MSN-MSNG(3-2間)判定", Align = TextAlign.Center)]
        public string? LeakMg232dec { get; set; }

        [ExcelKit(Desc = "多列标识", Align = TextAlign.Center)]
        public string? LeakCol { get; set; }

        [ExcelKit(Desc = "Iss计测日时", Align = TextAlign.Center)]
        public DateTime? IssDate { get; set; }

        [ExcelKit(Desc = "P锁定判定", Align = TextAlign.Center)]
        public string? IssP { get; set; }

        [ExcelKit(Desc = "notP判定", Align = TextAlign.Center)]
        public string? IssnotP { get; set; }

        [ExcelKit(Desc = "官能判定", Align = TextAlign.Center)]
        public string? IssFunction { get; set; }

        [ExcelKit(Desc = "MG1探测接触电阻U-V间 Ω", Align = TextAlign.Center)]
        public string? IssMg1uv { get; set; }

        [ExcelKit(Desc = "MG1探测接触电阻U-V间判定", Align = TextAlign.Center)]
        public string? IssMg1uvdec { get; set; }

        [ExcelKit(Desc = "MG1探测接触电阻V-W间 Ω", Align = TextAlign.Center)]
        public string? IssMg1vw { get; set; }

        [ExcelKit(Desc = "MG1探测接触电阻V-W间判定", Align = TextAlign.Center)]
        public string? IssMg1vwdec { get; set; }

        [ExcelKit(Desc = "MG2探测接触电阻U-V间 Ω", Align = TextAlign.Center)]
        public string? IssMg2uv { get; set; }

        [ExcelKit(Desc = "MG2探测接触电阻U-V间判定", Align = TextAlign.Center)]
        public string? IssMg2uvdec { get; set; }

        [ExcelKit(Desc = "MG2探测接触电阻V-W间 Ω", Align = TextAlign.Center)]
        public string? IssMg2vw { get; set; }

        [ExcelKit(Desc = "MG2探测接触电阻V-W间判定", Align = TextAlign.Center)]
        public string? IssMg2vwdec { get; set; }

        [ExcelKit(Desc = "MG1旋转变压器偏移値", Align = TextAlign.Center)]
        public string? IssMg1value { get; set; }

        [ExcelKit(Desc = "MG1旋转变压器偏移値判定", Align = TextAlign.Center)]
        public string? IssMg1valueDec { get; set; }

        [ExcelKit(Desc = "MG2旋转变压器偏移値", Align = TextAlign.Center)]
        public string? IssMg2value { get; set; }

        [ExcelKit(Desc = "MG2旋转变压器偏移値判定", Align = TextAlign.Center)]
        public string? IssMg2valueDec { get; set; }

        [ExcelKit(Desc = "MG1反向电压U-V Ω", Align = TextAlign.Center)]
        public string? IssMg1disUv { get; set; }

        [ExcelKit(Desc = "MG1反向电压U-V判定", Align = TextAlign.Center)]
        public string? IssMg1disUvdec { get; set; }

        [ExcelKit(Desc = "MG1反向电压V-W Ω", Align = TextAlign.Center)]
        public string? IssMg1disVw { get; set; }

        [ExcelKit(Desc = "MG1反向电压V-W判定", Align = TextAlign.Center)]
        public string? IssMg1disVwdec { get; set; }

        [ExcelKit(Desc = "MG2反向电压U-V Ω", Align = TextAlign.Center)]
        public string? IssMg2disUv { get; set; }

        [ExcelKit(Desc = "MG2反向电压U-V判定", Align = TextAlign.Center)]
        public string? IssMg2disUvdec { get; set; }

        [ExcelKit(Desc = "MG2反向电压V-W Ω", Align = TextAlign.Center)]
        public string? IssMg2disVw { get; set; }

        [ExcelKit(Desc = "MG2反向电压V-W判定", Align = TextAlign.Center)]
        public string? IssMg2disVwdec { get; set; }

        [ExcelKit(Desc = "齿轮比確認MG2旋转数", Align = TextAlign.Center)]
        public string? IssMg2gear { get; set; }

        [ExcelKit(Desc = "齿轮比確認判定", Align = TextAlign.Center)]
        public string? IssMg2gearDec { get; set; }

        [ExcelKit(Desc = "异音測定加速判定", Align = TextAlign.Center)]
        public string? IssRevup { get; set; }

        [ExcelKit(Desc = "异音測定減速判定", Align = TextAlign.Center)]
        public string? IssSlowup { get; set; }

        [ExcelKit(Desc = "加速側计数器综合判定", Align = TextAlign.Center)]
        public string? IssRevCounter { get; set; }

        [ExcelKit(Desc = "加速側最终综合判定", Align = TextAlign.Center)]
        public string? IssRevLast { get; set; }

        [ExcelKit(Desc = "減速側计数器综合判定", Align = TextAlign.Center)]
        public string? IssSlowCounter { get; set; }

        [ExcelKit(Desc = "減速側最终综合判定", Align = TextAlign.Center)]
        public string? IssSlowLast { get; set; }

        [ExcelKit(Desc = "加速側差速器轴平均負荷扭矩", Align = TextAlign.Center)]
        public string? IssRevAvg { get; set; }

        [ExcelKit(Desc = "加速側差速器轴平均負荷扭矩判定", Align = TextAlign.Center)]
        public string? IssRevAvgDec { get; set; }

        [ExcelKit(Desc = "減速側差速器轴平均負荷扭矩", Align = TextAlign.Center)]
        public string? IssSlowAvg { get; set; }

        [ExcelKit(Desc = "減速側差速器轴平均負荷扭矩判定", Align = TextAlign.Center)]
        public string? IssSlowAvgDec { get; set; }

        [ExcelKit(Desc = "油温传感器温度", Align = TextAlign.Center)]
        public string? IssOilTemp { get; set; }

        [ExcelKit(Desc = "加速側计数器区间1噪音", Align = TextAlign.Center)]
        public string? IssRev1Noise { get; set; }

        [ExcelKit(Desc = "加速側计数器区间1频率", Align = TextAlign.Center)]
        public string? IssRev1Rate { get; set; }

        [ExcelKit(Desc = "加速側计数器区间1判定", Align = TextAlign.Center)]
        public string? IssRev1 { get; set; }

        [ExcelKit(Desc = "加速側计数器区间2噪音", Align = TextAlign.Center)]
        public string? IssRev2Noise { get; set; }

        [ExcelKit(Desc = "加速側计数器区间2频率", Align = TextAlign.Center)]
        public string? IssRev2Rate { get; set; }

        [ExcelKit(Desc = "加速側计数器区间2判定", Align = TextAlign.Center)]
        public string? IssRev2 { get; set; }

        [ExcelKit(Desc = "加速側计数器区间3噪音", Align = TextAlign.Center)]
        public string? IssRev3Noise { get; set; }

        [ExcelKit(Desc = "加速側计数器区间3频率", Align = TextAlign.Center)]
        public string? IssRev3Rate { get; set; }

        [ExcelKit(Desc = "加速側计数器区间3判定", Align = TextAlign.Center)]
        public string? IssRev3 { get; set; }

        [ExcelKit(Desc = "加速側计数器区间4噪音", Align = TextAlign.Center)]
        public string? IssRev4Noise { get; set; }

        [ExcelKit(Desc = "加速側计数器区间4频率", Align = TextAlign.Center)]
        public string? IssRev4Rate { get; set; }

        [ExcelKit(Desc = "加速側计数器区间4判定", Align = TextAlign.Center)]
        public string? IssRev4 { get; set; }

        [ExcelKit(Desc = "加速側计数器区间5噪音", Align = TextAlign.Center)]
        public string? IssRev5Noise { get; set; }

        [ExcelKit(Desc = "加速側计数器区间5频率", Align = TextAlign.Center)]
        public string? IssRev5Rate { get; set; }

        [ExcelKit(Desc = "加速側计数器区间5判定", Align = TextAlign.Center)]
        public string? IssRev5 { get; set; }

        [ExcelKit(Desc = "加速側最终区间1噪音", Align = TextAlign.Center)]
        public string? IssRevLast1Noise { get; set; }

        [ExcelKit(Desc = "加速側最终区间1频率", Align = TextAlign.Center)]
        public string? IssRevLast1Rate { get; set; }

        [ExcelKit(Desc = "加速側最终区间1判定", Align = TextAlign.Center)]
        public string? IssRevLast1 { get; set; }

        [ExcelKit(Desc = "加速側最终区间2噪音", Align = TextAlign.Center)]
        public string? IssRevLast2Noise { get; set; }

        [ExcelKit(Desc = "加速側最终区间2频率", Align = TextAlign.Center)]
        public string? IssRevLast2Rate { get; set; }

        [ExcelKit(Desc = "加速側最终区间2判定", Align = TextAlign.Center)]
        public string? IssRevLast2 { get; set; }

        [ExcelKit(Desc = "加速側最终区间3噪音", Align = TextAlign.Center)]
        public string? IssRevLast3Noise { get; set; }

        [ExcelKit(Desc = "加速側最终区间3频率", Align = TextAlign.Center)]
        public string? IssRevLast3Rate { get; set; }

        [ExcelKit(Desc = "加速側最终区间3判定", Align = TextAlign.Center)]
        public string? IssRevLast3 { get; set; }

        [ExcelKit(Desc = "加速側最终区间4噪音", Align = TextAlign.Center)]
        public string? IssRevLast4Noise { get; set; }

        [ExcelKit(Desc = "加速側最终区间4频率", Align = TextAlign.Center)]
        public string? IssRevLast4Rate { get; set; }

        [ExcelKit(Desc = "加速側最终区间4判定", Align = TextAlign.Center)]
        public string? IssRevLast4 { get; set; }

        [ExcelKit(Desc = "加速側最终区间5噪音", Align = TextAlign.Center)]
        public string? IssRevLast5Noise { get; set; }

        [ExcelKit(Desc = "加速側最终区间5频率", Align = TextAlign.Center)]
        public string? IssRevLast5Rate { get; set; }

        [ExcelKit(Desc = "加速側最终区间5判定", Align = TextAlign.Center)]
        public string? IssRevLast5 { get; set; }

        [ExcelKit(Desc = "減速側计数器区间1噪音", Align = TextAlign.Center)]
        public string? IssSlow1Noise { get; set; }

        [ExcelKit(Desc = "減速側计数器区间1频率", Align = TextAlign.Center)]
        public string? IssSlow1Rate { get; set; }

        [ExcelKit(Desc = "減速側计数器区间1判定", Align = TextAlign.Center)]
        public string? IssSlow1 { get; set; }

        [ExcelKit(Desc = "減速側计数器区间2噪音", Align = TextAlign.Center)]
        public string? IssSlow2Noise { get; set; }

        [ExcelKit(Desc = "減速側计数器区间2频率", Align = TextAlign.Center)]
        public string? IssSlow2Rate { get; set; }

        [ExcelKit(Desc = "減速側计数器区间2判定", Align = TextAlign.Center)]
        public string? IssSlow2 { get; set; }

        [ExcelKit(Desc = "減速側计数器区间3噪音", Align = TextAlign.Center)]
        public string? IssSlow3Noise { get; set; }

        [ExcelKit(Desc = "減速側计数器区间3频率", Align = TextAlign.Center)]
        public string? IssSlow3Rate { get; set; }

        [ExcelKit(Desc = "減速側计数器区间3判定", Align = TextAlign.Center)]
        public string? IssSlow3 { get; set; }

        [ExcelKit(Desc = "減速側计数器区间4噪音", Align = TextAlign.Center)]
        public string? IssSlow4Noise { get; set; }

        [ExcelKit(Desc = "減速側计数器区间4频率", Align = TextAlign.Center)]
        public string? IssSlow4Rate { get; set; }

        [ExcelKit(Desc = "減速側计数器区间4判定", Align = TextAlign.Center)]
        public string? IssSlow4 { get; set; }

        [ExcelKit(Desc = "減速側计数器区间5噪音", Align = TextAlign.Center)]
        public string? IssSlow5Noise { get; set; }

        [ExcelKit(Desc = "減速側计数器区间5频率", Align = TextAlign.Center)]
        public string? IssSlow5Rate { get; set; }

        [ExcelKit(Desc = "減速側计数器区间5判定", Align = TextAlign.Center)]
        public string? IssSlow5 { get; set; }

        [ExcelKit(Desc = "減速側最终区间1噪音", Align = TextAlign.Center)]
        public string? IssSlowLast1Noise { get; set; }

        [ExcelKit(Desc = "減速側最终区间1频率", Align = TextAlign.Center)]
        public string? IssSlowLast1Rate { get; set; }

        [ExcelKit(Desc = "減速側最终区间1判定", Align = TextAlign.Center)]
        public string? IssSlowLast1 { get; set; }

        [ExcelKit(Desc = "減速側最终区间2噪音", Align = TextAlign.Center)]
        public string? IssSlowLast2Noise { get; set; }

        [ExcelKit(Desc = "減速側最终区间2频率", Align = TextAlign.Center)]
        public string? IssSlowLast2Rate { get; set; }


        [ExcelKit(Desc = "減速側最终区间2判定", Align = TextAlign.Center)]
        public string? IssSlowLast2 { get; set; }

        [ExcelKit(Desc = "減速側最终区间3噪音", Align = TextAlign.Center)]
        public string? IssSlowLast3Noise { get; set; }

        [ExcelKit(Desc = "減速側最终区间3频率", Align = TextAlign.Center)]
        public string? IssSlowLast3Rate { get; set; }

        [ExcelKit(Desc = "減速側最终区间3判定", Align = TextAlign.Center)]
        public string? IssSlowLast3 { get; set; }

        [ExcelKit(Desc = "減速側最终区间4噪音", Align = TextAlign.Center)]
        public string? IssSlowLast4Noise { get; set; }

        [ExcelKit(Desc = "減速側最终区间4频率", Align = TextAlign.Center)]
        public string? IssSlowLast4Rate { get; set; }

        [ExcelKit(Desc = "減速側最终区间4判定", Align = TextAlign.Center)]
        public string? IssSlowLast4 { get; set; }

        [ExcelKit(Desc = "減速側最终区间5噪音", Align = TextAlign.Center)]
        public string? IssSlowLast5Noise { get; set; }

        [ExcelKit(Desc = "減速側最终区间5频率", Align = TextAlign.Center)]
        public string? IssSlowLast5Rate { get; set; }

        [ExcelKit(Desc = "減速側最终区间5判定", Align = TextAlign.Center)]
        public string? IssSlowLast5 { get; set; }

        [ExcelKit(Desc = "加速颜色映射综合判定", Align = TextAlign.Center)]
        public string? IssRevColor { get; set; }

        [ExcelKit(Desc = "減速颜色映射综合判定", Align = TextAlign.Center)]
        public string? IssSlowColor { get; set; }

        [ExcelKit(Desc = "①加速颜色映射判定噪音(dB)", Align = TextAlign.Center)]
        public string? IssRevColor1dB { get; set; }

        [ExcelKit(Desc = "①加速颜色映射判定频率(Hz)", Align = TextAlign.Center)]
        public string? IssRevColor1Hz { get; set; }

        [ExcelKit(Desc = "①加速颜色映射判定旋转数(rpm)", Align = TextAlign.Center)]
        public string? IssRevColor1rpm { get; set; }

        [ExcelKit(Desc = "①加速颜色映射判定次数", Align = TextAlign.Center)]
        public string? IssRevColor1sum { get; set; }

        [ExcelKit(Desc = "①加速颜色映射判定", Align = TextAlign.Center)]
        public string? IssRevColor1Dec { get; set; }

        [ExcelKit(Desc = "①減速颜色映射判定噪音(dB)", Align = TextAlign.Center)]
        public string? IssSlowColor1dB { get; set; }

        [ExcelKit(Desc = "①減速颜色映射判定频率(Hz)", Align = TextAlign.Center)]
        public string? IssSlowColor1Hz { get; set; }

        [ExcelKit(Desc = "①減速颜色映射判定旋转数(rpm)", Align = TextAlign.Center)]
        public string? IssSlowColor1rpm { get; set; }

        [ExcelKit(Desc = "①減速颜色映射判定次数", Align = TextAlign.Center)]
        public string? IssSlowColor1sum { get; set; }

        [ExcelKit(Desc = "①減速颜色映射判定", Align = TextAlign.Center)]
        public string? IssSlowColor1Dec { get; set; }

        [ExcelKit(Desc = "②加速颜色映射判定噪音(dB)", Align = TextAlign.Center)]
        public string? IssRevColor2dB { get; set; }

        [ExcelKit(Desc = "②加速颜色映射判定频率(Hz)", Align = TextAlign.Center)]
        public string? IssRevColor2Hz { get; set; }

        [ExcelKit(Desc = "②加速颜色映射判定旋转数(rpm)", Align = TextAlign.Center)]
        public string? IssRevColor2rpm { get; set; }

        [ExcelKit(Desc = "②加速颜色映射判定次数", Align = TextAlign.Center)]
        public string? IssRevColor2sum { get; set; }

        [ExcelKit(Desc = "②加速颜色映射判定", Align = TextAlign.Center)]
        public string? IssRevColor2Dec { get; set; }

        [ExcelKit(Desc = "②減速颜色映射判定噪音(dB)", Align = TextAlign.Center)]
        public string? IssSlowColor2dB { get; set; }

        [ExcelKit(Desc = "②減速颜色映射判定频率(Hz)", Align = TextAlign.Center)]
        public string? IssSlowColor2Hz { get; set; }

        [ExcelKit(Desc = "②減速颜色映射判定旋转数(rpm)", Align = TextAlign.Center)]
        public string? IssSlowColor2rpm { get; set; }

        [ExcelKit(Desc = "②減速颜色映射判定次数", Align = TextAlign.Center)]
        public string? IssSlowColor2sum { get; set; }

        [ExcelKit(Desc = "②減速颜色映射判定", Align = TextAlign.Center)]
        public string? IssSlowColor2Dec { get; set; }

        [ExcelKit(Desc = "③加速颜色映射判定噪音(dB)", Align = TextAlign.Center)]
        public string? IssRevColor3dB { get; set; }

        [ExcelKit(Desc = "③加速颜色映射判定频率(Hz)", Align = TextAlign.Center)]
        public string? IssRevColor3Hz { get; set; }

        [ExcelKit(Desc = "③加速颜色映射判定旋转数(rpm)", Align = TextAlign.Center)]
        public string? IssRevColor3rpm { get; set; }

        [ExcelKit(Desc = "③加速颜色映射判定次数", Align = TextAlign.Center)]
        public string? IssRevColor3sum { get; set; }

        [ExcelKit(Desc = "③加速颜色映射判定", Align = TextAlign.Center)]
        public string? IssRevColor3Dec { get; set; }

        [ExcelKit(Desc = "③減速颜色映射判定噪音(dB)", Align = TextAlign.Center)]
        public string? IssSlowColor3dB { get; set; }

        [ExcelKit(Desc = "③減速颜色映射判定频率(Hz)", Align = TextAlign.Center)]
        public string? IssSlowColor3Hz { get; set; }

        [ExcelKit(Desc = "③減速颜色映射判定旋转数(rpm)", Align = TextAlign.Center)]
        public string? IssSlowColor3rpm { get; set; }

        [ExcelKit(Desc = "③減速颜色映射判定次数", Align = TextAlign.Center)]
        public string? IssSlowColor3sum { get; set; }

        [ExcelKit(Desc = "③減速颜色映射判定", Align = TextAlign.Center)]
        public string? IssSlowColor3Dec { get; set; }

        [ExcelKit(Desc = "多行识别", Align = TextAlign.Center)]
        public string? IssCol { get; set; }

        [ExcelKit(Desc = "油泵油圧", Align = TextAlign.Center)]
        public string? IssOilPump { get; set; }

        [ExcelKit(Desc = "油泵油圧判定", Align = TextAlign.Center)]
        public string? IssOilPumpDec { get; set; }

        [ExcelKit(Desc = "溢流阀油圧", Align = TextAlign.Center)]
        public string? IssReliefValve { get; set; }

        [ExcelKit(Desc = "溢流阀油圧判定", Align = TextAlign.Center)]
        public string? IssReliefValveDec { get; set; }

        [ExcelKit(Desc = "防错防误26计测日時", Align = TextAlign.Center)]
        public string? PokayokeDate26 { get; set; }

        [ExcelKit(Desc = "防错防误28计测日時", Align = TextAlign.Center)]
        public string? PokayokeDate28 { get; set; }

        [ExcelKit(Desc = "防错防误29计测日時", Align = TextAlign.Center)]
        public string? PokayokeDate29 { get; set; }

        [ExcelKit(Desc = "刻印计测日時", Align = TextAlign.Center)]
        public string? EngravingData { get; set; }

        [ExcelKit(Desc = "防错防误30计测日時", Align = TextAlign.Center)]
        public string? PokayokeDate30 { get; set; }

        [ExcelKit(Desc = "防错防误31计测日時", Align = TextAlign.Center)]
        public string? PokayokeDate31 { get; set; }

        [ExcelKit(Desc = "外観検査计测日時", Align = TextAlign.Center)]
        public string? InspectionDate { get; set; }

        [ExcelKit(Desc = "防错防误32计测日時", Align = TextAlign.Center)]
        public string? PokayokeDate32 { get; set; }

        [ExcelKit(Desc = "HSG セット计测日時", Align = TextAlign.Center)]
        public string? HsgSetDate { get; set; }

        [ExcelKit(Desc = "托盘 No", Align = TextAlign.Center)]
        public string? Tray { get; set; }

        [ExcelKit(Desc = "重量", Align = TextAlign.Center)]
        public string? Weight { get; set; }
    }
}
