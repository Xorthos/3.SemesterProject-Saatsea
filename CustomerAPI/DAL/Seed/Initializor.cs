using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Seed
{
    public class Initializor
    {
        public static void Initalize()
        {
            Database.SetInitializer(new Initializer());
        }
    }
}
