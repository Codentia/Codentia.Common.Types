using System;
using System.Collections.Generic;
using System.Text;

namespace MattchedIT.Common
{
    /// <summary>
    /// Common Interface describing a "product" - used for import/export/transfer of product data
    /// </summary>
    public interface IProduct
    {
        /// <summary>
        /// Gets the unique code identifying the product
        /// </summary>
        string Code
        {
            get;
        }

        /// <summary>
        /// Gets or sets the title of the product (short description)
        /// </summary>
        string Title
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the detailed (long) description of the product
        /// </summary>
        string Description
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the title of the merchant selling the product
        /// </summary>
        string Merchant
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the URL pointing to a full-size image of the product
        /// </summary>
        string ImageFullSizeUrl
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the URL pointing to a thumbnail image of the product
        /// </summary>
        string ImageThumbnailUrl
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the price of the product in GBP
        /// </summary>
        decimal Price
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the quantity available in stock
        /// </summary>
        int QuantityInStock
        {
            get;
            set;
        }

        /// <summary>
        ///  Gets or sets the weight in grams
        /// </summary>
        decimal Weight
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the Category (String describing the type of product, or categories to which it belongs)
        /// </summary>
        string Category
        {
            get;
        }
    }
}
