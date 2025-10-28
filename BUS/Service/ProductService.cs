using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Service
{
    public class ProductService
    {
        private readonly ProductRepository _repo;

        public ProductService(ProductRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var product = await _repo.GetByIdAsync(id);
            if (product == null)
                throw new KeyNotFoundException("Product không tồn tại.");
            return product;
        }

        public async Task AddAsync(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.Name))
                throw new ArgumentException("Tên sản phẩm không được để trống.");

            await _repo.AddAsync(product);
        }

        public async Task UpdateAsync(Product updateProduct)
        {
            //check
            if(updateProduct == null) throw new ArgumentNullException(nameof(updateProduct));

            //validate
            if (string.IsNullOrWhiteSpace(updateProduct.Name))
                throw new ArgumentException("Tên sản phẩm không được để trống.");

            if (updateProduct.BrandId <= 0)
                throw new ArgumentException("Thương hiệu sản phẩm không được để trống.");

            if (updateProduct.CategoryId <= 0)
                throw new ArgumentException("Danh mục sản phẩm không được để trống.");

            if (updateProduct.GenderId <= 0)
                throw new ArgumentException("Giới tính sản phẩm không được để trống.");

            // findpro
            var existingProduct = await _repo.GetByIdAsync(updateProduct.ProductID);
            if (existingProduct == null)
                throw new KeyNotFoundException("Không tìm thấy sản phẩm để cập nhật.");
            // updatedata
            existingProduct.Name = updateProduct.Name;
            existingProduct.Description = updateProduct.Description;
            existingProduct.ImageUrl = updateProduct.ImageUrl;
            existingProduct.BrandId = updateProduct.BrandId;
            existingProduct.CategoryId = updateProduct.CategoryId;
            existingProduct.GenderId = updateProduct.GenderId;

            existingProduct.CreatedAt = existingProduct.CreatedAt;
                                                                  

            // update DB
            await _repo.UpdateAsync(existingProduct);
        }
    }
}
