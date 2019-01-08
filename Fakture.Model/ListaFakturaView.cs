namespace Fakture.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ListaFakturaView")]
    public partial class ListaFakturaView
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string BrojRN { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "date")]
        public DateTime DatumIzdavanjaRN { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(40)]
        public string MestoIzdavanjaRN { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "date")]
        public DateTime DatumPrometa { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DatumPrometaDO { get; set; }

        [StringLength(40)]
        public string MestoPrometa { get; set; }

        [StringLength(100)]
        public string NazivPrviRed { get; set; }

        [StringLength(100)]
        public string NazivDrugiRed { get; set; }

        [StringLength(100)]
        public string Adresa { get; set; }

        [StringLength(6)]
        public string PostBroj { get; set; }

        [StringLength(100)]
        public string Mesto { get; set; }

        public decimal? VrednostBezPDVa { get; set; }

        public decimal? IznosRabata { get; set; }

        public decimal? OsnovicaZaPDV { get; set; }

        public decimal? IznosPDVa { get; set; }

        public decimal? VrednostSaPDV { get; set; }

        [StringLength(9)]
        public string PIB { get; set; }

        [StringLength(64)]
        public string Telefon { get; set; }

        [StringLength(255)]
        public string BrojTR { get; set; }

        [StringLength(255)]
        public string NazivBanke { get; set; }

        public int? RokPlacanja { get; set; }

        [StringLength(15)]
        public string NacinPlacanja { get; set; }

        [StringLength(50)]
        public string FakturuIzdao { get; set; }

        [Column(TypeName = "date")]
        public DateTime? PrevozDatumOd { get; set; }

        [Column(TypeName = "date")]
        public DateTime? PrevozDatumDo { get; set; }

        [StringLength(100)]
        public string PrevozImePrezime { get; set; }

        [StringLength(12)]
        public string PrevozRegBrojVozila { get; set; }

        [StringLength(255)]
        public string Napomena { get; set; }

        [StringLength(25)]
        public string BrojFI { get; set; }

        public int? KupacId { get; set; }
    }
}
