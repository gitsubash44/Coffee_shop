using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee_shop
{
     public class CoffeeList
    {
        public List<Coffee> AllCoffees { get; set; }

        public CoffeeList()
        {
            AllCoffees = new List<Coffee>();
        }
    }
}
