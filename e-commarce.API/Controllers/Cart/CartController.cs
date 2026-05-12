using ecommarce.BLL.DTOs;
using ecommarce.BLL.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ecommarnce_api_CRUD_project.Controllers.Cart
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CartController : ControllerBase
    {

        private readonly ICartServices _cartService;

        public CartController(ICartServices cartService)
        {
            _cartService = cartService;
        }
        [HttpGet]
        [Authorize(Roles = "User,Admin")]
        public async Task<IActionResult> GetCart()
        {
            var userId = GetUserId();

            var cart = await _cartService.GetCartAsync(userId);

            return Ok(cart);
        }
        [HttpPost("add")]
        [Authorize(Roles = "User,Admin")]
        public async Task<IActionResult> AddToCart([FromBody] AddtoCartDto dto)
        {
            var userId = GetUserId();

            await _cartService.AddToCartAsync(userId, dto);

            return Ok(new
            {
                Message = "Item added to cart successfully"
            });
        }
        [HttpPut("update")]
        [Authorize(Roles = "User,Admin")]
        public async Task<IActionResult> UpdateCartItem([FromBody] UpdatetoCartDto dto)
        {
            var userId = GetUserId();

            await _cartService.UpdateCartItemAsync(userId, dto.ProductId, dto.Quantity);

            return Ok(new
            {
                Message = "Cart item updated"
            });
        }
        [HttpDelete("{productId}")]
        [Authorize(Roles = "User,Admin")]
        public async Task<IActionResult> RemoveFromCart(Guid productId)
        {
            var userId = GetUserId();

            await _cartService.RemoveFromCartAsync(userId, productId);

            return Ok(new
            {
                Message = "Item removed from cart"
            });
        }
        [HttpDelete("clear")]
        [Authorize(Roles = "User,Admin")]
        public async Task<IActionResult> ClearCart()
        {
            var userId = GetUserId();

            await _cartService.ClearCartAsync(userId);

            return Ok(new
            {
                Message = "Cart cleared successfully"
            });
        }
        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}


