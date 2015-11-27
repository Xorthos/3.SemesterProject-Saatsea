using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Seed
{
    class Initializer : DropCreateDatabaseAlways<DAL.Context.Context>
    {
        public override void InitializeDatabase(DAL.Context.Context context)
        {
            
            base.InitializeDatabase(context);
        }
    }
}
