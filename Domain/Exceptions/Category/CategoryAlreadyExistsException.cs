﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingPlatform.DatabaseService.Domain.Exceptions.Category
{
    public class CategoryAlreadyExistsException:BadRequestException
    {
        public CategoryAlreadyExistsException(string message) : base(message)
        {
        }
    }
}
