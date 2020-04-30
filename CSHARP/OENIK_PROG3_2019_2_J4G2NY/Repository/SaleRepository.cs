// <copyright file="SaleRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Webshop.Repository
{
    using System.Collections.Generic;
    using System.Linq;
    using Webshop.Data;

    /// <summary>
    /// SaleRepository.
    /// </summary>
    public class SaleRepository : IRepository<Sales>
    {
        /// <summary>
        /// GetAll().
        /// </summary>
        /// <returns>IQueryable Users.</returns>
        public IEnumerable<Sales> GetAll()
        {
            return new DBHandler().WebshopDBEntities.Sales;
        }

        /// <summary>
        /// Add().
        /// </summary>
        /// <param name="obj">Object for add.</param>
        public void Add(Sales obj)
        {
            DBHandler a = new DBHandler();
            a.WebshopDBEntities.Sales.Add(obj);
            a.WebshopDBEntities.SaveChanges();
            DBHandler.Instance.Dispose();
        }

        /// <summary>
        /// Delete().
        /// </summary>
        /// <param name="id">Id of the deleted object.</param>
        public void Delete(decimal id)
        {
            DBHandler a = new DBHandler();
            var v = a.WebshopDBEntities.Sales.Where(u => u.ID == id).FirstOrDefault();
            a.WebshopDBEntities.Sales.Remove(v);
            a.WebshopDBEntities.SaveChanges();
            DBHandler.Instance.Dispose();
        }

        /// <summary>
        /// Get().
        /// </summary>
        /// <param name="id">Id of the object.</param>
        /// <returns>The required object.</returns>
        public Sales GetByID(decimal id)
        {
            return new DBHandler().WebshopDBEntities.Sales.FirstOrDefault(t => t.ID == id);
        }

        /// <summary>
        /// Update().
        /// </summary>
        /// <param name="oldid">The old object's ID.</param>
        /// <param name="newobject">The new object.</param>
        public void Update(decimal oldid, Sales newobject)
        {
            this.Delete(oldid);
            this.Add(newobject);
        }
    }
}
