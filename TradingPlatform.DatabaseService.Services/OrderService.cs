﻿using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using TradingPlatform.EntityContracts.Order;
using TradingPlatform.DatabaseService.Domain.Entities;
using TradingPlatform.DatabaseService.Domain.Repository_interfaces;
using TradingPlatform.DatabaseService.Services.Abstractions;
using TradingPlatform.EntityExceptions.Order;
using System;

namespace TradingPlatform.DatabaseService.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public OrderService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<OrderReadDto>> GetAllAsync()
        {
            var orders = await _repository.Orders.GetAllAsync();
            return _mapper.Map<IEnumerable<OrderReadDto>>(orders);
        }
        public async Task<OrderReadDto> GetByIdAsync(int id)
        {
            var order = await _repository.Orders.FindByIdAsync(id);

            if (order == null)
            {
                throw new OrderNotFoundException("Order not found");
            }
            return _mapper.Map<OrderReadDto>(order);
        }
        public async Task UpdateAsync(int id, OrderCreateDto orderCreateDto)
        {
            if (id != orderCreateDto.Id)
            {
                throw new OrderNotFoundException("Order with such id does not exists");
            }
            try
            {
                var order = _mapper.Map<Order>(orderCreateDto);
                await _repository.Orders.UpdateAsync(order);
            }
            catch (Exception)
            {
                if (await _repository.Orders.ExistsAsync(id))
                {
                    throw new OrderAlreadyExistsException("Order already exists");
                }
            }
        }
        public async Task<OrderReadDto> CreateAsync(OrderCreateDto orderCreateDto)
        {
            var order = _mapper.Map<Order>(orderCreateDto);
            order.Custumer =await _repository.Users.FindByIdAsync(orderCreateDto.CustumerId);
            await _repository.Orders.AddAsync(order);

            return _mapper.Map<OrderReadDto>(order);
        }
        public async Task DeleteAsync(int id)
        {
            var order = await _repository.Orders.FindByIdAsync(id);
            if (order == null)
            {
                throw new OrderNotFoundException("Order with such id does not exists");
            }
            await _repository.Orders.RemoveAsync(order);
        }
        public async Task<IEnumerable<OrderReadDto>> FindBySearchAsync(OrderSearchDto orderSearchDto)
        {
            var orders = await _repository.Orders.FindAllAsync(item =>
            (string.IsNullOrEmpty(orderSearchDto.Name) || item.Name.Contains(orderSearchDto.Name)) &&
            (string.IsNullOrEmpty(orderSearchDto.CustumerName) || item.Custumer.UserName.Contains(orderSearchDto.CustumerName)) &&
            item.Status == orderSearchDto.Status);

            return _mapper.Map<IEnumerable<OrderReadDto>>(orders);
        }
    }
}
