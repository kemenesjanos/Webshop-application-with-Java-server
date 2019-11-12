// <copyright file="LogicTester.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Webshop.Data;
using Webshop.Logic;
using Webshop.Repository;

namespace Webshop.Logic.Tests
{
    /// <summary>
    /// The tester class.
    /// </summary>
    [TestFixture]
    public class LogicTester
    {
        /// <summary>
        /// Test Get all.
        /// </summary>
        [Test]
        public void Test_GetAll()
        {
            RepositoryHelper mockrepoHelper;
            Mock<IRepository<User>> mockRepoUsers;
            Mock<IRepository<Sale>> mockRepoSales;
            Mock<IRepository<Loc>> mockRepoLoc;
            Logic mockLogic;

            mockRepoUsers = new Mock<IRepository<User>>();
            mockRepoSales = new Mock<IRepository<Sale>>();
            mockRepoLoc = new Mock<IRepository<Loc>>();

            mockRepoLoc.Setup(x => x.GetAll()).Returns(new List<Loc>()
            {
                    new Loc() { ID = 1, Country = "AA", Street = "aa", House_Number = 1, Zip_Code = 1111 },
                    new Loc() { ID = 2, Country = "BB", Street = "bb", House_Number = 2, Zip_Code = 2222 },
                    new Loc() { ID = 3, Country = "CC", Street = "cc", House_Number = 3, Zip_Code = 3333 },
            });

            mockRepoSales.Setup(x => x.GetAll()).Returns(new List<Sale>()
            {
                new Sale() { Product_Name = "AA", ID = 1, Price = 2000, Buyer_ID = 1, Seller_ID = 2, Category = "egyéb", Shipping_Cost = 1000, Transaction_Date = DateTime.Parse("2015.01.01") },
                new Sale() { Product_Name = "BB", ID = 2, Price = 3000, Buyer_ID = 2, Seller_ID = 3, Category = "egyéb", Shipping_Cost = 2000, Transaction_Date = DateTime.Parse("2015.01.01") },
                new Sale() { Product_Name = "CC", ID = 3, Price = 4000, Buyer_ID = 3, Seller_ID = 1, Category = "egyéb", Shipping_Cost = 3000, Transaction_Date = DateTime.Parse("2015.01.01") },
            });

            mockRepoUsers.Setup(x => x.GetAll()).Returns(new List<User>()
                {
                new User() { Birth_Date = DateTime.Parse("1999.06.14"), ID = 1, Email = "AAgmail", FullName = "AA", Location_ID = 1, Phone_Number = 1111111111, Registration_Date = DateTime.Parse("2010.01.01") },
                new User() { Birth_Date = DateTime.Parse("2000.01.01"), ID = 2, Email = "BBgmail", FullName = "BB", Location_ID = 2, Phone_Number = 2222222222, Registration_Date = DateTime.Parse("2018.01.01") },
                new User() { Birth_Date = DateTime.Parse("2001.01.01"), ID = 3, Email = "CCgmail", FullName = "CC", Location_ID = 3, Phone_Number = 3333333333, Registration_Date = DateTime.Parse("2019.01.01") },
                });

            mockrepoHelper = new RepositoryHelper(mockRepoLoc.Object, mockRepoSales.Object, mockRepoUsers.Object);

            mockLogic = new Logic(mockrepoHelper);

            IEnumerable<Sale> testsales = mockLogic.GetAllSales();

            Assert.That(testsales.Count() == 3);
        }

        /// <summary>
        /// Test insert.
        /// </summary>
        [Test]
        public void Test_Insert()
        {
            RepositoryHelper mockrepoHelper;
            Mock<IRepository<User>> mockRepoUsers;
            Mock<IRepository<Sale>> mockRepoSales;
            Mock<IRepository<Loc>> mockRepoLoc;
            Logic mockLogic;

            mockRepoUsers = new Mock<IRepository<User>>();
            mockRepoSales = new Mock<IRepository<Sale>>();
            mockRepoLoc = new Mock<IRepository<Loc>>();

            mockrepoHelper = new RepositoryHelper(mockRepoLoc.Object, mockRepoSales.Object, mockRepoUsers.Object);

            mockLogic = new Logic(mockrepoHelper);

            mockLogic.InsertLocationData(50, "A", "A", 20, -1111);

            mockRepoLoc.Verify(x => x.Add(It.IsAny<Loc>()), Times.Never());

            mockLogic.InsertLocationData(50, "A", "A", 20, 11111);

            mockRepoLoc.Verify(x => x.Add(It.IsAny<Loc>()), Times.Never());

            mockLogic.InsertLocationData(50, "A", "A", 20, 1111);

            mockRepoLoc.Verify(x => x.Add(It.IsAny<Loc>()), Times.Once());
        }

        /// <summary>
        /// Test get by id.
        /// </summary>
        [Test]
        public void Test_GetByID()
        {
            RepositoryHelper mockrepoHelper;
            Mock<IRepository<User>> mockRepoUsers;
            Mock<IRepository<Sale>> mockRepoSales;
            Mock<IRepository<Loc>> mockRepoLoc;
            Logic mockLogic;

            mockRepoUsers = new Mock<IRepository<User>>();
            mockRepoSales = new Mock<IRepository<Sale>>();
            mockRepoLoc = new Mock<IRepository<Loc>>();

            mockrepoHelper = new RepositoryHelper(mockRepoLoc.Object, mockRepoSales.Object, mockRepoUsers.Object);

            mockLogic = new Logic(mockrepoHelper);

            Loc test = mockLogic.GetLocByID(1);

            mockRepoLoc.Verify(x => x.Get(It.IsAny<decimal>()), Times.Once);
        }

        /// <summary>
        /// Test Delete.
        /// </summary>
        [Test]
        public void Test_Delete()
        {
            RepositoryHelper mockrepoHelper;
            Mock<IRepository<User>> mockRepoUsers;
            Mock<IRepository<Sale>> mockRepoSales;
            Mock<IRepository<Loc>> mockRepoLoc;
            Logic mockLogic;

            mockRepoUsers = new Mock<IRepository<User>>();
            mockRepoSales = new Mock<IRepository<Sale>>();
            mockRepoLoc = new Mock<IRepository<Loc>>();

            mockrepoHelper = new RepositoryHelper(mockRepoLoc.Object, mockRepoSales.Object, mockRepoUsers.Object);

            mockLogic = new Logic(mockrepoHelper);

            bool test = mockLogic.DeleteLocation(10);

            Assert.That(test == false);
        }

        /// <summary>
        /// Test Update.
        /// </summary>
        [Test]
        public void Test_Update()
        {
            RepositoryHelper mockrepoHelper;
            Mock<IRepository<User>> mockRepoUsers;
            Mock<IRepository<Sale>> mockRepoSales;
            Mock<IRepository<Loc>> mockRepoLoc;
            Logic mockLogic;

            mockRepoUsers = new Mock<IRepository<User>>();
            mockRepoSales = new Mock<IRepository<Sale>>();
            mockRepoLoc = new Mock<IRepository<Loc>>();

            mockrepoHelper = new RepositoryHelper(mockRepoLoc.Object, mockRepoSales.Object, mockRepoUsers.Object);

            mockLogic = new Logic(mockrepoHelper);

            bool test = mockLogic.UpdateLocation(10, It.IsAny<Loc>());

            Assert.That(test == false);
        }
    }
}
