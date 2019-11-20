// <copyright file="UserRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Webshop.Repository
{
    using System.Collections.Generic;
    using System.Linq;
    using Webshop.Data;

    /// <summary>
    /// UserRepository.
    /// </summary>
    public class UserRepository : IRepository<User>
    {
        /// <summary>
        /// GetAll().
        /// </summary>
        /// <returns>IQueryable Users.</returns>
        public IEnumerable<User> GetAll()
        {
                return new DBHandler().WebshopDBEntities.Users;
        }

        /// <summary>
        /// Add().
        /// </summary>
        /// <param name="obj">Object for add.</param>
        public void Add(User obj)
        {
            DBHandler a = new DBHandler();
            a.WebshopDBEntities.Users.Add(obj);
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
            var v = a.WebshopDBEntities.Users.Where(u => u.ID == id).FirstOrDefault();
            a.WebshopDBEntities.Users.Remove(v);
            a.WebshopDBEntities.SaveChanges();
            DBHandler.Instance.Dispose();
        }

        /// <summary>
        /// Get().
        /// </summary>
        /// <param name="id">Id of the object.</param>
        /// <returns>The required object.</returns>
        public User GetByID(decimal id)
        {
            return new DBHandler().WebshopDBEntities.Users.FirstOrDefault(t => t.ID == id);
        }

        /// <summary>
        /// Update().
        /// </summary>
        /// <param name="oldid">The old object's ID.</param>
        /// <param name="newobject">The new object.</param>
        public void Update(decimal oldid, User newobject)
        {
            this.Delete(oldid);
            this.Add(newobject);
        }
    }
}
