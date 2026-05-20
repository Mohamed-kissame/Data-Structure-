using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;


namespace BLL
{
    public class ProductManager
    {


        private Dictionary<string, Product> _productByCode;


        public ProductManager()
        {
            _productByCode = new Dictionary<string, Product>();
        }

        private bool IsValidProduct(Product product)
        {
            return product != null;
        }

        private bool IsValidCode(string productCode)
        {
            return !string.IsNullOrWhiteSpace(productCode);
        }

        private bool IsValidName(string productName)
        {
            return !string.IsNullOrWhiteSpace(productName);
        }

        private bool IsValidCategory(string category)

        {
            return !string.IsNullOrWhiteSpace(category);
        }

        private bool IsValidPrice(decimal price)
        {
            return price > 0;
        }
        private bool IsValidStock(int stock)
        {
            return stock >= 0;

        }
        private string NormalizeCode(string productCode)
        {
            return productCode.Trim().ToUpper();
        }


        public void LoadProductsFromDatabase()
        {

            List<Product> products = ProductRepository.GetAllProducts();

            _productByCode.Clear();

            foreach (Product product in products)
            {

                product.ProductCode = NormalizeCode(product.ProductCode);

                if(_productByCode.ContainsKey(product.ProductCode))
                {
                    continue;
                }
                else
                {
                    _productByCode.Add(product.ProductCode, product);
                }

            }

        }

        public  Product GetProductFromCache(string productCode)
        {

            if (!IsValidCode(productCode))
            {
                Console.WriteLine("Enter a valide code without space and the code cannot be null or Empty");
                return null;
            }

            productCode = NormalizeCode(productCode);

            if(_productByCode.TryGetValue(productCode , out Product product))
            {

                return product;

            }
            else
            {
                Console.WriteLine($"No Product Found with this Code {productCode}");
            }


            return null;
        }

        public void AddProduct(Product product)
        {

            if (!IsValidProduct(product))
            {

                Console.WriteLine("The Product Object must be not null");
                return;
            }

            if (!IsValidCode(product.ProductCode))
            {
                Console.WriteLine("Enter a valide code without space and the code cannot be null or Empty");
                return;
            }

            if (!IsValidName(product.ProductName))
            {
                Console.WriteLine("Enter a valide Name without space and the code cannot be null or Empty");
                return;
            }


            if (!IsValidCategory(product.Category))
            {
                Console.WriteLine("Enter a valide Category without space and the code cannot be null or Empty");
                return;
            }

            if(!IsValidPrice(product.Price))
            {
                Console.WriteLine("The Price Must be Greate than 0");
                return;
            }

            if (!IsValidStock(product.StockQuantity))
            {
                Console.WriteLine("The Stock Quantity Must be Greate or equal Zero");
                return;
            }

            product.ProductCode = NormalizeCode(product.ProductCode);
            product.ProductName = product.ProductName.Trim();
            product.Category = product.Category.Trim();


            if (_productByCode.ContainsKey(product.ProductCode)){

                Console.WriteLine($"You Cannot Add this product withe the given Code {product.ProductCode} Because its already Exist Try Another one");
                return;

            }

           int NewProductID = ProductRepository.InsertProduct(product);

            if (NewProductID != -1)
            {

                product.ProductId = NewProductID;
                _productByCode.Add(product.ProductCode, product);
            }
            else
            {
                Console.WriteLine("insert failed");
            }

        }

        public void UpdateProductPrice(string productCode, decimal newPrice)
        {

            Product product = null;

            if (!IsValidCode(productCode))
            {

                Console.WriteLine("Enter a valide code without space and the code cannot be null or Empty");
                return;
            }

            if (!IsValidPrice(newPrice))
            {
                Console.WriteLine("The Price Must be Greate than 0");
                return;
            }

            productCode = NormalizeCode(productCode);

            if (_productByCode.TryGetValue(productCode , out Product Product))
            {
                product = Product;
            }
            else
            {
                Console.WriteLine($"No Product Found with this Code {productCode}");
                return;
            }

            bool Success = ProductRepository.UpdateProductPrice(productCode, newPrice);

            if (Success)
            {
                product.Price = newPrice;
                product.UpdatedAt = DateTime.Now;


            }
            else
            {
                Console.WriteLine("update failed");
            }

        }

