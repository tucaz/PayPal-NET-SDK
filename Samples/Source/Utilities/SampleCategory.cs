using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayPal.Sample.Utilities
{
    public class SampleCategory
    {
        /// <summary>
        /// Gets or sets the title of this sample category (e.g. Payments, Sale, Vault, etc.)
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the anchor ID for the category.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the hyperlink for the title.
        /// </summary>
        public string Href { get; set; }

        /// <summary>
        /// Gets or sets the list of SampleItems to be included in this category.
        /// </summary>
        public List<SampleItem> Items { get; set; }

        /// <summary>
        /// Default constructor that initializes the Items list.
        /// </summary>
        public SampleCategory()
        {
            this.Items = new List<SampleItem>();
        }
    }
}