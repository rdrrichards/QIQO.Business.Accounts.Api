using System;

namespace QIQO.Business.Accounts.Proxies.Models
{
    public class AccountPerson : PersonBase
    {
        public string RoleInCompany { get; set; }
        public int EntityPersonKey { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Comment { get; set; }
        public QIQOPersonType CompanyRoleType { get; set; } = QIQOPersonType.AccountEmployee;
    }
}
