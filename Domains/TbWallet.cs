using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbWallet
    {
        public Guid? WalletId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string TransactionType { get; set; }
        public string TransactionValue { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }
    }
}
