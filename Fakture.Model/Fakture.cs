namespace Fakture.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Fakture")]
    public partial class Fakture
    {
        public Fakture()
        {
            FaktureStavke = new HashSet<FaktureStavke>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string BrojRN { get; set; }

        [Column(TypeName = "date")]
        public DateTime DatumIzdavanjaRN { get; set; }

        [Required]
        [StringLength(40)]
        public string MestoIzdavanjaRN { get; set; }

        [Column(TypeName = "date")]
        public DateTime DatumPrometa { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DatumPrometaDO { get; set; }

        [StringLength(40)]
        public string MestoPrometa { get; set; }

        public int? RokPlacanja { get; set; }

        [StringLength(15)]
        public string NacinPlacanja { get; set; }

        [StringLength(25)]
        public string BrojFI { get; set; }

        public decimal? VrednostSaPDV { get; set; }

        public int? KupacId { get; set; }

        public int TRProdavcaId { get; set; }

        [StringLength(255)]
        public string Napomena { get; set; }

        [StringLength(100)]
        public string PrevozImePrezime { get; set; }

        [Column(TypeName = "date")]
        public DateTime? PrevozDatumOd { get; set; }

        [Column(TypeName = "date")]
        public DateTime? PrevozDatumDo { get; set; }

        [StringLength(12)]
        public string PrevozRegBrojVozila { get; set; }

        [StringLength(50)]
        public string FakturuIzdao { get; set; }

        public virtual FirmePodaci FirmePodaci { get; set; }

        public virtual ICollection<FaktureStavke> FaktureStavke { get; set; }

        public virtual FirmeTR FirmeTR { get; set; }
    }
}
