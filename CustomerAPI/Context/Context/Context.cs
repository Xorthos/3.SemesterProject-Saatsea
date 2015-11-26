using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Context.Models;

namespace DAL.Context
{
    public class Context : DbContext
    {
        #region constants

        public static readonly string CONNECTIONSTRING_NAME = "name=SaatSea";
        #endregion

        #region DbSets
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Contructor: this will turn off lazy loading on every object,
        /// this is to make sure there will be no serialization problems.
        /// </summary>
        public Context() : base(CONNECTIONSTRING_NAME)
        {
            //this turns off lazy loading.
            this.Configuration.LazyLoadingEnabled = false;
        }
        #endregion
    }
}
