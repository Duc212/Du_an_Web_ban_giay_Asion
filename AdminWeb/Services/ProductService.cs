using AdminWeb.Models;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Forms;

namespace AdminWeb.Services
{
    public class ProductService
    {
        private readonly HttpClient _http;

        public ProductService(HttpClient http)
        {
            _http = http;
        }

        // ============ PRODUCT CRUD ============

        public async Task<GetAllProductsResponse> GetAllProductsAsync(
            int pageIndex = 1,
            int pageSize = 10,
            string keyword = "",
            int? categoryId = null,
            int? brandId = null,
            string sortBy = "name",
            string sortOrder = "asc")
        {
            var query = $"api/ProductAdmin/GetAllProducts?pageIndex={pageIndex}&pageSize={pageSize}";

            if (!string.IsNullOrWhiteSpace(keyword))
                query += $"&keyword={Uri.EscapeDataString(keyword)}";

            if (categoryId.HasValue)
                query += $"&categoryId={categoryId.Value}";

            if (brandId.HasValue)
                query += $"&brandId={brandId.Value}";

            if (!string.IsNullOrWhiteSpace(sortBy))
                query += $"&sortBy={sortBy}";

            if (!string.IsNullOrWhiteSpace(sortOrder))
                query += $"&sortOrder={sortOrder}";

            try
            {
                var response = await _http.GetAsync(query);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<GetAllProductsResponse>()
                        ?? new GetAllProductsResponse();
                }
            }
            catch
            {
                // Log error if needed
            }

            return new GetAllProductsResponse
            {
                Success = false,
                Message = "Lỗi khi tải danh sách sản phẩm"
            };
        }

        public async Task<GetProductDetailResponse> GetProductDetailAsync(int productId)
        {
            try
            {
                var response = await _http.GetAsync($"api/ProductAdmin/GetProductDetail/{productId}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<GetProductDetailResponse>()
                        ?? new GetProductDetailResponse();
                }
            }
            catch
            {
                // Log error if needed
            }

            return new GetProductDetailResponse
            {
                Success = false,
                Message = "Lỗi khi tải chi tiết sản phẩm"
            };
        }

