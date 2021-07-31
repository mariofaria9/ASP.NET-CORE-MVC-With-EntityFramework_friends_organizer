using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NiverAmigosMario3.Models;

namespace NiverAmigosMario3.Data
{
    public class BancoDeDados : DbContext
    {
        public BancoDeDados(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Amigo> Amigos { get; set; }
    }
}
