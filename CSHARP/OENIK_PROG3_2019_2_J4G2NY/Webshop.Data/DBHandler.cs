// <copyright file="DBHandler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Webshop.Data
{
    using System;

    /// <summary>
    /// DB handler.
    /// </summary>
    public sealed class DBHandler : IDisposable
    {
        private static DBHandler instance;

        /// <summary>
        /// Initializes a new instance of the <see cref="DBHandler"/> class.
        /// </summary>
        public DBHandler()
        {
            this.WebshopDBEntities = new WebshopDBEntities();
        }

        /// <summary>
        /// Gets instance.
        /// </summary>
        public static DBHandler Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DBHandler();
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets or sets webshopDBEntities.
        /// </summary>
        public WebshopDBEntities WebshopDBEntities { get; set; }

        /// <summary>
        /// Dispose.
        /// </summary>
        public void Dispose()
        {
            this.WebshopDBEntities.Dispose();
        }
    }
}
