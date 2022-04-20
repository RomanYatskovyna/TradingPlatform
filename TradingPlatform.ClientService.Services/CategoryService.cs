﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TradingPlatform.ClientService.Domain.HttpInterfaces;
using TradingPlatform.ClientService.Services.Abstractions;
using TradingPlatform.EntityContracts.Category;
using TradingPlatform.EntityContracts.Product;
using TradingPlatform.EntityExceptions.Category;

namespace TradingPlatform.ClientService.Services
{
    public class CategoryService : ServiceBase, ICategoryService
    {
        public CategoryService(IHttpClientManager client, IHttpContextAccessor contextAccessor, IMapper mapper) : base(client, contextAccessor, mapper)
        {
        }
        public async Task<IEnumerable<CategoryReadDto>> IndexAsync()
        {
            return await _client.CategoryHttpClient.GetAllAsync();
        }
        public async Task<CategoryReadDto> DetailsAsync(int id)
        {
            return await _client.CategoryHttpClient.GetByIdAsync(id);
        }
        public async Task CreatePostAsync(CategoryCreateDto categoryCreateDto)
        {
            await _client.CategoryHttpClient.CreateAsync(categoryCreateDto);
        }
        public async Task DeleteAsync(int id)
        {
            await _client.CategoryHttpClient.DeleteAsync(id);
        }

        public async Task EditPostAsync(int id, CategoryCreateDto categoryCreateDto)
        {
            await _client.CategoryHttpClient.UpdateAsync(id, categoryCreateDto);
        }

        public async Task<CategoryCreateDto> EditGetAsync(int id)
        {
            var category = await _client.CategoryHttpClient.GetByIdAsync(id);
            if (category == null)
            {
                throw new CategoryNotFoundException("Category not found");
            }
            return _mapper.Map<CategoryCreateDto>(category);
        }
    }
}
