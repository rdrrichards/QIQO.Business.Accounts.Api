using QIQO.Business.Accounts.Data.Entities;
using QIQO.Business.Accounts.Proxies.Models;

namespace QIQO.Business.Accounts.Proxies.Services
{
    public class AccountEntityService : IAccountEntityService
    {
        public Account Map(AccountData ent)
        {
            return new Account
            {
                AccountCode = ent.AccountCode,
                AccountName = ent.AccountName,
                AccountDesc = ent.AccountDesc,
                AccountDBA = ent.AccountDba,
                AccountStartDate = ent.AccountStartDate,
                AccountEndDate = ent.AccountEndDate,
                AccountKey = ent.AccountKey,
                AccountType = (QIQOAccountType)ent.AccountTypeKey,
            };
        }

        public AccountData Map(Account ent)
        {
            return new AccountData
            {
                AccountCode = ent.AccountCode,
                AccountName = ent.AccountName,
                AccountDesc = ent.AccountDesc,
                AccountDba = ent.AccountDBA,
                AccountStartDate = ent.AccountStartDate,
                AccountEndDate = ent.AccountEndDate,
                AccountKey = ent.AccountKey,
                AccountTypeKey = (int)ent.AccountType,
            };
        }
    }
}
