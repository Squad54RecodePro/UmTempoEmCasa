using Microsoft.EntityFrameworkCore;
using UmTempoEmCasa.Models;

namespace UmTempoEmCasa.Context
{
    public class MVCContext : DbContext
    {
        public MVCContext(DbContextOptions<MVCContext> options)
            : base(options)
        {
        }

        public DbSet<Anuncio> Anuncios { get; set; }

        public DbSet<Anfitriao> Anfitrioes { get; set; }

        public DbSet<Imovel> Imoveis { get; set; }

        public DbSet<Refugiado> Refugiados { get; set; }

        public DbSet<Ongs> Ongs { get; set; }

        public DbSet<Reserva> Reservas { get; set; }

        public DbSet<Contato> Contatos { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anuncio>()
                .HasOne(p => p.Imovel)
                .WithMany()
                .HasForeignKey(p => p.ImovelForeignKey);

            modelBuilder.Entity<Imovel>()
                .HasOne(p => p.Anfitrioes)
                .WithMany(b => b.Imovel)
                .HasForeignKey(p => p.AnfitriaoForeignKey);

            modelBuilder.Entity<Reserva>()
                .HasOne(p => p.Anuncios)
                .WithMany(b => b.Reservas)
                .HasForeignKey(p => p.AnuncioForeignKey);

            modelBuilder.Entity<Reserva>()
                .HasOne(p => p.Refugiados)
                .WithMany(b => b.Reservas)
                .HasForeignKey(p => p.RefugiadoForeignKey);



        }
    }
}
