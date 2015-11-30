using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Abstraction
{
    public interface IRepository<T>
    {
        /// <summary>
        /// Will add an item to the database of the type T
        /// </summary>
        /// <param name="item">the item that will be added</param>
        /// <returns>The added item with the correct primary key.</returns>
        T Add(T item);

        /// <summary>
        /// Will collect an enumarable of type T
        /// </summary>
        /// <returns>an enumarable of type T</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Returns a specific item with the Id id
        /// </summary>
        /// <param name="id">the Id of the wanted item</param>
        /// <returns>the item with the Id of id</returns>
        T Get(int id);

        /// <summary>
        /// Will update an item of type T in the database
        /// </summary>
        /// <param name="item">the item that will be updated</param>
        /// <returns>true if it was successfully updated</returns>
        bool Update(T item);

        /// <summary>
        /// In order not to lose historical information, we have choosen to make
        /// it so that you cannot delete an item, but that you can deactivate it.
        /// Deactivating means that historical information about that item can be
        /// stored in the database.
        /// </summary>
        /// <param name="item">the item that is wanted Deactivated </param>
        /// <returns>true if the item was successfully deactivated</returns>
        bool DeActivate(T item);
    }
}
