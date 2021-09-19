using API1809.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace API1809
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext([NotNullAttribute] DbContextOptions options) : base(options)
        {

        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Maquinaria> Maquinaria { get; set; }
        public DbSet<Alquiler> Alquiler { get; set; }
    }
}
