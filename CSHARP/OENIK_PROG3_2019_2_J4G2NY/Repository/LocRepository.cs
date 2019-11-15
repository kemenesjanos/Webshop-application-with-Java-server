// <copyright file="LocRepository.cs" company="PlaceholderCompany">
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
    /// LocRepository.
    /// </summary>
    public class LocRepository : IRepository<Loc>
    {
        ///// <summary>
        ///// WebshopDBEntities db.
        ///// </summary>
        //private readonly WebshopDBEntities new DBHandler().webshopDBEntities;

        ///// <summary>
        ///// Initializes a new instance of the <see cref="LocRepository"/> class.
        ///// Ctor.
        ///// </summary>
        //public LocRepository()
        //{
        //    this.new DBHandler().webshopDBEntities = new WebshopDBEntities();
        //}

        /// <summary>
        /// GetAll().
        /// </summary>
        /// <returns>IQueryable Users.</returns>
        public IEnumerable<Loc> GetAll()
        {
            return new DBHandler().webshopDBEntities.Locs;
        }

        /// <summary>
        /// Add.
        /// </summary>
        /// <param name="obj">Location object.</param>
        public void Add(Loc obj)
        {
            DBHandler a = new DBHandler();
            a.webshopDBEntities.Locs.Add(obj);
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
            var v = a.webshopDBEntities.Locs.Where(u => u.ID == id).FirstOrDefault();
            a.webshopDBEntities.Locs.Remove(v);
            a.webshopDBEntities.SaveChanges();
            DBHandler.Instance.Dispose();
        }

        /// <summary>
        /// Get().
        /// </summary>
        /// <param name="id">Id of the object.</param>
        /// <returns>The required object.</returns>
        public Loc Get(decimal id)
        {
            return new DBHandler().webshopDBEntities.Locs.Where(x => x.ID == id).FirstOrDefault();
        }

        /// <summary>
        /// Update().
        /// </summary>
        /// <param name="oldid">The old object's ID.</param>
        /// <param name="newobject">The new object.</param>
        public void Update(decimal oldid, Loc newobject)
        {
            this.Delete(oldid);
            this.Add(newobject);
        }
    }
}
