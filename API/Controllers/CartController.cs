using API.Extensions;
using BUS.Services.Interfaces;
using DAL.DTOs.Carts.Req;
using DAL.DTOs.Carts.Res;
using DAL.Entities;
using Helper.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartServices _cartServices;

        public CartController(ICartServices cartServices)
        {
            _cartServices = cartServices;
        }

        [HttpPost("AddToCart")]
        [BAuthorize]
        public async Task<CommonResponse<CartSummaryRes>> AddToCart([FromBody] AddToCartReq request)
        {
            var userId = HttpContextHelper.GetUserId();

          

            var result = await _cartServices.AddToCartAsync(userId, request);

            return result;
        }
        /// <summary>
        /// Lấy thông tin giỏ hàng
        /// </summary>
        [HttpGet("GetCart")]
        [BAuthorize]
        public async Task<CommonResponse<CartSummaryRes>> GetCart()
        {

            var userId = HttpContextHelper.GetUserId();

            var result = await _cartServices.GetCartAsync(userId);
            return result;
        }


        [HttpPost("UpdateCart")]
        [BAuthorize]
        public async Task<CommonResponse<CartItemRes>> UpdateCartItem(int cartItemId, [FromBody] UpdateCartItemReq request)
        {

            var userId = HttpContextHelper.GetUserId();


            var result = await _cartServices.UpdateCartItemAsync(userId, cartItemId, request.Quantity);



            return result;

        }

        /// <summary>
        /// Xóa sản phẩm khỏi giỏ hàng
        /// </summary>
        [HttpPost("RemoveCartItem")]
        [BAuthorize]
        public async Task<CommonResponse<string>> RemoveCartItem(int cartItemId)
        {

            var userId = HttpContextHelper.GetUserId();

            var result = await _cartServices.RemoveCartItemAsync(userId, cartItemId);

            return result;

        }

        /// <summary>
        /// Xóa toàn bộ giỏ hàng
        /// </summary>
        [HttpPost("ClearCart")]
        [BAuthorize]
        public async Task<CommonResponse<string>> ClearCart()
        {

            var userId = HttpContextHelper.GetUserId();


            var result = await _cartServices.ClearCartAsync(userId);
            return result;

        }

        /// <summary>
        /// Lấy số lượng sản phẩm trong giỏ hàng (cho badge)
        /// </summary>
        [HttpGet("GetCartItemCount")]
        [BAuthorize]
        public async Task<CommonResponse<CartSummaryRes>> GetCartItemCount()
        {

            var userId = HttpContextHelper.GetUserId();

            var cart = await _cartServices.GetCartAsync(userId);
            return cart;
        }
    }
}