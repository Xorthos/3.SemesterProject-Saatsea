using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class Context : DbContext
    {
        /// <summary>
        /// Contructor: this will turn off lazy loading on every object,
        /// this is to make sure there will be no serialization problems.
        /// </summary>
        public Context() : base("name=SaatSea")
        {
            //this turns off lazy loading.
            this.Configuration.LazyLoadingEnabled = false;
        }
    }
}
