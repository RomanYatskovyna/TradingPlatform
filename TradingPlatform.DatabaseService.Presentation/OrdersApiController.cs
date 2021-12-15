﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TradingPlatform.EntityContracts.Order;

namespace TradingPlatform.DatabaseService.Presentation
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersApiController : DefaultApiController
    {
        // GET: api/OrdersApi
        [HttpGet]
        [ProducesResponseType(typeof(OrderReadDto), StatusCodes.Status200OK)]
        [Authorize]
        public async Task<ActionResult<IEnumerable<OrderReadDto>>> GetOrders()
        {
            var orders = await ServiceManager.OrderService.GetAllAsync();

            return Ok(orders);
        }

        // GET: api/OrdersApi/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(OrderReadDto), StatusCodes.Status200OK)]
        [Authorize]
        public async Task<ActionResult<OrderReadDto>> GetOrder(int id)
        {
            var order = await ServiceManager.OrderService.GetByIdAsync(id);

            return order;
        }

        // PUT: api/OrdersApi/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize(Roles = "Admin,Custumer")]
        public async Task<IActionResult> UpdateOrder(int id, OrderCreateDto orderCreateDto)
        {
            await ServiceManager.OrderService.UpdateAsync(id, orderCreateDto);

            return Ok();
        }

        // POST: api/OrdersApi
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(OrderReadDto), StatusCodes.Status200OK)]
        //[Authorize(Roles = "Custumer")]
        [Authorize]
        public async Task<ActionResult<OrderReadDto>> CreateOrder(OrderCreateDto orderCreateDto)
        {
            var order = await ServiceManager.OrderService.CreateAsync(orderCreateDto);

            return Ok(order);
        }

        // DELETE: api/OrdersApi/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(OrderReadDto), StatusCodes.Status204NoContent)]
        [Authorize(Roles = "Admin,Custumer")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            await ServiceManager.OrderService.DeleteAsync(id);

            return NoContent();
        }

        [HttpPost("by-filter")]
        [ProducesResponseType(typeof(IEnumerable<OrderReadDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<OrderReadDto>>> GetBySearchFilterAsync( OrderSearchDto filter)
        {
            var orders = await ServiceManager.OrderService.FindBySearchAsync(filter);

            return Ok(orders);
        }
    }
}
