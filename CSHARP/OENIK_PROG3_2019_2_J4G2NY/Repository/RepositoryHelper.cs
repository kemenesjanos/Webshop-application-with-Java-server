// <copyright file="RepositoryHelper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Webshop.Repository
{
    using Webshop.Data;

    /// <summary>
    /// Helps the repository's usage.
    /// </summary>
    public class RepositoryHelper
    {
        private readonly IRepository<Loc> locRepo;
        private readonly IRepository<Sales> saleRepo;
        private readonly IRepository<Users> userRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryHelper"/> class.
        /// Ctor.
        /// </summary>
        /// <param name="locRepository">loc repository.</param>
        /// <param name="saleRepository">Sale repository.</param>
        /// <param name="userRepository">User repository.</param>
        public RepositoryHelper(IRepository<Loc> locRepository, IRepository<Sales> saleRepository, IRepository<Users> userRepository)
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
        public virtual IRepository<Sales> SaleRepository
        {
            get { return this.saleRepo; }
        }

        /// <summary>
        /// Gets User repository.
        /// </summary>
        public virtual IRepository<Users> UserRepository
        {
            get { return this.userRepo; }
        }
    }
}
