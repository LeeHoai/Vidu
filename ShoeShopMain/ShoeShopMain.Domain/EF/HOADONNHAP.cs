namespace ShoeShopMain.Domain.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOADONNHAP")]
    public partial class HOADONNHAP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOADONNHAP()
        {
            CT_HDNHAP = new HashSet<CT_HDNHAP>();
        }

        [Key]
        public int MaHDN { get; set; }

        public int? MaNCC { get; set; }

        public DateTime? NgayNhap { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_HDNHAP> CT_HDNHAP { get; set; }
    }
}
