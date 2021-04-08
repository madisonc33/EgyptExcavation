using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EgyptExcavation.Models
{
    public partial class egyptexcavationContext : DbContext
    {
        public egyptexcavationContext()
        {
        }

        public egyptexcavationContext(DbContextOptions<egyptexcavationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AgeCode> AgeCode { get; set; }
        public virtual DbSet<Body> Body { get; set; }
        public virtual DbSet<Bone> Bone { get; set; }
        public virtual DbSet<Burial> Burial { get; set; }
        public virtual DbSet<BurialAdultChildCode> BurialAdultChildCode { get; set; }
        public virtual DbSet<BurialWrappingCode> BurialWrappingCode { get; set; }
        public virtual DbSet<Cranial> Cranial { get; set; }
        public virtual DbSet<Excavation> Excavation { get; set; }
        public virtual DbSet<FaceBundleCode> FaceBundleCode { get; set; }
        public virtual DbSet<Files> Files { get; set; }
        public virtual DbSet<GenderCodeSingle> GenderCodeSingle { get; set; }
        public virtual DbSet<HairColorCode> HairColorCode { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<PhysicalOrientation> PhysicalOrientation { get; set; }
        public virtual DbSet<Sample> Sample { get; set; }
        public virtual DbSet<Storage> Storage { get; set; }
        public virtual DbSet<Tooth> Tooth { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=database-1.ck5snpiu0zac.us-east-1.rds.amazonaws.com,1433;Initial Catalog=egyptexcavation;User Id=admin;Password=intex2DBAdmin;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AgeCode>(entity =>
            {
                entity.HasKey(e => e.AgeKey)
                    .HasName("PK__AgeCode__28D1FD276F4DBAB6");

                entity.Property(e => e.AgeKey)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Body>(entity =>
            {
                entity.Property(e => e.BodyId)
                    .HasColumnName("BodyID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AdultChildKey)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.AgeAtDeath)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.AgeKey)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.AgeMethod)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.BoneId).HasColumnName("BoneID");

                entity.Property(e => e.BurialPreservation)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CranialId).HasColumnName("CranialID");

                entity.Property(e => e.DescriptionOfTaken)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GenderKey)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.GenderMethod)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.HairColorKey)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.PreservationIndex)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.SequenceDna)
                    .HasColumnName("SequenceDNA")
                    .IsUnicode(false);

                entity.Property(e => e.WrappingKey)
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Bone>(entity =>
            {
                entity.Property(e => e.BoneId)
                    .HasColumnName("BoneID")
                    .ValueGeneratedNever();

                entity.Property(e => e.BasilarSuture)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EpiphysealUnion)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.OsteologyNotes)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Osteophytosis)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PubicSymphysis)
                    .HasMaxLength(5)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Burial>(entity =>
            {
                entity.Property(e => e.BurialId)
                    .HasColumnName("BurialID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ArtifactsDescription)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.BiologicalInitials)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BiologicalNotes)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.BodyId).HasColumnName("BodyID");

                entity.Property(e => e.BurialSituation)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Cluster)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ExcavationId).HasColumnName("ExcavationID");

                entity.Property(e => e.FaceBundleKey)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Goods)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.LocId).HasColumnName("LocID");

                entity.Property(e => e.OrientationId).HasColumnName("OrientationID");
            });

            modelBuilder.Entity<BurialAdultChildCode>(entity =>
            {
                entity.HasKey(e => e.AdultChildKey)
                    .HasName("PK__BurialAd__CBD31B9A17525ABA");

                entity.Property(e => e.AdultChildKey)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BurialWrappingCode>(entity =>
            {
                entity.HasKey(e => e.WrappingKey)
                    .HasName("PK__BurialWr__60655CBA5F59AC9A");

                entity.Property(e => e.WrappingKey)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cranial>(entity =>
            {
                entity.Property(e => e.CranialId)
                    .HasColumnName("CranialID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CranialSuture)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.GefunctionTotal).HasColumnName("GEFunctionTotal");

                entity.Property(e => e.GenderKey)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MonthOnSkull)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.OsteologyUnknownComment)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.PoroticHyperostosisLoc)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Tmjoa).HasColumnName("TMJOA");
            });

            modelBuilder.Entity<Excavation>(entity =>
            {
                entity.Property(e => e.ExcavationId)
                    .HasColumnName("ExcavationID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Byusample).HasColumnName("BYUSample");

                entity.Property(e => e.ExcMonth)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.FieldBook)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InitialsOfEntryChecker)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.InitialsOfEntryExpert)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FaceBundleCode>(entity =>
            {
                entity.HasKey(e => e.FaceBundleKey)
                    .HasName("PK__FaceBund__E34323E86D6BD20A");

                entity.Property(e => e.FaceBundleKey)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Files>(entity =>
            {
                entity.HasKey(e => e.FileId)
                    .HasName("PK__Files__6F0F989F7666803A");

                entity.Property(e => e.FileId)
                    .HasColumnName("FileID")
                    .ValueGeneratedNever();

                entity.Property(e => e.BoneBook).HasColumnType("image");

                entity.Property(e => e.BurialId).HasColumnName("BurialID");

                entity.Property(e => e.FieldNote).HasColumnType("image");

                entity.Property(e => e.OtherNote).HasColumnType("image");

                entity.Property(e => e.Photo).HasColumnType("image");
            });

            modelBuilder.Entity<GenderCodeSingle>(entity =>
            {
                entity.HasKey(e => e.GenderKey)
                    .HasName("PK__GenderCo__44C092CD0CEFA286");

                entity.Property(e => e.GenderKey)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HairColorCode>(entity =>
            {
                entity.HasKey(e => e.HairColorKey)
                    .HasName("PK__HairColo__4361919026C35CF4");

                entity.Property(e => e.HairColorKey)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasKey(e => e.LocId)
                    .HasName("PK__Location__6A46DEE94EFCF9D7");

                entity.Property(e => e.LocId)
                    .HasColumnName("LocID")
                    .ValueGeneratedNever();

                entity.Property(e => e.BurialEw)
                    .HasColumnName("BurialEW")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.BurialNs)
                    .HasColumnName("BurialNS")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.MetersEw).HasColumnName("MetersEW");

                entity.Property(e => e.MetersNs).HasColumnName("MetersNS");

                entity.Property(e => e.Subplot)
                    .HasMaxLength(2)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PhysicalOrientation>(entity =>
            {
                entity.HasKey(e => e.OrientationId)
                    .HasName("PK__Physical__8B50BCC3997DE2FA");

                entity.Property(e => e.OrientationId)
                    .HasColumnName("OrientationID")
                    .ValueGeneratedNever();

                entity.Property(e => e.HeadDirection)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StoFeet).HasColumnName("SToFeet");

                entity.Property(e => e.StoHead).HasColumnName("SToHead");

                entity.Property(e => e.WtoFeet).HasColumnName("WToFeet");

                entity.Property(e => e.WtoHead).HasColumnName("WToHead");
            });

            modelBuilder.Entity<Sample>(entity =>
            {
                entity.Property(e => e.SampleId)
                    .HasColumnName("SampleID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AvgCalibrated95PercCalDate)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.BodyId).HasColumnName("BodyID");

                entity.Property(e => e.C14sample2017).HasColumnName("C14Sample2017");

                entity.Property(e => e.Category)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Conventional14CageBp).HasColumnName("Conventional14CAgeBP");

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.DescriptionOfTaken)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.LocationDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Notes).IsUnicode(false);

                entity.Property(e => e.Questions).IsUnicode(false);

                entity.Property(e => e._14calDate).HasColumnName("14CalDate");
            });

            modelBuilder.Entity<Storage>(entity =>
            {
                entity.HasKey(e => e.RackId)
                    .HasName("PK__Storage__0363D948E8E32B39");

                entity.Property(e => e.RackId)
                    .HasColumnName("RackID")
                    .ValueGeneratedNever();

                entity.Property(e => e.RackNum)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.SampleId).HasColumnName("SampleID");
            });

            modelBuilder.Entity<Tooth>(entity =>
            {
                entity.Property(e => e.ToothId)
                    .HasColumnName("ToothID")
                    .ValueGeneratedNever();

                entity.Property(e => e.BodyId).HasColumnName("BodyID");

                entity.Property(e => e.PathologyAnomoly)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ToothAttrition)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ToothEruption)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
