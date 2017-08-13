using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QIQO.Business.Accounts.Proxies.Models;

namespace QIQO.Business.Accounts.Proxies.Clients
{
    public class AddressClient : IAddressService
    {
        public int CreateAddress(Address address)
        {
            throw new NotImplementedException();
        }

        public Task<int> CreateAddressAsync(Address address)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAddress(Address address)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAddressAsync(Address address)
        {
            throw new NotImplementedException();
        }

        public Address GetAddress(int address_key)
        {
            throw new NotImplementedException();
        }

        public Task<Address> GetAddressAsync(int address_key)
        {
            throw new NotImplementedException();
        }

        public List<Address> GetAddressesByCompany(Company company)
        {
            throw new NotImplementedException();
        }

        public Task<List<Address>> GetAddressesByCompanyAsync(Company company)
        {
            throw new NotImplementedException();
        }

        public List<Address> GetAddressesByEntity(int entity_key, QIQOEntityType entity_type)
        {
            throw new NotImplementedException();
        }

        public Task<List<Address>> GetAddressesByEntityAsync(int entity_key, QIQOEntityType entity_type)
        {
            throw new NotImplementedException();
        }
    }
}
