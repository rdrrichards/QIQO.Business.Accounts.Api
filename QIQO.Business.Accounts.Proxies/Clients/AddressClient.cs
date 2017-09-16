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
        public void SaveAddress(Address address)
        {
            ExecuteHandledOperation(() => { return _addressRepository.Save(_addressEntityService.Map(address)); });
        }

        public Task SaveAddressAsync(Address address)
        {
            return Task.Run(() => SaveAddress(address));
        }

        public void DeleteAddress(Address address)
        {
            ExecuteHandledOperation(() => { _addressRepository.Delete(_addressEntityService.Map(address));  });
        }

        public Task DeleteAddressAsync(Address address)
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
