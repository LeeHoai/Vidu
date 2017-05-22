namespace ShoeShopMain.Domain.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ShoeShopMainDbContext : DbContext
    {
        public ShoeShopMainDbContext()
            : base("name=ShoeShopMainDbContext3")
        {
        }

        public virtual DbSet<CT_HDBAN> CT_HDBAN { get; set; }
        public virtual DbSet<CT_HDNHAP> CT_HDNHAP { get; set; }
        public virtual DbSet<DONGIABAN> DONGIABANs { get; set; }
        public virtual DbSet<HOADONBAN> HOADONBANs { get; set; }
        public virtual DbSet<HOADONNHAP> HOADONNHAPs { get; set; }
        public virtual DbSet<LOAISANPHAM> LOAISANPHAMs { get; set; }
        public virtual DbSet<NHACUNGCAP> NHACUNGCAPs { get; set; }
        public virtual DbSet<NHASANXUAT> NHASANXUATs { get; set; }
        public virtual DbSet<QUYEN> QUYENs { get; set; }
        public virtual DbSet<SANPHAM> SANPHAMs { get; set; }
        public virtual DbSet<TAIKHOAN> TAIKHOANs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CT_HDBAN>()
                .Property(e => e.DonGia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CT_HDNHAP>()
                .Property(e => e.DonGia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DONGIABAN>()
                .Property(e => e.DonGiaBan1)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HOADONBAN>()
                .HasMany(e => e.CT_HDBAN)
                .WithRequired(e => e.HOADONBAN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HOADONNHAP>()
                .HasMany(e => e.CT_HDNHAP)
                .WithRequired(e => e.HOADONNHAP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SANPHAM>()
                .HasMany(e => e.CT_HDBAN)
                .WithRequired(e => e.SANPHAM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SANPHAM>()
                .HasMany(e => e.CT_HDNHAP)
                .WithRequired(e => e.SANPHAM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SANPHAM>()
                .HasMany(e => e.DONGIABANs)
                .WithRequired(e => e.SANPHAM)
                .WillCascadeOnDelete(false);
        }
    }
}
