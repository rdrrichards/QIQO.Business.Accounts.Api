using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QIQO.Business.Accounts.Proxies.Models;
using QIQO.Business.Accounts.Data.Interfaces;
using QIQO.Business.Accounts.Proxies.Services;

namespace QIQO.Business.Accounts.Proxies.Clients
{
    public class AddressClient : ClientBase, IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IAddressEntityService _addressEntityService;

        public AddressClient(IAddressRepository addressRepository, IAddressEntityService addressEntityService)
        {
            _addressRepository = addressRepository;
            _addressEntityService = addressEntityService;
        }
        public int SaveAddress(Address address)
        {
            return ExecuteHandledOperation(() => { return _addressRepository.Save(_addressEntityService.Map(address)); });
        }

        public Task<int> SaveAddressAsync(Address address)
        {
            return Task.Run(() => SaveAddress(address));
        }

        public bool DeleteAddress(Address address)
        {
            return ExecuteHandledOperation(() =>
            {
                _addressRepository.Delete(_addressEntityService.Map(address));
                return true;
            });
        }

        public Task<bool> DeleteAddressAsync(Address address)
        {
            return Task.Run(() => DeleteAddress(address));
        }

        public Address GetAddress(int address_key)
        {
            return ExecuteHandledOperation(() => { return _addressEntityService.Map(_addressRepository.GetByID(address_key)); });
        }

        public Task<Address> GetAddressAsync(int address_key)
        {
            return Task.Run(() => GetAddress(address_key));
        }

        public List<Address> GetAddressesByEntity(int entity_key, QIQOEntityType entity_type)
        {
            return ExecuteHandledOperation(() => { return _addressEntityService.Map(_addressRepository.GetAll(entity_key, (int)entity_type)); });
        }

        public Task<List<Address>> GetAddressesByEntityAsync(int entity_key, QIQOEntityType entity_type)
        {
            return Task.Run(() => GetAddressesByEntity(entity_key, entity_type));
        }
    }
}
