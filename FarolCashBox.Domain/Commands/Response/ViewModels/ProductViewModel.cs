﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarolCashBox.Domain.Commands.Response.ViewModels
{
    public class ProductViewModel
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public string ProductType { get; set; }
    }
}
