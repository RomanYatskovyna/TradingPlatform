﻿using System.Collections.Generic;
using System.Threading.Tasks;
using TradingPlatform.EntityContracts.Category;

namespace TradingPlatform.DatabaseService.Services.Abstractions
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryReadDto>> GetAllAsync();
        Task<CategoryReadDto> GetByIdAsync(int id);
        Task UpdateAsync(int id, CategoryCreateDto categoryReadDto);
        Task<CategoryReadDto> CreateAsync(CategoryCreateDto categoryCreateDto);
        Task DeleteAsync(int id);
        Task<IEnumerable<CategoryReadDto>> FindBySearchAsync(CategorySearchDto categorySearchDto);
    }
}