        public void UpdateStock(string productCode, int newStock)
        {
            Product product = null;

            if (!IsValidCode(productCode))
            {

                Console.WriteLine("Enter a valide code without space and the code cannot be null or Empty");
                return;
            }

            if (!IsValidStock(newStock))
            {
                Console.WriteLine("The stock quantity must be greater than or equal to 0.");
                return;
            }

            productCode = NormalizeCode(productCode);

            if (_productByCode.TryGetValue(productCode, out Product Product))
            {
                product = Product;
            }
            else
            {
                Console.WriteLine($"No Product Found with this Code {productCode}");
                return;
            }

            bool Success = ProductRepository.UpdateProductStock(productCode, newStock);

            if (Success)
            {
                product.StockQuantity = newStock;
                product.UpdatedAt = DateTime.Now;


            }
            else
            {
                Console.WriteLine("update failed");
            }
        }

        public void DeactivateProduct(string productCode)
        {

            Product product = null;

            if (!IsValidCode(productCode))
            {

                Console.WriteLine("Enter a valide code without space and the code cannot be null or Empty");
                return;
            }

          

            productCode = NormalizeCode(productCode);

            if (_productByCode.TryGetValue(productCode, out Product Product))
            {
                product = Product;

                if(product.IsActive == false)
                {
                    Console.WriteLine("This product its already inactive");
                    return;
                }
            }
            else
            {
                Console.WriteLine($"No Product Found with this Code {productCode}");
                return;
            }

            bool Success = ProductRepository.DeactivateProduct(productCode);

            if (Success)
            {
                product.IsActive = false;
                product.UpdatedAt = DateTime.Now;

            }
            else
            {
                Console.WriteLine("Deactivate failed");
            }
          
        }

        public void RemoveProductFromCacheOnly(string productCode)
        {

            if (!IsValidCode(productCode))
            {

                Console.WriteLine("Enter a valide code without space and the code cannot be null or Empty");
                return;
            }

            productCode = NormalizeCode(productCode);

            if (_productByCode.Remove(productCode))
            {

                Console.WriteLine($"The Product with code {productCode} is deleted successfuly");

            }
            else
            {

                Console.WriteLine($"The Product with code {productCode} is Failed To delete");

            }


        }


        public void DeleteProductFromDatabaseAndCache(string productCode)
        {

           
            if (!IsValidCode(productCode))
            {

                Console.WriteLine("Enter a valide code without space and the code cannot be null or Empty");
                return;
            }



            productCode = NormalizeCode(productCode);

            if (!_productByCode.ContainsKey(productCode))
            {
                Console.WriteLine($"No Product Found with this Code {productCode}");
                return;
            }
          

            bool Success = ProductRepository.DeleteProduct(productCode);

            if (Success)
            {

                _productByCode.Remove(productCode);

            }
            else
            {
                Console.WriteLine("Deleted Failed");
            }

        }

        public void RefreshProductFromDatabase(string productCode)
        {

            Product product = null;



            if (!IsValidCode(productCode))
            {

                Console.WriteLine("Enter a valide code without space and the code cannot be null or Empty");
                return;
            }



            productCode = NormalizeCode(productCode);

            product = ProductRepository.GetProductByCode(productCode);

            if (IsValidProduct(product))
            {
                product.ProductCode = NormalizeCode(product.ProductCode);
                _productByCode[product.ProductCode] = product;

            }
            else
            {
                Console.WriteLine($"No Product Found with this Code {productCode} in database");
                return;
            }

        }

        public void RefreshAllCache()
        {

            LoadProductsFromDatabase();
        }

        public List<Product> GetActiveProductsFromCache()
        {
            return _productByCode.Values.Where(p => p.IsActive).ToList();

        }

        public List<Product> GetProductsByCategoryFromCache(string category)
        {


            if (!IsValidCategory(category))
            {

                Console.WriteLine("Enter a valide Category without space and the code cannot be null or Empty");
                return new List<Product>();

            }

            category = category.Trim().ToUpper();

            return _productByCode.Values.Where(p => String.Equals(p.Category , category , StringComparison.OrdinalIgnoreCase)).ToList();

        }

        public List<Product> GetLowStockProductsFromCache(int threshold)
        {

            if (!IsValidStock(threshold))
            {
                Console.WriteLine("The Stock Quantity Must be Greate or equal Zero");
                return new List<Product>();
            }

            return _productByCode.Values.Where(p => p.StockQuantity <=  threshold).ToList();
        }

