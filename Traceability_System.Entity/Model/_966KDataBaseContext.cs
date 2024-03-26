using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Traceability_System.Entity.Model
{
    public partial class _966KDataBaseContext : DbContext
    {
        public _966KDataBaseContext()
        {
        }

        public _966KDataBaseContext(DbContextOptions<_966KDataBaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<GearTable> GearTables { get; set; } = null!;
        public virtual DbSet<MotorTable> MotorTables { get; set; } = null!;
        public virtual DbSet<RotorTable> RotorTables { get; set; } = null!;
        public virtual DbSet<Rrtable> Rrtables { get; set; } = null!;
        public virtual DbSet<Shipping> Shippings { get; set; } = null!;
        public virtual DbSet<Tatable> Tatables { get; set; } = null!;
        public virtual DbSet<Vw1RotorTable> Vw1RotorTables { get; set; } = null!;
        public virtual DbSet<Vw2RotorTable> Vw2RotorTables { get; set; } = null!;
        public virtual DbSet<VwGearTable> VwGearTables { get; set; } = null!;
        public virtual DbSet<VwMotorTable> VwMotorTables { get; set; } = null!;
        public virtual DbSet<VwRrtable> VwRrtables { get; set; } = null!;

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=.;Database=966KDataBase;uid=sa;pwd=123456");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GearTable>(entity =>
            {
                entity.ToTable("GearTable");

                entity.HasIndex(e => e.DfringSerial, "idx_GearTable_DfringSerial");

                entity.Property(e => e.Apicode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("APICode");

                entity.Property(e => e.ApicoreTemp)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("APICoreTemp");

                entity.Property(e => e.Apidate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("APIDate");

                entity.Property(e => e.ApideviationLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("APIDeviationLoad");

                entity.Property(e => e.ApifinalStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("APIFinalStroke");

                entity.Property(e => e.ApiinitTilt)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("APIInitTilt");

                entity.Property(e => e.Apiload)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("APILoad");

                entity.Property(e => e.Apimachine)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("APIMachine");

                entity.Property(e => e.ApimainStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("APIMainStroke");

                entity.Property(e => e.Apipos)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("APIPos");

                entity.Property(e => e.Apistroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("APIStroke");

                entity.Property(e => e.Apisttime)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("APISTTime");

                entity.Property(e => e.Asldate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ASLDate");

                entity.Property(e => e.AssemJoining1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AssemTight1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AssemTight2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AssyLeakTest)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AssyNoiseTest)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AssyUpright)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AxisSerial)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AxisTemp)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CaseDec)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.CaseFipgapp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CaseFIPGApp")
                    .IsFixedLength();

                entity.Property(e => e.CaseSerial)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Cdtemp)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CDTemp");

                entity.Property(e => e.CoDriveSerial)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CollectionDate).HasColumnType("datetime");

                entity.Property(e => e.Contact)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CoreAfter)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CoreBefore)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CoverSubIdsetSpare)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CoverSubIDSetSpare")
                    .IsFixedLength();

                entity.Property(e => e.CoverSubMw1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CoverSubMW1")
                    .IsFixedLength();

                entity.Property(e => e.CoverSubMw2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CoverSubMW2")
                    .IsFixedLength();

                entity.Property(e => e.CoverSubMw3)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CoverSubMW3")
                    .IsFixedLength();

                entity.Property(e => e.CoverSubMw4)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CoverSubMW4")
                    .IsFixedLength();

                entity.Property(e => e.CoverSubReject)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CoverSubRrCovBrgPressEquip)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CoverSubRrCovSetDmread)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CoverSubRrCovSetDMRead")
                    .IsFixedLength();

                entity.Property(e => e.CoverSubRrRevEquip)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CoverSubWaterConnTighten)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DamperImage)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DefDfcaseRead)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DefDFCaseRead")
                    .IsFixedLength();

                entity.Property(e => e.DefDfpinionShaftEquip)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DefDFPinionShaftEquip")
                    .IsFixedLength();

                entity.Property(e => e.DefDiffOperMeasureEquip)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DefDiffPinionPress)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DefLingDec)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.DefTweezersMw)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DefTweezersMW")
                    .IsFixedLength();

                entity.Property(e => e.Df1abvalue)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DF1ABValue");

                entity.Property(e => e.Df1angleAxis1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DF1AngleAxis1");

                entity.Property(e => e.Df1angleAxis2)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DF1AngleAxis2");

                entity.Property(e => e.Df1angleAxis3)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DF1AngleAxis3");

                entity.Property(e => e.Df1angleAxis4)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DF1AngleAxis4");

                entity.Property(e => e.Df1angleAxis5)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DF1AngleAxis5");

                entity.Property(e => e.Df1angleAxis6)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DF1AngleAxis6");

                entity.Property(e => e.Df1codeAxis1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DF1CodeAxis1");

                entity.Property(e => e.Df1codeAxis2)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DF1CodeAxis2");

                entity.Property(e => e.Df1codeAxis3)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DF1CodeAxis3");

                entity.Property(e => e.Df1codeAxis4)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DF1CodeAxis4");

                entity.Property(e => e.Df1codeAxis5)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DF1CodeAxis5");

                entity.Property(e => e.Df1codeAxis6)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DF1CodeAxis6");

                entity.Property(e => e.Df1date)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DF1Date");

                entity.Property(e => e.Df2abvalue)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DF2ABValue");

                entity.Property(e => e.Df2angleAxis1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DF2AngleAxis1");

                entity.Property(e => e.Df2angleAxis2)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DF2AngleAxis2");

                entity.Property(e => e.Df2angleAxis3)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DF2AngleAxis3");

                entity.Property(e => e.Df2angleAxis4)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DF2AngleAxis4");

                entity.Property(e => e.Df2angleAxis5)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DF2AngleAxis5");

                entity.Property(e => e.Df2angleAxis6)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DF2AngleAxis6");

                entity.Property(e => e.Df2codeAxis1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DF2CodeAxis1");

                entity.Property(e => e.Df2codeAxis2)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DF2CodeAxis2");

                entity.Property(e => e.Df2codeAxis3)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DF2CodeAxis3");

                entity.Property(e => e.Df2codeAxis4)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DF2CodeAxis4");

                entity.Property(e => e.Df2codeAxis5)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DF2CodeAxis5");

                entity.Property(e => e.Df2codeAxis6)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DF2CodeAxis6");

                entity.Property(e => e.Df2date)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DF2Date");

                entity.Property(e => e.Dfbrgdate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DFBRGDate");

                entity.Property(e => e.DfbrgfinalLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DFBRGFinalLoad");

                entity.Property(e => e.DfbrgfinalLoadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DFBRGFinalLoadSec");

                entity.Property(e => e.DfbrgfinalStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DFBRGFinalStroke");

                entity.Property(e => e.DfbrgfinalStrokeSec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DFBRGFinalStrokeSec");

                entity.Property(e => e.Dfbrgload)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DFBRGLoad");

                entity.Property(e => e.DfbrgloadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DFBRGLoadSec");

                entity.Property(e => e.DfbrgmainStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DFBRGMainStroke");

                entity.Property(e => e.Dfbrgstroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DFBRGStroke");

                entity.Property(e => e.DfbrgstrokeSec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DFBRGStrokeSec");

                entity.Property(e => e.Dfcase)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DFCase");

                entity.Property(e => e.DfcaseSerial)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DFCaseSerial");

                entity.Property(e => e.DfreverseDate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DFReverseDate");

                entity.Property(e => e.DfringSerial)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DFRingSerial");

                entity.Property(e => e.Dgaload3Axis)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DGALoad3Axis");

                entity.Property(e => e.Dgaload4Axis)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DGALoad4Axis");

                entity.Property(e => e.DgameasDate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DGAMeasDate");

                entity.Property(e => e.Dgapos3Axis)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DGAPos3Axis");

                entity.Property(e => e.Dgapos4Axis)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DGAPos4Axis");

                entity.Property(e => e.Dgmdagjudge)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DGMDAGJudge");

                entity.Property(e => e.DgmlhRh)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("DGMLhRh");

                entity.Property(e => e.DgmRh)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("DGMRh");

                entity.Property(e => e.DgmmaxTorque)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DGMMaxTorque");

                entity.Property(e => e.DgmmeasDate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DGMMeasDate");

                entity.Property(e => e.DgmminTorque)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DGMMinTorque");

                entity.Property(e => e.DiffBoltTight1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DiffBoltTight2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DiffBrgPressIn)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DiffOilsealPress1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DiffOilsealPress2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Dmread)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DMRead")
                    .IsFixedLength();

                entity.Property(e => e.DorpinSerial)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DpnfFinalLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DpnfFinalStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DpnfMainStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DpnfMeasDate)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DpntAngleAxis1)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DpntDate)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DpntDrop)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DpntJudgment)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DpntSeating)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DpntSlack)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DpntTorqueAxis1)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Dprfrl)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DPRFRL");

                entity.Property(e => e.Dprfrs)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DPRFRS");

                entity.Property(e => e.DprmeasDate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DPRMeasDate");

                entity.Property(e => e.DrainPlugTight)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DrivenSerial)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FillerTight)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Fipgreject)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("FIPGReject")
                    .IsFixedLength();

                entity.Property(e => e.Gear2Abvalue)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Gear2ABValue");

                entity.Property(e => e.Gear2Date)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Gear2FinalLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Gear2FinalLoadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Gear2FinalStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Gear2FinalStrokeSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Gear2Load)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Gear2LoadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Gear2MainStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Gear2Stroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Gear2StrokeSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GearAbvalue)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GearABValue");

                entity.Property(e => e.GearAssembly1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.GearDec)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.GearFinalLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GearFinalLoadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GearFinalStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GearFinalStrokeSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GearLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GearLoadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GearMainStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GearMeasDate)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.GearPressIn1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.GearPressIn2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.GearStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GearStrokeSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HeatEndTime)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HeatOutput)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HeatProcedure)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HeatSt)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("HeatST");

                entity.Property(e => e.HeatTime)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.HsgBrgFinalLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HsgBrgFinalLoadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HsgBrgFinalStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HsgBrgFinalStrokeSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HsgBrgInflectPtLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HsgBrgInflectPtLoadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HsgBrgInflectPtStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HsgBrgInflectPtStrokeSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HsgBrgMaasterStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HsgBrgMeasDate)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.HsgBrgPressIn1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.HsgBrgPressIn2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.HsgDec)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.HsgSerial)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.HsgSubShimSel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Ictldate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ICTLDate");

                entity.Property(e => e.Idexchange)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("IDExchange")
                    .IsFixedLength();

                entity.Property(e => e.Idwrite)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("IDWrite")
                    .IsFixedLength();

                entity.Property(e => e.Ihafter)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("IHAfter");

                entity.Property(e => e.Ihbefore)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("IHBefore");

                entity.Property(e => e.Insulation)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.InterNo)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.IsRcheat)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("IsRCHeat");

                entity.Property(e => e.JudgmentCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LabelPrinting)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LineDec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LubPipeAssem)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MandrelAttach)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Mg1dec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MG1Dec");

                entity.Property(e => e.Mg1fluxValue)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MG1FluxValue");

                entity.Property(e => e.Mg1rotorDec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MG1RotorDec");

                entity.Property(e => e.Mg1rserial)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MG1RSerial");

                entity.Property(e => e.Mg1sserial)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MG1SSerial");

                entity.Property(e => e.Mg1statorDec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MG1StatorDec");

                entity.Property(e => e.Mg1workTemp)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MG1WorkTemp");

                entity.Property(e => e.Mg2dec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MG2Dec");

                entity.Property(e => e.Mg2fluxValue)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MG2FluxValue");

                entity.Property(e => e.Mg2rotorDec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MG2RotorDec");

                entity.Property(e => e.Mg2rserial)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MG2RSerial");

                entity.Property(e => e.Mg2sserial)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MG2SSerial");

                entity.Property(e => e.Mg2statorDec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MG2StatorDec");

                entity.Property(e => e.Mg2workTemp)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MG2WorkTemp");

                entity.Property(e => e.MoDriveSerial)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MotorCoolPipeMw)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorCoolPipeMW")
                    .IsFixedLength();

                entity.Property(e => e.MotorCoolPipeMw2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorCoolPipeMW2")
                    .IsFixedLength();

                entity.Property(e => e.MotorFipgapp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorFIPGApp")
                    .IsFixedLength();

                entity.Property(e => e.MotorHarnEscMw)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorHarnEscMW")
                    .IsFixedLength();

                entity.Property(e => e.MotorHsgSrfBrgAm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorHsgSrfBrgAM")
                    .IsFixedLength();

                entity.Property(e => e.MotorHsgSrfKnockPam)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorHsgSrfKnockPAM")
                    .IsFixedLength();

                entity.Property(e => e.MotorInvMw)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorInvMW")
                    .IsFixedLength();

                entity.Property(e => e.MotorMg12rotorAssem)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorMG12RotorAssem")
                    .IsFixedLength();

                entity.Property(e => e.MotorMg12statorTightAm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorMG12StatorTightAM")
                    .IsFixedLength();

                entity.Property(e => e.MotorMg1statorInsAm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorMG1StatorInsAM")
                    .IsFixedLength();

                entity.Property(e => e.MotorMg2statorInsAm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorMG2StatorInsAM")
                    .IsFixedLength();

                entity.Property(e => e.MotorMtrCode)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MotorMw1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorMW1")
                    .IsFixedLength();

                entity.Property(e => e.MotorMw2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorMW2")
                    .IsFixedLength();

                entity.Property(e => e.MotorMwco0)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorMWCo0")
                    .IsFixedLength();

                entity.Property(e => e.MotorMwco1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorMWCo1")
                    .IsFixedLength();

                entity.Property(e => e.MotorMwco2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorMWCo2")
                    .IsFixedLength();

                entity.Property(e => e.MotorMwco3)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorMWCo3")
                    .IsFixedLength();

                entity.Property(e => e.MotorPrevStn)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MotorReject)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MotorRrCoverAssem)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MotorRrCoverSrfKnockPam)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorRrCoverSrfKnockPAM")
                    .IsFixedLength();

                entity.Property(e => e.MotorRrCoverSrfOutBrgAm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorRrCoverSrfOutBrgAM")
                    .IsFixedLength();

                entity.Property(e => e.MotorRrCoverTight1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MotorRrCoverTight2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MotorSngen)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorSNGen")
                    .IsFixedLength();

                entity.Property(e => e.MotorTermBoardMw)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorTermBoardMW")
                    .IsFixedLength();

                entity.Property(e => e.MotorThermMw)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorThermMW")
                    .IsFixedLength();

                entity.Property(e => e.Mw1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MW1")
                    .IsFixedLength();

                entity.Property(e => e.Mw2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MW2")
                    .IsFixedLength();

                entity.Property(e => e.Mw3)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MW3")
                    .IsFixedLength();

                entity.Property(e => e.NtangleAxis1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NTAngleAxis1");

                entity.Property(e => e.Ntcode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NTCode");

                entity.Property(e => e.Ntdate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NTDate");

                entity.Property(e => e.Ntdrop1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NTDrop1");

                entity.Property(e => e.Nthistory)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NTHistory");

                entity.Property(e => e.Ntseating1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NTSeating1");

                entity.Property(e => e.Ntslack1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NTSlack1");

                entity.Property(e => e.NttorqueAxis1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NTTorqueAxis1");

                entity.Property(e => e.OilCoolerAssem)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.OilInjection)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.OilPump)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.OilPumpAssembly)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ParkingDec)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Pinposition)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PokayokeDate33)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PokayokeDate34)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PokayokeDate35)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PokayokeDate36)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PokayokeDate37)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PokayokeDate38)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PokayokeDate39)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PokayokeDate40)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PokayokeDate41)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PokayokeDate42)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PokayokeDate43)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PokayokeDate44)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PokayokeDate45)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Preprocessing)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ProcDate)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Rapafter)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RAPAfter");

                entity.Property(e => e.Rapbefore)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RAPBefore");

                entity.Property(e => e.Rapcode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RAPCode");

                entity.Property(e => e.Rapcode2)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RAPCode2");

                entity.Property(e => e.Rapdate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RAPDate");

                entity.Property(e => e.RapfinalStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RAPFinalStroke");

                entity.Property(e => e.Rapload)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RAPLoad");

                entity.Property(e => e.RaploadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RAPLoadSec");

                entity.Property(e => e.Rapmain2Stroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RAPMain2Stroke");

                entity.Property(e => e.RapmainStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RAPMainStroke");

                entity.Property(e => e.Rapstroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RAPStroke");

                entity.Property(e => e.RapwashMain)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RAPWashMain");

                entity.Property(e => e.RapwashPos)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RAPWashPos");

                entity.Property(e => e.RapwashSensor)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RAPWashSensor");

                entity.Property(e => e.Rcserial)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RCSerial");

                entity.Property(e => e.Reject)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RejectTime)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Reshuffle)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RevRivetConfirm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RoomTemp)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RotorCoreTrans)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RotorExtractionInsp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RotorForeignSuction)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RotorHeating)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RotorMagnetization)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RotorNutCrimpMg1press)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RotorNutCrimpMG1Press")
                    .IsFixedLength();

                entity.Property(e => e.RotorNutTight)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RotorReject)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RotorResolverPress)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RotorShaftPress)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RotorShaftTrans)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RotorShippingInsp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RotorTamg2coreTrans)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RotorTAMG2CoreTrans")
                    .IsFixedLength();

                entity.Property(e => e.RotorTamg2extractionInsp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RotorTAMG2ExtractionInsp")
                    .IsFixedLength();

                entity.Property(e => e.RotorTamg2foreignSuction)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RotorTAMG2ForeignSuction")
                    .IsFixedLength();

                entity.Property(e => e.RotorTamg2heating)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RotorTAMG2Heating")
                    .IsFixedLength();

                entity.Property(e => e.RotorTamg2magnetization)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RotorTAMG2Magnetization")
                    .IsFixedLength();

                entity.Property(e => e.RotorTamg2nutCrimpMg1press)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RotorTAMG2NutCrimpMG1Press")
                    .IsFixedLength();

                entity.Property(e => e.RotorTamg2nutTight)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RotorTAMG2NutTight")
                    .IsFixedLength();

                entity.Property(e => e.RotorTamg2reject)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RotorTAMG2Reject")
                    .IsFixedLength();

                entity.Property(e => e.RotorTamg2resolverPress)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RotorTAMG2ResolverPress")
                    .IsFixedLength();

                entity.Property(e => e.RotorTamg2shaftPress)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RotorTAMG2ShaftPress")
                    .IsFixedLength();

                entity.Property(e => e.RotorTamg2shaftTrans)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RotorTAMG2ShaftTrans")
                    .IsFixedLength();

                entity.Property(e => e.RotorTamg2shippingInsp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RotorTAMG2ShippingInsp")
                    .IsFixedLength();

                entity.Property(e => e.RrCoverDec)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.RrcoverSerial)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RRCoverSerial");

                entity.Property(e => e.RropSerial)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RRopSerial");

                entity.Property(e => e.Rtpcode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RTPCode");

                entity.Property(e => e.RtpfinalStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RTPFinalStroke");

                entity.Property(e => e.Rtphistory)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RTPHistory");

                entity.Property(e => e.Rtpload)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RTPLoad");

                entity.Property(e => e.RtpmainStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RTPMainStroke");

                entity.Property(e => e.RtpstartDate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RTPStartDate");

                entity.Property(e => e.Rtpstroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RTPStroke");

                entity.Property(e => e.SerialStamping)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ShimSet)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ShipmentSerial)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ShippingPrep1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ShippingPrep2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Slnffastening)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SLNFFastening")
                    .IsFixedLength();

                entity.Property(e => e.Slnfriveting)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SLNFRiveting")
                    .IsFixedLength();

                entity.Property(e => e.SubShimSel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UpenderDate)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.VisualInsp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<MotorTable>(entity =>
            {
                entity.ToTable("MotorTable");

                entity.Property(e => e.Ab)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("AB");

                entity.Property(e => e.Angle10Axis)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Angle1Axis)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Angle2Axis)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Angle3Axis)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Angle4Axis)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Angle5Axis)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Angle6Axis)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Angle7Axis)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Angle8Axis)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Angle9Axis)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AngleAxis1Sec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AngleAxis2Sec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AngleAxis3Sec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AssemJoining1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AssemTight1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AssemTight2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AssyLeakTest)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AssyNoiseTest)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AssyUpright)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Axis10Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Axis1Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Axis2Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Axis3Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Axis4Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Axis5Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Axis6Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Axis7Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Axis8Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Axis9Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AxisCode1Sec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AxisCode2Sec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AxisCode3Sec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CaseDec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CaseFipgapp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CaseFIPGApp")
                    .IsFixedLength();

                entity.Property(e => e.CaseSerial)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CoDriveSerial)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CodeAxis1)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CodeAxis2)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CodeAxis3)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CollectionDate).HasColumnType("datetime");

                entity.Property(e => e.CoverSubIdsetSpare)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CoverSubIDSetSpare")
                    .IsFixedLength();

                entity.Property(e => e.CoverSubMw1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CoverSubMW1")
                    .IsFixedLength();

                entity.Property(e => e.CoverSubMw2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CoverSubMW2")
                    .IsFixedLength();

                entity.Property(e => e.CoverSubMw3)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CoverSubMW3")
                    .IsFixedLength();

                entity.Property(e => e.CoverSubMw4)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CoverSubMW4")
                    .IsFixedLength();

                entity.Property(e => e.CoverSubReject)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CoverSubRrCovBrgPressEquip)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CoverSubRrCovSetDmread)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CoverSubRrCovSetDMRead")
                    .IsFixedLength();

                entity.Property(e => e.CoverSubRrRevEquip)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CoverSubWaterConnTighten)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DamperImage)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DefDfcaseRead)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DefDFCaseRead")
                    .IsFixedLength();

                entity.Property(e => e.DefDfpinionShaftEquip)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DefDFPinionShaftEquip")
                    .IsFixedLength();

                entity.Property(e => e.DefDiffOperMeasureEquip)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DefDiffPinionPress)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DefLingDec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DefTweezersMw)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DefTweezersMW")
                    .IsFixedLength();

                entity.Property(e => e.Dfcase)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DFCase");

                entity.Property(e => e.DfcaseSerial)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DFCaseSerial");

                entity.Property(e => e.DfringSerial)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DFRingSerial");

                entity.Property(e => e.DiffBoltTight1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DiffBoltTight2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DiffBrgPressIn)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DiffOilsealPress1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DiffOilsealPress2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Dmread)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DMRead")
                    .IsFixedLength();

                entity.Property(e => e.DorpinSerial)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DrainPlugTight)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DrivenSerial)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FillerTight)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Fipgreject)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("FIPGReject")
                    .IsFixedLength();

                entity.Property(e => e.GearAssembly1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.GearDec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GearPressIn1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.GearPressIn2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.HsgBrgAbvalue)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("HsgBrgABValue");

                entity.Property(e => e.HsgBrgDate)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.HsgBrgFinalLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HsgBrgFinalLoadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HsgBrgFinalStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HsgBrgFinalStrokeSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HsgBrgLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HsgBrgLoadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HsgBrgMainStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HsgBrgPressIn1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.HsgBrgPressIn2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.HsgBrgStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HsgBrgStrokeSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HsgDec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HsgKnockAbvalue)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("HsgKnockABValue");

                entity.Property(e => e.HsgKnockDate)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.HsgKnockFinalLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HsgKnockFinalLoadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HsgKnockFinalStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HsgKnockFinalStrokeSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HsgKnockLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HsgKnockLoadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HsgKnockMainStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HsgKnockStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HsgKnockStrokeSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HsgSerial)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.HsgSubShimSel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Idexchange)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("IDExchange")
                    .IsFixedLength();

                entity.Property(e => e.Idwrite)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("IDWrite")
                    .IsFixedLength();

                entity.Property(e => e.ImgResult)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Insulation)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.InterNo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LabelPrinting)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LineDec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LubPipeAssem)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MandrelAttach)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MeasDate)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Mg1codeAxis1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MG1CodeAxis1");

                entity.Property(e => e.Mg1codeAxis2)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MG1CodeAxis2");

                entity.Property(e => e.Mg1codeAxis3)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MG1CodeAxis3");

                entity.Property(e => e.Mg1date)
                    .HasMaxLength(20)
                    .HasColumnName("MG1Date");

                entity.Property(e => e.Mg1dec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MG1Dec");

                entity.Property(e => e.Mg1fluxValue)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MG1FluxValue");

                entity.Property(e => e.Mg1rotorDec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MG1RotorDec");

                entity.Property(e => e.Mg1rserial)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MG1RSerial");

                entity.Property(e => e.Mg1sserial)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MG1SSerial");

                entity.Property(e => e.Mg1stator1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MG1Stator1");

                entity.Property(e => e.Mg1stator2)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MG1Stator2");

                entity.Property(e => e.Mg1stator3)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MG1Stator3");

                entity.Property(e => e.Mg1statorDec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MG1StatorDec");

                entity.Property(e => e.Mg1torqAngleAxis1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MG1TorqAngleAxis1");

                entity.Property(e => e.Mg1torqAngleAxis2)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MG1TorqAngleAxis2");

                entity.Property(e => e.Mg1torqAngleAxis3)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MG1TorqAngleAxis3");

                entity.Property(e => e.Mg1workTemp)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MG1WorkTemp");

                entity.Property(e => e.Mg2codeAxis1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MG2CodeAxis1");

                entity.Property(e => e.Mg2codeAxis2)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MG2CodeAxis2");

                entity.Property(e => e.Mg2codeAxis3)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MG2CodeAxis3");

                entity.Property(e => e.Mg2date)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MG2Date");

                entity.Property(e => e.Mg2dec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MG2Dec");

                entity.Property(e => e.Mg2fluxValue)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MG2FluxValue");

                entity.Property(e => e.Mg2rotorDec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MG2RotorDec");

                entity.Property(e => e.Mg2rserial)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MG2RSerial");

                entity.Property(e => e.Mg2sserial)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MG2SSerial");

                entity.Property(e => e.Mg2stator1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MG2Stator1");

                entity.Property(e => e.Mg2stator2)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MG2Stator2");

                entity.Property(e => e.Mg2stator3)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MG2Stator3");

                entity.Property(e => e.Mg2statorDec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MG2StatorDec");

                entity.Property(e => e.Mg2torqAngleAxis1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MG2TorqAngleAxis1");

                entity.Property(e => e.Mg2torqAngleAxis2)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MG2TorqAngleAxis2");

                entity.Property(e => e.Mg2torqAngleAxis3)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MG2TorqAngleAxis3");

                entity.Property(e => e.Mg2workTemp)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MG2WorkTemp");

                entity.Property(e => e.MoDriveSerial)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MotorCoolPipeMw)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorCoolPipeMW")
                    .IsFixedLength();

                entity.Property(e => e.MotorCoolPipeMw2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorCoolPipeMW2")
                    .IsFixedLength();

                entity.Property(e => e.MotorFipgapp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorFIPGApp")
                    .IsFixedLength();

                entity.Property(e => e.MotorHarnEscMw)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorHarnEscMW")
                    .IsFixedLength();

                entity.Property(e => e.MotorHsgSrfBrgAm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorHsgSrfBrgAM")
                    .IsFixedLength();

                entity.Property(e => e.MotorHsgSrfKnockPam)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorHsgSrfKnockPAM")
                    .IsFixedLength();

                entity.Property(e => e.MotorInvMw)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorInvMW")
                    .IsFixedLength();

                entity.Property(e => e.MotorMg12rotorAssem)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorMG12RotorAssem")
                    .IsFixedLength();

                entity.Property(e => e.MotorMg12statorTightAm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorMG12StatorTightAM")
                    .IsFixedLength();

                entity.Property(e => e.MotorMg1statorInsAm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorMG1StatorInsAM")
                    .IsFixedLength();

                entity.Property(e => e.MotorMg2statorInsAm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorMG2StatorInsAM")
                    .IsFixedLength();

                entity.Property(e => e.MotorMtrCode)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MotorMw1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorMW1")
                    .IsFixedLength();

                entity.Property(e => e.MotorMw2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorMW2")
                    .IsFixedLength();

                entity.Property(e => e.MotorMwco0)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorMWCo0")
                    .IsFixedLength();

                entity.Property(e => e.MotorMwco1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorMWCo1")
                    .IsFixedLength();

                entity.Property(e => e.MotorMwco2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorMWCo2")
                    .IsFixedLength();

                entity.Property(e => e.MotorMwco3)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorMWCo3")
                    .IsFixedLength();

                entity.Property(e => e.MotorPrevStn)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MotorReject)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MotorRrCoverAssem)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MotorRrCoverSrfKnockPam)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorRrCoverSrfKnockPAM")
                    .IsFixedLength();

                entity.Property(e => e.MotorRrCoverSrfOutBrgAm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorRrCoverSrfOutBrgAM")
                    .IsFixedLength();

                entity.Property(e => e.MotorRrCoverTight1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MotorRrCoverTight2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MotorSngen)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorSNGen")
                    .IsFixedLength();

                entity.Property(e => e.MotorTermBoardMw)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorTermBoardMW")
                    .IsFixedLength();

                entity.Property(e => e.MotorThermMw)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorThermMW")
                    .IsFixedLength();

                entity.Property(e => e.Mw1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MW1")
                    .IsFixedLength();

                entity.Property(e => e.Mw2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MW2")
                    .IsFixedLength();

                entity.Property(e => e.Mw3)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MW3")
                    .IsFixedLength();

                entity.Property(e => e.OilCoolerAssem)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.OilInjection)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.OilPump)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.OilPumpAssembly)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ParkingDec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PokayokeDate1)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PokayokeDate10)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PokayokeDate11)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PokayokeDate12)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PokayokeDate13)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PokayokeDate14)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PokayokeDate2)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PokayokeDate3)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PokayokeDate4)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PokayokeDate5)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PokayokeDate6)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PokayokeDate7)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PokayokeDate8)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PokayokeDate9)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PokayokeDateBas)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Preprocessing)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ReDate)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Reject)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Reshuffle)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RevRivetConfirm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RotorCoreTrans)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RotorExtractionInsp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RotorForeignSuction)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RotorHeating)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RotorMagnetization)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RotorNutCrimpMg1press)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RotorNutCrimpMG1Press")
                    .IsFixedLength();

                entity.Property(e => e.RotorNutTight)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RotorReject)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RotorResolverPress)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RotorShaftPress)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RotorShaftTrans)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RotorShippingInsp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RotorTamg2coreTrans)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RotorTAMG2CoreTrans")
                    .IsFixedLength();

                entity.Property(e => e.RotorTamg2extractionInsp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RotorTAMG2ExtractionInsp")
                    .IsFixedLength();

                entity.Property(e => e.RotorTamg2foreignSuction)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RotorTAMG2ForeignSuction")
                    .IsFixedLength();

                entity.Property(e => e.RotorTamg2heating)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RotorTAMG2Heating")
                    .IsFixedLength();

                entity.Property(e => e.RotorTamg2magnetization)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RotorTAMG2Magnetization")
                    .IsFixedLength();

                entity.Property(e => e.RotorTamg2nutCrimpMg1press)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RotorTAMG2NutCrimpMG1Press")
                    .IsFixedLength();

                entity.Property(e => e.RotorTamg2nutTight)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RotorTAMG2NutTight")
                    .IsFixedLength();

                entity.Property(e => e.RotorTamg2reject)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RotorTAMG2Reject")
                    .IsFixedLength();

                entity.Property(e => e.RotorTamg2resolverPress)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RotorTAMG2ResolverPress")
                    .IsFixedLength();

                entity.Property(e => e.RotorTamg2shaftPress)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RotorTAMG2ShaftPress")
                    .IsFixedLength();

                entity.Property(e => e.RotorTamg2shaftTrans)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RotorTAMG2ShaftTrans")
                    .IsFixedLength();

                entity.Property(e => e.RotorTamg2shippingInsp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RotorTAMG2ShippingInsp")
                    .IsFixedLength();

                entity.Property(e => e.RrCoverDec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RrFigpdate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RrFIGPDate");

                entity.Property(e => e.RrbrgAbvalue)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RRBrgABValue");

                entity.Property(e => e.RrbrgDate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RRBrgDate");

                entity.Property(e => e.RrbrgFinalLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RRBrgFinalLoad");

                entity.Property(e => e.RrbrgFinalLoadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RRBrgFinalLoadSec");

                entity.Property(e => e.RrbrgFinalStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RRBrgFinalStroke");

                entity.Property(e => e.RrbrgFinalStrokeSec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RRBrgFinalStrokeSec");

                entity.Property(e => e.RrbrgLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RRBrgLoad");

                entity.Property(e => e.RrbrgLoadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RRBrgLoadSec");

                entity.Property(e => e.RrbrgMainStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RRBrgMainStroke");

                entity.Property(e => e.RrbrgStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RRBrgStroke");

                entity.Property(e => e.RrbrgStrokeSec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RRBrgStrokeSec");

                entity.Property(e => e.RrcoverDate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RRCoverDate");

                entity.Property(e => e.RrcoverSerial)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RRCoverSerial");

                entity.Property(e => e.RrknockAbvalue)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RRKnockABValue");

                entity.Property(e => e.RrknockDate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RRKnockDate");

                entity.Property(e => e.RrknockFinalLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RRKnockFinalLoad");

                entity.Property(e => e.RrknockFinalLoadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RRKnockFinalLoadSec");

                entity.Property(e => e.RrknockFinalStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RRKnockFinalStroke");

                entity.Property(e => e.RrknockFinalStrokeSec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RRKnockFinalStrokeSec");

                entity.Property(e => e.RrknockLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RRKnockLoad");

                entity.Property(e => e.RrknockLoadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RRKnockLoadSec");

                entity.Property(e => e.RrknockMainStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RRKnockMainStroke");

                entity.Property(e => e.RrknockStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RRKnockStroke");

                entity.Property(e => e.RrknockStrokeSec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RRKnockStrokeSec");

                entity.Property(e => e.RropSerial)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RRopSerial");

                entity.Property(e => e.SerialStamping)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ShimSet)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ShipmentSerial)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ShippingPrep1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ShippingPrep2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Slnffastening)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SLNFFastening")
                    .IsFixedLength();

                entity.Property(e => e.Slnfriveting)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SLNFRiveting")
                    .IsFixedLength();

                entity.Property(e => e.StatorDate)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SubShimSel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TorqAngleAxis1)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TorqAngleAxis2)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TorqAngleAxis3)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Total1Abvalue)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Total1ABValue");

                entity.Property(e => e.Total1AngleAxis1)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Total1AngleAxis10)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Total1AngleAxis11)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Total1AngleAxis2)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Total1AngleAxis3)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Total1AngleAxis4)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Total1AngleAxis5)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Total1AngleAxis6)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Total1AngleAxis7)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Total1AngleAxis8)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Total1AngleAxis9)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Total1Axis10Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Total1Axis11Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Total1Axis1Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Total1Axis2Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Total1Axis3Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Total1Axis4Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Total1Axis5Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Total1Axis6Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Total1Axis7Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Total1Axis8Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Total1Axis9Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Total2Date)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TotalDate1)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.VisualInsp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<RotorTable>(entity =>
            {
                entity.ToTable("RotorTable");

                entity.HasIndex(e => e.Mg1rserial, "idx_Rotor_MG1RSerial");

                entity.Property(e => e.Apicode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("APICode");

                entity.Property(e => e.ApicoreTemp)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("APICoreTemp");

                entity.Property(e => e.Apidate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("APIDate");

                entity.Property(e => e.ApideviationLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("APIDeviationLoad");

                entity.Property(e => e.ApifinalStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("APIFinalStroke");

                entity.Property(e => e.ApiinitTilt)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("APIInitTilt");

                entity.Property(e => e.Apiload)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("APILoad");

                entity.Property(e => e.Apimachine)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("APIMachine");

                entity.Property(e => e.ApimainStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("APIMainStroke");

                entity.Property(e => e.Apipos)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("APIPos");

                entity.Property(e => e.Apistroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("APIStroke");

                entity.Property(e => e.Apisttime)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("APISTTime");

                entity.Property(e => e.Asldate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ASLDate");

                entity.Property(e => e.AssemJoining1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AssemTight1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AssemTight2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AssyLeakTest)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AssyNoiseTest)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AssyUpright)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AxisSerial)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AxisTemp)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CaseDec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CaseFipgapp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CaseFIPGApp")
                    .IsFixedLength();

                entity.Property(e => e.CaseSerial)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Cdtemp)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CDTemp");

                entity.Property(e => e.CoDriveSerial)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CollectionDate).HasColumnType("datetime");

                entity.Property(e => e.CoreAfter)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CoreBefore)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CoverSubIdsetSpare)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CoverSubIDSetSpare")
                    .IsFixedLength();

                entity.Property(e => e.CoverSubMw1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CoverSubMW1")
                    .IsFixedLength();

                entity.Property(e => e.CoverSubMw2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CoverSubMW2")
                    .IsFixedLength();

                entity.Property(e => e.CoverSubMw3)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CoverSubMW3")
                    .IsFixedLength();

                entity.Property(e => e.CoverSubMw4)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CoverSubMW4")
                    .IsFixedLength();

                entity.Property(e => e.CoverSubReject)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CoverSubRrCovBrgPressEquip)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CoverSubRrCovSetDmread)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CoverSubRrCovSetDMRead")
                    .IsFixedLength();

                entity.Property(e => e.CoverSubRrRevEquip)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CoverSubWaterConnTighten)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DamperImage)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DefDfcaseRead)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DefDFCaseRead")
                    .IsFixedLength();

                entity.Property(e => e.DefDfpinionShaftEquip)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DefDFPinionShaftEquip")
                    .IsFixedLength();

                entity.Property(e => e.DefDiffOperMeasureEquip)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DefDiffPinionPress)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DefLingDec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DefTweezersMw)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DefTweezersMW")
                    .IsFixedLength();

                entity.Property(e => e.Detection1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Detection2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Df1abvalue)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DF1ABValue");

                entity.Property(e => e.Df1angleAxis1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DF1AngleAxis1");

                entity.Property(e => e.Df1angleAxis2)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DF1AngleAxis2");

                entity.Property(e => e.Df1angleAxis3)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DF1AngleAxis3");

                entity.Property(e => e.Df1angleAxis4)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DF1AngleAxis4");

                entity.Property(e => e.Df1angleAxis5)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DF1AngleAxis5");

                entity.Property(e => e.Df1angleAxis6)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DF1AngleAxis6");

                entity.Property(e => e.Df1codeAxis1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DF1CodeAxis1");

                entity.Property(e => e.Df1codeAxis2)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DF1CodeAxis2");

                entity.Property(e => e.Df1codeAxis3)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DF1CodeAxis3");

                entity.Property(e => e.Df1codeAxis4)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DF1CodeAxis4");

                entity.Property(e => e.Df1codeAxis5)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DF1CodeAxis5");

                entity.Property(e => e.Df1codeAxis6)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DF1CodeAxis6");

                entity.Property(e => e.Df1date)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DF1Date");

                entity.Property(e => e.Df2abvalue)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DF2ABValue");

                entity.Property(e => e.Df2angleAxis1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DF2AngleAxis1");

                entity.Property(e => e.Df2angleAxis2)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DF2AngleAxis2");

                entity.Property(e => e.Df2angleAxis3)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DF2AngleAxis3");

                entity.Property(e => e.Df2angleAxis4)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DF2AngleAxis4");

                entity.Property(e => e.Df2angleAxis5)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DF2AngleAxis5");

                entity.Property(e => e.Df2angleAxis6)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DF2AngleAxis6");

                entity.Property(e => e.Df2codeAxis1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DF2CodeAxis1");

                entity.Property(e => e.Df2codeAxis2)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DF2CodeAxis2");

                entity.Property(e => e.Df2codeAxis3)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DF2CodeAxis3");

                entity.Property(e => e.Df2codeAxis4)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DF2CodeAxis4");

                entity.Property(e => e.Df2codeAxis5)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DF2CodeAxis5");

                entity.Property(e => e.Df2codeAxis6)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DF2CodeAxis6");

                entity.Property(e => e.Df2date)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DF2Date");

                entity.Property(e => e.Dfbrgdate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DFBRGDate");

                entity.Property(e => e.DfbrgfinalLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DFBRGFinalLoad");

                entity.Property(e => e.DfbrgfinalLoadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DFBRGFinalLoadSec");

                entity.Property(e => e.DfbrgfinalStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DFBRGFinalStroke");

                entity.Property(e => e.DfbrgfinalStrokeSec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DFBRGFinalStrokeSec");

                entity.Property(e => e.Dfbrgload)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DFBRGLoad");

                entity.Property(e => e.DfbrgloadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DFBRGLoadSec");

                entity.Property(e => e.DfbrgmainStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DFBRGMainStroke");

                entity.Property(e => e.Dfbrgstroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DFBRGStroke");

                entity.Property(e => e.DfbrgstrokeSec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DFBRGStrokeSec");

                entity.Property(e => e.Dfcase)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DFCase");

                entity.Property(e => e.DfcaseSerial)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DFCaseSerial");

                entity.Property(e => e.DfreverseDate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DFReverseDate");

                entity.Property(e => e.DfringSerial)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DFRingSerial");

                entity.Property(e => e.Dgaload3Axis)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DGALoad3Axis");

                entity.Property(e => e.Dgaload4Axis)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DGALoad4Axis");

                entity.Property(e => e.DgameasDate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DGAMeasDate");

                entity.Property(e => e.Dgapos3Axis)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DGAPos3Axis");

                entity.Property(e => e.Dgapos4Axis)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DGAPos4Axis");

                entity.Property(e => e.Dgmdagjudge)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DGMDAGJudge");

                entity.Property(e => e.DgmlhRh)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DGMLhRh");

                entity.Property(e => e.DgmmaxTorque)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DGMMaxTorque");

                entity.Property(e => e.DgmmeasTime)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DGMMeasTime");

                entity.Property(e => e.DgmminTorque)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DGMMinTorque");

                entity.Property(e => e.DiffBoltTight1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DiffBoltTight2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DiffBrgPressIn)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DiffOilsealPress1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DiffOilsealPress2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Dmread)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DMRead")
                    .IsFixedLength();

                entity.Property(e => e.DorpinSerial)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DpnfFinalLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DpnfFinalStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DpnfMainStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DpnfMeasDate)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DpntAngleAxis1)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DpntDate)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DpntDrop)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DpntJudgment)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DpntSeating)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DpntSlack)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DpntTorqueAxis1)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Dprfrl)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DPRFRL");

                entity.Property(e => e.Dprfrs)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DPRFRS");

                entity.Property(e => e.DprmeasTime)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DPRMeasTime");

                entity.Property(e => e.DrainPlugTight)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DrivenSerial)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FillerTight)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Fipgreject)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("FIPGReject")
                    .IsFixedLength();

                entity.Property(e => e.Gear2Abvalue)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Gear2ABValue");

                entity.Property(e => e.Gear2Date)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Gear2FinalLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Gear2FinalLoadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Gear2FinalStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Gear2FinalStrokeSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Gear2Load)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Gear2LoadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Gear2MainStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Gear2Stroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Gear2StrokeSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GearAbvalue)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GearABValue");

                entity.Property(e => e.GearAssembly1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.GearDec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GearFinalLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GearFinalLoadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GearFinalStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GearFinalStrokeSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GearLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GearLoadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GearMainStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GearMeasDate)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.GearPressIn1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.GearPressIn2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.GearStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GearStrokeSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HeatEndTime)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.HeatOutput)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HeatProcedure)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HeatSt)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("HeatST");

                entity.Property(e => e.HeatTime)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.HsgBrgFinalLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HsgBrgFinalLoadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HsgBrgFinalStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HsgBrgFinalStrokeSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HsgBrgInflectPtLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HsgBrgInflectPtLoadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HsgBrgInflectPtStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HsgBrgInflectPtStrokeSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HsgBrgMaasterStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HsgBrgMeasDate)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.HsgBrgPressIn1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.HsgBrgPressIn2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.HsgDec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HsgSerial)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.HsgSubShimSel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Ictldate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ICTLDate");

                entity.Property(e => e.Idexchange)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("IDExchange")
                    .IsFixedLength();

                entity.Property(e => e.Idwrite)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("IDWrite")
                    .IsFixedLength();

                entity.Property(e => e.Ihafter)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("IHAfter");

                entity.Property(e => e.Ihbefore)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("IHBefore");

                entity.Property(e => e.Insulation)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.InterNo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IsRcheat)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("IsRCHeat");

                entity.Property(e => e.JudgmentCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LabelPrinting)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LineDec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LubPipeAssem)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MandrelAttach)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Mg1dec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MG1Dec");

                entity.Property(e => e.Mg1fluxValue)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MG1FluxValue");

                entity.Property(e => e.Mg1rotorDec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MG1RotorDec");

                entity.Property(e => e.Mg1rserial)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MG1RSerial");

                entity.Property(e => e.Mg1sserial)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MG1SSerial");

                entity.Property(e => e.Mg1statorDec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MG1StatorDec");

                entity.Property(e => e.Mg1workTemp)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MG1WorkTemp");

                entity.Property(e => e.Mg2dec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MG2Dec");

                entity.Property(e => e.Mg2fluxValue)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MG2FluxValue");

                entity.Property(e => e.Mg2rotorDec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MG2RotorDec");

                entity.Property(e => e.Mg2rserial)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MG2RSerial");

                entity.Property(e => e.Mg2sserial)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MG2SSerial");

                entity.Property(e => e.Mg2statorDec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MG2StatorDec");

                entity.Property(e => e.Mg2workTemp)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MG2WorkTemp");

                entity.Property(e => e.MoDriveSerial)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MotorCoolPipeMw)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorCoolPipeMW")
                    .IsFixedLength();

                entity.Property(e => e.MotorCoolPipeMw2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorCoolPipeMW2")
                    .IsFixedLength();

                entity.Property(e => e.MotorFipgapp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorFIPGApp")
                    .IsFixedLength();

                entity.Property(e => e.MotorHarnEscMw)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorHarnEscMW")
                    .IsFixedLength();

                entity.Property(e => e.MotorHsgSrfBrgAm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorHsgSrfBrgAM")
                    .IsFixedLength();

                entity.Property(e => e.MotorHsgSrfKnockPam)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorHsgSrfKnockPAM")
                    .IsFixedLength();

                entity.Property(e => e.MotorInvMw)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorInvMW")
                    .IsFixedLength();

                entity.Property(e => e.MotorMg12rotorAssem)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorMG12RotorAssem")
                    .IsFixedLength();

                entity.Property(e => e.MotorMg12statorTightAm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorMG12StatorTightAM")
                    .IsFixedLength();

                entity.Property(e => e.MotorMg1statorInsAm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorMG1StatorInsAM")
                    .IsFixedLength();

                entity.Property(e => e.MotorMg2statorInsAm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorMG2StatorInsAM")
                    .IsFixedLength();

                entity.Property(e => e.MotorMtrCode)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MotorMw1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorMW1")
                    .IsFixedLength();

                entity.Property(e => e.MotorMw2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorMW2")
                    .IsFixedLength();

                entity.Property(e => e.MotorMwco0)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorMWCo0")
                    .IsFixedLength();

                entity.Property(e => e.MotorMwco1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorMWCo1")
                    .IsFixedLength();

                entity.Property(e => e.MotorMwco2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorMWCo2")
                    .IsFixedLength();

                entity.Property(e => e.MotorMwco3)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorMWCo3")
                    .IsFixedLength();

                entity.Property(e => e.MotorPrevStn)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MotorReject)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MotorRrCoverAssem)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MotorRrCoverSrfKnockPam)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorRrCoverSrfKnockPAM")
                    .IsFixedLength();

                entity.Property(e => e.MotorRrCoverSrfOutBrgAm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorRrCoverSrfOutBrgAM")
                    .IsFixedLength();

                entity.Property(e => e.MotorRrCoverTight1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MotorRrCoverTight2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MotorSngen)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorSNGen")
                    .IsFixedLength();

                entity.Property(e => e.MotorTermBoardMw)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorTermBoardMW")
                    .IsFixedLength();

                entity.Property(e => e.MotorThermMw)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorThermMW")
                    .IsFixedLength();

                entity.Property(e => e.Mw1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MW1")
                    .IsFixedLength();

                entity.Property(e => e.Mw2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MW2")
                    .IsFixedLength();

                entity.Property(e => e.Mw3)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MW3")
                    .IsFixedLength();

                entity.Property(e => e.NtangleAxis1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NTAngleAxis1");

                entity.Property(e => e.Ntcode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NTCode");

                entity.Property(e => e.Ntdate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NTDate");

                entity.Property(e => e.Ntdrop1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NTDrop1");

                entity.Property(e => e.Nthistory)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NTHistory");

                entity.Property(e => e.Ntseating1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NTSeating1");

                entity.Property(e => e.Ntslack1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NTSlack1");

                entity.Property(e => e.NttorqueAxis1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NTTorqueAxis1");

                entity.Property(e => e.OilCoolerAssem)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.OilInjection)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.OilPump)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.OilPumpAssembly)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ParkingDec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PokayokeDate33)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PokayokeDate34)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PokayokeDate35)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PokayokeDate36)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PokayokeDate37)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PokayokeDate38)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PokayokeDate39)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PokayokeDate40)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PokayokeDate41)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PokayokeDate42)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PokayokeDate43)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PokayokeDate44)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PokayokeDate45)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Preprocessing)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ProcDate)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Rapafter)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RAPAfter");

                entity.Property(e => e.Rapbefore)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RAPBefore");

                entity.Property(e => e.Rapcode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RAPCode");

                entity.Property(e => e.Rapcode2)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RAPCode2");

                entity.Property(e => e.Rapdate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RAPDate");

                entity.Property(e => e.RapfinalStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RAPFinalStroke");

                entity.Property(e => e.Rapload)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RAPLoad");

                entity.Property(e => e.RaploadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RAPLoadSec");

                entity.Property(e => e.Rapmain2Stroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RAPMain2Stroke");

                entity.Property(e => e.RapmainStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RAPMainStroke");

                entity.Property(e => e.Rapstroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RAPStroke");

                entity.Property(e => e.RapwashMain)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RAPWashMain");

                entity.Property(e => e.RapwashPos)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RAPWashPos");

                entity.Property(e => e.RapwashSensor)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RAPWashSensor");

                entity.Property(e => e.Rcserial)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RCSerial");

                entity.Property(e => e.Reject)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RejectTime)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Reshuffle)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RevRivetConfirm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RoomTemp)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RotorCoreTrans)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RotorExtractionInsp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RotorForeignSuction)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RotorHeating)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RotorMagnetization)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RotorNutCrimpMg1press)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RotorNutCrimpMG1Press")
                    .IsFixedLength();

                entity.Property(e => e.RotorNutTight)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RotorReject)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RotorResolverPress)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RotorShaftPress)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RotorShaftTrans)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RotorShippingInsp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RotorTamg2coreTrans)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RotorTAMG2CoreTrans")
                    .IsFixedLength();

                entity.Property(e => e.RotorTamg2extractionInsp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RotorTAMG2ExtractionInsp")
                    .IsFixedLength();

                entity.Property(e => e.RotorTamg2foreignSuction)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RotorTAMG2ForeignSuction")
                    .IsFixedLength();

                entity.Property(e => e.RotorTamg2heating)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RotorTAMG2Heating")
                    .IsFixedLength();

                entity.Property(e => e.RotorTamg2magnetization)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RotorTAMG2Magnetization")
                    .IsFixedLength();

                entity.Property(e => e.RotorTamg2nutCrimpMg1press)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RotorTAMG2NutCrimpMG1Press")
                    .IsFixedLength();

                entity.Property(e => e.RotorTamg2nutTight)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RotorTAMG2NutTight")
                    .IsFixedLength();

                entity.Property(e => e.RotorTamg2reject)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RotorTAMG2Reject")
                    .IsFixedLength();

                entity.Property(e => e.RotorTamg2resolverPress)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RotorTAMG2ResolverPress")
                    .IsFixedLength();

                entity.Property(e => e.RotorTamg2shaftPress)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RotorTAMG2ShaftPress")
                    .IsFixedLength();

                entity.Property(e => e.RotorTamg2shaftTrans)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RotorTAMG2ShaftTrans")
                    .IsFixedLength();

                entity.Property(e => e.RotorTamg2shippingInsp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RotorTAMG2ShippingInsp")
                    .IsFixedLength();

                entity.Property(e => e.RrCoverDec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RrcoverSerial)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RRCoverSerial");

                entity.Property(e => e.RropSerial)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RRopSerial");

                entity.Property(e => e.Rtpcode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RTPCode");

                entity.Property(e => e.RtpfinalStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RTPFinalStroke");

                entity.Property(e => e.Rtphistory)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RTPHistory");

                entity.Property(e => e.Rtpload)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RTPLoad");

                entity.Property(e => e.RtpmainStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RTPMainStroke");

                entity.Property(e => e.RtpstartDate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RTPStartDate");

                entity.Property(e => e.Rtpstroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RTPStroke");

                entity.Property(e => e.SerialStamping)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ShimSet)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ShipmentSerial)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ShippingPrep1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ShippingPrep2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Slnffastening)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SLNFFastening")
                    .IsFixedLength();

                entity.Property(e => e.Slnfriveting)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SLNFRiveting")
                    .IsFixedLength();

                entity.Property(e => e.SubShimSel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UpenderDate)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.VisualInsp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Rrtable>(entity =>
            {
                entity.ToTable("RRTable");

                entity.Property(e => e.AssemJoining1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AssemTight1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AssemTight2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AssyLeakTest)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AssyNoiseTest)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AssyUpright)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CaseDec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CaseFipgapp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CaseFIPGApp")
                    .IsFixedLength();

                entity.Property(e => e.CaseSerial)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CoDriveSerial)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CollectionDate).HasColumnType("datetime");

                entity.Property(e => e.CoverSubIdsetSpare)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CoverSubIDSetSpare")
                    .IsFixedLength();

                entity.Property(e => e.CoverSubMw1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CoverSubMW1")
                    .IsFixedLength();

                entity.Property(e => e.CoverSubMw2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CoverSubMW2")
                    .IsFixedLength();

                entity.Property(e => e.CoverSubMw3)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CoverSubMW3")
                    .IsFixedLength();

                entity.Property(e => e.CoverSubMw4)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CoverSubMW4")
                    .IsFixedLength();

                entity.Property(e => e.CoverSubReject)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CoverSubRrCovBrgPressEquip)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CoverSubRrCovSetDmread)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CoverSubRrCovSetDMRead")
                    .IsFixedLength();

                entity.Property(e => e.CoverSubRrRevEquip)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CoverSubWaterConnTighten)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DamperImage)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DefDfcaseRead)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DefDFCaseRead")
                    .IsFixedLength();

                entity.Property(e => e.DefDfpinionShaftEquip)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DefDFPinionShaftEquip")
                    .IsFixedLength();

                entity.Property(e => e.DefDiffOperMeasureEquip)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DefDiffPinionPress)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DefLingDec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DefTweezersMw)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DefTweezersMW")
                    .IsFixedLength();

                entity.Property(e => e.Dfcase)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DFCase");

                entity.Property(e => e.DfcaseSerial)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DFCaseSerial");

                entity.Property(e => e.DfringSerial)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DFRingSerial");

                entity.Property(e => e.DiffBoltTight1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DiffBoltTight2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DiffBrgPressIn)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DiffOilsealPress1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DiffOilsealPress2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Dmread)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DMRead")
                    .IsFixedLength();

                entity.Property(e => e.DorpinSerial)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DrainPlugTight)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DrivenSerial)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FillerTight)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Fipgreject)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("FIPGReject")
                    .IsFixedLength();

                entity.Property(e => e.GearAssembly1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.GearDec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GearPressIn1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.GearPressIn2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.HsgBrgFinalLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HsgBrgFinalLoadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HsgBrgFinalStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HsgBrgFinalStrokeSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HsgBrgLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HsgBrgLoadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HsgBrgMainStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HsgBrgMdate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("HsgBrgMDate");

                entity.Property(e => e.HsgBrgPressIn1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.HsgBrgPressIn2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.HsgBrgStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HsgBrgStrokeSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HsgDec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HsgSerial)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.HsgSubShimSel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Idexchange)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("IDExchange")
                    .IsFixedLength();

                entity.Property(e => e.Idwrite)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("IDWrite")
                    .IsFixedLength();

                entity.Property(e => e.Insulation)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.InterNo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LabelPrinting)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LineDec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LubPipeAssem)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MandrelAttach)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Mg1rotorDec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MG1RotorDec");

                entity.Property(e => e.Mg1rserial)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MG1RSerial");

                entity.Property(e => e.Mg1sserial)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MG1SSerial");

                entity.Property(e => e.Mg1statorDec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MG1StatorDec");

                entity.Property(e => e.Mg2rotorDec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MG2RotorDec");

                entity.Property(e => e.Mg2rserial)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MG2RSerial");

                entity.Property(e => e.Mg2sserial)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MG2SSerial");

                entity.Property(e => e.Mg2statorDec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MG2StatorDec");

                entity.Property(e => e.MoDriveSerial)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MotorCoolPipeMw)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorCoolPipeMW")
                    .IsFixedLength();

                entity.Property(e => e.MotorCoolPipeMw2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorCoolPipeMW2")
                    .IsFixedLength();

                entity.Property(e => e.MotorFipgapp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorFIPGApp")
                    .IsFixedLength();

                entity.Property(e => e.MotorHarnEscMw)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorHarnEscMW")
                    .IsFixedLength();

                entity.Property(e => e.MotorHsgSrfBrgAm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorHsgSrfBrgAM")
                    .IsFixedLength();

                entity.Property(e => e.MotorHsgSrfKnockPam)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorHsgSrfKnockPAM")
                    .IsFixedLength();

                entity.Property(e => e.MotorInvMw)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorInvMW")
                    .IsFixedLength();

                entity.Property(e => e.MotorMg12rotorAssem)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorMG12RotorAssem")
                    .IsFixedLength();

                entity.Property(e => e.MotorMg12statorTightAm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorMG12StatorTightAM")
                    .IsFixedLength();

                entity.Property(e => e.MotorMg1statorInsAm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorMG1StatorInsAM")
                    .IsFixedLength();

                entity.Property(e => e.MotorMg2statorInsAm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorMG2StatorInsAM")
                    .IsFixedLength();

                entity.Property(e => e.MotorMtrCode)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MotorMw1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorMW1")
                    .IsFixedLength();

                entity.Property(e => e.MotorMw2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorMW2")
                    .IsFixedLength();

                entity.Property(e => e.MotorMwco0)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorMWCo0")
                    .IsFixedLength();

                entity.Property(e => e.MotorMwco1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorMWCo1")
                    .IsFixedLength();

                entity.Property(e => e.MotorMwco2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorMWCo2")
                    .IsFixedLength();

                entity.Property(e => e.MotorMwco3)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorMWCo3")
                    .IsFixedLength();

                entity.Property(e => e.MotorPrevStn)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MotorReject)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MotorRrCoverAssem)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MotorRrCoverSrfKnockPam)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorRrCoverSrfKnockPAM")
                    .IsFixedLength();

                entity.Property(e => e.MotorRrCoverSrfOutBrgAm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorRrCoverSrfOutBrgAM")
                    .IsFixedLength();

                entity.Property(e => e.MotorRrCoverTight1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MotorRrCoverTight2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MotorSngen)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorSNGen")
                    .IsFixedLength();

                entity.Property(e => e.MotorTermBoardMw)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorTermBoardMW")
                    .IsFixedLength();

                entity.Property(e => e.MotorThermMw)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorThermMW")
                    .IsFixedLength();

                entity.Property(e => e.Mw1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MW1")
                    .IsFixedLength();

                entity.Property(e => e.Mw2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MW2")
                    .IsFixedLength();

                entity.Property(e => e.Mw3)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MW3")
                    .IsFixedLength();

                entity.Property(e => e.Number)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.OilCoolerAssem)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.OilInjection)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.OilPump)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.OilPumpAssembly)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ParkingDec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PokayokeDate39)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PokayokeDate40)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PokayokeDate41)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PokayokeDate42)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PokayokeDate43)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PokayokeDate44)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PokayokeDate45)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Preprocessing)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Reject)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RejectTime)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Reshuffle)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RevRivetConfirm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RotorCoreTrans)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RotorExtractionInsp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RotorForeignSuction)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RotorHeating)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RotorMagnetization)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RotorNutCrimpMg1press)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RotorNutCrimpMG1Press")
                    .IsFixedLength();

                entity.Property(e => e.RotorNutTight)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RotorReject)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RotorResolverPress)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RotorShaftPress)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RotorShaftTrans)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RotorShippingInsp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RotorTamg2coreTrans)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RotorTAMG2CoreTrans")
                    .IsFixedLength();

                entity.Property(e => e.RotorTamg2extractionInsp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RotorTAMG2ExtractionInsp")
                    .IsFixedLength();

                entity.Property(e => e.RotorTamg2foreignSuction)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RotorTAMG2ForeignSuction")
                    .IsFixedLength();

                entity.Property(e => e.RotorTamg2heating)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RotorTAMG2Heating")
                    .IsFixedLength();

                entity.Property(e => e.RotorTamg2magnetization)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RotorTAMG2Magnetization")
                    .IsFixedLength();

                entity.Property(e => e.RotorTamg2nutCrimpMg1press)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RotorTAMG2NutCrimpMG1Press")
                    .IsFixedLength();

                entity.Property(e => e.RotorTamg2nutTight)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RotorTAMG2NutTight")
                    .IsFixedLength();

                entity.Property(e => e.RotorTamg2reject)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RotorTAMG2Reject")
                    .IsFixedLength();

                entity.Property(e => e.RotorTamg2resolverPress)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RotorTAMG2ResolverPress")
                    .IsFixedLength();

                entity.Property(e => e.RotorTamg2shaftPress)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RotorTAMG2ShaftPress")
                    .IsFixedLength();

                entity.Property(e => e.RotorTamg2shaftTrans)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RotorTAMG2ShaftTrans")
                    .IsFixedLength();

                entity.Property(e => e.RotorTamg2shippingInsp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RotorTAMG2ShippingInsp")
                    .IsFixedLength();

                entity.Property(e => e.RrCoverDec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RrcoverSerial)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RRCoverSerial");

                entity.Property(e => e.RropSerial)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RRopSerial");

                entity.Property(e => e.SerialStamping)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ShimSet)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ShipmentSerial)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ShippingPrep1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ShippingPrep2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Slnffastening)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SLNFFastening")
                    .IsFixedLength();

                entity.Property(e => e.Slnfriveting)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SLNFRiveting")
                    .IsFixedLength();

                entity.Property(e => e.SubShimSel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UpenderDate)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.VisualInsp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Shipping>(entity =>
            {
                entity.ToTable("Shipping");

                entity.Property(e => e.BackNo).HasMaxLength(50);

                entity.Property(e => e.Destination).HasMaxLength(50);

                entity.Property(e => e.DestinationArea).HasMaxLength(50);

                entity.Property(e => e.LeadTime).HasColumnType("datetime");

                entity.Property(e => e.Operator).HasMaxLength(50);

                entity.Property(e => e.OrderNo).HasMaxLength(50);

                entity.Property(e => e.PlineNo).HasMaxLength(50);

                entity.Property(e => e.Printing).HasMaxLength(50);

                entity.Property(e => e.ProductNo).HasMaxLength(50);

                entity.Property(e => e.ReceivingNo).HasMaxLength(50);

                entity.Property(e => e.ReceivingPoint).HasMaxLength(50);

                entity.Property(e => e.SerialNo)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.ShippingTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Tatable>(entity =>
            {
                entity.ToTable("TATable");

                entity.Property(e => e.AssemJoining1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AssemTight1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AssemTight2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AssyDate)
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.AssyLeakTest)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AssyNoiseTest)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AssyUpright)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CaseDec)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.CaseFipgapp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CaseFIPGApp")
                    .IsFixedLength();

                entity.Property(e => e.CaseSerial)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CoDriveSerial)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CollectionDate).HasColumnType("datetime");

                entity.Property(e => e.CoverSubIdsetSpare)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CoverSubIDSetSpare")
                    .IsFixedLength();

                entity.Property(e => e.CoverSubMw1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CoverSubMW1")
                    .IsFixedLength();

                entity.Property(e => e.CoverSubMw2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CoverSubMW2")
                    .IsFixedLength();

                entity.Property(e => e.CoverSubMw3)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CoverSubMW3")
                    .IsFixedLength();

                entity.Property(e => e.CoverSubMw4)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CoverSubMW4")
                    .IsFixedLength();

                entity.Property(e => e.CoverSubReject)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CoverSubRrCovBrgPressEquip)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CoverSubRrCovSetDmread)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CoverSubRrCovSetDMRead")
                    .IsFixedLength();

                entity.Property(e => e.CoverSubRrRevEquip)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CoverSubWaterConnTighten)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DamperImage)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DefDfcaseRead)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DefDFCaseRead")
                    .IsFixedLength();

                entity.Property(e => e.DefDfpinionShaftEquip)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DefDFPinionShaftEquip")
                    .IsFixedLength();

                entity.Property(e => e.DefDiffOperMeasureEquip)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DefDiffPinionPress)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DefLingDec)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.DefTweezersMw)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DefTweezersMW")
                    .IsFixedLength();

                entity.Property(e => e.Dfcase)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DFCase");

                entity.Property(e => e.DfcaseSerial)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DFCaseSerial");

                entity.Property(e => e.DfringSerial)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DFRingSerial");

                entity.Property(e => e.DiffBoltTight1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DiffBoltTight2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DiffBrgPressIn)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DiffOilsealPress1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DiffOilsealPress2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Dmread)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DMRead")
                    .IsFixedLength();

                entity.Property(e => e.DorpinSerial)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DrainPlugTight)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DrivenSerial)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DtrayWeight)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DTrayWeight");

                entity.Property(e => e.EngravingData)
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.FillerTight)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Fipgreject)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("FIPGReject")
                    .IsFixedLength();

                entity.Property(e => e.GearAssembly1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.GearDec)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.GearPressIn1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.GearPressIn2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Hsg1Ab)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Hsg1AB");

                entity.Property(e => e.Hsg1Abvalue)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Hsg1ABValue");

                entity.Property(e => e.Hsg1AngleAxis1)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hsg1AngleAxis10)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hsg1AngleAxis11)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hsg1AngleAxis2)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hsg1AngleAxis3)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hsg1AngleAxis4)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hsg1AngleAxis5)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hsg1AngleAxis6)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hsg1AngleAxis7)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hsg1AngleAxis8)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hsg1AngleAxis9)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hsg1CodeAxis1)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hsg1CodeAxis10)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hsg1CodeAxis11)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hsg1CodeAxis2)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hsg1CodeAxis3)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hsg1CodeAxis4)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hsg1CodeAxis5)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hsg1CodeAxis6)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hsg1CodeAxis7)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hsg1CodeAxis8)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hsg1CodeAxis9)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hsg1Date)
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.Hsg1FinalLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hsg1FinalLoadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hsg1FinalStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hsg1FinalStrokeSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hsg1MainStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hsg1MeasDate)
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.Hsg1PtLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hsg1PtLoadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hsg1Stroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hsg1StrokeSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hsg2Ab)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Hsg2AB");

                entity.Property(e => e.Hsg2Abvalue)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Hsg2ABValue");

                entity.Property(e => e.Hsg2AngleAxis1)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hsg2AngleAxis10)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hsg2AngleAxis11)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hsg2AngleAxis2)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hsg2AngleAxis3)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hsg2AngleAxis4)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hsg2AngleAxis5)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hsg2AngleAxis6)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hsg2AngleAxis7)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hsg2AngleAxis8)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hsg2AngleAxis9)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hsg2CodeAxis1)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hsg2CodeAxis10)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hsg2CodeAxis11)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hsg2CodeAxis2)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hsg2CodeAxis3)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hsg2CodeAxis4)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hsg2CodeAxis5)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hsg2CodeAxis6)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hsg2CodeAxis7)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hsg2CodeAxis8)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hsg2CodeAxis9)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hsg2Date)
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.Hsg2FinalLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hsg2FinalLoadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hsg2FinalStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hsg2FinalStrokeSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hsg2MaesDate)
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.Hsg2MainStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hsg2PtLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hsg2PtLoadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hsg2Stroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hsg2StrokeSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HsgBrgPressIn1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.HsgBrgPressIn2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.HsgDec)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.HsgFigpdate)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("HsgFIGPDate");

                entity.Property(e => e.HsgFigpportrait)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("HsgFIGPPortrait");

                entity.Property(e => e.HsgFitDate)
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.HsgSerial)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.HsgSetDate)
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.HsgSubShimSel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Idexchange)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("IDExchange")
                    .IsFixedLength();

                entity.Property(e => e.Idwrite)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("IDWrite")
                    .IsFixedLength();

                entity.Property(e => e.InspectionDate)
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.Insulation)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.InterNo)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.IssCol)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssDate)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssFunction)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssMg1disUv)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("IssMG1DisUV");

                entity.Property(e => e.IssMg1disUvdec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("IssMG1DisUVDec");

                entity.Property(e => e.IssMg1disVw)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("IssMG1DisVW");

                entity.Property(e => e.IssMg1disVwdec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("IssMG1DisVWDec");

                entity.Property(e => e.IssMg1uv)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("IssMG1UV");

                entity.Property(e => e.IssMg1uvdec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("IssMG1UVDec");

                entity.Property(e => e.IssMg1value)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("IssMG1Value");

                entity.Property(e => e.IssMg1valueDec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("IssMG1ValueDec");

                entity.Property(e => e.IssMg1vw)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("IssMG1VW");

                entity.Property(e => e.IssMg1vwdec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("IssMG1VWDec");

                entity.Property(e => e.IssMg2disUv)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("IssMG2DisUV");

                entity.Property(e => e.IssMg2disUvdec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("IssMG2DisUVDec");

                entity.Property(e => e.IssMg2disVw)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("IssMG2DisVW");

                entity.Property(e => e.IssMg2disVwdec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("IssMG2DisVWDec");

                entity.Property(e => e.IssMg2gear)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("IssMG2Gear");

                entity.Property(e => e.IssMg2gearDec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("IssMG2GearDec");

                entity.Property(e => e.IssMg2uv)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("IssMG2UV");

                entity.Property(e => e.IssMg2uvdec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("IssMG2UVDec");

                entity.Property(e => e.IssMg2value)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("IssMG2Value");

                entity.Property(e => e.IssMg2valueDec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("IssMG2ValueDec");

                entity.Property(e => e.IssMg2vw)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("IssMG2VW");

                entity.Property(e => e.IssMg2vwdec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("IssMG2VWDec");

                entity.Property(e => e.IssOilPump)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssOilPumpDec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssOilTemp)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssP)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssReliefValve)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssReliefValveDec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssRev1)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssRev1Noise)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssRev1Rate)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssRev2)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssRev2Noise)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssRev2Rate)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssRev3)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssRev3Noise)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssRev3Rate)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssRev4)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssRev4Noise)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssRev4Rate)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssRev5)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssRev5Noise)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssRev5Rate)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssRevAvg)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssRevAvgDec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssRevColor)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssRevColor1Dec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssRevColor1Hz)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssRevColor1dB)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssRevColor1rpm)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssRevColor1sum)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssRevColor2Dec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssRevColor2Hz)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssRevColor2dB)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssRevColor2rpm)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssRevColor2sum)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssRevColor3Dec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssRevColor3Hz)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssRevColor3dB)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssRevColor3rpm)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssRevColor3sum)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssRevCounter)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssRevLast)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssRevLast1)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssRevLast1Noise)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssRevLast1Rate)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssRevLast2)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssRevLast2Noise)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssRevLast2Rate)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssRevLast3)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssRevLast3Noise)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssRevLast3Rate)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssRevLast4)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssRevLast4Noise)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssRevLast4Rate)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssRevLast5)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssRevLast5Noise)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssRevLast5Rate)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssRevup)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssSlow1)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssSlow1Noise)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssSlow1Rate)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssSlow2)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssSlow2Noise)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssSlow2Rate)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssSlow3)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssSlow3Noise)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssSlow3Rate)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssSlow4)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssSlow4Noise)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssSlow4Rate)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssSlow5)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssSlow5Noise)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssSlow5Rate)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssSlowAvg)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssSlowAvgDec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssSlowColor)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssSlowColor1Dec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssSlowColor1Hz)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssSlowColor1dB)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssSlowColor1rpm)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssSlowColor1sum)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssSlowColor2Dec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssSlowColor2Hz)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssSlowColor2dB)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssSlowColor2rpm)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssSlowColor2sum)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssSlowColor3Dec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssSlowColor3Hz)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssSlowColor3dB)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssSlowColor3rpm)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssSlowColor3sum)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssSlowCounter)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssSlowLast)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssSlowLast1)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssSlowLast1Noise)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssSlowLast1Rate)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssSlowLast2)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssSlowLast2Noise)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssSlowLast2Rate)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssSlowLast3)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssSlowLast3Noise)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssSlowLast3Rate)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssSlowLast4)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssSlowLast4Noise)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssSlowLast4Rate)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssSlowLast5)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssSlowLast5Noise)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssSlowLast5Rate)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssSlowup)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssnotP)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LabelPrinting)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LeakCol)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LeakCorrect)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LeakDate)
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.LeakEtaf)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("LeakETAF");

                entity.Property(e => e.LeakFrontOil)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LeakGear)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LeakHumidity)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LeakLastOil)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LeakMain)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LeakMg1135)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("LeakMG1135");

                entity.Property(e => e.LeakMg1135dec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("LeakMG1135Dec");

                entity.Property(e => e.LeakMg11410)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("LeakMG11410");

                entity.Property(e => e.LeakMg11410dec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("LeakMG11410Dec");

                entity.Property(e => e.LeakMg196)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("LeakMG196");

                entity.Property(e => e.LeakMg196dec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("LeakMG196Dec");

                entity.Property(e => e.LeakMg1dec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("LeakMG1Dec");

                entity.Property(e => e.LeakMg1dielectric)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("LeakMG1Dielectric");

                entity.Property(e => e.LeakMg1dielectricDec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("LeakMG1DielectricDec");

                entity.Property(e => e.LeakMg1mohm)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("LeakMG1Mohm");

                entity.Property(e => e.LeakMg1rotateDec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("LeakMG1RotateDec");

                entity.Property(e => e.LeakMg1uv)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("LeakMG1UV");

                entity.Property(e => e.LeakMg1uvdec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("LeakMG1UVDec");

                entity.Property(e => e.LeakMg1uw)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("LeakMG1UW");

                entity.Property(e => e.LeakMg1uwdec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("LeakMG1UWDec");

                entity.Property(e => e.LeakMg1wmg2v)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("LeakMG1WMG2V");

                entity.Property(e => e.LeakMg1wu)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("LeakMG1WU");

                entity.Property(e => e.LeakMg1wudec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("LeakMG1WUDec");

                entity.Property(e => e.LeakMg2117)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("LeakMG2117");

                entity.Property(e => e.LeakMg2117dec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("LeakMG2117Dec");

                entity.Property(e => e.LeakMg232)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("LeakMG232");

                entity.Property(e => e.LeakMg232dec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("LeakMG232Dec");

                entity.Property(e => e.LeakMg281)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("LeakMG281");

                entity.Property(e => e.LeakMg281dec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("LeakMG281Dec");

                entity.Property(e => e.LeakMg2dec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("LeakMG2Dec");

                entity.Property(e => e.LeakMg2dielectric)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("LeakMG2Dielectric");

                entity.Property(e => e.LeakMg2dielectricDec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("LeakMG2DielectricDec");

                entity.Property(e => e.LeakMg2mohm)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("LeakMG2Mohm");

                entity.Property(e => e.LeakMg2rotateDec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("LeakMG2RotateDec");

                entity.Property(e => e.LeakMg2uv)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("LeakMG2UV");

                entity.Property(e => e.LeakMg2uvdec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("LeakMG2UVDec");

                entity.Property(e => e.LeakMg2uw)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("LeakMG2UW");

                entity.Property(e => e.LeakMg2uwdec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("LeakMG2UWDec");

                entity.Property(e => e.LeakMg2wu)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("LeakMG2WU");

                entity.Property(e => e.LeakMg2wudec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("LeakMG2WUDec");

                entity.Property(e => e.LeakOil)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LeakOilLine)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LeakOilLineDec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LeakOilTempDec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LeakOilTempMohmDec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LeakResolver)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LeakResolverDec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LeakTemp)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LeakTempDec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LeakThermistor)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LeakThermistorDec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LeakThermistorMg1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("LeakThermistorMG1");

                entity.Property(e => e.LeakThermistorMg1dec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("LeakThermistorMG1Dec");

                entity.Property(e => e.LeakThermistorMg2)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("LeakThermistorMG2");

                entity.Property(e => e.LeakThermistorMg2dec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("LeakThermistorMG2Dec");

                entity.Property(e => e.LineDec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LubPipeAssem)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MandrelAttach)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Mg1rotorDec)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("MG1RotorDec");

                entity.Property(e => e.Mg1rserial)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MG1RSerial");

                entity.Property(e => e.Mg1sserial)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MG1SSerial");

                entity.Property(e => e.Mg1statorDec)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("MG1StatorDec");

                entity.Property(e => e.Mg2rotorDec)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("MG2RotorDec");

                entity.Property(e => e.Mg2rserial)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MG2RSerial");

                entity.Property(e => e.Mg2sserial)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MG2SSerial");

                entity.Property(e => e.Mg2statorDec)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("MG2StatorDec");

                entity.Property(e => e.MoDriveSerial)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MotorCoolPipeMw)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorCoolPipeMW")
                    .IsFixedLength();

                entity.Property(e => e.MotorCoolPipeMw2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorCoolPipeMW2")
                    .IsFixedLength();

                entity.Property(e => e.MotorFipgapp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorFIPGApp")
                    .IsFixedLength();

                entity.Property(e => e.MotorHarnEscMw)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorHarnEscMW")
                    .IsFixedLength();

                entity.Property(e => e.MotorHsgSrfBrgAm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorHsgSrfBrgAM")
                    .IsFixedLength();

                entity.Property(e => e.MotorHsgSrfKnockPam)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorHsgSrfKnockPAM")
                    .IsFixedLength();

                entity.Property(e => e.MotorInvMw)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorInvMW")
                    .IsFixedLength();

                entity.Property(e => e.MotorMg12rotorAssem)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorMG12RotorAssem")
                    .IsFixedLength();

                entity.Property(e => e.MotorMg12statorTightAm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorMG12StatorTightAM")
                    .IsFixedLength();

                entity.Property(e => e.MotorMg1statorInsAm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorMG1StatorInsAM")
                    .IsFixedLength();

                entity.Property(e => e.MotorMg2statorInsAm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorMG2StatorInsAM")
                    .IsFixedLength();

                entity.Property(e => e.MotorMtrCode)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MotorMw1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorMW1")
                    .IsFixedLength();

                entity.Property(e => e.MotorMw2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorMW2")
                    .IsFixedLength();

                entity.Property(e => e.MotorMwco0)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorMWCo0")
                    .IsFixedLength();

                entity.Property(e => e.MotorMwco1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorMWCo1")
                    .IsFixedLength();

                entity.Property(e => e.MotorMwco2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorMWCo2")
                    .IsFixedLength();

                entity.Property(e => e.MotorMwco3)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorMWCo3")
                    .IsFixedLength();

                entity.Property(e => e.MotorPrevStn)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MotorReject)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MotorRrCoverAssem)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MotorRrCoverSrfKnockPam)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorRrCoverSrfKnockPAM")
                    .IsFixedLength();

                entity.Property(e => e.MotorRrCoverSrfOutBrgAm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorRrCoverSrfOutBrgAM")
                    .IsFixedLength();

                entity.Property(e => e.MotorRrCoverTight1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MotorRrCoverTight2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MotorSngen)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorSNGen")
                    .IsFixedLength();

                entity.Property(e => e.MotorTermBoardMw)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorTermBoardMW")
                    .IsFixedLength();

                entity.Property(e => e.MotorThermMw)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MotorThermMW")
                    .IsFixedLength();

                entity.Property(e => e.Mw1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MW1")
                    .IsFixedLength();

                entity.Property(e => e.Mw2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MW2")
                    .IsFixedLength();

                entity.Property(e => e.Mw3)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MW3")
                    .IsFixedLength();

                entity.Property(e => e.OilCoolerAssem)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.OilInjection)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.OilPump)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.OilPumpAssembly)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Os1abvalue)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("OS1ABValue");

                entity.Property(e => e.Os1date)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("OS1Date");

                entity.Property(e => e.Os1lhfinalLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("OS1LHFinalLoad");

                entity.Property(e => e.Os1lhfinalStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("OS1LHFinalStroke");

                entity.Property(e => e.Os1lhload)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("OS1LHLoad");

                entity.Property(e => e.Os1lhstroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("OS1LHStroke");

                entity.Property(e => e.Os1mainStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("OS1MainStroke");

                entity.Property(e => e.Os1rhfinalLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("OS1RHFinalLoad");

                entity.Property(e => e.Os1rhfinalStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("OS1RHFinalStroke");

                entity.Property(e => e.Os1rhload)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("OS1RHLoad");

                entity.Property(e => e.Os1rhstroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("OS1RHStroke");

                entity.Property(e => e.Os2abvalue)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("OS2ABValue");

                entity.Property(e => e.Os2date)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("OS2Date");

                entity.Property(e => e.Os2finalLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("OS2FinalLoad");

                entity.Property(e => e.Os2finalStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("OS2FinalStroke");

                entity.Property(e => e.Os2mainStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("OS2MainStroke");

                entity.Property(e => e.Os2ptLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("OS2PtLoad");

                entity.Property(e => e.Os2stroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("OS2Stroke");

                entity.Property(e => e.ParkingDec)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.PokayokeDate15)
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.PokayokeDate16)
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.PokayokeDate18)
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.PokayokeDate19)
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.PokayokeDate20)
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.PokayokeDate21)
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.PokayokeDate22)
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.PokayokeDate23)
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.PokayokeDate24)
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.PokayokeDate25)
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.PokayokeDate26)
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.PokayokeDate27)
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.PokayokeDate28)
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.PokayokeDate29)
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.PokayokeDate30)
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.PokayokeDate31)
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.PokayokeDate32)
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.Preprocessing)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Reject)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Reshuffle)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RevRivetConfirm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RotorCoreTrans)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RotorExtractionInsp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RotorForeignSuction)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RotorHeating)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RotorMagnetization)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RotorNutCrimpMg1press)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RotorNutCrimpMG1Press")
                    .IsFixedLength();

                entity.Property(e => e.RotorNutTight)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RotorReject)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RotorResolverPress)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RotorShaftPress)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RotorShaftTrans)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RotorShippingInsp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RotorTamg2coreTrans)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RotorTAMG2CoreTrans")
                    .IsFixedLength();

                entity.Property(e => e.RotorTamg2extractionInsp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RotorTAMG2ExtractionInsp")
                    .IsFixedLength();

                entity.Property(e => e.RotorTamg2foreignSuction)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RotorTAMG2ForeignSuction")
                    .IsFixedLength();

                entity.Property(e => e.RotorTamg2heating)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RotorTAMG2Heating")
                    .IsFixedLength();

                entity.Property(e => e.RotorTamg2magnetization)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RotorTAMG2Magnetization")
                    .IsFixedLength();

                entity.Property(e => e.RotorTamg2nutCrimpMg1press)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RotorTAMG2NutCrimpMG1Press")
                    .IsFixedLength();

                entity.Property(e => e.RotorTamg2nutTight)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RotorTAMG2NutTight")
                    .IsFixedLength();

                entity.Property(e => e.RotorTamg2reject)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RotorTAMG2Reject")
                    .IsFixedLength();

                entity.Property(e => e.RotorTamg2resolverPress)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RotorTAMG2ResolverPress")
                    .IsFixedLength();

                entity.Property(e => e.RotorTamg2shaftPress)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RotorTAMG2ShaftPress")
                    .IsFixedLength();

                entity.Property(e => e.RotorTamg2shaftTrans)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RotorTAMG2ShaftTrans")
                    .IsFixedLength();

                entity.Property(e => e.RotorTamg2shippingInsp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RotorTAMG2ShippingInsp")
                    .IsFixedLength();

                entity.Property(e => e.RrCoverDec)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.RrcoverSerial)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RRCoverSerial");

                entity.Property(e => e.RropSerial)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RRopSerial");

                entity.Property(e => e.SerialStamping)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ShimCaset2)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ShimCaset4)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ShimGear)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ShimGrade)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ShimGradeCo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ShimGradeIn)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ShimHsgt1)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ShimHsgt3)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ShimHsgt5)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ShimHsgt7)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ShimMeasDate)
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.ShimSet)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ShimShellt6)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ShimShellt8)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ShimSlider)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ShimValueCo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ShimValueDiff)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ShimValueIn)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ShimValuePin)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Shimt1Main)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Shimt1t2)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Shimt2Main)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Shimt3Main)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Shimt3t4)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Shimt4Main)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Shimt5Main)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Shimt5t6)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Shimt6Main)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Shimt7Main)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Shimt7t8)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Shimt8Main)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ShipmentSerial)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ShippingPrep1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ShippingPrep2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Slnffastening)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SLNFFastening")
                    .IsFixedLength();

                entity.Property(e => e.Slnfriveting)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SLNFRiveting")
                    .IsFixedLength();

                entity.Property(e => e.SubShimSel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TagMeasDate)
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.VisualInsp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Vw1RotorTable>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw1_RotorTable");

                entity.Property(e => e.Ro1Apicode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1APICode");

                entity.Property(e => e.Ro1ApicoreTemp)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1APICoreTemp");

                entity.Property(e => e.Ro1Apidate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Ro1APIDate");

                entity.Property(e => e.Ro1ApideviationLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1APIDeviationLoad");

                entity.Property(e => e.Ro1ApifinalStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1APIFinalStroke");

                entity.Property(e => e.Ro1ApiinitTilt)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1APIInitTilt");

                entity.Property(e => e.Ro1Apiload)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1APILoad");

                entity.Property(e => e.Ro1Apimachine)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1APIMachine");

                entity.Property(e => e.Ro1ApimainStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1APIMainStroke");

                entity.Property(e => e.Ro1Apipos)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1APIPos");

                entity.Property(e => e.Ro1Apistroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1APIStroke");

                entity.Property(e => e.Ro1Apisttime)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Ro1APISTTime");

                entity.Property(e => e.Ro1Asldate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Ro1ASLDate");

                entity.Property(e => e.Ro1AxisSerial)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1AxisTemp)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1Cdtemp)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1CDTemp");

                entity.Property(e => e.Ro1CoreAfter)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1CoreBefore)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1Detection1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1Detection2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1Df1abvalue)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1DF1ABValue");

                entity.Property(e => e.Ro1Df1angleAxis1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1DF1AngleAxis1");

                entity.Property(e => e.Ro1Df1angleAxis2)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1DF1AngleAxis2");

                entity.Property(e => e.Ro1Df1angleAxis3)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1DF1AngleAxis3");

                entity.Property(e => e.Ro1Df1angleAxis4)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1DF1AngleAxis4");

                entity.Property(e => e.Ro1Df1angleAxis5)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1DF1AngleAxis5");

                entity.Property(e => e.Ro1Df1angleAxis6)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1DF1AngleAxis6");

                entity.Property(e => e.Ro1Df1codeAxis1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1DF1CodeAxis1");

                entity.Property(e => e.Ro1Df1codeAxis2)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1DF1CodeAxis2");

                entity.Property(e => e.Ro1Df1codeAxis3)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1DF1CodeAxis3");

                entity.Property(e => e.Ro1Df1codeAxis4)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1DF1CodeAxis4");

                entity.Property(e => e.Ro1Df1codeAxis5)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1DF1CodeAxis5");

                entity.Property(e => e.Ro1Df1codeAxis6)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1DF1CodeAxis6");

                entity.Property(e => e.Ro1Df1date)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Ro1DF1Date");

                entity.Property(e => e.Ro1Df2abvalue)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1DF2ABValue");

                entity.Property(e => e.Ro1Df2angleAxis1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1DF2AngleAxis1");

                entity.Property(e => e.Ro1Df2angleAxis2)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1DF2AngleAxis2");

                entity.Property(e => e.Ro1Df2angleAxis3)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1DF2AngleAxis3");

                entity.Property(e => e.Ro1Df2angleAxis4)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1DF2AngleAxis4");

                entity.Property(e => e.Ro1Df2angleAxis5)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1DF2AngleAxis5");

                entity.Property(e => e.Ro1Df2angleAxis6)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1DF2AngleAxis6");

                entity.Property(e => e.Ro1Df2codeAxis1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1DF2CodeAxis1");

                entity.Property(e => e.Ro1Df2codeAxis2)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1DF2CodeAxis2");

                entity.Property(e => e.Ro1Df2codeAxis3)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1DF2CodeAxis3");

                entity.Property(e => e.Ro1Df2codeAxis4)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1DF2CodeAxis4");

                entity.Property(e => e.Ro1Df2codeAxis5)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1DF2CodeAxis5");

                entity.Property(e => e.Ro1Df2codeAxis6)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1DF2CodeAxis6");

                entity.Property(e => e.Ro1Df2date)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Ro1DF2Date");

                entity.Property(e => e.Ro1Dfbrgdate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Ro1DFBRGDate");

                entity.Property(e => e.Ro1DfbrgfinalLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1DFBRGFinalLoad");

                entity.Property(e => e.Ro1DfbrgfinalLoadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1DFBRGFinalLoadSec");

                entity.Property(e => e.Ro1DfbrgfinalStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1DFBRGFinalStroke");

                entity.Property(e => e.Ro1DfbrgfinalStrokeSec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1DFBRGFinalStrokeSec");

                entity.Property(e => e.Ro1Dfbrgload)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1DFBRGLoad");

                entity.Property(e => e.Ro1DfbrgloadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1DFBRGLoadSec");

                entity.Property(e => e.Ro1DfbrgmainStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1DFBRGMainStroke");

                entity.Property(e => e.Ro1Dfbrgstroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1DFBRGStroke");

                entity.Property(e => e.Ro1DfbrgstrokeSec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1DFBRGStrokeSec");

                entity.Property(e => e.Ro1DfreverseDate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Ro1DFReverseDate");

                entity.Property(e => e.Ro1Dgaload3Axis)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1DGALoad3Axis");

                entity.Property(e => e.Ro1Dgaload4Axis)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1DGALoad4Axis");

                entity.Property(e => e.Ro1DgameasDate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Ro1DGAMeasDate");

                entity.Property(e => e.Ro1Dgapos3Axis)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1DGAPos3Axis");

                entity.Property(e => e.Ro1Dgapos4Axis)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1DGAPos4Axis");

                entity.Property(e => e.Ro1Dgmdagjudge)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1DGMDAGJudge");

                entity.Property(e => e.Ro1DgmlhRh)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1DGMLhRh");

                entity.Property(e => e.Ro1DgmmaxTorque)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1DGMMaxTorque");

                entity.Property(e => e.Ro1DgmmeasTime)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Ro1DGMMeasTime");

                entity.Property(e => e.Ro1DgmminTorque)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1DGMMinTorque");

                entity.Property(e => e.Ro1DpnfFinalLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1DpnfFinalStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1DpnfMainStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1DpnfMeasDate)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1DpntAngleAxis1)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1DpntDate)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1DpntDrop)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1DpntJudgment)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1DpntSeating)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1DpntSlack)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1DpntTorqueAxis1)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1Dprfrl)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1DPRFRL");

                entity.Property(e => e.Ro1Dprfrs)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1DPRFRS");

                entity.Property(e => e.Ro1DprmeasTime)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1DPRMeasTime");

                entity.Property(e => e.Ro1Gear2Abvalue)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1Gear2ABValue");

                entity.Property(e => e.Ro1Gear2Date)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1Gear2FinalLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1Gear2FinalLoadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1Gear2FinalStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1Gear2FinalStrokeSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1Gear2Load)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1Gear2LoadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1Gear2MainStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1Gear2Stroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1Gear2StrokeSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1GearAbvalue)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1GearABValue");

                entity.Property(e => e.Ro1GearFinalLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1GearFinalLoadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1GearFinalStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1GearFinalStrokeSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1GearLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1GearLoadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1GearMainStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1GearMeasDate)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1GearStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1GearStrokeSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1HeatEndTime)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1HeatOutput)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1HeatProcedure)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1HeatSt)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1HeatST");

                entity.Property(e => e.Ro1HeatTime)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1HsgBrgFinalLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1HsgBrgFinalLoadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1HsgBrgFinalStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1HsgBrgFinalStrokeSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1HsgBrgInflectPtLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1HsgBrgInflectPtLoadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1HsgBrgInflectPtStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1HsgBrgInflectPtStrokeSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1HsgBrgMaasterStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1HsgBrgMeasDate)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1Ictldate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Ro1ICTLDate");

                entity.Property(e => e.Ro1Ihafter)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1IHAfter");

                entity.Property(e => e.Ro1Ihbefore)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1IHBefore");

                entity.Property(e => e.Ro1IsRcheat)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1IsRCHeat");

                entity.Property(e => e.Ro1JudgmentCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1Mg1dec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1MG1Dec");

                entity.Property(e => e.Ro1Mg1fluxValue)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1MG1FluxValue");

                entity.Property(e => e.Ro1Mg1rserial)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Ro1MG1RSerial");

                entity.Property(e => e.Ro1Mg1workTemp)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1MG1WorkTemp");

                entity.Property(e => e.Ro1Mg2dec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1MG2Dec");

                entity.Property(e => e.Ro1Mg2fluxValue)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1MG2FluxValue");

                entity.Property(e => e.Ro1Mg2workTemp)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1MG2WorkTemp");

                entity.Property(e => e.Ro1NtangleAxis1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1NTAngleAxis1");

                entity.Property(e => e.Ro1Ntcode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1NTCode");

                entity.Property(e => e.Ro1Ntdate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Ro1NTDate");

                entity.Property(e => e.Ro1Ntdrop1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1NTDrop1");

                entity.Property(e => e.Ro1Nthistory)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1NTHistory");

                entity.Property(e => e.Ro1Ntseating1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1NTSeating1");

                entity.Property(e => e.Ro1Ntslack1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1NTSlack1");

                entity.Property(e => e.Ro1NttorqueAxis1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1NTTorqueAxis1");

                entity.Property(e => e.Ro1PokayokeDate33)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1PokayokeDate34)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1PokayokeDate35)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1PokayokeDate36)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1PokayokeDate37)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1PokayokeDate38)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1PokayokeDate39)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1PokayokeDate40)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1PokayokeDate41)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1PokayokeDate42)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1PokayokeDate43)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1PokayokeDate44)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1PokayokeDate45)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1ProcDate)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1Rapafter)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1RAPAfter");

                entity.Property(e => e.Ro1Rapbefore)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1RAPBefore");

                entity.Property(e => e.Ro1Rapcode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1RAPCode");

                entity.Property(e => e.Ro1Rapcode2)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1RAPCode2");

                entity.Property(e => e.Ro1Rapdate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Ro1RAPDate");

                entity.Property(e => e.Ro1RapfinalStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1RAPFinalStroke");

                entity.Property(e => e.Ro1Rapload)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1RAPLoad");

                entity.Property(e => e.Ro1RaploadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1RAPLoadSec");

                entity.Property(e => e.Ro1Rapmain2Stroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1RAPMain2Stroke");

                entity.Property(e => e.Ro1RapmainStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1RAPMainStroke");

                entity.Property(e => e.Ro1Rapstroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1RAPStroke");

                entity.Property(e => e.Ro1RapwashMain)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1RAPWashMain");

                entity.Property(e => e.Ro1RapwashPos)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1RAPWashPos");

                entity.Property(e => e.Ro1RapwashSensor)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1RAPWashSensor");

                entity.Property(e => e.Ro1Rcserial)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1RCSerial");

                entity.Property(e => e.Ro1RejectTime)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1RoomTemp)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro1Rtpcode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1RTPCode");

                entity.Property(e => e.Ro1RtpfinalStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1RTPFinalStroke");

                entity.Property(e => e.Ro1Rtphistory)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1RTPHistory");

                entity.Property(e => e.Ro1Rtpload)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1RTPLoad");

                entity.Property(e => e.Ro1RtpmainStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1RTPMainStroke");

                entity.Property(e => e.Ro1RtpstartDate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Ro1RTPStartDate");

                entity.Property(e => e.Ro1Rtpstroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro1RTPStroke");

                entity.Property(e => e.Ro1UpenderDate)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Vw2RotorTable>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw2_RotorTable");

                entity.Property(e => e.Ro2Apicode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2APICode");

                entity.Property(e => e.Ro2ApicoreTemp)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2APICoreTemp");

                entity.Property(e => e.Ro2Apidate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Ro2APIDate");

                entity.Property(e => e.Ro2ApideviationLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2APIDeviationLoad");

                entity.Property(e => e.Ro2ApifinalStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2APIFinalStroke");

                entity.Property(e => e.Ro2ApiinitTilt)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2APIInitTilt");

                entity.Property(e => e.Ro2Apiload)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2APILoad");

                entity.Property(e => e.Ro2Apimachine)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2APIMachine");

                entity.Property(e => e.Ro2ApimainStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2APIMainStroke");

                entity.Property(e => e.Ro2Apipos)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2APIPos");

                entity.Property(e => e.Ro2Apistroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2APIStroke");

                entity.Property(e => e.Ro2Apisttime)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Ro2APISTTime");

                entity.Property(e => e.Ro2Asldate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Ro2ASLDate");

                entity.Property(e => e.Ro2AxisSerial)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2AxisTemp)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2Cdtemp)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2CDTemp");

                entity.Property(e => e.Ro2CoreAfter)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2CoreBefore)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2Detection1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2Detection2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2Df1abvalue)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2DF1ABValue");

                entity.Property(e => e.Ro2Df1angleAxis1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2DF1AngleAxis1");

                entity.Property(e => e.Ro2Df1angleAxis2)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2DF1AngleAxis2");

                entity.Property(e => e.Ro2Df1angleAxis3)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2DF1AngleAxis3");

                entity.Property(e => e.Ro2Df1angleAxis4)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2DF1AngleAxis4");

                entity.Property(e => e.Ro2Df1angleAxis5)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2DF1AngleAxis5");

                entity.Property(e => e.Ro2Df1angleAxis6)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2DF1AngleAxis6");

                entity.Property(e => e.Ro2Df1codeAxis1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2DF1CodeAxis1");

                entity.Property(e => e.Ro2Df1codeAxis2)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2DF1CodeAxis2");

                entity.Property(e => e.Ro2Df1codeAxis3)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2DF1CodeAxis3");

                entity.Property(e => e.Ro2Df1codeAxis4)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2DF1CodeAxis4");

                entity.Property(e => e.Ro2Df1codeAxis5)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2DF1CodeAxis5");

                entity.Property(e => e.Ro2Df1codeAxis6)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2DF1CodeAxis6");

                entity.Property(e => e.Ro2Df1date)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Ro2DF1Date");

                entity.Property(e => e.Ro2Df2abvalue)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2DF2ABValue");

                entity.Property(e => e.Ro2Df2angleAxis1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2DF2AngleAxis1");

                entity.Property(e => e.Ro2Df2angleAxis2)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2DF2AngleAxis2");

                entity.Property(e => e.Ro2Df2angleAxis3)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2DF2AngleAxis3");

                entity.Property(e => e.Ro2Df2angleAxis4)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2DF2AngleAxis4");

                entity.Property(e => e.Ro2Df2angleAxis5)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2DF2AngleAxis5");

                entity.Property(e => e.Ro2Df2angleAxis6)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2DF2AngleAxis6");

                entity.Property(e => e.Ro2Df2codeAxis1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2DF2CodeAxis1");

                entity.Property(e => e.Ro2Df2codeAxis2)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2DF2CodeAxis2");

                entity.Property(e => e.Ro2Df2codeAxis3)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2DF2CodeAxis3");

                entity.Property(e => e.Ro2Df2codeAxis4)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2DF2CodeAxis4");

                entity.Property(e => e.Ro2Df2codeAxis5)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2DF2CodeAxis5");

                entity.Property(e => e.Ro2Df2codeAxis6)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2DF2CodeAxis6");

                entity.Property(e => e.Ro2Df2date)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Ro2DF2Date");

                entity.Property(e => e.Ro2Dfbrgdate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Ro2DFBRGDate");

                entity.Property(e => e.Ro2DfbrgfinalLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2DFBRGFinalLoad");

                entity.Property(e => e.Ro2DfbrgfinalLoadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2DFBRGFinalLoadSec");

                entity.Property(e => e.Ro2DfbrgfinalStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2DFBRGFinalStroke");

                entity.Property(e => e.Ro2DfbrgfinalStrokeSec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2DFBRGFinalStrokeSec");

                entity.Property(e => e.Ro2Dfbrgload)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2DFBRGLoad");

                entity.Property(e => e.Ro2DfbrgloadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2DFBRGLoadSec");

                entity.Property(e => e.Ro2DfbrgmainStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2DFBRGMainStroke");

                entity.Property(e => e.Ro2Dfbrgstroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2DFBRGStroke");

                entity.Property(e => e.Ro2DfbrgstrokeSec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2DFBRGStrokeSec");

                entity.Property(e => e.Ro2DfreverseDate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Ro2DFReverseDate");

                entity.Property(e => e.Ro2Dgaload3Axis)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2DGALoad3Axis");

                entity.Property(e => e.Ro2Dgaload4Axis)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2DGALoad4Axis");

                entity.Property(e => e.Ro2DgameasDate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Ro2DGAMeasDate");

                entity.Property(e => e.Ro2Dgapos3Axis)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2DGAPos3Axis");

                entity.Property(e => e.Ro2Dgapos4Axis)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2DGAPos4Axis");

                entity.Property(e => e.Ro2Dgmdagjudge)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2DGMDAGJudge");

                entity.Property(e => e.Ro2DgmlhRh)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2DGMLhRh");

                entity.Property(e => e.Ro2DgmmaxTorque)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2DGMMaxTorque");

                entity.Property(e => e.Ro2DgmmeasTime)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Ro2DGMMeasTime");

                entity.Property(e => e.Ro2DgmminTorque)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2DGMMinTorque");

                entity.Property(e => e.Ro2DpnfFinalLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2DpnfFinalStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2DpnfMainStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2DpnfMeasDate)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2DpntAngleAxis1)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2DpntDate)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2DpntDrop)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2DpntJudgment)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2DpntSeating)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2DpntSlack)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2DpntTorqueAxis1)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2Dprfrl)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2DPRFRL");

                entity.Property(e => e.Ro2Dprfrs)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2DPRFRS");

                entity.Property(e => e.Ro2DprmeasTime)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2DPRMeasTime");

                entity.Property(e => e.Ro2Gear2Abvalue)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2Gear2ABValue");

                entity.Property(e => e.Ro2Gear2Date)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2Gear2FinalLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2Gear2FinalLoadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2Gear2FinalStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2Gear2FinalStrokeSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2Gear2Load)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2Gear2LoadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2Gear2MainStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2Gear2Stroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2Gear2StrokeSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2GearAbvalue)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2GearABValue");

                entity.Property(e => e.Ro2GearFinalLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2GearFinalLoadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2GearFinalStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2GearFinalStrokeSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2GearLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2GearLoadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2GearMainStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2GearMeasDate)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2GearStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2GearStrokeSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2HeatEndTime)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2HeatOutput)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2HeatProcedure)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2HeatSt)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2HeatST");

                entity.Property(e => e.Ro2HeatTime)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2HsgBrgFinalLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2HsgBrgFinalLoadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2HsgBrgFinalStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2HsgBrgFinalStrokeSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2HsgBrgInflectPtLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2HsgBrgInflectPtLoadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2HsgBrgInflectPtStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2HsgBrgInflectPtStrokeSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2HsgBrgMaasterStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2HsgBrgMeasDate)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2Ictldate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Ro2ICTLDate");

                entity.Property(e => e.Ro2Ihafter)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2IHAfter");

                entity.Property(e => e.Ro2Ihbefore)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2IHBefore");

                entity.Property(e => e.Ro2IsRcheat)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2IsRCHeat");

                entity.Property(e => e.Ro2JudgmentCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2Mg1dec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2MG1Dec");

                entity.Property(e => e.Ro2Mg1fluxValue)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2MG1FluxValue");

                entity.Property(e => e.Ro2Mg1rserial)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Ro2MG1RSerial");

                entity.Property(e => e.Ro2Mg1workTemp)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2MG1WorkTemp");

                entity.Property(e => e.Ro2Mg2dec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2MG2Dec");

                entity.Property(e => e.Ro2Mg2fluxValue)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2MG2FluxValue");

                entity.Property(e => e.Ro2Mg2workTemp)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2MG2WorkTemp");

                entity.Property(e => e.Ro2NtangleAxis1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2NTAngleAxis1");

                entity.Property(e => e.Ro2Ntcode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2NTCode");

                entity.Property(e => e.Ro2Ntdate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Ro2NTDate");

                entity.Property(e => e.Ro2Ntdrop1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2NTDrop1");

                entity.Property(e => e.Ro2Nthistory)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2NTHistory");

                entity.Property(e => e.Ro2Ntseating1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2NTSeating1");

                entity.Property(e => e.Ro2Ntslack1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2NTSlack1");

                entity.Property(e => e.Ro2NttorqueAxis1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2NTTorqueAxis1");

                entity.Property(e => e.Ro2PokayokeDate33)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2PokayokeDate34)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2PokayokeDate35)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2PokayokeDate36)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2PokayokeDate37)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2PokayokeDate38)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2PokayokeDate39)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2PokayokeDate40)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2PokayokeDate41)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2PokayokeDate42)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2PokayokeDate43)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2PokayokeDate44)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2PokayokeDate45)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2ProcDate)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2Rapafter)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2RAPAfter");

                entity.Property(e => e.Ro2Rapbefore)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2RAPBefore");

                entity.Property(e => e.Ro2Rapcode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2RAPCode");

                entity.Property(e => e.Ro2Rapcode2)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2RAPCode2");

                entity.Property(e => e.Ro2Rapdate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Ro2RAPDate");

                entity.Property(e => e.Ro2RapfinalStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2RAPFinalStroke");

                entity.Property(e => e.Ro2Rapload)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2RAPLoad");

                entity.Property(e => e.Ro2RaploadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2RAPLoadSec");

                entity.Property(e => e.Ro2Rapmain2Stroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2RAPMain2Stroke");

                entity.Property(e => e.Ro2RapmainStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2RAPMainStroke");

                entity.Property(e => e.Ro2Rapstroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2RAPStroke");

                entity.Property(e => e.Ro2RapwashMain)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2RAPWashMain");

                entity.Property(e => e.Ro2RapwashPos)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2RAPWashPos");

                entity.Property(e => e.Ro2RapwashSensor)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2RAPWashSensor");

                entity.Property(e => e.Ro2Rcserial)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2RCSerial");

                entity.Property(e => e.Ro2RejectTime)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2RoomTemp)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ro2Rtpcode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2RTPCode");

                entity.Property(e => e.Ro2RtpfinalStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2RTPFinalStroke");

                entity.Property(e => e.Ro2Rtphistory)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2RTPHistory");

                entity.Property(e => e.Ro2Rtpload)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2RTPLoad");

                entity.Property(e => e.Ro2RtpmainStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2RTPMainStroke");

                entity.Property(e => e.Ro2RtpstartDate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Ro2RTPStartDate");

                entity.Property(e => e.Ro2Rtpstroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Ro2RTPStroke");

                entity.Property(e => e.Ro2UpenderDate)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VwGearTable>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_GearTable");

                entity.Property(e => e.GeApicode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeAPICode");

                entity.Property(e => e.GeApicoreTemp)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeAPICoreTemp");

                entity.Property(e => e.GeApidate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("GeAPIDate");

                entity.Property(e => e.GeApideviationLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeAPIDeviationLoad");

                entity.Property(e => e.GeApifinalStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeAPIFinalStroke");

                entity.Property(e => e.GeApiinitTilt)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeAPIInitTilt");

                entity.Property(e => e.GeApiload)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeAPILoad");

                entity.Property(e => e.GeApimachine)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeAPIMachine");

                entity.Property(e => e.GeApimainStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeAPIMainStroke");

                entity.Property(e => e.GeApipos)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeAPIPos");

                entity.Property(e => e.GeApistroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeAPIStroke");

                entity.Property(e => e.GeApisttime)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("GeAPISTTime");

                entity.Property(e => e.GeAsldate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("GeASLDate");

                entity.Property(e => e.GeAxisSerial)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GeAxisTemp)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GeCdtemp)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeCDTemp");

                entity.Property(e => e.GeContact)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GeCoreAfter)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GeCoreBefore)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GeDf1abvalue)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeDF1ABValue");

                entity.Property(e => e.GeDf1angleAxis1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeDF1AngleAxis1");

                entity.Property(e => e.GeDf1angleAxis2)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeDF1AngleAxis2");

                entity.Property(e => e.GeDf1angleAxis3)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeDF1AngleAxis3");

                entity.Property(e => e.GeDf1angleAxis4)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeDF1AngleAxis4");

                entity.Property(e => e.GeDf1angleAxis5)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeDF1AngleAxis5");

                entity.Property(e => e.GeDf1angleAxis6)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeDF1AngleAxis6");

                entity.Property(e => e.GeDf1codeAxis1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeDF1CodeAxis1");

                entity.Property(e => e.GeDf1codeAxis2)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeDF1CodeAxis2");

                entity.Property(e => e.GeDf1codeAxis3)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeDF1CodeAxis3");

                entity.Property(e => e.GeDf1codeAxis4)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeDF1CodeAxis4");

                entity.Property(e => e.GeDf1codeAxis5)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeDF1CodeAxis5");

                entity.Property(e => e.GeDf1codeAxis6)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeDF1CodeAxis6");

                entity.Property(e => e.GeDf1date)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("GeDF1Date");

                entity.Property(e => e.GeDf2abvalue)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeDF2ABValue");

                entity.Property(e => e.GeDf2angleAxis1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeDF2AngleAxis1");

                entity.Property(e => e.GeDf2angleAxis2)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeDF2AngleAxis2");

                entity.Property(e => e.GeDf2angleAxis3)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeDF2AngleAxis3");

                entity.Property(e => e.GeDf2angleAxis4)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeDF2AngleAxis4");

                entity.Property(e => e.GeDf2angleAxis5)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeDF2AngleAxis5");

                entity.Property(e => e.GeDf2angleAxis6)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeDF2AngleAxis6");

                entity.Property(e => e.GeDf2codeAxis1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeDF2CodeAxis1");

                entity.Property(e => e.GeDf2codeAxis2)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeDF2CodeAxis2");

                entity.Property(e => e.GeDf2codeAxis3)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeDF2CodeAxis3");

                entity.Property(e => e.GeDf2codeAxis4)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeDF2CodeAxis4");

                entity.Property(e => e.GeDf2codeAxis5)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeDF2CodeAxis5");

                entity.Property(e => e.GeDf2codeAxis6)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeDF2CodeAxis6");

                entity.Property(e => e.GeDf2date)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("GeDF2Date");

                entity.Property(e => e.GeDfbrgdate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("GeDFBRGDate");

                entity.Property(e => e.GeDfbrgfinalLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeDFBRGFinalLoad");

                entity.Property(e => e.GeDfbrgfinalLoadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeDFBRGFinalLoadSec");

                entity.Property(e => e.GeDfbrgfinalStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeDFBRGFinalStroke");

                entity.Property(e => e.GeDfbrgfinalStrokeSec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeDFBRGFinalStrokeSec");

                entity.Property(e => e.GeDfbrgload)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeDFBRGLoad");

                entity.Property(e => e.GeDfbrgloadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeDFBRGLoadSec");

                entity.Property(e => e.GeDfbrgmainStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeDFBRGMainStroke");

                entity.Property(e => e.GeDfbrgstroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeDFBRGStroke");

                entity.Property(e => e.GeDfbrgstrokeSec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeDFBRGStrokeSec");

                entity.Property(e => e.GeDfreverseDate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("GeDFReverseDate");

                entity.Property(e => e.GeDfringSerial)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.GeDgaload3Axis)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeDGALoad3Axis");

                entity.Property(e => e.GeDgaload4Axis)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeDGALoad4Axis");

                entity.Property(e => e.GeDgameasDate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("GeDGAMeasDate");

                entity.Property(e => e.GeDgapos3Axis)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeDGAPos3Axis");

                entity.Property(e => e.GeDgapos4Axis)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeDGAPos4Axis");

                entity.Property(e => e.GeDgmdagjudge)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeDGMDAGJudge");

                entity.Property(e => e.GeDgmlhRh)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("GeDGMLhRh");

                entity.Property(e => e.GeDgmmaxTorque)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeDGMMaxTorque");

                entity.Property(e => e.GeDgmmeasDate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("GeDGMMeasDate");

                entity.Property(e => e.GeDgmminTorque)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeDGMMinTorque");

                entity.Property(e => e.GeDpnfFinalLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GeDpnfFinalStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GeDpnfMainStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GeDpnfMeasDate)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.GeDpntAngleAxis1)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GeDpntDate)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.GeDpntDrop)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GeDpntJudgment)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GeDpntSeating)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GeDpntSlack)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GeDpntTorqueAxis1)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GeDprfrl)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeDPRFRL");

                entity.Property(e => e.GeDprfrs)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeDPRFRS");

                entity.Property(e => e.GeDprmeasDate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("GeDPRMeasDate");

                entity.Property(e => e.GeGear2Abvalue)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeGear2ABValue");

                entity.Property(e => e.GeGear2Date)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.GeGear2FinalLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GeGear2FinalLoadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GeGear2FinalStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GeGear2FinalStrokeSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GeGear2Load)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GeGear2LoadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GeGear2MainStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GeGear2Stroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GeGear2StrokeSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GeGearAbvalue)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeGearABValue");

                entity.Property(e => e.GeGearFinalLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GeGearFinalLoadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GeGearFinalStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GeGearFinalStrokeSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GeGearLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GeGearLoadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GeGearMainStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GeGearMeasDate)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.GeGearStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GeGearStrokeSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GeHeatEndTime)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GeHeatOutput)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GeHeatProcedure)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GeHeatSt)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeHeatST");

                entity.Property(e => e.GeHeatTime)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.GeHsgBrgFinalLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GeHsgBrgFinalLoadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GeHsgBrgFinalStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GeHsgBrgFinalStrokeSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GeHsgBrgInflectPtLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GeHsgBrgInflectPtLoadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GeHsgBrgInflectPtStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GeHsgBrgInflectPtStrokeSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GeHsgBrgMaasterStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GeHsgBrgMeasDate)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.GeIctldate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("GeICTLDate");

                entity.Property(e => e.GeIhafter)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeIHAfter");

                entity.Property(e => e.GeIhbefore)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeIHBefore");

                entity.Property(e => e.GeIsRcheat)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeIsRCHeat");

                entity.Property(e => e.GeJudgmentCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GeMg1dec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeMG1Dec");

                entity.Property(e => e.GeMg1fluxValue)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeMG1FluxValue");

                entity.Property(e => e.GeMg1workTemp)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeMG1WorkTemp");

                entity.Property(e => e.GeMg2dec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeMG2Dec");

                entity.Property(e => e.GeMg2fluxValue)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeMG2FluxValue");

                entity.Property(e => e.GeMg2workTemp)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeMG2WorkTemp");

                entity.Property(e => e.GeNtangleAxis1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeNTAngleAxis1");

                entity.Property(e => e.GeNtcode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeNTCode");

                entity.Property(e => e.GeNtdate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("GeNTDate");

                entity.Property(e => e.GeNtdrop1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeNTDrop1");

                entity.Property(e => e.GeNthistory)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeNTHistory");

                entity.Property(e => e.GeNtseating1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeNTSeating1");

                entity.Property(e => e.GeNtslack1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeNTSlack1");

                entity.Property(e => e.GeNttorqueAxis1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeNTTorqueAxis1");

                entity.Property(e => e.GePinposition)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GePokayokeDate33)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.GePokayokeDate34)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.GePokayokeDate35)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.GePokayokeDate36)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.GePokayokeDate37)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.GePokayokeDate38)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.GePokayokeDate39)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.GePokayokeDate40)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.GePokayokeDate41)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.GePokayokeDate42)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.GePokayokeDate43)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.GePokayokeDate44)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.GePokayokeDate45)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.GeProcDate)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.GeRapafter)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeRAPAfter");

                entity.Property(e => e.GeRapbefore)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeRAPBefore");

                entity.Property(e => e.GeRapcode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeRAPCode");

                entity.Property(e => e.GeRapcode2)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeRAPCode2");

                entity.Property(e => e.GeRapdate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("GeRAPDate");

                entity.Property(e => e.GeRapfinalStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeRAPFinalStroke");

                entity.Property(e => e.GeRapload)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeRAPLoad");

                entity.Property(e => e.GeRaploadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeRAPLoadSec");

                entity.Property(e => e.GeRapmain2Stroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeRAPMain2Stroke");

                entity.Property(e => e.GeRapmainStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeRAPMainStroke");

                entity.Property(e => e.GeRapstroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeRAPStroke");

                entity.Property(e => e.GeRapwashMain)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeRAPWashMain");

                entity.Property(e => e.GeRapwashPos)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeRAPWashPos");

                entity.Property(e => e.GeRapwashSensor)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeRAPWashSensor");

                entity.Property(e => e.GeRcserial)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeRCSerial");

                entity.Property(e => e.GeRejectTime)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.GeRoomTemp)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GeRtpcode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeRTPCode");

                entity.Property(e => e.GeRtpfinalStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeRTPFinalStroke");

                entity.Property(e => e.GeRtphistory)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeRTPHistory");

                entity.Property(e => e.GeRtpload)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeRTPLoad");

                entity.Property(e => e.GeRtpmainStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeRTPMainStroke");

                entity.Property(e => e.GeRtpstartDate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("GeRTPStartDate");

                entity.Property(e => e.GeRtpstroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GeRTPStroke");

                entity.Property(e => e.GeUpenderDate)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VwMotorTable>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_MotorTable");

                entity.Property(e => e.MoAb)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MoAB");

                entity.Property(e => e.MoAngle10Axis)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoAngle1Axis)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoAngle2Axis)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoAngle3Axis)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoAngle4Axis)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoAngle5Axis)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoAngle6Axis)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoAngle7Axis)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoAngle8Axis)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoAngle9Axis)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoAngleAxis1Sec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoAngleAxis2Sec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoAngleAxis3Sec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoAxis10Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoAxis1Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoAxis2Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoAxis3Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoAxis4Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoAxis5Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoAxis6Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoAxis7Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoAxis8Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoAxis9Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoAxisCode1Sec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoAxisCode2Sec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoAxisCode3Sec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoCodeAxis1)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoCodeAxis2)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoCodeAxis3)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoHsgBrgAbvalue)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MoHsgBrgABValue");

                entity.Property(e => e.MoHsgBrgDate)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MoHsgBrgFinalLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoHsgBrgFinalLoadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoHsgBrgFinalStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoHsgBrgFinalStrokeSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoHsgBrgLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoHsgBrgLoadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoHsgBrgMainStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoHsgBrgStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoHsgBrgStrokeSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoHsgKnockAbvalue)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MoHsgKnockABValue");

                entity.Property(e => e.MoHsgKnockDate)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MoHsgKnockFinalLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoHsgKnockFinalLoadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoHsgKnockFinalStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoHsgKnockFinalStrokeSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoHsgKnockLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoHsgKnockLoadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoHsgKnockMainStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoHsgKnockStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoHsgKnockStrokeSec)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoImgResult)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoMeasDate)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MoMg1codeAxis1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MoMG1CodeAxis1");

                entity.Property(e => e.MoMg1codeAxis2)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MoMG1CodeAxis2");

                entity.Property(e => e.MoMg1codeAxis3)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MoMG1CodeAxis3");

                entity.Property(e => e.MoMg1date)
                    .HasMaxLength(20)
                    .HasColumnName("MoMG1Date");

                entity.Property(e => e.MoMg1dec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MoMG1Dec");

                entity.Property(e => e.MoMg1fluxValue)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MoMG1FluxValue");

                entity.Property(e => e.MoMg1stator1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MoMG1Stator1");

                entity.Property(e => e.MoMg1stator2)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MoMG1Stator2");

                entity.Property(e => e.MoMg1stator3)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MoMG1Stator3");

                entity.Property(e => e.MoMg1torqAngleAxis1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MoMG1TorqAngleAxis1");

                entity.Property(e => e.MoMg1torqAngleAxis2)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MoMG1TorqAngleAxis2");

                entity.Property(e => e.MoMg1torqAngleAxis3)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MoMG1TorqAngleAxis3");

                entity.Property(e => e.MoMg1workTemp)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MoMG1WorkTemp");

                entity.Property(e => e.MoMg2codeAxis1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MoMG2CodeAxis1");

                entity.Property(e => e.MoMg2codeAxis2)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MoMG2CodeAxis2");

                entity.Property(e => e.MoMg2codeAxis3)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MoMG2CodeAxis3");

                entity.Property(e => e.MoMg2date)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MoMG2Date");

                entity.Property(e => e.MoMg2dec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MoMG2Dec");

                entity.Property(e => e.MoMg2fluxValue)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MoMG2FluxValue");

                entity.Property(e => e.MoMg2stator1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MoMG2Stator1");

                entity.Property(e => e.MoMg2stator2)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MoMG2Stator2");

                entity.Property(e => e.MoMg2stator3)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MoMG2Stator3");

                entity.Property(e => e.MoMg2torqAngleAxis1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MoMG2TorqAngleAxis1");

                entity.Property(e => e.MoMg2torqAngleAxis2)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MoMG2TorqAngleAxis2");

                entity.Property(e => e.MoMg2torqAngleAxis3)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MoMG2TorqAngleAxis3");

                entity.Property(e => e.MoMg2workTemp)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MoMG2WorkTemp");

                entity.Property(e => e.MoPokayokeDate1)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MoPokayokeDate10)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MoPokayokeDate11)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MoPokayokeDate12)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MoPokayokeDate13)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MoPokayokeDate14)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MoPokayokeDate2)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MoPokayokeDate3)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MoPokayokeDate4)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MoPokayokeDate5)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MoPokayokeDate6)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MoPokayokeDate7)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MoPokayokeDate8)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MoPokayokeDate9)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MoPokayokeDateBas)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MoReDate)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MoRrFigpdate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MoRrFIGPDate");

                entity.Property(e => e.MoRrbrgAbvalue)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MoRRBrgABValue");

                entity.Property(e => e.MoRrbrgDate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MoRRBrgDate");

                entity.Property(e => e.MoRrbrgFinalLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MoRRBrgFinalLoad");

                entity.Property(e => e.MoRrbrgFinalLoadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MoRRBrgFinalLoadSec");

                entity.Property(e => e.MoRrbrgFinalStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MoRRBrgFinalStroke");

                entity.Property(e => e.MoRrbrgFinalStrokeSec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MoRRBrgFinalStrokeSec");

                entity.Property(e => e.MoRrbrgLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MoRRBrgLoad");

                entity.Property(e => e.MoRrbrgLoadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MoRRBrgLoadSec");

                entity.Property(e => e.MoRrbrgMainStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MoRRBrgMainStroke");

                entity.Property(e => e.MoRrbrgStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MoRRBrgStroke");

                entity.Property(e => e.MoRrbrgStrokeSec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MoRRBrgStrokeSec");

                entity.Property(e => e.MoRrcoverDate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MoRRCoverDate");

                entity.Property(e => e.MoRrknockAbvalue)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MoRRKnockABValue");

                entity.Property(e => e.MoRrknockDate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MoRRKnockDate");

                entity.Property(e => e.MoRrknockFinalLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MoRRKnockFinalLoad");

                entity.Property(e => e.MoRrknockFinalLoadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MoRRKnockFinalLoadSec");

                entity.Property(e => e.MoRrknockFinalStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MoRRKnockFinalStroke");

                entity.Property(e => e.MoRrknockFinalStrokeSec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MoRRKnockFinalStrokeSec");

                entity.Property(e => e.MoRrknockLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MoRRKnockLoad");

                entity.Property(e => e.MoRrknockLoadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MoRRKnockLoadSec");

                entity.Property(e => e.MoRrknockMainStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MoRRKnockMainStroke");

                entity.Property(e => e.MoRrknockStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MoRRKnockStroke");

                entity.Property(e => e.MoRrknockStrokeSec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MoRRKnockStrokeSec");

                entity.Property(e => e.MoShipmentSerial)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MoStatorDate)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MoTorqAngleAxis1)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoTorqAngleAxis2)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoTorqAngleAxis3)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoTotal1Abvalue)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MoTotal1ABValue");

                entity.Property(e => e.MoTotal1AngleAxis1)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoTotal1AngleAxis10)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoTotal1AngleAxis11)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoTotal1AngleAxis2)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoTotal1AngleAxis3)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoTotal1AngleAxis4)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoTotal1AngleAxis5)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoTotal1AngleAxis6)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoTotal1AngleAxis7)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoTotal1AngleAxis8)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoTotal1AngleAxis9)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoTotal1Axis10Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoTotal1Axis11Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoTotal1Axis1Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoTotal1Axis2Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoTotal1Axis3Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoTotal1Axis4Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoTotal1Axis5Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoTotal1Axis6Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoTotal1Axis7Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoTotal1Axis8Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoTotal1Axis9Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoTotal2Date)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MoTotalDate1)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VwRrtable>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_RRTable");

                entity.Property(e => e.RrhsgBrgFinalLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RRHsgBrgFinalLoad");

                entity.Property(e => e.RrhsgBrgFinalLoadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RRHsgBrgFinalLoadSec");

                entity.Property(e => e.RrhsgBrgFinalStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RRHsgBrgFinalStroke");

                entity.Property(e => e.RrhsgBrgFinalStrokeSec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RRHsgBrgFinalStrokeSec");

                entity.Property(e => e.RrhsgBrgLoad)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RRHsgBrgLoad");

                entity.Property(e => e.RrhsgBrgLoadSec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RRHsgBrgLoadSec");

                entity.Property(e => e.RrhsgBrgMainStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RRHsgBrgMainStroke");

                entity.Property(e => e.RrhsgBrgMdate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RRHsgBrgMDate");

                entity.Property(e => e.RrhsgBrgStroke)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RRHsgBrgStroke");

                entity.Property(e => e.RrhsgBrgStrokeSec)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RRHsgBrgStrokeSec");

                entity.Property(e => e.RrpokayokeDate39)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RRPokayokeDate39");

                entity.Property(e => e.RrpokayokeDate40)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RRPokayokeDate40");

                entity.Property(e => e.RrpokayokeDate41)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RRPokayokeDate41");

                entity.Property(e => e.RrpokayokeDate42)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RRPokayokeDate42");

                entity.Property(e => e.RrpokayokeDate43)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RRPokayokeDate43");

                entity.Property(e => e.RrpokayokeDate44)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RRPokayokeDate44");

                entity.Property(e => e.RrpokayokeDate45)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RRPokayokeDate45");

                entity.Property(e => e.RrrejectTime)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RRRejectTime");

                entity.Property(e => e.RrrrcoverSerial)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RRRRCoverSerial");

                entity.Property(e => e.RrupenderDate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RRUpenderDate");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
