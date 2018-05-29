﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.Models
{
    public interface IDb
    {
        IList<Book> Books { get; set; }
        IList<Customer> Customers { get; set; }
    }
}
