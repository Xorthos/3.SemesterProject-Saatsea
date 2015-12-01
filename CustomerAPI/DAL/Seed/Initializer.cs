using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Seed
{
    class Initializer : DropCreateDatabaseAlways<Context.Context>
    {
        public Initializer()
        {
            InitializeDatabase(new Context.Context());
        }
        public override void InitializeDatabase(DAL.Context.Context context)
        {
            
            base.InitializeDatabase(context);
        }
    }
}
