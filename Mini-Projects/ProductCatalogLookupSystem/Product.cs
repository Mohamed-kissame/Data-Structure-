using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogLookupSystem
{
    public class Product
    {


        public string Code { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Category { get; set; }

        public int Stock { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }


        public Product(string Code , string Name , decimal Price , string Category , int Stock )
        {

            this.Code = Code;
            this.Name = Name;
            this.Price = Price;
            this.Category = Category;
            this.Stock = Stock;
            this.IsActive = true;
            this.CreatedAt = DateTime.Now;
            
        }


    }
}
