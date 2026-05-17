using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogLookupSystem
{
    public class ProductCatalog
    {

        private Dictionary<string, Product> _products;


        public ProductCatalog()
        {
            _products = new Dictionary<string, Product>();

        }

        private bool IsNullOrEmptyProductList(List<Product> product)
        {
            return product == null || product.Count == 0;
        }

        private bool ValidatePrice(decimal price)
        {
            return price > 0;
        }

        private bool ValidateStock(int stock)
        {
            return stock >= 0;
        }

        private bool ValidateInput(string Code , string Name , string Category)
        {

            return !string.IsNullOrWhiteSpace(Code) && !string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Category);
        }

        private bool ValidateCode(string code)
        {
            return !string.IsNullOrWhiteSpace(code);
        }

        private bool ValidateCategory(string Category)
        {
            return !string.IsNullOrWhiteSpace(Category);
        }

        private bool ProductExists(string code)
        {

            return _products.ContainsKey(code);

        }


        private Product CreateProduct(string code , string name , decimal  price , string category , int stock)
        {

            return new Product(code, name, price, category, stock);
        }

        public void AddProduct(string code, string name, decimal price, string category, int stock)
        {

            if(!ValidateInput(code , name , category))
            {
                Console.WriteLine("You must Enter a valide Code and name and Category");
                return;
            }

            if(!ValidateStock(stock))
            {

                Console.WriteLine("Stock must be >= 0");
                return;

            }

            if (!ValidatePrice(price))
            {
                Console.WriteLine("The Price must be > 0 "); return;
            }

            code = code.Trim().ToUpper();
            name = name.Trim();
            category = category.Trim();


            if (ProductExists(code))
            {
                Console.WriteLine("The Code of this product is alraedy Exists Try Another One");
                return;

            }
            else
            {
                _products.Add(code, CreateProduct(code, name, price, category, stock));
            }

        }

        public void AddOrUpdateProduct(string code, string name, decimal price, string category, int stock)
        {

            if (!ValidateInput(code, name, category))
            {
                Console.WriteLine("You must Enter a valide Code and name and Category");
                return;
            }

            if (!ValidateStock(stock))
            {

                Console.WriteLine("Stock must be >= 0");
                return;

            }

            if (!ValidatePrice(price))
            {
                Console.WriteLine("The Price must be > 0 "); return;
            }

            code = code.Trim().ToUpper();
            name = name.Trim();
            category = category.Trim();


            _products[code] = CreateProduct(code, name, price,category, stock);


        }

        public Product GetProductByCode(string code)
        {

            if (!ValidateCode(code))
            {
                Console.WriteLine("The Code is Invalide you should enter a valide one ");
                return null;
            }

            code = code.Trim().ToUpper();


            if(_products.TryGetValue(code, out Product product))
            {
                return product;
            }
            else
            {
                Console.WriteLine($"No Product Found with this code {code} try a valide one");
                return null;
            }


        }

        public void UpdatePrice(string code, decimal newPrice)
        {

            if (!ValidateCode(code))
            {
                Console.WriteLine("The Code is Invalide you should enter a valide one ");
                return ;
            }

            if (!ValidatePrice(newPrice))
            {

                Console.WriteLine("The New Price must be > 0 "); return;

            }

            code = code.Trim().ToUpper();

            if (_products.TryGetValue(code, out Product product))
            {
               
                product.Price = newPrice;
                return;
            }
            else
            {

                Console.WriteLine($"No Product Found with this code {code} try a valide one");

            }
        }

        public void UpdateStock(string code, int newStock)
        {
            if (!ValidateCode(code))
            {
                Console.WriteLine("The Code is Invalide you should enter a valide one ");
                return;
            }

            if (!ValidateStock(newStock))
            {

                Console.WriteLine("The New stock must be >= 0 "); return;

            }

            code = code.Trim().ToUpper();

            if (_products.TryGetValue(code, out Product product))
            {

                product.Stock = newStock;
                return;
            }
            else
            {

                Console.WriteLine($"No Product Found with this code {code} try a valide one");

            }
        }

        public void DeactivateProduct(string code)
        {

            if (!ValidateCode(code))
            {
                Console.WriteLine("The Code is Invalide you should enter a valide one ");
                return;
            }

            code = code.Trim().ToUpper();

            if (_products.TryGetValue(code, out Product product))
            {

                if(product.IsActive == false)
                {
                    Console.WriteLine("Is Already inactive");
                    return;
                }
                
                  product.IsActive = false;
                 
            }
            else
            {

                Console.WriteLine($"No Product Found with this code {code} try a valide one");

            }


        }

        public void RemoveProduct(string code)
        {

            
            if (!ValidateCode(code))
            {
                Console.WriteLine("The Code is Invalide you should enter a valide one ");
                return;
            }

            code = code.Trim().ToUpper();

            if (_products.Remove(code))
            {
                Console.WriteLine($"The Product with code {code} was deleted successfully");
            }
            else
            {
                Console.WriteLine($"No Product Found with this code {code} try a valide one");
            }

        }

        public bool ContainsProduct(string code)
        {
            if (!ValidateCode(code))
            {
                Console.WriteLine("The Code is Invalide you should enter a valide one ");
                return false;
            }

            code = code.Trim().ToUpper();

            return ProductExists(code);
        }

        public void ShowProducts(List<Product> products)
        {
            if (IsNullOrEmptyProductList(products))
            {
                Console.WriteLine("No Product To Show");
                return;
            }

            foreach (Product product in products)
            {

                Console.WriteLine("-------------------------------------------\n");

                Console.WriteLine($"Code      : {product.Code}");
                Console.WriteLine($"Name      : {product.Name}");
                Console.WriteLine($"Price     : {product.Price}");
                Console.WriteLine($"Category  : {product.Category}");
                Console.WriteLine($"Stock     : {product.Stock}");
                Console.WriteLine($"Is Active : {(product.IsActive == true ? "Yes" : "No")}");
                Console.WriteLine($"CreatedAt : {product.CreatedAt}");



                Console.WriteLine("\n-------------------------------------------\n");


            }
        }

        public void ShowAllProducts()
        {

            ShowProducts(_products.Values.ToList());
        }

        public void ShowActiveProducts()
        {
            ShowProducts(_products.Values.Where(p => p.IsActive == true).ToList());
        }

        public List<Product> GetProductsByCategory(string category)
        {

            if (!ValidateCategory(category))
            {
                Console.WriteLine("Enter a valide category must be not null or empty");
                return new List<Product>();
            }

            category = category.Trim();

            return _products.Values.Where(p => string.Equals(p.Category , category , StringComparison.OrdinalIgnoreCase)).ToList();


        }

        public List<Product> GetProductsAbovePrice(decimal minPrice)
        {

            if(minPrice < 0)
            {
                Console.WriteLine("The minimum price must be greater than or equal to 0"); return new List<Product>();
            }

            return _products.Values.Where(p => p.Price >  minPrice).ToList();

        }

        public List<Product> GetSortedByPrice()
        {

            return _products.Values.OrderBy(p => p.Price).ToList();
        }

        public List<Product> GetTopExpensiveProducts(int count)
        {

            if(count <= 0)
            {
                Console.WriteLine("The count must be greater than 0 ");
                return new List<Product>();
            }

            return _products.Values.OrderByDescending(p => p.Price).Take(count).ToList();
        }

        public void ShowProductsGroupedByCategory()
        {

            if(_products.Count == 0)
            {
                Console.WriteLine("No products to group");
                return;
            }

            var Category = _products.Values.GroupBy(p =>  p.Category);

            foreach( var group in Category)
            {

                Console.WriteLine($"Category : {group.Key}");

                foreach(Product p in group)
                {

                    Console.WriteLine($"Code   : {p.Code}");
                    Console.WriteLine($"Name   : {p.Name}");
                    Console.WriteLine($"Price  : {p.Price}");

                    Console.WriteLine("\n-----------------------------\n");
                }

            }


        }

        public void ShowStatistics()
        {

            if (_products.Count == 0)
            {
                Console.WriteLine("No statistics available to show");
                return;
            }

           
            int ActiveCount = _products.Values.Count(p =>  p.IsActive );
            int InActiveCount = _products.Values.Count(p => !p.IsActive);
            int sumStock = _products.Values.Sum(p => p.Stock);
            decimal AvrgPrice = _products.Values.Average(p => p.Price);
            Product MostExpP = _products.Values.OrderByDescending(p => p.Price).FirstOrDefault();
            Product chpestPr = _products.Values.OrderBy(p => p.Price).FirstOrDefault();
            int CountCategory = _products.Values.Select(p => p.Category).Distinct().Count();

            Console.WriteLine("\t\tStatistics of Catalog\t\t");

            Console.WriteLine("\n-----------------------------------------------\n");

            Console.WriteLine($"Total Products    : {_products.Count}");
            Console.WriteLine($"Active products   : {ActiveCount}");
            Console.WriteLine($"InActive Products : {InActiveCount}");
            Console.WriteLine($"Total Stock Qt    : {sumStock}");
            Console.WriteLine($"Avg Price         : {AvrgPrice}");
            Console.WriteLine("Most expensive product : ");
            Console.WriteLine("\n-----------------------------\n");
            Console.WriteLine($"Code   : {MostExpP.Code}");
            Console.WriteLine($"Name   : {MostExpP.Name}");
            Console.WriteLine($"Price  : {MostExpP.Price}");
            Console.WriteLine("\n-----------------------------\n");
            Console.WriteLine(" Cheapest product      : ");
            Console.WriteLine("\n-----------------------------\n");
            Console.WriteLine($"Code   : {chpestPr.Code}");
            Console.WriteLine($"Name   : {chpestPr.Name}");
            Console.WriteLine($"Price  : {chpestPr.Price}");
            Console.WriteLine("\n-----------------------------\n");
            Console.WriteLine($"Number of Category : {CountCategory} ");



            Console.WriteLine("\n-----------------------------------------------\n");


        }

        public void ClearCatalog()
        {

            if(_products.Count == 0)
            {
                Console.WriteLine("Catalog already empty");
                return;
            }

            _products.Clear();
            Console.WriteLine("Catalog cleared");
        }
    }

}