        public async Task<ApiResponse> AddProductAsync(AddProductRequest request)
        {
            try
            {
                var response = await _http.PostAsJsonAsync("api/ProductAdmin/AddProduct", request);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<ApiResponse>()
                        ?? new ApiResponse { Success = false, Message = "Lỗi không xác định" };
                }

                var errorContent = await response.Content.ReadAsStringAsync();
                return new ApiResponse
                {
                    Success = false,
                    Message = $"Lỗi: {response.StatusCode} - {errorContent}"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    Success = false,
                    Message = $"Lỗi: {ex.Message}"
                };
            }
        }

        public async Task<ApiResponse> UpdateProductAsync(UpdateProductRequest request)
        {
            try
            {
                var response = await _http.PutAsJsonAsync("api/ProductAdmin/UpdateProduct", request);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<ApiResponse>()
                        ?? new ApiResponse { Success = false, Message = "Lỗi không xác định" };
                }

                var errorContent = await response.Content.ReadAsStringAsync();
                return new ApiResponse
                {
                    Success = false,
                    Message = $"Lỗi: {response.StatusCode} - {errorContent}"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    Success = false,
                    Message = $"Lỗi: {ex.Message}"
                };
            }
        }

        public async Task<ApiResponse> DeleteProductAsync(int productId)
        {
            try
            {
                var response = await _http.DeleteAsync($"api/ProductAdmin/DeleteProduct/{productId}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<ApiResponse>()
                        ?? new ApiResponse { Success = false, Message = "Lỗi không xác định" };
                }

                var errorContent = await response.Content.ReadAsStringAsync();
                return new ApiResponse
                {
                    Success = false,
                    Message = $"Lỗi: {response.StatusCode} - {errorContent}"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    Success = false,
                    Message = $"Lỗi: {ex.Message}"
                };
            }
        }

        // ============ VARIANTS MANAGEMENT ============

        public async Task<GetVariantsResponse> GetProductVariantsAsync(int productId)
        {
            try
            {
                var response = await _http.GetAsync($"api/ProductAdmin/GetProductVariants/{productId}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<GetVariantsResponse>()
                        ?? new GetVariantsResponse();
                }
            }
            catch
            {
                // Log error if needed
            }

            return new GetVariantsResponse
            {
                Success = false,
                Message = "Lỗi khi tải danh sách variants"
            };
        }

        public async Task<ApiResponse> AddVariantAsync(AddSingleVariantRequest request)
        {
            try
            {
                var response = await _http.PostAsJsonAsync("api/ProductAdmin/AddVariant", request);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<ApiResponse>()
                        ?? new ApiResponse { Success = false, Message = "Lỗi không xác định" };
                }

                var errorContent = await response.Content.ReadAsStringAsync();
                return new ApiResponse
                {
                    Success = false,
                    Message = $"Lỗi: {response.StatusCode} - {errorContent}"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    Success = false,
                    Message = $"Lỗi: {ex.Message}"
                };
            }
        }

        public async Task<ApiResponse> AddVariantAsync(AddVariantRequest request)
        {
            try
            {
                var response = await _http.PostAsJsonAsync("api/ProductAdmin/AddVariant", request);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<ApiResponse>()
                        ?? new ApiResponse { Success = false, Message = "Lỗi không xác định" };
                }

                var errorContent = await response.Content.ReadAsStringAsync();
                return new ApiResponse
                {
                    Success = false,
                    Message = $"Lỗi: {response.StatusCode} - {errorContent}"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    Success = false,
                    Message = $"Lỗi: {ex.Message}"
                };
            }
        }

        public async Task<ApiResponse> UpdateVariantAsync(UpdateVariantRequest request)
        {
            try
            {
                var response = await _http.PutAsJsonAsync("api/ProductAdmin/UpdateVariant", request);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<ApiResponse>()
                        ?? new ApiResponse { Success = false, Message = "Lỗi không xác định" };
                }

                var errorContent = await response.Content.ReadAsStringAsync();
                return new ApiResponse
                {
                    Success = false,
                    Message = $"Lỗi: {response.StatusCode} - {errorContent}"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    Success = false,
                    Message = $"Lỗi: {ex.Message}"
                };
            }
        }



        public async Task<ApiResponse> DeleteVariantAsync(int variantId)
        {
            try
            {
                var response = await _http.DeleteAsync($"api/ProductAdmin/DeleteVariant/{variantId}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<ApiResponse>()
                        ?? new ApiResponse { Success = false, Message = "Lỗi không xác định" };
                }

                var errorContent = await response.Content.ReadAsStringAsync();
                return new ApiResponse
                {
                    Success = false,
                    Message = $"Lỗi: {response.StatusCode} - {errorContent}"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    Success = false,
                    Message = $"Lỗi: {ex.Message}"
                };
            }
        }

        public async Task<ApiResponse> UpdateStockAsync(UpdateStockRequest request)
        {
            try
            {
                var response = await _http.PutAsJsonAsync("api/ProductAdmin/UpdateStock", request);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<ApiResponse>()
                        ?? new ApiResponse { Success = false, Message = "Lỗi không xác định" };
                }

                var errorContent = await response.Content.ReadAsStringAsync();
                return new ApiResponse
                {
                    Success = false,
                    Message = $"Lỗi: {response.StatusCode} - {errorContent}"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    Success = false,
                    Message = $"Lỗi: {ex.Message}"
                };
            }
        }

        // ============ DROPDOWN DATA ============

        public async Task<GetColorsResponse> GetColorsAsync()
        {
            try
            {
                var response = await _http.GetAsync("api/ProductAdmin/GetColors");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<GetColorsResponse>()
                        ?? new GetColorsResponse();
                }
            }
            catch
            {
                // Log error if needed
            }

            return new GetColorsResponse
            {
                Success = false,
                Message = "Lỗi khi tải danh sách màu"
            };
        }

        public async Task<GetSizesResponse> GetSizesAsync()
        {
            try
            {
                var response = await _http.GetAsync("api/ProductAdmin/GetSizes");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<GetSizesResponse>()
                        ?? new GetSizesResponse();
                }
            }
            catch
            {
                // Log error if needed
            }

            return new GetSizesResponse
            {
                Success = false,
                Message = "Lỗi khi tải danh sách size"
            };
        }

        public async Task<GetGendersResponse> GetGendersAsync()
        {
            try
            {
                var response = await _http.GetAsync("api/ProductAdmin/GetGenders");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<GetGendersResponse>()
                        ?? new GetGendersResponse();
                }
            }
            catch
            {
                // Log error if needed
            }

            return new GetGendersResponse
            {
                Success = false,
                Message = "Lỗi khi tải danh sách giới tính"
            };
        }

        // ============ STATISTICS ============

        public async Task<GetStatisticsResponse> GetStatisticsAsync()
        {
            try
            {
                var response = await _http.GetAsync("api/ProductAdmin/GetProductStatistics");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<GetStatisticsResponse>()
                        ?? new GetStatisticsResponse();
                }
            }
            catch
            {
                // Log error if needed
            }

            return new GetStatisticsResponse
            {
                Success = false,
                Message = "Lỗi khi tải thống kê"
            };
        }

        public async Task<GetAllProductsResponse> GetLowStockProductsAsync(
            int pageIndex = 1,
            int pageSize = 10,
            int threshold = 10)
        {
            try
            {
                var query = $"api/ProductAdmin/GetLowStockProducts?pageIndex={pageIndex}&pageSize={pageSize}&threshold={threshold}";
                var response = await _http.GetAsync(query);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<GetAllProductsResponse>()
                        ?? new GetAllProductsResponse();
                }
            }
            catch
            {
                // Log error if needed
            }

            return new GetAllProductsResponse
            {
                Success = false,
                Message = "Lỗi khi tải sản phẩm sắp hết hàng"
            };
        }

        public async Task<UploadImageResponse> UploadImageAsync(IBrowserFile file)
        {
            try
            {
                // Create multipart form data
                using var content = new MultipartFormDataContent();
                
                // Read file content
                var fileContent = new StreamContent(file.OpenReadStream(maxAllowedSize: 5 * 1024 * 1024)); // 5MB max
                fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType);
                content.Add(fileContent, "file", file.Name);

                var response = await _http.PostAsync("api/ProductAdmin/UploadImage", content);
                
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<UploadImageResponse>()
                        ?? new UploadImageResponse { Success = false, Message = "Lỗi khi parse response" };
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    return new UploadImageResponse
                    {
                        Success = false,
                        Message = $"Upload thất bại: {response.StatusCode}"
                    };
                }
            }
            catch (Exception ex)
            {
                return new UploadImageResponse
                {
                    Success = false,
                    Message = $"Lỗi: {ex.Message}"
                };
            }
        }

        public async Task<ApiResponse> AddProductImageAsync(AddProductImageRequest request)
        {
            try
            {
                var response = await _http.PostAsJsonAsync("api/ProductAdmin/AddProductImage", request);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<ApiResponse>()
                        ?? new ApiResponse { Success = false, Message = "Lỗi không xác định" };
                }

                var errorContent = await response.Content.ReadAsStringAsync();
                return new ApiResponse
                {
                    Success = false,
                    Message = $"Thêm ảnh thất bại: {response.StatusCode}"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    Success = false,
                    Message = $"Lỗi: {ex.Message}"
                };
            }
        }
    }
}
