// <copyright file="LocRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Webshop.Repository
{
    using System.Collections.Generic;
    using System.Linq;
    using Webshop.Data;

    /// <summary>
    /// LocRepository.
    /// </summary>
    public class LocRepository : IRepository<Loc>
    {
        /// <summary>
        /// GetAll().
        /// </summary>
        /// <returns>IQueryable Users.</returns>
        public IEnumerable<Loc> GetAll()
        {
            return new DBHandler().WebshopDBEntities.Locs;
        }

        /// <summary>
        /// Add.
        /// </summary>
        /// <param name="obj">Location object.</param>
        public void Add(Loc obj)
        {
            DBHandler a = new DBHandler();
            a.WebshopDBEntities.Locs.Add(obj);
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
            var v = a.WebshopDBEntities.Locs.Where(u => u.ID == id).FirstOrDefault();
            a.WebshopDBEntities.Locs.Remove(v);
            a.WebshopDBEntities.SaveChanges();
            DBHandler.Instance.Dispose();
        }

        /// <summary>
        /// Get().
        /// </summary>
        /// <param name="id">Id of the object.</param>
        /// <returns>The required object.</returns>
        public Loc GetByID(decimal id)
        {
            return new DBHandler().WebshopDBEntities.Locs.Where(x => x.ID == id).FirstOrDefault();
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
