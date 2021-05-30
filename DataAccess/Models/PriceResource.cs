using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    /// <summary>
    /// The resource for all Prices.
    /// </summary>
    public class PriceResource
    {
        /// <summary>
        /// Unique identifier for the object.
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Whether the price can be used for new purchases.
        /// </summary>
        public bool Active { get; set; }
        /// <summary>
        /// Three-letter ISO currency code, in lowercase.
        /// </summary>
        public string Currency { get; set; }
        /// <summary>
        /// Set of key-value pairs that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        /// </summary>
        public Dictionary<string, string> Metadata { get; set; }
        /// <summary>
        /// The ID of the product this price is associated with.
        /// </summary>
        public string Product { get; set; }
        /// <summary>
        /// One of one_time or recurring depending on whether the price is for a one-time purchase or a recurring (subscription) purchase.
        /// </summary>
        public string Type { get; set; }

    }
}
