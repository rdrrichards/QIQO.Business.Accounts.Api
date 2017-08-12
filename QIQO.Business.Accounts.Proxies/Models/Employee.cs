using System;
using System.Collections.Generic;

namespace QIQO.Business.Accounts.Proxies.Models
{
    public class Employee : PersonBase
    {
        public int ParentEmployeeKey { get; set; }
        public List<Company> Companies { get; set; } = new List<Company>();
        public string RoleInCompany { get; set; }
        public int EntityPersonKey { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Comment { get; set; }
        public QIQOPersonType CompanyRoleType { get; set; } = QIQOPersonType.EmployeeHourly;
    }

}
