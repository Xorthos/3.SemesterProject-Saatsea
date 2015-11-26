using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Context.Seed
{
    public class Initializor
    {
        public static void Initalize()
        {
            Database.SetInitializer(new Initializer());
        }
    }
}
