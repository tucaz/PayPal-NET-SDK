using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayPal.Sample.Utilities
{
    public class SampleItem
    {
        /// <summary>
        /// Gets or sets the title of the entry that will appear as a line item on the main Default.aspx page.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets an optional note to include with the title (e.g. needing an Authorization Code for making a Future Payment)
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Gets or sets the ASPX page that will be called to run this sample.
        /// </summary>
        public string ExecutePage { get; set; }

        /// <summary>
        /// Gets or sets the ASPX page that contains the source code for this sample.
        /// </summary>
        public string SourcePage { get; set; }
    }
}