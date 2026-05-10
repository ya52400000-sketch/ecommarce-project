using e_commarce.BLL.services;
using ecommarce.BLL.DTOs;
using ecommarce.DAL.eunm;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ecommarnce_api_CRUD_project.Controllers.Order
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderServices _orderService;

        public OrderController(IOrderServices orderService)
        {
            _orderService = orderService;
        }
        [HttpPost]
        [Authorize(Roles ="Admin,User")]
        public async Task<IActionResult> CreateOrder()
        {
            var userId = GetUserId();

            var orderId = await _orderService.CreateOrderAsync(userId);

            return Ok(new
            {
                Message = "Order created successfully",
                OrderId = orderId
            });
        }
        [HttpGet]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetAll([FromQuery] FilterOrderDto filter)
        {
            var result = await _orderService.GetAllOrdersAsync(filter);
            return Ok(result);
        }
        [HttpGet("{orderId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetById(int orderId)
        {
            var result = await _orderService.GetOrderAsync(orderId);
            return Ok(result);
        }
        [HttpPost("{orderId}/cancel")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Cancel(int orderId)
        {
            var userId = GetUserId();

            await _orderService.CancelOrderAsync(orderId, userId);

            return Ok(new
            {
                Message = "Order cancelled successfully"
            });
        }
        [HttpPut("{orderId}/status")]
        [Authorize(Roles = "Admin,User")]

        public async Task<IActionResult> ChangeStatus(int orderId, [FromBody] OrderStatus status)
        {
            await _orderService.ChangeOrderStatusAsync(orderId, status);

            return Ok(new
            {
                Message = "Order status updated"
            });
        }
        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}

