using QIQO.Business.Accounts.Data.Entities;
using QIQO.Business.Accounts.Proxies.Models;
using QIQO.Business.Core.Contracts;

namespace QIQO.Business.Accounts.Proxies.Services
{
    public interface IAccountEntityService : IEntityService<Account, AccountData> { }
    public interface IAddressEntityService : IEntityService<Address, AddressData> { }
    public interface ICommentEntityService : IEntityService<Comment, CommentData> { }
    public interface ICompanyEntityService : IEntityService<Company, CompanyData> { }
    public interface IContactEntityService : IEntityService<Contact, ContactData> { }
    public interface IAttributeEntityService : IEntityService<EntityAttribute, AttributeData> { }
    public interface IFeeScheduleEntityService : IEntityService<FeeSchedule, FeeScheduleData> { }
    public interface IAccountPersonEntityService : IEntityService<AccountPerson, PersonData> { }
    public interface IEmployeeEntityService : IEntityService<Employee, PersonData> { }
}
