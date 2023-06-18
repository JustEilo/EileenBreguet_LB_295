using EileenBreguet_Backup2;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryApi
{
    public class LibraryContext : DbContext
    {
        public DbSet<Games> Games { get; set; }
        public DbSet<Charakters> Charakters { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CharakterDB;Trusted_Connection=True");
        }
 
    }
}
