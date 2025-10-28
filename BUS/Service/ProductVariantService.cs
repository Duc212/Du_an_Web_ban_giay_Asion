using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Service
{
    public class ProductVariantService
    {
        private readonly ProductVariantRepository _repo;

        public ProductVariantService(ProductVariantRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<ProductVariant>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<ProductVariant> GetByIdAsync(int id)
        {
            var variant = await _repo.GetByIdAsync(id);
            if (variant == null)
                throw new KeyNotFoundException("Variant không tồn tại.");
            return variant;
        }

        public async Task AddAsync(ProductVariant variant)
        {
            if (variant.ImportPrice < 0 || variant.SellingPrice < 0)
                throw new ArgumentException("Giá sản phẩm phải >= 0");

            if (variant.StockQuantity < 0)
                throw new ArgumentException("Số lượng tồn kho phải >= 0");

            await _repo.AddAsync(variant);
        }

        public async Task UpdateAsync(ProductVariant variant)
        {
            var existing = await _repo.GetByIdAsync(variant.VariantID);
            if (existing == null)
                throw new KeyNotFoundException("Variant không tồn tại.");

            existing.ColorID = variant.ColorID;
            existing.SizeID = variant.SizeID;
            existing.ImportPrice = variant.ImportPrice;
            existing.SellingPrice = variant.SellingPrice;
            existing.StockQuantity = variant.StockQuantity;
            existing.Status = variant.Status;

            await _repo.UpdateAsync(existing);
        }

        //public async Task DeleteAsync(int id)
        //{
        //    var variant = await _repo.GetByIdAsync(id);
        //    if (variant == null)
        //        throw new KeyNotFoundException("Variant không tồn tại.");

        //    await _repo.DeleteAsync(variant);
        //}
    }
}
