using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
    public partial class VwHighestSalesIteSeller
    {
        public Guid? ItemSellerId { get; set; }

        public int NumberOfSalesTransaction { get; set; }
    }
}
