#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UmTempoEmCasa.Models;

    public class UmTempoEmCasaContext : DbContext
    {
        public UmTempoEmCasaContext (DbContextOptions<UmTempoEmCasaContext> options)
            : base(options)
        {
        }

        public DbSet<UmTempoEmCasa.Models.Anuncio> Anuncio { get; set; }

        public DbSet<UmTempoEmCasa.Models.Anfitriao> Anfitriao { get; set; }

        public DbSet<UmTempoEmCasa.Models.Imovel> Imovel { get; set; }

        public DbSet<UmTempoEmCasa.Models.Reserva> Reserva { get; set; }

        public DbSet<UmTempoEmCasa.Models.Refugiado> Refugiado { get; set; }
    }
