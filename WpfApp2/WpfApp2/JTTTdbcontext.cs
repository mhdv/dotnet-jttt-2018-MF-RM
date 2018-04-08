using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WpfApp2
{
    public class JTTTdbcontext : DbContext
    {
        public JTTTdbcontext() : base("JTTTdb")
        {
            Database.SetInitializer(new SQLdb());
        }

        public DbSet<JTTTdb> task { get; set; }
    }
}
