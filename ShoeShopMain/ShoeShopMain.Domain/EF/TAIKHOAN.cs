namespace ShoeShopMain.Domain.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TAIKHOAN")]
    public partial class TAIKHOAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TAIKHOAN()
        {
            HOADONBANs = new HashSet<HOADONBAN>();
        }

        [Key]
        public int MaTaiKhoan { get; set; }

        [StringLength(50)]
        public string MatKhau { get; set; }

        [StringLength(250)]
        public string HoTen { get; set; }

        [StringLength(50)]
        public string SoDienThoai { get; set; }

        [StringLength(500)]
        public string DiaChi { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public int? MaQuyen { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADONBAN> HOADONBANs { get; set; }

        public virtual QUYEN QUYEN { get; set; }
    }
}
