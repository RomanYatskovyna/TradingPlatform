﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using TradingPlatform.DatabaseService.Domain.Entities;
using TradingPlatform.DatabaseService.Contracts.Product;

namespace TradingPlatform.Models
{
    public class IndexViewModel
    {
        public List<List<ProductReadDto>> Products {  get; set; }
        public SearchViewModel Search {  get; set; }
        public ItemPaginationViewModel ItemPagination {  get; set; }
        public SelectList AvailableOrdersSelectList { get; set; }
    }
}
