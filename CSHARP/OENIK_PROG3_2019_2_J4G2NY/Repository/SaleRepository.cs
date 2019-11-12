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
        /// <summary>
        /// WebshopDBEntities db.
        /// </summary>
        private readonly WebshopDBEntities dB;

        /// <summary>
        /// Initializes a new instance of the <see cref="SaleRepository"/> class.
        /// Ctor.
        /// </summary>
        public SaleRepository()
        {
            this.dB = new WebshopDBEntities();
        }

        /// <summary>
        /// GetAll().
        /// </summary>
        /// <returns>IQueryable Users.</returns>
        public IQueryable<Sale> GetAll()
        {
            return this.dB.Sales;
        }

        /// <summary>
        /// Add().
        /// </summary>
        /// <param name="obj">Object for add.</param>
        public void Add(Sale obj)
        {
            this.dB.Sales.Add(obj);
            this.dB.SaveChanges();
        }

        /// <summary>
        /// Delete().
        /// </summary>
        /// <param name="id">Id of the deleted object.</param>
        public void Delete(decimal id)
        {
            this.dB.Sales.Remove(this.Get(id));
            this.dB.SaveChanges();
        }

        /// <summary>
        /// Get().
        /// </summary>
        /// <param name="id">Id of the object.</param>
        /// <returns>The required object.</returns>
        public Sale Get(decimal id)
        {
            return this.dB.Sales.FirstOrDefault(t => t.ID == id);
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

        IEnumerable<Sale> IRepository<Sale>.GetAll()
        {
            return dB.Sales.ToArray();
        }
    }
}
