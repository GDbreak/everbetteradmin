using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    /// <summary>
    /// The detailed resource for all Products.
    /// </summary>
    public class ProductDetailsResource : ProductResource
    {
        /// <summary>
        /// The price objects associated with the product.
        /// </summary>
        public List<PriceResource> Prices { get; set; }
    }
}
