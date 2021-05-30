using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    /// <summary>
    /// The resource for all Products.
    /// </summary>
    public class ProductResource
    {
        /// <summary>
        /// Unique identifier for the object.
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Whether the product is currently available for purchase.
        /// </summary>
        public bool Active { get; set; }
        /// <summary>
        /// The product’s description, meant to be displayable to the customer. Use this field to optionally store a long form explanation of the product being sold for your own rendering purposes.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Set of key-value pairs that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        /// </summary>
        public Dictionary<string, string> Metadata { get; set; }
        /// <summary>
        /// The product’s name, meant to be displayable to the customer. Whenever this product is sold via a subscription, name will show up on associated invoice line item descriptions.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// A list of up to 8 URLs of images for this product, meant to be displayable to the customer.
        /// </summary>
        public string[] Images { get; set; }
        /// <summary>
        /// Whether this product is shipped (i.e., physical goods).
        /// </summary>
        public bool Shippable { get; set; }
        /// <summary>
        /// A URL of a publicly-accessible webpage for this product.
        /// </summary>
        public string Url { get; set; }
    }
}
