﻿using System;
using CHUSHKA.Models.Enums;

namespace CHUSHKA.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public ProductType Type { get; set; }

    }
}
