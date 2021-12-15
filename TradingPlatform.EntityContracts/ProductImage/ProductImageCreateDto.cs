﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingPlatform.EntityContracts.ProductImage
{
    public class ProductImageCreateDto
    {
        [Required]
        [MaxLength(255, ErrorMessage = "Extension must be less than 255 symbols.")]
        public string Extension { get; set; }
        [Required]
        [MaxLength(255, ErrorMessage = "Extension must be less than 255 symbols.")]
        public string Name { get; set; }
        [Required]
        public byte[] Data { get; set; }
    }
}
