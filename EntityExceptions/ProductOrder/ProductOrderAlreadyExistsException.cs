﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingPlatform.EntityExceptions.ProductOrder
{
    public class ProductOrderAlreadyExistsException : BadRequestException
    {
        public ProductOrderAlreadyExistsException(string message) : base(message)
        {
        }
    }
}