        public void ShowProducts(List<Product> products)
        {

            if(products == null || products.Count == 0)
            {
                Console.WriteLine("No products to show");
                return;
            }


            Console.WriteLine("\t\tList Of products\t\t");

            Console.WriteLine("\n=========================================================\n");

            foreach(Product product in products)
            {

                Console.WriteLine($"Product ID     :  {product.ProductId}");
                Console.WriteLine($"Product Code   :  {product.ProductCode}");
                Console.WriteLine($"Product Name   :  {product.ProductName}");
                Console.WriteLine($"Category       :  {product.Category}");
                Console.WriteLine($"Price          :  {product.Price}");
                Console.WriteLine($"Stock Qt       :  {product.StockQuantity}");
                Console.WriteLine($"IsActive       :  {(product.IsActive == true ? "Yes" : "No" )}");
                Console.WriteLine($"Created At     :  {product.CreatedAt}");
                Console.WriteLine($"Updated At     :  {(product.UpdatedAt != null ? product.UpdatedAt.Value.ToShortDateString() : "No Update")}");

                Console.WriteLine("---------------------------------------------------------------\n");



            }

            Console.WriteLine("\n=========================================================\n");

        }

        public void ShowCacheStatistics()
        {

            if (_productByCode.Count == 0)
            {
                Console.WriteLine("No statistics available to show");
                return;
            }


            int ActiveCount = _productByCode.Values.Count(p => p.IsActive);
            int InActiveCount = _productByCode.Values.Count(p => !p.IsActive);
            int sumStock = _productByCode.Values.Sum(p => p.StockQuantity);
            decimal AvrgPrice = _productByCode.Values.Average(p => p.Price);
            Product MostExpP = _productByCode.Values.OrderByDescending(p => p.Price).FirstOrDefault();
            Product chpestPr = _productByCode.Values.OrderBy(p => p.Price).FirstOrDefault();
            int CountCategory = _productByCode.Values.Select(p => p.Category).Distinct().Count();

            Console.WriteLine("\t\tStatistics of Catalog\t\t");

            Console.WriteLine("\n-----------------------------------------------\n");

            Console.WriteLine($"Total Products    : {_productByCode.Count}");
            Console.WriteLine($"Active products   : {ActiveCount}");
            Console.WriteLine($"InActive Products : {InActiveCount}");
            Console.WriteLine($"Total Stock Qt    : {sumStock}");
            Console.WriteLine($"Avg Price         : {AvrgPrice}");
            Console.WriteLine("Most expensive product : ");
            Console.WriteLine("\n-----------------------------\n");
            Console.WriteLine($"Code   : {MostExpP.ProductCode}");
            Console.WriteLine($"Name   : {MostExpP.ProductName}");
            Console.WriteLine($"Price  : {MostExpP.Price}");
            Console.WriteLine("\n-----------------------------\n");
            Console.WriteLine(" Cheapest product      : ");
            Console.WriteLine("\n-----------------------------\n");
            Console.WriteLine($"Code   : {chpestPr.ProductCode}");
            Console.WriteLine($"Name   : {chpestPr.ProductName}");
            Console.WriteLine($"Price  : {chpestPr.Price}");
            Console.WriteLine("\n-----------------------------\n");
            Console.WriteLine($"Number of Category : {CountCategory} ");



            Console.WriteLine("\n-----------------------------------------------\n");
        }

        public void CompareDatabaseVsCacheCount()
        {

            int CountProductInDb = ProductRepository.GetProductsCount();

            int CountProductInCash = _productByCode.Count();

            int missing = CountProductInDb - CountProductInCash;
            int extra = CountProductInCash - CountProductInDb;

            if(CountProductInDb == -1)
            {
                Console.WriteLine("Could not read database count");
                return;
              
            }


            Console.WriteLine($"Database count : {CountProductInDb}");
            Console.WriteLine($"Cash count     : {CountProductInCash}");

            if(CountProductInDb == CountProductInCash)
            {
                Console.WriteLine("Database and cache are synchronized");
                return;
            }

            if(CountProductInDb > CountProductInCash)
            {
                Console.WriteLine($"Cache is missing {missing} product(s)");
                return;
            }

            if(CountProductInCash > CountProductInDb)
            {
                Console.WriteLine($"Cache has {extra} extra product(s)");
                return;
            }

        }
    }
}
