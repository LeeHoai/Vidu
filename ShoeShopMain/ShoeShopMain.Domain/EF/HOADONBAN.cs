namespace ShoeShopMain.Domain.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOADONBAN")]
    public partial class HOADONBAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOADONBAN()
        {
            CT_HDBAN = new HashSet<CT_HDBAN>();
        }

        [Key]
        public int MaHDB { get; set; }

        public int? MaTaiKhoan { get; set; }

        public DateTime? NgayBan { get; set; }

        public bool? TinhTrang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_HDBAN> CT_HDBAN { get; set; }

        public virtual TAIKHOAN TAIKHOAN { get; set; }
    }
}
