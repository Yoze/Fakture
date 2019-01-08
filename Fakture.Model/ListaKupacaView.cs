namespace Fakture.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ListaKupacaView")]
    public partial class ListaKupacaView
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string NazivPrviRed { get; set; }

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
    }
}
