﻿using System.Collections.Generic;
using TradingPlatform.Contracts.Order;

namespace TradingPlatform.Contracts.ApplicationUser
{
    public class ApplicationUserReadDto
    {
        public string Id { get; set; } 
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public virtual IEnumerable<OrderReadDto> Orders { get; set; }

    }
}