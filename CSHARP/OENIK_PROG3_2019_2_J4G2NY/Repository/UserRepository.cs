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
    public class UserRepository : IRepository<User>
    {
        ///// <summary>
        ///// WebshopDBEntities db.
        ///// </summary>
        //private WebshopDBEntities new DBHandler().webshopDBEntities;

        ///// <summary>
        ///// Initializes a new instance of the <see cref="UserRepository"/> class.
        ///// Ctor.
        ///// </summary>
        //public UserRepository()
        //{
        //    this.new DBHandler().webshopDBEntities = new WebshopDBEntities();
        //}

        /// <summary>
        /// GetAll().
        /// </summary>
        /// <returns>IQueryable Users.</returns>
        public IEnumerable<User> GetAll()
        {
                return new DBHandler().webshopDBEntities.Users;
        }

        /// <summary>
        /// Add().
        /// </summary>
        /// <param name="obj">Object for add.</param>
        public void Add(User obj)
        {

            DBHandler a = new DBHandler();
            a.webshopDBEntities.Users.Add(obj);
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
            var v = a.webshopDBEntities.Users.Where(u => u.ID == id).FirstOrDefault();
            a.webshopDBEntities.Users.Remove(v);
            a.webshopDBEntities.SaveChanges();
            DBHandler.Instance.Dispose();
        }

        /// <summary>
        /// Get().
        /// </summary>
        /// <param name="id">Id of the object.</param>
        /// <returns>The required object.</returns>
        public User Get(decimal id)
        {
            return new DBHandler().webshopDBEntities.Users.FirstOrDefault(t => t.ID == id);
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
