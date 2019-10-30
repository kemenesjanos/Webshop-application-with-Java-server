using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    /// <summary>
    /// CRUD methods interface.
    /// </summary>
    interface IRepository
    {
        /// <summary>
        /// CREAT.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        void Add<T>(T obj);
        /// <summary>
        /// READ.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        T Get<T>(int id);
        /// <summary>
        /// UPDATE.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="oldid"></param>
        /// <param name="newobject"></param>
        void Update<T>(int oldid, T newobject);
        /// <summary>
        /// DELETE.
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);
    }
}
