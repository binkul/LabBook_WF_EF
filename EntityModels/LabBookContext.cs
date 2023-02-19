using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LabBook_WF_EF.EntityModels
{
    public partial class LabBookContext : DbContext
    {
        public LabBookContext()
        {
        }

        public LabBookContext(DbContextOptions<LabBookContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CmbClpDataSheets> CmbClpDataSheets { get; set; }
        public virtual DbSet<CmbClpHp> CmbClpHp { get; set; }
        public virtual DbSet<CmbClpPictogram> CmbClpPictogram { get; set; }
        public virtual DbSet<CmbClpSignalWord> CmbClpSignalWord { get; set; }
        public virtual DbSet<CmbCompOperation> CmbCompOperation { get; set; }
        public virtual DbSet<CmbContrastClass> CmbContrastClass { get; set; }
        public virtual DbSet<CmbContrastType> CmbContrastType { get; set; }
        public virtual DbSet<CmbContrastYield> CmbContrastYield { get; set; }
        public virtual DbSet<CmbCurrency> CmbCurrency { get; set; }
        public virtual DbSet<CmbGlosClass> CmbGlosClass { get; set; }
        public virtual DbSet<CmbMaterialFunction> CmbMaterialFunction { get; set; }
        public virtual DbSet<CmbPaintPrice> CmbPaintPrice { get; set; }
        public virtual DbSet<CmbPaintType> CmbPaintType { get; set; }
        public virtual DbSet<CmbScrubClass> CmbScrubClass { get; set; }
        public virtual DbSet<CmbSemiProductType> CmbSemiProductType { get; set; }
        public virtual DbSet<CmbUnit> CmbUnit { get; set; }
        public virtual DbSet<CmbVoc> CmbVoc { get; set; }
        public virtual DbSet<ExpAshBurn> ExpAshBurn { get; set; }
        public virtual DbSet<ExpCommon> ExpCommon { get; set; }
        public virtual DbSet<ExpComposition> ExpComposition { get; set; }
        public virtual DbSet<ExpCompositionArchive> ExpCompositionArchive { get; set; }
        public virtual DbSet<ExpCompositionData> ExpCompositionData { get; set; }
        public virtual DbSet<ExpCompositionHistory> ExpCompositionHistory { get; set; }
        public virtual DbSet<ExpContrast> ExpContrast { get; set; }
        public virtual DbSet<ExpCycle> ExpCycle { get; set; }
        public virtual DbSet<ExpGloss> ExpGloss { get; set; }
        public virtual DbSet<ExpLabBook> ExpLabBook { get; set; }
        public virtual DbSet<ExpSpectro> ExpSpectro { get; set; }
        public virtual DbSet<ExpViscosity> ExpViscosity { get; set; }
        public virtual DbSet<Material> Material { get; set; }
        public virtual DbSet<MaterialCas> MaterialCas { get; set; }
        public virtual DbSet<MaterialClp> MaterialClp { get; set; }
        public virtual DbSet<MaterialComposition> MaterialComposition { get; set; }
        public virtual DbSet<MaterialGhs> MaterialGhs { get; set; }
        public virtual DbSet<MaterialQualityControl> MaterialQualityControl { get; set; }
        public virtual DbSet<MaterialQualityControlData> MaterialQualityControlData { get; set; }
        public virtual DbSet<MaterialQualityControlDefaultValues> MaterialQualityControlDefaultValues { get; set; }
        public virtual DbSet<MaterialQualityControlFields> MaterialQualityControlFields { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductBrand> ProductBrand { get; set; }
        public virtual DbSet<ProductBuyer> ProductBuyer { get; set; }
        public virtual DbSet<QualityControl> QualityControl { get; set; }
        public virtual DbSet<QualityControlData> QualityControlData { get; set; }
        public virtual DbSet<QualityControlFields> QualityControlFields { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConfigData.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CmbClpDataSheets>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('pusty')");

                entity.Property(e => e.Remarks)
                    .HasColumnName("remarks")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<CmbClpHp>(entity =>
            {
                entity.ToTable("CmbClpHP");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Class)
                    .IsRequired()
                    .HasColumnName("class")
                    .HasMaxLength(50);

                entity.Property(e => e.Clp)
                    .IsRequired()
                    .HasColumnName("clp")
                    .HasMaxLength(50);

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(500);

                entity.Property(e => e.GhsId)
                    .HasColumnName("ghs_id")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsH)
                    .IsRequired()
                    .HasColumnName("is_h")
                    .HasDefaultValueSql("('true')");

                entity.Property(e => e.Ordering).HasColumnName("ordering");

                entity.Property(e => e.SignalId)
                    .HasColumnName("signal_id")
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<CmbClpPictogram>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(50);

                entity.Property(e => e.Ghs).HasColumnName("ghs");

                entity.Property(e => e.PngFile)
                    .IsRequired()
                    .HasColumnName("png_file")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CmbClpSignalWord>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CmbCompOperation>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CmbContrastClass>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CmbContrastType>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<CmbContrastYield>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CmbCurrency>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(20);

                entity.Property(e => e.Rate).HasColumnName("rate");
            });

            modelBuilder.Entity<CmbGlosClass>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CmbMaterialFunction>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CmbPaintPrice>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CmbPaintType>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CmbScrubClass>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<CmbSemiProductType>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<CmbUnit>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CmbVoc>(entity =>
            {
                entity.ToTable("CmbVOC");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Voc)
                    .IsRequired()
                    .HasColumnName("VOC")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ExpAshBurn>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Ash450).HasColumnName("ash_450");

                entity.Property(e => e.Ash900).HasColumnName("ash_900");

                entity.Property(e => e.CalciumCarbonate).HasColumnName("calcium_carbonate");

                entity.Property(e => e.Crucible1).HasColumnName("crucible_1");

                entity.Property(e => e.Crucible1051).HasColumnName("crucible_105_1");

                entity.Property(e => e.Crucible1052).HasColumnName("crucible_105_2");

                entity.Property(e => e.Crucible1053).HasColumnName("crucible_105_3");

                entity.Property(e => e.Crucible2).HasColumnName("crucible_2");

                entity.Property(e => e.Crucible3).HasColumnName("crucible_3");

                entity.Property(e => e.Crucible4051).HasColumnName("crucible_405_1");

                entity.Property(e => e.Crucible4052).HasColumnName("crucible_405_2");

                entity.Property(e => e.Crucible4053).HasColumnName("crucible_405_3");

                entity.Property(e => e.Crucible9001).HasColumnName("crucible_900_1");

                entity.Property(e => e.Crucible9002).HasColumnName("crucible_900_2");

                entity.Property(e => e.Crucible9003).HasColumnName("crucible_900_3");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateUpdate)
                    .HasColumnName("date_update")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LabbookId).HasColumnName("labbook_id");

                entity.Property(e => e.Organic).HasColumnName("organic");

                entity.Property(e => e.Others).HasColumnName("others");

                entity.Property(e => e.Paint1).HasColumnName("paint_1");

                entity.Property(e => e.Paint2).HasColumnName("paint_2");

                entity.Property(e => e.Paint3).HasColumnName("paint_3");

                entity.Property(e => e.Solid).HasColumnName("solid");

                entity.Property(e => e.TitaniumDioxide).HasColumnName("titanium_dioxide");

                entity.Property(e => e.VocContent)
                    .HasColumnName("voc_content")
                    .HasMaxLength(20);

                entity.Property(e => e.VocId)
                    .HasColumnName("voc_id")
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<ExpCommon>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AdhesionIso2409)
                    .HasColumnName("adhesion_ISO2409")
                    .HasMaxLength(1000);

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateUpdate)
                    .HasColumnName("date_update")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DryingIso91171)
                    .HasColumnName("drying_ISO9117_1")
                    .HasMaxLength(50);

                entity.Property(e => e.DryingIso91173)
                    .HasColumnName("drying_ISO9117_3")
                    .HasMaxLength(50);

                entity.Property(e => e.FlashRust)
                    .HasColumnName("flash_rust")
                    .HasMaxLength(50);

                entity.Property(e => e.FlowLimit)
                    .HasColumnName("flow_limit")
                    .HasMaxLength(50);

                entity.Property(e => e.Hardness)
                    .HasColumnName("hardness")
                    .HasMaxLength(50);

                entity.Property(e => e.KoenigIso2409)
                    .HasColumnName("koenig_ISO2409")
                    .HasMaxLength(50);

                entity.Property(e => e.LabbookId)
                    .HasColumnName("labbook_id")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Other)
                    .HasColumnName("other")
                    .HasMaxLength(2000);

                entity.Property(e => e.PersonIso2409)
                    .HasColumnName("person_ISO2409")
                    .HasMaxLength(50);

                entity.Property(e => e.Runoff)
                    .HasColumnName("runoff")
                    .HasMaxLength(50);

                entity.Property(e => e.SaltSprayIso9227)
                    .HasColumnName("salt_spray_ISO9227")
                    .HasMaxLength(500);

                entity.Property(e => e.SchockIso6272)
                    .HasColumnName("schock_ISO6272")
                    .HasMaxLength(50);

                entity.Property(e => e.ScratchIso62721)
                    .HasColumnName("scratch_ISO6272_1")
                    .HasMaxLength(50);

                entity.Property(e => e.ScrubBrush)
                    .HasColumnName("scrub_brush")
                    .HasMaxLength(50);

                entity.Property(e => e.ScrubIso11998)
                    .HasColumnName("scrub_ISO11998")
                    .HasMaxLength(50);

                entity.Property(e => e.ScrubIso11998Class)
                    .HasColumnName("scrub_ISO11998_class")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.StainIso28124)
                    .HasColumnName("stain_ISO2812_4")
                    .HasMaxLength(1000);

                entity.Property(e => e.UvTest)
                    .HasColumnName("UV_test")
                    .HasMaxLength(500);

                entity.Property(e => e.WaterIso28122)
                    .HasColumnName("water_ISO2812_2")
                    .HasMaxLength(50);

                entity.Property(e => e.YellowingIso7724)
                    .HasColumnName("yellowing_ISO7724")
                    .HasMaxLength(50);

                entity.Property(e => e.Yield)
                    .HasColumnName("yield")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ExpComposition>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(10, 4)");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasMaxLength(200);

                entity.Property(e => e.Component)
                    .IsRequired()
                    .HasColumnName("component")
                    .HasMaxLength(200);

                entity.Property(e => e.IsIntermediate)
                    .IsRequired()
                    .HasColumnName("is_intermediate")
                    .HasDefaultValueSql("('false')");

                entity.Property(e => e.LabbookId).HasColumnName("labbook_id");

                entity.Property(e => e.Operation)
                    .HasColumnName("operation")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Ordering).HasColumnName("ordering");
            });

            modelBuilder.Entity<ExpCompositionArchive>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(10, 4)");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasMaxLength(200);

                entity.Property(e => e.Component)
                    .IsRequired()
                    .HasColumnName("component")
                    .HasMaxLength(300);

                entity.Property(e => e.IsIntermediate)
                    .IsRequired()
                    .HasColumnName("is_intermediate")
                    .HasDefaultValueSql("('false')");

                entity.Property(e => e.LabbookId).HasColumnName("labbook_id");

                entity.Property(e => e.Operation).HasColumnName("operation");

                entity.Property(e => e.Ordering).HasColumnName("ordering");

                entity.Property(e => e.Version).HasColumnName("version");
            });

            modelBuilder.Entity<ExpCompositionData>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.ChangeDate)
                    .HasColumnName("change_date")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasMaxLength(300);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.LabbookId).HasColumnName("labbook_id");

                entity.Property(e => e.LoginId)
                    .HasColumnName("login_id")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Mass)
                    .HasColumnName("mass")
                    .HasColumnType("decimal(12, 4)")
                    .HasDefaultValueSql("((1000))");

                entity.Property(e => e.Version)
                    .HasColumnName("version")
                    .HasDefaultValueSql("((-1))");
            });

            modelBuilder.Entity<ExpCompositionHistory>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ChangeDate)
                    .HasColumnName("change_date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasMaxLength(400);

                entity.Property(e => e.LabbookId).HasColumnName("labbook_id");

                entity.Property(e => e.LoginId)
                    .HasColumnName("login_id")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Mass)
                    .HasColumnName("mass")
                    .HasColumnType("decimal(12, 4)")
                    .HasDefaultValueSql("((1000))");

                entity.Property(e => e.Version)
                    .HasColumnName("version")
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<ExpContrast>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasMaxLength(2000);

                entity.Property(e => e.Contrast100)
                    .HasColumnName("contrast_100")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Contrast150)
                    .HasColumnName("contrast_150")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Contrast240)
                    .HasColumnName("contrast_240")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Contrast75)
                    .HasColumnName("contrast_75")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.ContrastClass)
                    .HasColumnName("contrast_class")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ContrastYield)
                    .HasColumnName("contrast_yield")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateUpdate)
                    .HasColumnName("date_update")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LabbookId).HasColumnName("labbook_id");

                entity.Property(e => e.OtherAContrast)
                    .HasColumnName("other_a_contrast")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.OtherAType)
                    .HasColumnName("other_a_type")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.OtherBContrast)
                    .HasColumnName("other_b_contrast")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.OtherBType)
                    .HasColumnName("other_b_type")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Sp100)
                    .HasColumnName("sp_100")
                    .HasColumnType("decimal(7, 3)");

                entity.Property(e => e.Sp150)
                    .HasColumnName("sp_150")
                    .HasColumnType("decimal(7, 3)");

                entity.Property(e => e.Sp240)
                    .HasColumnName("sp_240")
                    .HasColumnType("decimal(7, 3)");

                entity.Property(e => e.Sp75)
                    .HasColumnName("sp_75")
                    .HasColumnType("decimal(7, 3)");

                entity.Property(e => e.Tw100)
                    .HasColumnName("tw_100")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.Tw150)
                    .HasColumnName("tw_150")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.Tw240)
                    .HasColumnName("tw_240")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.Tw75)
                    .HasColumnName("tw_75")
                    .HasColumnType("decimal(6, 4)");
            });

            modelBuilder.Entity<ExpCycle>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<ExpGloss>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasMaxLength(2000);

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateUpdate)
                    .HasColumnName("date_update")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Gloss20)
                    .HasColumnName("gloss_20")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Gloss60)
                    .HasColumnName("gloss_60")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Gloss85)
                    .HasColumnName("gloss_85")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.GlossClass)
                    .HasColumnName("gloss_class")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LabbookId).HasColumnName("labbook_id");
            });

            modelBuilder.Entity<ExpLabBook>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("Numer D doświadczenia");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CycleId)
                    .HasColumnName("cycle_id")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasColumnName("deleted")
                    .HasDefaultValueSql("('false')");

                entity.Property(e => e.Density)
                    .HasColumnName("density")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.Modified)
                    .HasColumnName("modified")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Observation)
                    .HasColumnName("observation")
                    .HasMaxLength(4000);

                entity.Property(e => e.Remarks)
                    .HasColumnName("remarks")
                    .HasMaxLength(4000);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(200)
                    .HasDefaultValueSql("('Pusty')");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<ExpSpectro>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AM)
                    .HasColumnName("a_m")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.AS)
                    .HasColumnName("a_s")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.BM)
                    .HasColumnName("b_m")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.BS)
                    .HasColumnName("b_s")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasMaxLength(2000);

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateUpdate)
                    .HasColumnName("date_update")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LM)
                    .HasColumnName("L_m")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.LS)
                    .HasColumnName("L_s")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.LabbookId)
                    .HasColumnName("labbook_id")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.WiM)
                    .HasColumnName("WI_m")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.WiS)
                    .HasColumnName("WI_s")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.X).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Y).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.YiM)
                    .HasColumnName("YI_m")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.YiS)
                    .HasColumnName("YI_s")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Z).HasColumnType("decimal(6, 3)");
            });

            modelBuilder.Entity<ExpViscosity>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Brook1)
                    .HasColumnName("brook_1")
                    .HasColumnType("decimal(12, 2)");

                entity.Property(e => e.Brook10)
                    .HasColumnName("brook_10")
                    .HasColumnType("decimal(12, 2)");

                entity.Property(e => e.Brook100)
                    .HasColumnName("brook_100")
                    .HasColumnType("decimal(12, 2)");

                entity.Property(e => e.Brook20)
                    .HasColumnName("brook_20")
                    .HasColumnType("decimal(12, 2)");

                entity.Property(e => e.Brook30)
                    .HasColumnName("brook_30")
                    .HasColumnType("decimal(12, 2)");

                entity.Property(e => e.Brook40)
                    .HasColumnName("brook_40")
                    .HasColumnType("decimal(12, 2)");

                entity.Property(e => e.Brook5)
                    .HasColumnName("brook_5")
                    .HasColumnType("decimal(12, 2)");

                entity.Property(e => e.Brook50)
                    .HasColumnName("brook_50")
                    .HasColumnType("decimal(12, 2)");

                entity.Property(e => e.Brook60)
                    .HasColumnName("brook_60")
                    .HasColumnType("decimal(12, 2)");

                entity.Property(e => e.Brook70)
                    .HasColumnName("brook_70")
                    .HasColumnType("decimal(12, 2)");

                entity.Property(e => e.Brook80)
                    .HasColumnName("brook_80")
                    .HasColumnType("decimal(12, 2)");

                entity.Property(e => e.Brook90)
                    .HasColumnName("brook_90")
                    .HasColumnType("decimal(12, 2)");

                entity.Property(e => e.BrookComment)
                    .HasColumnName("brook_comment")
                    .HasMaxLength(200);

                entity.Property(e => e.BrookDisc)
                    .HasColumnName("brook_disc")
                    .HasMaxLength(50);

                entity.Property(e => e.BrookXDisc)
                    .HasColumnName("brook_x_disc")
                    .HasMaxLength(50);

                entity.Property(e => e.BrookXRpm)
                    .HasColumnName("brook_x_rpm")
                    .HasMaxLength(50);

                entity.Property(e => e.BrookXVis)
                    .HasColumnName("brook_x_vis")
                    .HasColumnType("decimal(12, 2)");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateUpdate)
                    .HasColumnName("date_update")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Ici)
                    .HasColumnName("ici")
                    .HasColumnType("decimal(12, 2)");

                entity.Property(e => e.IciComment)
                    .HasColumnName("ici_comment")
                    .HasMaxLength(50);

                entity.Property(e => e.IciDisc)
                    .HasColumnName("ici_disc")
                    .HasMaxLength(50);

                entity.Property(e => e.Krebs)
                    .HasColumnName("krebs")
                    .HasColumnType("decimal(12, 2)");

                entity.Property(e => e.KrebsComment)
                    .HasColumnName("krebs_comment")
                    .HasMaxLength(50);

                entity.Property(e => e.LabbookId).HasColumnName("labbook_id");

                entity.Property(e => e.PH)
                    .HasColumnName("pH")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Temp)
                    .HasColumnName("temp")
                    .HasMaxLength(50);

                entity.Property(e => e.VisType)
                    .IsRequired()
                    .HasColumnName("vis_type")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'brookfield')");
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Ash450).HasColumnName("ash_450");

                entity.Property(e => e.ClpMsdsId)
                    .HasColumnName("clp_msds_id")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ClpSignalWordId)
                    .HasColumnName("clp_signal_word_id")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CurrencyId)
                    .HasColumnName("currency_id")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateUpdate)
                    .HasColumnName("date_update")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Density).HasColumnName("density");

                entity.Property(e => e.FunctionId)
                    .HasColumnName("function_id")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IntermediateNrD)
                    .HasColumnName("intermediate_nrD")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("('false')");

                entity.Property(e => e.IsDanger)
                    .IsRequired()
                    .HasColumnName("is_danger")
                    .HasDefaultValueSql("('false')");

                entity.Property(e => e.IsIntermediate)
                    .IsRequired()
                    .HasColumnName("is_intermediate")
                    .HasDefaultValueSql("('false')");

                entity.Property(e => e.IsObserved)
                    .IsRequired()
                    .HasColumnName("is_observed")
                    .HasDefaultValueSql("('false')");

                entity.Property(e => e.IsProduction)
                    .IsRequired()
                    .HasColumnName("is_production")
                    .HasDefaultValueSql("('false')");

                entity.Property(e => e.LoginId)
                    .HasColumnName("login_id")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("((200))");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(8, 4)");

                entity.Property(e => e.Remarks)
                    .HasColumnName("remarks")
                    .HasMaxLength(2000);

                entity.Property(e => e.Solids).HasColumnName("solids");

                entity.Property(e => e.UnitId)
                    .HasColumnName("unit_id")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Voc)
                    .HasColumnName("VOC")
                    .HasColumnType("decimal(5, 2)");
            });

            modelBuilder.Entity<MaterialCas>(entity =>
            {
                entity.ToTable("MaterialCAS");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cas)
                    .HasColumnName("CAS")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'-')");

                entity.Property(e => e.ClpSignalWordId)
                    .HasColumnName("clp_signal_word_id")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasMaxLength(200);

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(200);

                entity.Property(e => e.Shortcut)
                    .IsRequired()
                    .HasColumnName("shortcut")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'brak')");

                entity.Property(e => e.We)
                    .HasColumnName("WE")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'-')");
            });

            modelBuilder.Entity<MaterialClp>(entity =>
            {
                entity.ToTable("MaterialCLP");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClpId).HasColumnName("clp_id");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MaterialId).HasColumnName("material_id");
            });

            modelBuilder.Entity<MaterialComposition>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(8, 4)");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasMaxLength(100);

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MaterialCasId).HasColumnName("materialCas_id");

                entity.Property(e => e.MaterialId).HasColumnName("material_id");
            });

            modelBuilder.Entity<MaterialGhs>(entity =>
            {
                entity.ToTable("MaterialGHS");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.GhsId).HasColumnName("ghs_id");

                entity.Property(e => e.MaterialId).HasColumnName("material_id");
            });

            modelBuilder.Entity<MaterialQualityControl>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Accepted).HasColumnName("accepted");

                entity.Property(e => e.DeliveryDate)
                    .HasColumnName("delivery_date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeliveryNumber)
                    .HasColumnName("delivery_number")
                    .HasMaxLength(50);

                entity.Property(e => e.LoginId)
                    .HasColumnName("login_id")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.MaterialId)
                    .HasColumnName("material_id")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.QualityNumber)
                    .HasColumnName("quality_number")
                    .HasMaxLength(50);

                entity.Property(e => e.Remarks)
                    .HasColumnName("remarks")
                    .HasMaxLength(1000);
            });

            modelBuilder.Entity<MaterialQualityControlData>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.A).HasColumnName("a");

                entity.Property(e => e.Appearance)
                    .HasColumnName("appearance")
                    .HasMaxLength(200);

                entity.Property(e => e.B).HasColumnName("b");

                entity.Property(e => e.Biology).HasColumnName("biology");

                entity.Property(e => e.ControlId).HasColumnName("control_id");

                entity.Property(e => e.Density).HasColumnName("density");

                entity.Property(e => e.Inclusion)
                    .HasColumnName("inclusion")
                    .HasMaxLength(50);

                entity.Property(e => e.PH).HasColumnName("pH");

                entity.Property(e => e.Sieve)
                    .HasColumnName("sieve")
                    .HasMaxLength(50);

                entity.Property(e => e.Solids).HasColumnName("solids");

                entity.Property(e => e.Temperature)
                    .HasColumnName("temperature")
                    .HasMaxLength(50);

                entity.Property(e => e.ViscosityA).HasColumnName("viscosity_a");

                entity.Property(e => e.ViscosityADisc)
                    .HasColumnName("viscosity_a_disc")
                    .HasMaxLength(50);

                entity.Property(e => e.ViscosityASpeed)
                    .HasColumnName("viscosity_a_speed")
                    .HasMaxLength(50);

                entity.Property(e => e.ViscosityB).HasColumnName("viscosity_b");

                entity.Property(e => e.ViscosityBDisc)
                    .HasColumnName("viscosity_b_disc")
                    .HasMaxLength(50);

                entity.Property(e => e.ViscosityBSpeed)
                    .HasColumnName("viscosity_b_speed")
                    .HasMaxLength(50);

                entity.Property(e => e.ViscosityC).HasColumnName("viscosity_c");

                entity.Property(e => e.ViscosityCDisc)
                    .HasColumnName("viscosity_c_disc")
                    .HasMaxLength(50);

                entity.Property(e => e.ViscosityCSpeed)
                    .HasColumnName("viscosity_c_speed")
                    .HasMaxLength(50);

                entity.Property(e => e.Wi).HasColumnName("WI");

                entity.Property(e => e.Yi).HasColumnName("YI");
            });

            modelBuilder.Entity<MaterialQualityControlDefaultValues>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DefaultValue)
                    .HasColumnName("default_value")
                    .HasMaxLength(1000);

                entity.Property(e => e.MaterialId).HasColumnName("material_id");
            });

            modelBuilder.Entity<MaterialQualityControlFields>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ActiveFields)
                    .HasColumnName("active_fields")
                    .HasMaxLength(1000);

                entity.Property(e => e.MaterialId).HasColumnName("material_id");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(2000);

                entity.Property(e => e.HpIndex)
                    .HasColumnName("hp_index")
                    .HasMaxLength(50);

                entity.Property(e => e.IsArchive)
                    .IsRequired()
                    .HasColumnName("is_archive")
                    .HasDefaultValueSql("('false')");

                entity.Property(e => e.IsDanger)
                    .IsRequired()
                    .HasColumnName("is_danger")
                    .HasDefaultValueSql("('false')");

                entity.Property(e => e.IsExperimetPhase)
                    .IsRequired()
                    .HasColumnName("is_experimetPhase")
                    .HasDefaultValueSql("('false')");

                entity.Property(e => e.LabbookId).HasColumnName("labbook_id");

                entity.Property(e => e.LoginId)
                    .HasColumnName("login_id")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(500);

                entity.Property(e => e.ProductGlossId)
                    .HasColumnName("product_gloss_id")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ProductPriceId)
                    .HasColumnName("product_price_id")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ProductTypeId)
                    .HasColumnName("product_type_id")
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<ProductBrand>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BuyerId)
                    .HasColumnName("buyer_id")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("('false')");

                entity.Property(e => e.LoginId)
                    .HasColumnName("login_id")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.MsdsId)
                    .HasColumnName("msds_id")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('Brak')");

                entity.Property(e => e.ProductId)
                    .HasColumnName("product_id")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Varanty)
                    .HasColumnName("varanty")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ProductBuyer>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<QualityControl>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ActiveFields)
                    .HasColumnName("active_fields")
                    .HasMaxLength(1000);

                entity.Property(e => e.LabbookId).HasColumnName("labbook_id");

                entity.Property(e => e.LoginId)
                    .HasColumnName("login_id")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Number).HasColumnName("number");

                entity.Property(e => e.ProductIndex)
                    .HasColumnName("product_index")
                    .HasMaxLength(20);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasColumnName("product_name")
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('Pusty')");

                entity.Property(e => e.ProductTypeId)
                    .HasColumnName("product_type_id")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ProductionDate)
                    .HasColumnName("production_date")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Remarks)
                    .HasColumnName("remarks")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<QualityControlData>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AM).HasColumnName("a_m");

                entity.Property(e => e.AS).HasColumnName("a_s");

                entity.Property(e => e.Adhesion)
                    .HasColumnName("adhesion")
                    .HasMaxLength(200);

                entity.Property(e => e.BM).HasColumnName("b_m");

                entity.Property(e => e.BS).HasColumnName("b_s");

                entity.Property(e => e.Comments)
                    .HasColumnName("comments")
                    .HasMaxLength(500);

                entity.Property(e => e.Contrast100).HasColumnName("contrast_100");

                entity.Property(e => e.Contrast125).HasColumnName("contrast_125");

                entity.Property(e => e.Contrast150).HasColumnName("contrast_150");

                entity.Property(e => e.Contrast200).HasColumnName("contrast_200");

                entity.Property(e => e.Contrast240).HasColumnName("contrast_240");

                entity.Property(e => e.Contrast250).HasColumnName("contrast_250");

                entity.Property(e => e.Contrast300).HasColumnName("contrast_300");

                entity.Property(e => e.Contrast75).HasColumnName("contrast_75");

                entity.Property(e => e.ContrastClass)
                    .HasColumnName("contrast_class")
                    .HasMaxLength(20);

                entity.Property(e => e.ContrastRemarks)
                    .HasColumnName("contrast_remarks")
                    .HasMaxLength(200);

                entity.Property(e => e.ContrastWire100).HasColumnName("contrast_wire_100");

                entity.Property(e => e.ContrastWire125).HasColumnName("contrast_wire_125");

                entity.Property(e => e.ContrastWire150).HasColumnName("contrast_wire_150");

                entity.Property(e => e.ContrastWire200).HasColumnName("contrast_wire_200");

                entity.Property(e => e.ContrastWire250).HasColumnName("contrast_wire_250");

                entity.Property(e => e.De).HasColumnName("DE");

                entity.Property(e => e.Density).HasColumnName("density");

                entity.Property(e => e.Disc)
                    .HasColumnName("disc")
                    .HasMaxLength(20);

                entity.Property(e => e.DryingI)
                    .HasColumnName("drying_I")
                    .HasMaxLength(20);

                entity.Property(e => e.DryingIi)
                    .HasColumnName("drying_II")
                    .HasMaxLength(20);

                entity.Property(e => e.DryingIii)
                    .HasColumnName("drying_III")
                    .HasMaxLength(20);

                entity.Property(e => e.DryingIv)
                    .HasColumnName("drying_IV")
                    .HasMaxLength(20);

                entity.Property(e => e.DryingRemarks)
                    .HasColumnName("drying_remarks")
                    .HasMaxLength(200);

                entity.Property(e => e.DryingV)
                    .HasColumnName("drying_V")
                    .HasMaxLength(20);

                entity.Property(e => e.DryingVi)
                    .HasColumnName("drying_VI")
                    .HasMaxLength(20);

                entity.Property(e => e.DryingVii)
                    .HasColumnName("drying_VII")
                    .HasMaxLength(20);

                entity.Property(e => e.F450).HasColumnName("f_450");

                entity.Property(e => e.F900).HasColumnName("f_900");

                entity.Property(e => e.FLime).HasColumnName("f_lime");

                entity.Property(e => e.FOrganic).HasColumnName("f_organic");

                entity.Property(e => e.FRemarks)
                    .HasColumnName("f_remarks")
                    .HasMaxLength(200);

                entity.Property(e => e.FSolids).HasColumnName("f_solids");

                entity.Property(e => e.FTalcum).HasColumnName("f_talcum");

                entity.Property(e => e.FTitanium).HasColumnName("f_titanium");

                entity.Property(e => e.Flow)
                    .HasColumnName("flow")
                    .HasMaxLength(50);

                entity.Property(e => e.Gloss20).HasColumnName("gloss_20");

                entity.Property(e => e.Gloss60).HasColumnName("gloss_60");

                entity.Property(e => e.Gloss85).HasColumnName("gloss_85");

                entity.Property(e => e.GlossRemarks)
                    .HasColumnName("gloss_remarks")
                    .HasMaxLength(200);

                entity.Property(e => e.LM).HasColumnName("L_m");

                entity.Property(e => e.LS).HasColumnName("L_s");

                entity.Property(e => e.MeasureDate)
                    .HasColumnName("measure_date")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PH).HasColumnName("pH");

                entity.Property(e => e.QualityId).HasColumnName("quality_id");

                entity.Property(e => e.Runoff)
                    .HasColumnName("runoff")
                    .HasMaxLength(50);

                entity.Property(e => e.ScrubingBrush)
                    .HasColumnName("scrubing_brush")
                    .HasMaxLength(50);

                entity.Property(e => e.ScrubingRemarks)
                    .HasColumnName("scrubing_remarks")
                    .HasMaxLength(200);

                entity.Property(e => e.ScrubingSponge)
                    .HasColumnName("scrubing_sponge")
                    .HasMaxLength(50);

                entity.Property(e => e.SpectroRemarks)
                    .HasColumnName("spectro_remarks")
                    .HasMaxLength(200);

                entity.Property(e => e.Temp)
                    .HasColumnName("temp")
                    .HasMaxLength(10);

                entity.Property(e => e.Vis1).HasColumnName("vis_1");

                entity.Property(e => e.Vis10).HasColumnName("vis_10");

                entity.Property(e => e.Vis100).HasColumnName("vis_100");

                entity.Property(e => e.Vis15).HasColumnName("vis_15");

                entity.Property(e => e.Vis2).HasColumnName("vis_2");

                entity.Property(e => e.Vis20).HasColumnName("vis_20");

                entity.Property(e => e.Vis25).HasColumnName("vis_25");

                entity.Property(e => e.Vis30).HasColumnName("vis_30");

                entity.Property(e => e.Vis35).HasColumnName("vis_35");

                entity.Property(e => e.Vis40).HasColumnName("vis_40");

                entity.Property(e => e.Vis45).HasColumnName("vis_45");

                entity.Property(e => e.Vis5).HasColumnName("vis_5");

                entity.Property(e => e.Vis50).HasColumnName("vis_50");

                entity.Property(e => e.Vis55).HasColumnName("vis_55");

                entity.Property(e => e.Vis60).HasColumnName("vis_60");

                entity.Property(e => e.Vis65).HasColumnName("vis_65");

                entity.Property(e => e.Vis70).HasColumnName("vis_70");

                entity.Property(e => e.Vis75).HasColumnName("vis_75");

                entity.Property(e => e.Vis80).HasColumnName("vis_80");

                entity.Property(e => e.Vis85).HasColumnName("vis_85");

                entity.Property(e => e.Vis90).HasColumnName("vis_90");

                entity.Property(e => e.Vis95).HasColumnName("vis_95");

                entity.Property(e => e.ViscRemarks)
                    .HasColumnName("visc_remarks")
                    .HasMaxLength(200);

                entity.Property(e => e.Voc)
                    .HasColumnName("VOC")
                    .HasMaxLength(50);

                entity.Property(e => e.WiM).HasColumnName("WI_m");

                entity.Property(e => e.WiS).HasColumnName("WI_s");

                entity.Property(e => e.YiM).HasColumnName("YI_m");

                entity.Property(e => e.YiS).HasColumnName("YI_s");
            });

            modelBuilder.Entity<QualityControlFields>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ActiveFields)
                    .IsRequired()
                    .HasColumnName("active_fields")
                    .HasMaxLength(1000)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LabbookId).HasColumnName("labbook_id");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasColumnName("active")
                    .HasDefaultValueSql("('true')");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EMail)
                    .IsRequired()
                    .HasColumnName("e_mail")
                    .HasMaxLength(50);

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasColumnName("identifier")
                    .HasMaxLength(10)
                    .HasComment("first letter of name and surname eg. JB");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnName("login")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50);

                entity.Property(e => e.Permission)
                    .IsRequired()
                    .HasColumnName("permission")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('user')");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("surname")
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
