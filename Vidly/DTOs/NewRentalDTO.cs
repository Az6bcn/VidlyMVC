﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.DTOs
{
    public class NewRentalDTO
    {
        public int CustomerID { get; set; }
        public List<int> MovieIDs { get; set; }
    }
}