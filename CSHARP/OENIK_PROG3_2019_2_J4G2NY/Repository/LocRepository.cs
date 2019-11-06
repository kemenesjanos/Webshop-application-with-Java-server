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
        /// <summary>
        /// WebshopDBEntities db.
        /// </summary>
        private readonly WebshopDBEntities dB;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocRepository"/> class.
        /// Ctor.
        /// </summary>
        public LocRepository()
        {
            this.dB = new WebshopDBEntities();
        }

        /// <summary>
        /// GetAll().
        /// </summary>
        /// <returns>IQueryable Users.</returns>
        public IQueryable<Loc> GetAll()
        {
            return this.dB.Locs;
        }

        /// <summary>
        /// Add.
        /// </summary>
        /// <param name="obj">Location object.</param>
        public void Add(Loc obj)
        {
            this.dB.Locs.Add(obj);
            this.dB.SaveChanges();
        }

        /// <summary>
        /// Delete().
        /// </summary>
        /// <param name="id">Id of the deleted object.</param>
        public void Delete(int id)
        {
            this.dB.Locs.Remove(this.Get(id));
            this.dB.SaveChanges();
        }

        /// <summary>
        /// Get().
        /// </summary>
        /// <param name="id">Id of the object.</param>
        /// <returns>The required object.</returns>
        public Loc Get(int id)
        {
            return this.dB.Locs.FirstOrDefault(t => t.ID == id);
        }

        /// <summary>
        /// Update().
        /// </summary>
        /// <param name="oldid">The old object's ID.</param>
        /// <param name="newobject">The new object.</param>
        public void Update(int oldid, Loc newobject)
        {
            this.Delete(oldid);
            this.Add(newobject);
        }
    }
}
