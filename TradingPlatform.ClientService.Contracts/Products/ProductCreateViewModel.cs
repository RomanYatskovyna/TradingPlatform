﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using TradingPlatform.EntityContracts.Product;

namespace TradingPlatform.ClientService.Contracts.Products
{
    public class ProductCreateViewModel
    {
        public IFormFile ImageThumbnail { get; set; }
        public IEnumerable<IFormFile> Images { get; set; }
        public ProductCreateDto ProductCreate { get; set; }
        public SelectList Categories { get; set; }
    }
}
