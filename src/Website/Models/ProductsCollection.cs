using System.Collections.Generic;

namespace Website.Models
{
    public class ProductsCollection : Products
    {
        public IEnumerable<Product> All()
        {
            return new[]
            {
                new Product(1, "Prod1"),
                new Product(2, "Prod2"),
                new Product(3, "Prod3"),
                new Product(4, "Prod4"),
            };
        }
    }
}