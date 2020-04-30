// <copyright file="ILogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Webshop.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Webshop.Data;

    /// <summary>
    /// ILogic.
    /// </summary>
    public interface ILogic
    {
        // CRUD methods

        /// <summary>
        /// Insert data to Location.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="country">country.</param>
        /// <param name="street">street.</param>
        /// <param name="house_Number">house number.</param>
        /// <param name="zip_Code">zip code.</param>
        /// <returns>If the params are good bool.</returns>
        bool InsertLocationData(decimal id, string country, string street, decimal house_Number, decimal zip_Code);

        /// <summary>
        /// Insert data to Sales.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="transaction_Date">transaction date.</param>
        /// <param name="product_Name">product name.</param>
        /// <param name="price">price.</param>
        /// <param name="category">category.</param>
        /// <param name="shipping_Cost">shipping cost.</param>
        /// <param name="sellerId">seller.</param>
        /// <param name="buyerId">buyer.</param>
        /// <returns>If the params are good bool.</returns>
        bool InsertSalesData(decimal id, DateTime transaction_Date, string product_Name, decimal price, string category, decimal shipping_Cost, decimal sellerId, decimal buyerId);

        /// <summary>
        /// Insert data to Users.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="fullName">full name.</param>
        /// <param name="email">email.</param>
        /// <param name="phone_Number">phone number.</param>
        /// <param name="birth_Date">birth date.</param>
        /// <param name="registration_Date">registration date.</param>
        /// <param name="locId">location.</param>
        /// <returns>If the params are good bool.</returns>
        bool InsertUsersData(decimal id, string fullName, string email, decimal phone_Number, DateTime birth_Date, DateTime registration_Date, decimal locId);

        /// <summary>
        /// Get location by id.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>Location.</returns>
        Loc GetLocById(decimal id);

        /// <summary>
        /// Get sale by id.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>Sale.</returns>
        Sales GetSaleById(decimal id);

        /// <summary>
        /// Get user by id.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>user.</returns>
        Users GetUserById(decimal id);

        /// <summary>
        /// Get all Locations.
        /// </summary>
        /// <returns>All location.</returns>
        IEnumerable<Loc> GetAllLocations();

        /// <summary>
        /// Get all sales.
        /// </summary>
        /// <returns>All sale.</returns>
        IEnumerable<Sales> GetAllSales();

        /// <summary>
        /// Get all users.
        /// </summary>
        /// <returns>All users.</returns>
        IEnumerable<Users> GetAllUsers();

        /// <summary>
        /// Update Location.
        /// </summary>
        /// <param name="oldid">oldid.</param>
        /// <param name="newLoc">new Location.</param>
        /// <returns>Bool Success.</returns>
        bool UpdateLocation(decimal oldid, Loc newLoc);

        /// <summary>
        /// Update Sale.
        /// </summary>
        /// <param name="oldid">old id.</param>
        /// <param name="newSale"> new Sale.</param>
        /// <returns>Bool Success.</returns>
        bool UpdateSale(decimal oldid, Sales newSale);

        /// <summary>
        /// Update user.
        /// </summary>
        /// <param name="oldid">old id.</param>
        /// <param name="newUser">new User.</param>
        /// <returns>Bool Success.</returns>
        bool UpdateUser(decimal oldid, Users newUser);

        /// <summary>
        /// Delete location.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>Bool Success.</returns>
        bool DeleteLocation(decimal id);

        /// <summary>
        /// Delete sale.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>Bool Success.</returns>
        bool DeleteSale(decimal id);

        /// <summary>
        /// Delete User.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>Bool Success.</returns>
        bool DeleteUser(decimal id);

        // Non CRUD methods.

        /// <summary>
        /// Select Sales where the Seller and the Buyer In The Same Town.
        /// </summary>
        /// <returns>IQueryable sales.</returns>
        IQueryable<Sales> SelectSalesWhereTheSellerAndTheBuyerInTheSameCountry();

        /// <summary>
        /// SelectUsersWhereTheyAreOnlyBuyers.
        /// </summary>
        /// <returns>IQueryable users.</returns>
        IQueryable<Users> SelectUsersWhereTheyAreOnlyBuyers();

        /// <summary>
        /// SelectUsersWhereTheyAreOnlySellers.
        /// </summary>
        /// <returns>IQueryable users.</returns>
        IQueryable<Users> SelectUsersWhereTheyAreOnlySellers();

        /// <summary>
        /// SelectUsersWhereIsNoSale.
        /// </summary>
        /// <returns>IQueryable users.</returns>
        IQueryable<Users> SelectUsersWhereIsNoSale();

        /// <summary>
        /// HowMuchThePeopleOfThisCitySpentAvg.
        /// </summary>
        /// <param name="countryName">City name.</param>
        /// <returns>Avg spent in this city.</returns>
        int HowMuchThePeopleOfThisCountrySpentAvg(string countryName);

        /// <summary>
        /// WhichCategoryPeopleInThisAgeGroupSpentTheMost.
        /// </summary>
        /// <param name="minAge">min age.</param>
        /// <param name="maxAge">max age.</param>
        /// <returns>Category name.</returns>
        string WhichCategoryPeopleInThisAgeGroupSpentTheMost(int minAge, int maxAge);

        /// <summary>
        /// Request an Equity Ratio from Java.
        /// </summary>
        /// <param name="price">Price.</param>
        /// <returns>Equity Ratio.</returns>
        int ShareholdingRequestJava(int price);
    }
}
