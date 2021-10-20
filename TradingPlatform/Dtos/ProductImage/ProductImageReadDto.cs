﻿using System;
using System.ComponentModel.DataAnnotations;

namespace TradingPlatform.Dtos
{
    public class ProductImageReadDto
    {
        public virtual ProductReadDto Product { get; set; }
        public byte[] ImageData { get; set; }
        public string GetImage()
        {
            var base64 = Convert.ToBase64String(ImageData);
            var image = string.Format("data:image/gif;base64,{0}", base64);
            return image;
        }
    }
}
