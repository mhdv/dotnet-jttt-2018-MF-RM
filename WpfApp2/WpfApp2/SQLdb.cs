using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel;

namespace WpfApp2
{
    public class SQLdb : System.Data.Entity.DropCreateDatabaseIfModelChanges<JTTTdbcontext>
    {
        public void addToDb(JTTTdbcontext context)
        {
            JTTTdb task;

            // task = new JTTTdb() { task = new JTTT { url = "http://demotywatory.pl", text = "autobus", mail = "mehowpol@gmail.com" } };
            task = new JTTTdb() { URL = "http://demotywatory.pl", text = "autobus", mail = "mehowpol@gmail.com" };
            context.task.Add(task);

            context.SaveChanges();
        }

        protected override void Seed(JTTTdbcontext context)
        {

            JTTTdb task;

            // task = new JTTTdb() { task = new JTTT { url = "http://demotywatory.pl", text = "autobus", mail = "mehowpol@gmail.com" } };
            task = new JTTTdb() { URL = "http://demotywatory.pl", text = "autobus", mail = "mehowpol@gmail.com" };
            context.task.Add(task);

            context.SaveChanges();
            base.Seed(context);
        }

    }
}
