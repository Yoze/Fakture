namespace Fakture.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ListaStavkiFaktureView")]
    public partial class ListaStavkiFaktureView
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int? FakturaId { get; set; }

        [StringLength(255)]
        public string NazivVrsteStavke { get; set; }

        [StringLength(255)]
        public string VrstaStavkeDodOpis { get; set; }

        [StringLength(10)]
        public string JedinicaMere { get; set; }

        [Key]
        [Column(Order = 1)]
        public decimal Kolicina { get; set; }

        [Key]
        [Column(Order = 2)]
        public decimal CenaBezPDV { get; set; }

        [Key]
        [Column(Order = 3)]
        public decimal VrednostBezPDV { get; set; }

        [Key]
        [Column(Order = 4)]
        public decimal Rabat { get; set; }

        [Key]
        [Column(Order = 5)]
        public decimal IznosRabata { get; set; }

        [Key]
        [Column(Order = 6)]
        public decimal OsnovicaPDV { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StopaPDV { get; set; }

        [Key]
        [Column(Order = 8)]
        public decimal IznosPDV { get; set; }

        [Key]
        [Column(Order = 9)]
        public decimal VrednostSaPDV { get; set; }
    }
}
