using Entities.DataTransferObjects;
using Entities.LinkModels;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Net.Http.Headers;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductLinks : IProductLinks
    {

        private readonly LinkGenerator _linkGenerator;
        private readonly IDataShaper<ProductDto> _dataShaper;
        public ProductLinks(LinkGenerator linkGenerator, IDataShaper<ProductDto> shaper)
        {
            _linkGenerator = linkGenerator;
            _dataShaper = shaper;
        }

        public LinkResponse TryGenereteLinks(ICollection<ProductDto> productDto, string fields, HttpContext httpContext)
        {
            var shapedProduct = ShapedData(productDto, fields);
            if (shouldGenerateLinl(httpContext))
                return ReturnLinkedProducts(productDto, fields, httpContext, shapedProduct);
            return ReturnShapedProducts(shapedProduct);
        }

        private LinkResponse ReturnLinkedProducts(ICollection<ProductDto> productDto, string fields, HttpContext httpContext, List<Entity> shapedProduct)
        {
            var productDtoList = productDto.ToList();
            for (var index = 0; index < productDtoList.Count; index++)
            {
                var productLinks = CreateForProduct(httpContext, productDtoList[index], fields);
                shapedProduct[index].Add("Links", productLinks);
            }
            var productCollection = new LinkCollectionWrapper<Entity>(shapedProduct);
            CreateForProducts(httpContext, productCollection);
            return new LinkResponse { HasLinks = true, LinkedEntities = productCollection };
        }

        private List<Link> CreateForProduct(HttpContext httpContext, ProductDto productDto, string fields)
        {
            var links = new List<Link>()
            {
                new Link()
                {
                    Href = $"/api/{httpContext.GetRouteData().Values["controller"].ToString().ToLower()}"
                    +$"/{productDto.Id}",
                    Rel="self",
                    Method="GET"
                },
                new Link()
                {
                    Href = $"/api/{httpContext.GetRouteData().Values["controller"].ToString().ToLower()}",
                    Rel="create",
                    Method="POST"

                }

            };
            return links;

        }
        private LinkCollectionWrapper<Entity> CreateForProducts(HttpContext httpContext,
            LinkCollectionWrapper<Entity> productCollectionWrapper)
        {
            productCollectionWrapper.Links.Add(new Link()
            {
                Href = $"/api/{httpContext.GetRouteData().Values["controller"].ToString().ToLower()}",
                Rel = "self",
                Method = "GET"
            });
            return productCollectionWrapper;

        }
        private LinkResponse ReturnShapedProducts(List<Entity> shapedProduct)
        {
            return new LinkResponse() { ShapedEntities = shapedProduct };
        }

        private bool shouldGenerateLinl(HttpContext httpContext)
        {
            var mediaType = (MediaTypeHeaderValue)httpContext.Items["AcceptHeaderMediaType"];
            return mediaType.SubTypeWithoutSuffix
               .EndsWith("hateoas", StringComparison.InvariantCultureIgnoreCase);

        }

        private List<Entity> ShapedData(ICollection<ProductDto> productDto, string fields)
        {
            return _dataShaper.ShapeData(productDto, fields)
                .Select(b => b.Entity)
                .ToList();
        }
    }
}
