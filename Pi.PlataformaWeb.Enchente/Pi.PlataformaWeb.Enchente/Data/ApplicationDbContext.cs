using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pi.PlataformaWeb.Enchente.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pi.PlataformaWeb.Enchente.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<DadoVolumetrico> DadosVolumetricos { get; set; }
        public DbSet<Inscrito> Inscritos { get; set; }
    }
}
