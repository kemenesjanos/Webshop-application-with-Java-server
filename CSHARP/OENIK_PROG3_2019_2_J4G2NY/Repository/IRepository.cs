// <copyright file="IRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Webshop.Repository
{
    using System.Collections.Generic;

    /// <summary>
    /// IRepository.
    /// </summary>
    /// <typeparam name="T">The generic type of the object.</typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Add.
        /// </summary>
        /// <param name="obj">object to add.</param>
        void Add(T obj);

        /// <summary>
        /// Get.
        /// </summary>
        /// <param name="id">Id of the object wanted to get.</param>
        /// <returns>The wanted object.</returns>
        T GetByID(decimal id);

        /// <summary>
        /// Update.
        /// </summary>
        /// <param name="oldid">The id of the old object.</param>
        /// <param name="newobject">The new object.</param>
        void Update(decimal oldid, T newobject);

        /// <summary>
        /// Delete.
        /// </summary>
        /// <param name="id">Id of the deleting object.</param>
        void Delete(decimal id);

        /// <summary>
        /// Get All.
        /// </summary>
        /// <returns>All.</returns>
        IEnumerable<T> GetAll();
    }
}
