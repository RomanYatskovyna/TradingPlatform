﻿using TradingPlatform.EntityContracts.Order;
using TradingPlatform.EntityContracts.Product;

namespace TradingPlatform.EntityContracts.ProductOrder
{
    public class ProductOrderReadDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        //public virtual OrderReadDto Order { get; set; }
        //public virtual ProductReadDto Product { get; set; }
    }
}