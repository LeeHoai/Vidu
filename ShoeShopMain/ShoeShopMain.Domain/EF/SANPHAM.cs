namespace ShoeShopMain.Domain.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SANPHAM")]
    public partial class SANPHAM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SANPHAM()
        {
            CT_HDBAN = new HashSet<CT_HDBAN>();
            CT_HDNHAP = new HashSet<CT_HDNHAP>();
            DONGIABANs = new HashSet<DONGIABAN>();
        }

        [Key]
        public int MaSP { get; set; }

        [StringLength(250)]
        public string TenSP { get; set; }

        public double? DonGia { get; set; }

        public int? SoLuongTon { get; set; }

        public int? MaLoaiSP { get; set; }

        public int? MaNSX { get; set; }

        public int? MaNCC { get; set; }

        [StringLength(250)]
        public string Hinh { get; set; }

        [StringLength(250)]
        public string MoTa { get; set; }

        [StringLength(50)]
        public string ChiTiet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_HDBAN> CT_HDBAN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_HDNHAP> CT_HDNHAP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DONGIABAN> DONGIABANs { get; set; }

        public virtual LOAISANPHAM LOAISANPHAM { get; set; }

        public virtual NHACUNGCAP NHACUNGCAP { get; set; }

        public virtual NHASANXUAT NHASANXUAT { get; set; }
    }
}
