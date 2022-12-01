using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using StandBy.Business.Models;


namespace StandBy.Data.Context
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions options) : base (options){
        }

        DbSet<Cliente> Clientes { get; set; }

     

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Faz o mapeamento de todas as minhas classe
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            //base.OnModelCreating(modelBuilder); 
        }
    }
}
