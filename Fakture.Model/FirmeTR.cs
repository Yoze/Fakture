namespace Fakture.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FirmeTR")]
    public partial class FirmeTR
    {
        public FirmeTR()
        {
            Fakture = new HashSet<Fakture>();
        }

        public int ID { get; set; }

        [StringLength(255)]
        public string BrojTR { get; set; }

        [StringLength(255)]
        public string NazivBanke { get; set; }

        public int? FirmePodaciId { get; set; }

        [StringLength(255)]
        public string Beleska { get; set; }

        public bool? Podrazumevani { get; set; }

        public virtual ICollection<Fakture> Fakture { get; set; }

        public virtual FirmePodaci FirmePodaci { get; set; }
    }
}
