using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BabyShoping.Model;

namespace BabyShoping.Data
{
    class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Toy> Toys { get; set; }
        public DataContext() : base("DefaultConnection")
        {

        }
    
        
    }
}
