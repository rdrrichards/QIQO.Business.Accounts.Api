using QIQO.Business.Accounts.Proxies.Models;
using QIQO.Business.Core.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QIQO.Business.Accounts.Proxies
{
    public interface IAddressService : IServiceContract
    {
        List<Address> GetAddressesByEntity(int entity_key, QIQOEntityType entity_type);
        List<Address> GetAddressesByCompany(Company company);
        int CreateAddress(Address address);
        bool DeleteAddress(Address address);
        Address GetAddress(int address_key);
        //List<AddressPostal> GetStateListByCountry(string country);
        //AddressPostal GetAddressInfoByPostal(string postal_code);

        
        Task<List<Address>> GetAddressesByEntityAsync(int entity_key, QIQOEntityType entity_type);
        Task<List<Address>> GetAddressesByCompanyAsync(Company company);
        Task<int> CreateAddressAsync(Address address);
        Task<bool> DeleteAddressAsync(Address address);
        Task<Address> GetAddressAsync(int address_key);
        //Task<List<AddressPostal>> GetStateListByCountryAsync(string country);
        //Task<AddressPostal> GetAddressInfoByPostalAsync(string postal_code);
    }

}
