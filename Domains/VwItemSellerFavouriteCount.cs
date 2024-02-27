using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
    public partial class VwItemSellerFavouriteCount
    {
        public Guid? ItemSellerId { get; set; }

        public int NumberOfAdd { get; set; }
    }
}
