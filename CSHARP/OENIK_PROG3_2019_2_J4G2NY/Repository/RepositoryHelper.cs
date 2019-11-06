// <copyright file="RepositoryHelper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop.Repository
{
    /// <summary>
    /// Helps the repository's usage.
    /// </summary>
    public class RepositoryHelper
    {
        private readonly LocRepository locRepo;
        private readonly SaleRepository saleRepo;
        private readonly UserRepository userRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryHelper"/> class.
        /// Ctor.
        /// </summary>
        public RepositoryHelper()
        {
            this.locRepo = new LocRepository();
            this.saleRepo = new SaleRepository();
            this.userRepo = new UserRepository();
        }

        /// <summary>
        /// Gets loc repository.
        /// </summary>
        public virtual LocRepository LocRepository
        {
            get { return this.locRepo; }
        }

        /// <summary>
        /// Gets Sale repository.
        /// </summary>
        public virtual SaleRepository SaleRepository
        {
            get { return this.saleRepo; }
        }

        /// <summary>
        /// Gets User repository.
        /// </summary>
        public virtual UserRepository UserRepository
        {
            get { return this.userRepo; }
        }
    }
}
