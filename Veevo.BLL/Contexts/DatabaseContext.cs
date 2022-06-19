using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veevo.BLL.Models.Database;

namespace Veevo.BLL.Contexts
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DatabaseContext()
        {
            Database.EnsureCreated(); 
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=49153;Database=veevo;Username=postgres;Password=postgrespw");
        }
        public DbSet<DialogDatabaseModel> Dialogs => Set<DialogDatabaseModel>();
        public DbSet<MessageDatabaseModel> Messages => Set<MessageDatabaseModel>();
        public DbSet<UserDatabaseModel> Users => Set<UserDatabaseModel>();
        public DbSet<UpdateDatabaseModel> Updates => Set<UpdateDatabaseModel>();
    }
}
