using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakipProgDemo.Entitiy
{
    class StokTakipEntitiy :DbContext
    {
        public DbSet<Product> Products { get; set; }
        
    }
}
