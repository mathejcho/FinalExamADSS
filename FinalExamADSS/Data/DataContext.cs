using FinalExamADSS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalExamADSS.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext>options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientCars>().HasKey(bc => new
            {
                bc.ClientId,
                bc.CarId
            });
            modelBuilder.Entity<ClientCars>().HasOne(c => c.Car).WithMany(cc => cc.ClientCars).HasForeignKey(c => c.CarId);
            modelBuilder.Entity<ClientCars>().HasOne(cl => cl.Client).WithMany(cc => cc.ClientCars).HasForeignKey(cl => cl.ClientId);

            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Client> Client { get; set; }
        public DbSet<Car> Car { get; set; }
        public DbSet<ClientCars> ClientCars { get; set; }
    }
}
