using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace souvenir.Model
{
    public  class SouvenirDbContext: DbContext
    {
        public SouvenirDbContext() : base("SouvenirDbContext")
        { 

        } 
        public DbSet<Souvenir> Souvenirs { get; set; }
        public DbSet<SouvenirType> SouvenirTypes { get; set; }
    }
}
