﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingPlatform.EntityExceptions.Category
{
    public class CategoryNotFoundException : NotFoundException
    {
        public CategoryNotFoundException(string message) : base(message)
        {
        }
    }
}