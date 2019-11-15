// <copyright file="SaleRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop.Data;

namespace Webshop.Repository
{
    /// <summary>
    /// SaleRepository.
    /// </summary>
    public class SaleRepository : IRepository<Sale>
    {
        ///// <summary>
        ///// WebshopDBEntities db.
        ///// </summary>
        //private readonly WebshopDBEntities new DBHandler().webshopDBEntities;

        ///// <summary>
        ///// Initializes a new instance of the <see cref="SaleRepository"/> class.
        ///// Ctor.
        ///// </summary>
        //public SaleRepository()
        //{
        //    new DBHandler().webshopDBEntities = new WebshopDBEntities();
        //}

        /// <summary>
        /// GetAll().
        /// </summary>
        /// <returns>IQueryable Users.</returns>
        public IEnumerable<Sale> GetAll()
        {
            return new DBHandler().webshopDBEntities.Sales;
        }

        /// <summary>
        /// Add().
        /// </summary>
        /// <param name="obj">Object for add.</param>
        public void Add(Sale obj)
        {
            DBHandler a = new DBHandler();
            a.webshopDBEntities.Sales.Add(obj);
            a.webshopDBEntities.SaveChanges();
            DBHandler.Instance.Dispose();
        }

        /// <summary>
        /// Delete().
        /// </summary>
        /// <param name="id">Id of the deleted object.</param>
        public void Delete(decimal id)
        {
            DBHandler a = new DBHandler();
            var v = a.webshopDBEntities.Sales.Where(u => u.ID == id).FirstOrDefault();
            a.webshopDBEntities.Sales.Remove(v);
            a.webshopDBEntities.SaveChanges();
            DBHandler.Instance.Dispose();
        }

        /// <summary>
        /// Get().
        /// </summary>
        /// <param name="id">Id of the object.</param>
        /// <returns>The required object.</returns>
        public Sale Get(decimal id)
        {
            return new DBHandler().webshopDBEntities.Sales.FirstOrDefault(t => t.ID == id);
        }

        /// <summary>
        /// Update().
        /// </summary>
        /// <param name="oldid">The old object's ID.</param>
        /// <param name="newobject">The new object.</param>
        public void Update(decimal oldid, Sale newobject)
        {
            this.Delete(oldid);
            this.Add(newobject);
        }
    }
}
