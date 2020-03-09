using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace JqueryDataTableMasterDetail.Models.CoreEF
{
    public partial class ContosoRetailDWContext : DbContext
    {
      

        public ContosoRetailDWContext(DbContextOptions<ContosoRetailDWContext> options)
            : base(options)
        {
        }

       
        public virtual DbSet<DimProductCategory> DimProductCategory { get; set; }
        public virtual DbSet<DimProductSubcategory> DimProductSubcategory { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{

            //    optionsBuilder.UseSqlServer();
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<DimProductCategory>(entity =>
            {
                entity.HasKey(e => e.ProductCategoryKey)
                    .HasName("PK_DimProductCategory_ProductCategoryKey");

                entity.HasIndex(e => e.ProductCategoryLabel)
                    .HasName("AK_DimProductCategory_ProductCategoryLabel")
                    .IsUnique();

                entity.Property(e => e.EtlloadId).HasColumnName("ETLLoadID");

                entity.Property(e => e.LoadDate).HasColumnType("datetime");

                entity.Property(e => e.ProductCategoryDescription)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ProductCategoryLabel).HasMaxLength(100);

                entity.Property(e => e.ProductCategoryName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<DimProductSubcategory>(entity =>
            {
                entity.HasKey(e => e.ProductSubcategoryKey)
                    .HasName("PK_DimProductSubcategory_ProductSubcategoryKey");

                entity.HasIndex(e => e.ProductSubcategoryLabel)
                    .HasName("AK_DimProductSubcategory_ProductSubcategoryLabel")
                    .IsUnique();

                entity.Property(e => e.EtlloadId).HasColumnName("ETLLoadID");

                entity.Property(e => e.LoadDate).HasColumnType("datetime");

                entity.Property(e => e.ProductSubcategoryDescription).HasMaxLength(100);

                entity.Property(e => e.ProductSubcategoryLabel).HasMaxLength(100);

                entity.Property(e => e.ProductSubcategoryName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.ProductCategoryKeyNavigation)
                    .WithMany(p => p.DimProductSubcategory)
                    .HasForeignKey(d => d.ProductCategoryKey)
                    .HasConstraintName("FK_DimProductSubcategory_DimProductCategory");
            });

           
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
