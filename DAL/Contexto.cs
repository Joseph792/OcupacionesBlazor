using Microsoft.EntityFrameworkCore;
using RegistroOcupaciones.Models;

namespace RegistroOcupaciones.DAL
{
    public class Contexto : DbContext
    {

        public DbSet<Ocupaciones> Ocupaciones { get; set; }

        public Contexto(DbContextOptions<Contexto> options) : base(options) { }


    }
}