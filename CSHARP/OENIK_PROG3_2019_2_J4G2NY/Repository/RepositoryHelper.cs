// <copyright file="RepositoryHelper.cs" company="PlaceholderCompany">
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
    /// Helps the repository's usage.
    /// </summary>
    public class RepositoryHelper
    {
        private readonly IRepository<Loc> locRepo;
        private readonly IRepository<Sale> saleRepo;
        private readonly IRepository<User> userRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryHelper"/> class.
        /// Ctor.
        /// </summary>
        public RepositoryHelper(IRepository<Loc> locRepository, IRepository<Sale> saleRepository, IRepository<User> userRepository)
        {
            this.locRepo = locRepository;
            this.saleRepo = saleRepository;
            this.userRepo = userRepository;
        }

        /// <summary>
        /// Gets loc repository.
        /// </summary>
        public virtual IRepository<Loc> LocRepository
        {
            get { return this.locRepo; }
        }

        /// <summary>
        /// Gets Sale repository.
        /// </summary>
        public virtual IRepository<Sale> SaleRepository
        {
            get { return this.saleRepo; }
        }

        /// <summary>
        /// Gets User repository.
        /// </summary>
        public virtual IRepository<User> UserRepository
        {
            get { return this.userRepo; }
        }

        
    }
}
