﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace feane.Models.ViewModel
{
    public class OrderViewModel
    {
        public IEnumerable<Order> Order { get; set; }

        public IEnumerable<Menu> Menu { get; set; }
    }
}
