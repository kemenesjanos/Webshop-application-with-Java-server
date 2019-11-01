// <copyright file="UserRepository.cs" company="PlaceholderCompany">
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
    public class SaleRepository : IRepository
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
        public IQueryable<Sales> GetAll()
        {
            return this.dB.Sales;
        }

        /// <summary>
        /// Add().
        /// </summary>
        /// <param name="obj">Object for add.</param>
        public void Add(object obj)
        {
            if (obj is Sales)
            {
                this.dB.Sales.Add(obj as Sales);
                this.dB.SaveChanges();
            }
            else
            {
                throw new WrongParameterException(obj);
            }
        }

        /// <summary>
        /// Delete().
        /// </summary>
        /// <param name="id">Id of the deleted object.</param>
        public void Delete(int id)
        {
            this.dB.Sales.Remove(this.Get(id) as Sales);
            this.dB.SaveChanges();
        }

        /// <summary>
        /// Get().
        /// </summary>
        /// <param name="id">Id of the object.</param>
        /// <returns>The required object.</returns>
        public object Get(int id)
        {
            return this.dB.Sales.FirstOrDefault(t => t.ID == id);
        }

        /// <summary>
        /// Update().
        /// </summary>
        /// <param name="oldid">The old object's ID.</param>
        /// <param name="newobject">The new object.</param>
        public void Update(int oldid, object newobject)
        {
            if (newobject is Sales)
            {
                this.Delete(oldid);
                this.Add(newobject as Sales);
            }
            else
            {
                throw new WrongParameterException(newobject);
            }
        }
    }
}
