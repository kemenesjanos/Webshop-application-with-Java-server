// <copyright file="WrongParameterException.cs" company="PlaceholderCompany">
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
    /// WrongParameterException.
    /// </summary>
    public class WrongParameterException : Exception
    {
        /// <summary>
        /// Gets or sets the wrong parameter Object.
        /// </summary>
        public object Obj { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WrongParameterException"/> class.
        /// WrongParameterException ctor.
        /// </summary>
        /// <param name="obj">the wrong parameter Object.</param>
        public WrongParameterException(object obj)
        {
            this.Obj = obj;
        }
    }
}
