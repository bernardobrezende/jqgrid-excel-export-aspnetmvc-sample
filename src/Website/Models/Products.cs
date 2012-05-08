using System.Collections.Generic;

namespace Website.Models
{
    public interface Products
    {
        IEnumerable<Product> All();
    }
}
