using DAL;
using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Service
{
    public class AddressService
    {
        private readonly AddressRepository _addressRepo;
        public AddressService(AddressRepository addressRepo)
        {
            _addressRepo = addressRepo;
        }
        public async Task<List<Address>> GettAllAsync()
        {
            return await _addressRepo.GetAllAsync();
        }
        public async Task<Address?> GetByIdAsync(int id)
        {
            var address = await _addressRepo.GetByIdAsync(id);
            if(address == null)
            {
                throw new KeyNotFoundException($"Không tìm thấy địa chỉ ");
            }
            return address;
        }
        public async Task AddAddressAsync(Address address)
        {

            await _addressRepo.AddAsync(address);
        }

        public async Task UpdateAddressAsync(Address address)
        {

            var existing = await _addressRepo.GetByIdAsync(address.AddressID);
            if (existing == null)
                throw new KeyNotFoundException($"Không tìm thấy địa chỉ với Id = {address.AddressID}");

            existing.AddressDetail = address.AddressDetail;
            existing.City = address.City;
            existing.Ward = address.Ward;
            existing.Street = address.Street;

            await _addressRepo.UpdateAsync(existing);
        }

        public async Task DeleteAddressAsync(int addressId)
        {   
            var existing = await _addressRepo.GetByIdAsync(addressId);
            if (existing == null)
                throw new KeyNotFoundException($"Không tìm thấy địa chỉ với Id = {addressId}");

            await _addressRepo.DeleteAsync(existing);
        }
    }
}
