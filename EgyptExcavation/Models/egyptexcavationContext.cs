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
        public virtual DbSet<Files> Files { get; set; }
        public virtual DbSet<GenderCodeSingle> GenderCodeSingle { get; set; }
        public virtual DbSet<HairColorCode> HairColorCode { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<MyStudd> MyStudd { get; set; }
        public virtual DbSet<PhysicalOrientation> PhysicalOrientation { get; set; }
        public virtual DbSet<Sample> Sample { get; set; }
        public virtual DbSet<Storage> Storage { get; set; }
        public virtual DbSet<Tooth> Tooth { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=database-1.ck5snpiu0zac.us-east-1.rds.amazonaws.com,1433;Initial Catalog=egyptexcavation;User Id=admin;Password=intex2DBAdmin;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AgeCode>(entity =>
            {
                entity.HasKey(e => e.AgeKey)
                    .HasName("PK__AgeCode__28D1FD27A6625BE0");

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

                entity.Property(e => e.BoneTaken)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.BurialPreservation)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CranialId).HasColumnName("CranialID");

                entity.Property(e => e.DescriptionOfTaken)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EstimateLivingStature).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.GenderKey)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.GenderMethod)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.HairColorKey)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.HairTaken)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.PreservationIndex)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.SampleTaken)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.SequenceDna)
                    .HasColumnName("SequenceDNA")
                    .IsUnicode(false);

                entity.Property(e => e.SoftTissueTaken)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.TextileTaken)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.ToothTaken)
                    .HasMaxLength(1)
                    .IsFixedLength();

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

                entity.Property(e => e.BoneLength).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.EpiphysealUnion)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FemerLength).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.FemurDiameter).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.FemurHead).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ForemanMagnum).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Humerus).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.HumerusHead).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.HumerusLength).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.IliacCrest).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.MedialClavicle).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.OsteologyNotes)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Osteophytosis)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PostcrainiaAtMagazine)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.PostcrainiaTrauma)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.PubicSymphysis)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.TibiaLength).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<Burial>(entity =>
            {
                entity.Property(e => e.BurialId)
                    .HasColumnName("BurialID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ArtifactFound)
                    .HasMaxLength(1)
                    .IsFixedLength();

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

                entity.Property(e => e.FaceBundle)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.Goods)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.LocId).HasColumnName("LocID");

                entity.Property(e => e.OrientationId).HasColumnName("OrientationID");

                entity.Property(e => e.PreviouslySampled)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.ToBeConfirmed)
                    .HasMaxLength(1)
                    .IsFixedLength();
            });

            modelBuilder.Entity<BurialAdultChildCode>(entity =>
            {
                entity.HasKey(e => e.AdultChildKey)
                    .HasName("PK__BurialAd__CBD31B9AA797EF4B");

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
                    .HasName("PK__BurialWr__60655CBA9181FAD7");

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

                entity.Property(e => e.BasionNasion).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.BasionProsithanLength).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.BasonBergmaHeight).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.BizgoymaticDiameter).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ButtonOsteoma)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.CranialSuture)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CribraOrbitalia)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.GefunctionTotal)
                    .HasColumnName("GEFunctionTotal")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.GenderKey)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InterorbitalBreadth).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.MaxCranialBreadth).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.MaxCranialLength).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.MaxNasalBreadth).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.MetopicSuture)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.MonthOnSkull)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.NasionProsthion).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.OsteologyUnknownComment)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.PoroticHyperostosis)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.PoroticHyperostosisLoc)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SkullAtMagazine)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.SkullTrauma)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.Tmjoa)
                    .HasColumnName("TMJOA")
                    .HasMaxLength(1)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Excavation>(entity =>
            {
                entity.Property(e => e.ExcavationId)
                    .HasColumnName("ExcavationID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Byusample)
                    .HasColumnName("BYUSample")
                    .HasMaxLength(1)
                    .IsFixedLength();

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

            modelBuilder.Entity<Files>(entity =>
            {
                entity.HasKey(e => e.FileId)
                    .HasName("PK__Files__6F0F989FF420B6A5");

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
                    .HasName("PK__GenderCo__44C092CD001988F5");

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
                    .HasName("PK__HairColo__43619190DECEE264");

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
                    .HasName("PK__Location__6A46DEE98D7C19CF");

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

            modelBuilder.Entity<MyStudd>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PhysicalOrientation>(entity =>
            {
                entity.HasKey(e => e.OrientationId)
                    .HasName("PK__Physical__8B50BCC3BE0C7D95");

                entity.Property(e => e.OrientationId)
                    .HasColumnName("OrientationID")
                    .ValueGeneratedNever();

                entity.Property(e => e.BurialDepth).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.HeadDirection)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.LengthOfRemainsInMeters).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.StoFeet)
                    .HasColumnName("SToFeet")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.StoHead)
                    .HasColumnName("SToHead")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.WtoFeet)
                    .HasColumnName("WToFeet")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.WtoHead)
                    .HasColumnName("WToHead")
                    .HasColumnType("decimal(18, 0)");
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

                entity.Property(e => e.BoneTaken)
                    .HasMaxLength(1)
                    .IsFixedLength();

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

                entity.Property(e => e.HairTaken)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.LocationDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Notes).IsUnicode(false);

                entity.Property(e => e.Questions).IsUnicode(false);

                entity.Property(e => e.SampleTaken)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.SoftTissueTaken)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.TextileTaken)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.ToothTaken)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e._14calDate).HasColumnName("14CalDate");
            });

            modelBuilder.Entity<Storage>(entity =>
            {
                entity.HasKey(e => e.RackId)
                    .HasName("PK__Storage__0363D94862719E11");

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

                entity.Property(e => e.LinearHypoplasiaEnamel)
                    .HasMaxLength(1)
                    .IsFixedLength();

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
