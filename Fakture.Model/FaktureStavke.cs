namespace Fakture.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FaktureStavke")]
    public partial class FaktureStavke
    {
        public int ID { get; set; }

        public int? FakturaId { get; set; }

        public int? VrstaStavkeRacunaId { get; set; }

        [StringLength(255)]
        public string VrstaStavkeDodOpis { get; set; }

        public decimal Kolicina { get; set; }

        public decimal CenaBezPDV { get; set; }

        public decimal VrednostBezPDV { get; set; }

        public decimal Rabat { get; set; }

        public decimal IznosRabata { get; set; }

        public decimal OsnovicaPDV { get; set; }

        public int StopaPDV { get; set; }

        public decimal IznosPDV { get; set; }

        public decimal VrednostSaPDV { get; set; }

        public bool CheckBoxCenaSaPDV { get; set; }

        public virtual Fakture Fakture { get; set; }
        
        public virtual VrsteStavkiRacuna VrsteStavkiRacuna { get; set; }
    }
}
