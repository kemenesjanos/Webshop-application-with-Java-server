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
    /// UserRepository.
    /// </summary>
    public class UserRepository : IRepository<Users>
    {
        /// <summary>
        /// WebshopDBEntities db.
        /// </summary>
        private readonly WebshopDBEntities dB;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// Ctor.
        /// </summary>
        public UserRepository()
        {
            this.dB = new WebshopDBEntities();
        }

        /// <summary>
        /// GetAll().
        /// </summary>
        /// <returns>IQueryable Users.</returns>
        public IQueryable<Users> GetAll()
        {
            return this.dB.Users;
        }

        /// <summary>
        /// Add().
        /// </summary>
        /// <param name="obj">Object for add.</param>
        public void Add(Users obj)
        {
                this.dB.Users.Add(obj);
                this.dB.SaveChanges();
        }

        /// <summary>
        /// Delete().
        /// </summary>
        /// <param name="id">Id of the deleted object.</param>
        public void Delete(decimal id)
        {
            this.dB.Users.Remove(this.Get(id));
            this.dB.SaveChanges();
        }

        /// <summary>
        /// Get().
        /// </summary>
        /// <param name="id">Id of the object.</param>
        /// <returns>The required object.</returns>
        public Users Get(decimal id)
        {
            return this.dB.Users.FirstOrDefault(t => t.ID == id);
        }

        /// <summary>
        /// Update().
        /// </summary>
        /// <param name="oldid">The old object's ID.</param>
        /// <param name="newobject">The new object.</param>
        public void Update(decimal oldid, Users newobject)
        {
            this.Delete(oldid);
            this.Add(newobject);
        }
    }
}
