﻿using System.Collections.Generic;
using System.Threading.Tasks;
using TradingPlatform.EntityContracts.Product;

namespace TradingPlatform.DatabaseService.Services.Abstractions
{
    public interface IProductService
    {
        Task<IEnumerable<ProductReadDto>> GetAllAsync();
        Task<ProductReadDto> GetByIdAsync(int id);
        Task UpdateAsync(int id, ProductCreateDto productReadDto);
        Task<ProductReadDto> CreateAsync(ProductCreateDto productCreateDto);
        Task DeleteAsync(int id);
        Task<IEnumerable<ProductReadDto>> FindBySearchAsync(ProductSearchDto productSearchDto);
    }
}
