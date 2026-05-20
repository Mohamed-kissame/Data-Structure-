using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Product
    {

        public int ProductId { get; set; }

        public string ProductCode { get; set; }

        public string ProductName { get; set; }

        public string Category { get; set; }

        public Decimal Price { get; set; }

        public int StockQuantity { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public Product(int ProductID, string ProductCode, string ProductName, string Category, Decimal Price, int StockQt, bool IsActive, DateTime CreatedAt, DateTime? UpdatedAt)
        {

            this.ProductId = ProductID;
            this.ProductCode = ProductCode;
            this.ProductName = ProductName;
            this.Category = Category;
            this.Price = Price;
            this.StockQuantity = StockQt;
            this.IsActive = IsActive;
            this.CreatedAt = CreatedAt;
            this.UpdatedAt = UpdatedAt;



        }

    }
}
