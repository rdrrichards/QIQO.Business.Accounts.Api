using QIQO.Business.Core.Contracts;
using System;

namespace QIQO.Business.Accounts.Data.Entities
{
    public class AccountData : CommonData, IEntity
    {
        public int AccountKey { get; set; }
        public int CompanyKey { get; set; }
        public int AccountTypeKey { get; set; }
        public string AccountCode { get; set; }
        public string AccountName { get; set; }
        public string AccountDesc { get; set; }
        public string AccountDba { get; set; }
        public DateTime AccountStartDate { get; set; }
        public DateTime AccountEndDate { get; set; }

        public int EntityRowKey
        {
            get { return AccountKey; }
            set { AccountKey = value; }
        }
    }
}
