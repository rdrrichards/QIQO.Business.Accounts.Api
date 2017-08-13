using System;
using QIQO.Business.Accounts.Data.Entities;
using QIQO.Business.Accounts.Proxies.Models;

namespace QIQO.Business.Accounts.Proxies.Services
{
    public class EmployeeEntityService : IEmployeeEntityService
    {
        public Employee Map(PersonData ent)
        {
            throw new NotImplementedException();
        }

        public PersonData Map(Employee employee)
        {
            PersonData person = new PersonData()
            {
                PersonKey = employee.PersonKey,
                PersonFirstName = employee.PersonFirstName,
                PersonMi = employee.PersonMI,
                PersonLastName = employee.PersonLastName,
                PersonCode = employee.PersonCode,
                PersonDob = employee.PersonDOB
            };
            return person;
        }
        public PersonData Map(AccountPerson employee)
        {
            PersonData person = new PersonData()
            {
                PersonKey = employee.PersonKey,
                PersonFirstName = employee.PersonFirstName,
                PersonMi = employee.PersonMI,
                PersonLastName = employee.PersonLastName,
                PersonCode = employee.PersonCode,
                PersonDob = employee.PersonDOB
            };
            return person;
        }

        public void InitPersonData(AccountPerson person, PersonData emp_data)
        {
            person.PersonKey = emp_data.PersonKey;
            person.PersonCode = emp_data.PersonCode;
            person.PersonFirstName = emp_data.PersonFirstName;
            person.PersonLastName = emp_data.PersonLastName;
            person.PersonDOB = emp_data.PersonDob;
            person.PersonMI = emp_data.PersonMi;
            person.PersonFullNameFL = emp_data.PersonFirstName + " " + emp_data.PersonLastName;
            person.PersonFullNameLF = emp_data.PersonLastName + ", " + emp_data.PersonFirstName;
            person.PersonFullNameLFM = emp_data.PersonLastName + ", " + emp_data.PersonFirstName + " " + emp_data.PersonMi;
            person.PersonFullNameFML = emp_data.PersonFirstName + " " + emp_data.PersonMi + " " + emp_data.PersonLastName;
        }

        public void InitPersonData(Employee person, PersonData emp_data)
        {
            person.PersonKey = emp_data.PersonKey;
            person.PersonCode = emp_data.PersonCode;
            person.PersonFirstName = emp_data.PersonFirstName;
            person.PersonLastName = emp_data.PersonLastName;
            person.PersonDOB = emp_data.PersonDob;
            person.PersonMI = emp_data.PersonMi;
            person.PersonFullNameFL = emp_data.PersonFirstName + " " + emp_data.PersonLastName;
            person.PersonFullNameLF = emp_data.PersonLastName + ", " + emp_data.PersonFirstName;
            person.PersonFullNameLFM = emp_data.PersonLastName + ", " + emp_data.PersonFirstName + " " + emp_data.PersonMi;
            person.PersonFullNameFML = emp_data.PersonFirstName + " " + emp_data.PersonMi + " " + emp_data.PersonLastName;
        }

        //public void Map(EntityPersonData per_data, Employee emp_data)
        //{
        //    emp_data.Comment = per_data.Comment;
        //    emp_data.StartDate = per_data.StartDate;
        //    emp_data.EndDate = per_data.EndDate;
        //    emp_data.CompanyRoleType = (QIQOPersonType)per_data.PersonTypeKey;
        //    emp_data.RoleInCompany = per_data.PersonRole;
        //    emp_data.EntityPersonKey = per_data.EntityPersonKey;
        //    emp_data.AddedUserID = per_data.AuditAddUserId;
        //    emp_data.AddedDateTime = per_data.AuditAddDatetime;
        //    emp_data.UpdateUserID = per_data.AuditUpdateUserId;
        //    emp_data.UpdateDateTime = per_data.AuditUpdateDatetime;
        //}

        //public Employee Map(EntityPersonData emp_data)
        //{
        //    Employee employee = new Employee()
        //    {
        //        PersonKey = emp_data.PersonKey,
        //        Comment = emp_data.Comment,
        //        StartDate = emp_data.StartDate,
        //        EndDate = emp_data.EndDate,
        //        CompanyRoleType = (QIQOPersonType)emp_data.PersonTypeKey,
        //        RoleInCompany = emp_data.PersonRole,
        //        EntityPersonKey = emp_data.EntityPersonKey,
        //        AddedUserID = emp_data.AuditAddUserId,
        //        AddedDateTime = emp_data.AuditAddDatetime,
        //        UpdateUserID = emp_data.AuditUpdateUserId,
        //        UpdateDateTime = emp_data.AuditUpdateDatetime
        //    };
        //    return employee;
        //}
    }
}
