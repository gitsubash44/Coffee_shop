﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee_shop
{
    public class Coffee
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }

        // Constructor that generates a new unique ID
        public Coffee()
        {
            ID = Guid.NewGuid();
        }

    }
}
