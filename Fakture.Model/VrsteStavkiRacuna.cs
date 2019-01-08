namespace Fakture.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VrsteStavkiRacuna")]
    public partial class VrsteStavkiRacuna
    {
        public VrsteStavkiRacuna()
        {
            FaktureStavke = new HashSet<FaktureStavke>();
        }

        public int ID { get; set; }

        [StringLength(255)]
        public string NazivVrsteStavke { get; set; }

        [StringLength(10)]
        public string JedinicaMere { get; set; }

        public int StopaPDV { get; set; }

        public virtual ICollection<FaktureStavke> FaktureStavke { get; set; }
    }
}
