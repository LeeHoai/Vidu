namespace ShoeShopMain.Domain.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DONGIABAN")]
    public partial class DONGIABAN
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TrangThai { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaSP { get; set; }

        [Column("DonGiaBan")]
        public decimal? DonGiaBan1 { get; set; }

        public virtual SANPHAM SANPHAM { get; set; }
    }
}
