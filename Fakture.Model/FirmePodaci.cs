namespace Fakture.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FirmePodaci")]
    public partial class FirmePodaci
    {
        public FirmePodaci()
        {
            Fakture = new HashSet<Fakture>();
            FirmeTR = new HashSet<FirmeTR>();
        }

        public int Id { get; set; }

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

        [StringLength(64)]
        public string Telefon { get; set; }

        [StringLength(64)]
        public string Fax { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(13)]
        public string MB { get; set; }

        [StringLength(9)]
        public string PIB { get; set; }

        public bool ObveznikPDV { get; set; }

        [StringLength(255)]
        public string Beleska { get; set; }

        [StringLength(1)]
        public string Kategorija { get; set; }

        public virtual ICollection<Fakture> Fakture { get; set; }

        public virtual ICollection<FirmeTR> FirmeTR { get; set; }
    }
}
