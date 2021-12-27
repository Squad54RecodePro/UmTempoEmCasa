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
    }
