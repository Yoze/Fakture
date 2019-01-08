namespace Fakture.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FaktureModel : DbContext
    {
        public FaktureModel()
            //: base("name=FaktureConn")
            : base (AktivniKonekcioniString.OdabraniKonekcioniString)
        {
        }

        public virtual DbSet<Fakture> Fakture { get; set; }
        public virtual DbSet<FaktureStavke> FaktureStavke { get; set; }
        public virtual DbSet<FirmePodaci> FirmePodaci { get; set; }
        public virtual DbSet<FirmeTR> FirmeTR { get; set; }
        public virtual DbSet<VrsteStavkiRacuna> VrsteStavkiRacuna { get; set; }
        public virtual DbSet<ListaFakturaView> ListaFakturaView { get; set; }
        public virtual DbSet<ListaKupacaView> ListaKupacaView { get; set; }
        public virtual DbSet<ListaStavkiFaktureView> ListaStavkiFaktureView { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fakture>()
                .Property(e => e.VrednostSaPDV)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Fakture>()
                .HasMany(e => e.FaktureStavke)
                .WithOptional(e => e.Fakture)
                .HasForeignKey(e => e.FakturaId)
                .WillCascadeOnDelete();

            modelBuilder.Entity<FaktureStavke>()
                .Property(e => e.Kolicina)
                .HasPrecision(10, 2);

            modelBuilder.Entity<FaktureStavke>()
                .Property(e => e.CenaBezPDV)
                .HasPrecision(10, 2);

            modelBuilder.Entity<FaktureStavke>()
                .Property(e => e.VrednostBezPDV)
                .HasPrecision(10, 2);

            modelBuilder.Entity<FaktureStavke>()
                .Property(e => e.Rabat)
                .HasPrecision(5, 2);

            modelBuilder.Entity<FaktureStavke>()
                .Property(e => e.IznosRabata)
                .HasPrecision(10, 2);

            modelBuilder.Entity<FaktureStavke>()
                .Property(e => e.OsnovicaPDV)
                .HasPrecision(10, 2);

            modelBuilder.Entity<FaktureStavke>()
                .Property(e => e.IznosPDV)
                .HasPrecision(10, 2);

            modelBuilder.Entity<FaktureStavke>()
                .Property(e => e.VrednostSaPDV)
                .HasPrecision(10, 2);

            modelBuilder.Entity<FirmePodaci>()
                .HasMany(e => e.Fakture)
                .WithOptional(e => e.FirmePodaci)
                .HasForeignKey(e => e.KupacId);

            modelBuilder.Entity<FirmeTR>()
                .HasMany(e => e.Fakture)
                .WithRequired(e => e.FirmeTR)
                .HasForeignKey(e => e.TRProdavcaId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VrsteStavkiRacuna>()
                .HasMany(e => e.FaktureStavke)
                .WithOptional(e => e.VrsteStavkiRacuna)
                .HasForeignKey(e => e.VrstaStavkeRacunaId);

            modelBuilder.Entity<ListaFakturaView>()
                .Property(e => e.VrednostSaPDV)
                .HasPrecision(38, 2);

            modelBuilder.Entity<ListaFakturaView>()
                .Property(e => e.VrednostBezPDVa)
                .HasPrecision(38, 2);

            modelBuilder.Entity<ListaFakturaView>()
                .Property(e => e.IznosPDVa)
                .HasPrecision(38, 2);

            modelBuilder.Entity<ListaFakturaView>()
                .Property(e => e.IznosRabata)
                .HasPrecision(38, 2);

            modelBuilder.Entity<ListaFakturaView>()
                .Property(e => e.OsnovicaZaPDV)
                .HasPrecision(38, 2);

            modelBuilder.Entity<ListaStavkiFaktureView>()
                .Property(e => e.Kolicina)
                .HasPrecision(10, 2);

            modelBuilder.Entity<ListaStavkiFaktureView>()
                .Property(e => e.CenaBezPDV)
                .HasPrecision(10, 2);

            modelBuilder.Entity<ListaStavkiFaktureView>()
                .Property(e => e.VrednostBezPDV)
                .HasPrecision(10, 2);

            modelBuilder.Entity<ListaStavkiFaktureView>()
                .Property(e => e.Rabat)
                .HasPrecision(5, 2);

            modelBuilder.Entity<ListaStavkiFaktureView>()
                .Property(e => e.IznosRabata)
                .HasPrecision(10, 2);

            modelBuilder.Entity<ListaStavkiFaktureView>()
                .Property(e => e.OsnovicaPDV)
                .HasPrecision(10, 2);

            modelBuilder.Entity<ListaStavkiFaktureView>()
                .Property(e => e.IznosPDV)
                .HasPrecision(10, 2);

            modelBuilder.Entity<ListaStavkiFaktureView>()
                .Property(e => e.VrednostSaPDV)
                .HasPrecision(10, 2);
        }
    }
}
