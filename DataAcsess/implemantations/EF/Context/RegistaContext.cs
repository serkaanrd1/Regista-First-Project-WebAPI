using Microsoft.EntityFrameworkCore;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcsess.implemantations.EF.Context
{
    public class RegistaContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=.;database=Regista;trusted_connection=true;");
        }
   public DbSet<Product>? Products { get; set; }
   public DbSet<AdminPanelUser>? AdminPanelUsers { get; set; }

    }
}
