﻿using Entities.DataTransferObjects;
using Entities.LinkModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IProductLinks
    {
        LinkResponse TryGenereteLinks(ICollection<ProductDto> productDto ,string fields, HttpContext httpContext);
    }
}
