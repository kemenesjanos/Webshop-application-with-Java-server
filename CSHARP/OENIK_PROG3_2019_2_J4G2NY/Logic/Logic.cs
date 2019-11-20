﻿// <copyright file="Logic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop.Data;
using Webshop.Repository;

namespace Webshop.Logic
{
    /// <summary>
    /// Logic class.
    /// </summary>
    public class Logic : ILogic
    {
        /// <summary>
        /// Repo helper.
        /// </summary>
        private RepositoryHelper repoHelper;

        /// <summary>
        /// Initializes a new instance of the <see cref="Logic"/> class.
        /// Ctor.
        /// </summary>
        /// <param name="repositoryHelper">repo helper.</param>
        public Logic(RepositoryHelper repositoryHelper)
        {
            this.repoHelper = repositoryHelper;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Logic"/> class.
        /// Empty ctor.
        /// </summary>
        public Logic()
        {
            this.repoHelper = new RepositoryHelper(new LocRepository(), new SaleRepository(), new UserRepository());
        }

        /// <summary>
        /// Delete location.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>Bool success.</returns>
        public bool DeleteLocation(decimal id)
        {
            if (this.repoHelper.LocRepository.Get(id) != null)
            {
                this.repoHelper.LocRepository.Delete(id);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Delete user.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>Bool success.</returns>
        public bool DeleteSale(decimal id)
        {
            if (this.repoHelper.SaleRepository.Get(id) != null)
            {
                this.repoHelper.SaleRepository.Delete(id);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Delete user.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>Bool success.</returns>
        public bool DeleteUser(decimal id)
        {
            if (this.repoHelper.UserRepository.Get(id) != null)
            {
                this.repoHelper.UserRepository.Delete(id);
                return true;
            }
            else
            {
                return false;
            }
        }

        public int EquityRatioRequestJava(int price)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get all locations.
        /// </summary>
        /// <returns>IEnumerable loc.</returns>
        public IEnumerable<Loc> GetAllLocations()
        {
            return this.repoHelper.LocRepository.GetAll();
        }

        /// <summary>
        /// Get all sales.
        /// </summary>
        /// <returns>IEnumerable sales.</returns>
        public IEnumerable<Sale> GetAllSales()
        {
            return this.repoHelper.SaleRepository.GetAll();
        }

        /// <summary>
        /// Get all Users.
        /// </summary>
        /// <returns>IEnumerable users.</returns>
        public IEnumerable<User> GetAllUsers()
        {
            return this.repoHelper.UserRepository.GetAll();
        }

        /// <summary>
        /// Get loc by id.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>Location.</returns>
        public Loc GetLocByID(decimal id)
        {
            return this.repoHelper.LocRepository.Get(id);
        }

        /// <summary>
        /// Get sale by id.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>Sale.</returns>
        public Sale GetSaleByID(decimal id)
        {
            return this.repoHelper.SaleRepository.Get(id);
        }

        /// <summary>
        /// Get user by id.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>User.</returns>
        public User GetUserByID(decimal id)
        {
            return this.repoHelper.UserRepository.Get(id);
        }

        public int HowMuchThePeopleOfThisCountrySpentAVG(string cityName)
        {
            if (this.GetAllLocations().Select(s => s.Country).Contains(cityName))
            {
                return (int)this.GetAllSales().Where(w => w.User1.Loc.Country == cityName).Select(s => s.Price).Average();
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// Insert Location data.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="country">country.</param>
        /// <param name="street">street.</param>
        /// <param name="house_number">house number.</param>
        /// <param name="zip_code">zip code.</param>
        /// <returns>bool success.</returns>
        public bool InsertLocationData(decimal id, string country, string street, decimal house_number, decimal zip_code)
        {
            if (this.repoHelper.LocRepository.Get(id) == null && zip_code < 10000 && zip_code > 999 && house_number > 0)
            {
                Loc l = new Loc()
                {
                    ID = id,
                    Country = country,
                    Street = street,
                    House_Number = house_number,
                    Zip_Code = zip_code,
                };
                this.repoHelper.LocRepository.Add(l);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Insert sales data.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="transaction_Date">transaction date.</param>
        /// <param name="product_Name">product name.</param>
        /// <param name="price">price.</param>
        /// <param name="category">category.</param>
        /// <param name="shipping_Cost">shipping cost.</param>
        /// <param name="sellerId">seller id.</param>
        /// <param name="buyerId">buyer id.</param>
        /// <returns>Bool success.</returns>
        public bool InsertSalesData(decimal id, DateTime transaction_Date, string product_Name, decimal price, string category, decimal shipping_Cost, decimal sellerId, decimal buyerId)
        {
            ;
            if (this.repoHelper.SaleRepository.Get(id) == null && shipping_Cost >= 0 && price >= 0 &&
                this.repoHelper.UserRepository.Get(sellerId) != null && this.repoHelper.UserRepository.Get(buyerId) != null && "ruházat,elektronika,háztartási,élelmiszer,mezőgazdasági,papír - írószer,játék,gépjármű,egyéb".Split(',').Contains(category))
            {
                Sale s = new Sale()
                {
                    ID = id,
                    Transaction_Date = transaction_Date,
                    Product_Name = product_Name,
                    Price = price,
                    Category = category,
                    Shipping_Cost = shipping_Cost,
                    Seller_ID = sellerId,
                    Buyer_ID = buyerId,
                };
                this.repoHelper.SaleRepository.Add(s);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Insert Users data.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="fullName">full name.</param>
        /// <param name="email">email.</param>
        /// <param name="phone_Number">phone number.</param>
        /// <param name="birth_Date">birth date.</param>
        /// <param name="registration_Date">registration date.</param>
        /// <param name="locId">loc id.</param>
        /// <returns>Bool success.</returns>
        public bool InsertUsersData(decimal id, string fullName, string email, decimal phone_Number, DateTime birth_Date, DateTime registration_Date, decimal locId)
        {
            if (this.repoHelper.UserRepository.Get(id) == null && phone_Number > 999999999 && this.repoHelper.LocRepository.Get(locId) != null)
            {
                DBHandler.Instance.Dispose();
                User u = new User()
                {
                    ID = id,
                    FullName = fullName,
                    Email = email,
                    Phone_Number = phone_Number,
                    Birth_Date = birth_Date,
                    Registration_Date = registration_Date,
                    Location_ID = locId,

                    // Loc = this.repoHelper.LocRepository.Get(locId),
                };
                this.repoHelper.UserRepository.Add(u);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Select Sales Where The Seller And The Buyer In The Same Country.
        /// </summary>
        /// <returns>The sales.</returns>
        public IQueryable<Sale> SelectSalesWhereTheSellerAndTheBuyerInTheSameCountry()
        {
            return this.repoHelper.SaleRepository.GetAll().Where(x => x.User.Loc.Country == x.User1.Loc.Country).AsQueryable();
        }

        /// <summary>
        /// Select Users Where Is No Sale.
        /// </summary>
        /// <returns>the users.</returns>
        public IQueryable<User> SelectUsersWhereIsNoSale()
        {
            return this.repoHelper.UserRepository.GetAll().Where(x => !this.repoHelper.SaleRepository.GetAll().Select(c => c.Seller_ID).Contains(x.ID) &&
            !this.repoHelper.SaleRepository.GetAll().Select(c => c.Buyer_ID).Contains(x.ID)).AsQueryable();
        }

        /// <summary>
        /// Select Users Where They Are Only Buyers.
        /// </summary>
        /// <returns>The users.</returns>
        public IQueryable<User> SelectUsersWhereTheyAreOnlyBuyers()
        {
            return this.repoHelper.UserRepository.GetAll().Where(x => !this.repoHelper.SaleRepository.GetAll().Select(c => c.Seller_ID).Contains(x.ID) &&
            this.repoHelper.SaleRepository.GetAll().Select(c => c.Buyer_ID).Contains(x.ID)).AsQueryable();
        }

        /// <summary>
        /// Select Users Where They Are Only Sellers.
        /// </summary>
        /// <returns>The users.</returns>
        public IQueryable<User> SelectUsersWhereTheyAreOnlySellers()
        {
            return this.repoHelper.UserRepository.GetAll().Where(x => this.repoHelper.SaleRepository.GetAll().Select(c => c.Seller_ID).Contains(x.ID) &&
            !this.repoHelper.SaleRepository.GetAll().Select(c => c.Buyer_ID).Contains(x.ID)).AsQueryable();
        }

        /// <summary>
        /// Update Location.
        /// </summary>
        /// <param name="oldid">old id.</param>
        /// <param name="newLoc">new Loc.</param>
        /// <returns>Bool Success.</returns>
        public bool UpdateLocation(decimal oldid, Loc newLoc)
        {
            if (this.repoHelper.LocRepository.Get(oldid) != null && this.repoHelper.LocRepository.Get(newLoc.ID) == null && newLoc.Zip_Code < 10000 && newLoc.Zip_Code > 999 && newLoc.House_Number > 0)
            {
                this.repoHelper.LocRepository.Delete(oldid);
                this.repoHelper.LocRepository.Add(newLoc);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Update sale.
        /// </summary>
        /// <param name="oldid">old id.</param>
        /// <param name="newSale">new sale.</param>
        /// <returns>Bool success.</returns>
        public bool UpdateSale(decimal oldid, Sale newSale)
        {
            if (this.repoHelper.SaleRepository.Get(oldid) != null && this.repoHelper.SaleRepository.Get(newSale.ID) == null && newSale.Shipping_Cost >= 0 && newSale.Price >= 0 &&
                this.repoHelper.UserRepository.Get((decimal)newSale.Seller_ID) != null && this.repoHelper.UserRepository.Get((decimal)newSale.Buyer_ID) != null && "ruházat,elektronika,háztartási,élelmiszer,mezőgazdasági,papír - írószer,játék,gépjármű,egyéb".Split(',').Contains(newSale.Category))
            {
                this.repoHelper.SaleRepository.Delete(oldid);
                this.repoHelper.SaleRepository.Add(newSale);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Update User.
        /// </summary>
        /// <param name="oldid">old id.</param>
        /// <param name="newUser">new user.</param>
        /// <returns>bool success.</returns>
        public bool UpdateUser(decimal oldid, User newUser)
        {
            if (this.repoHelper.UserRepository.Get(oldid) != null && this.repoHelper.UserRepository.Get(newUser.ID) == null && newUser.Phone_Number > 999999999 && this.repoHelper.LocRepository.Get((decimal)newUser.Location_ID) != null)
            {
                this.repoHelper.UserRepository.Delete(oldid);
                this.repoHelper.UserRepository.Add(newUser);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Which Category People In This Age Group Spent The Most.
        /// </summary>
        /// <param name="minAge">Min age.</param>
        /// <param name="maxAge">Max age.</param>
        /// <returns>The category.</returns>
        public string WhichCategoryPeopleInThisAgeGroupSpentTheMost(int minAge, int maxAge)
        {
            if (minAge <= maxAge && minAge >= 0 && maxAge >= 0)
            {
                var agegroup = this.repoHelper.UserRepository.GetAll().Where(x => (DateTime.Today.Year - x.Birth_Date.Value.Year) >=  minAge &&
                (DateTime.Today.Year - x.Birth_Date.Value.Year) <= maxAge).Select(h => h.ID);

                var gr = this.repoHelper.SaleRepository.GetAll().Where(w => agegroup.Contains((decimal)w.Buyer_ID))
                            .GroupBy(g => g.Category).OrderByDescending(o => o.Sum(s => s.Price));

                if (!(gr.FirstOrDefault() is null))
                {
                    var cat = gr.FirstOrDefault().FirstOrDefault().Category;

                    var price = gr.FirstOrDefault().Sum(s => s.Price);

                    return minAge + " és " + maxAge + " éves kor között a(z) " +
                        cat + " kategóriára költöttek a legtöbbet, " + price + " ft ot.";
                }
                else
                {
                    return "Nincs a korosztályban vásárló.";
                }
            }
            else
            {
                return "Helytelen paraméterek.";
            }
        }
    }
}
