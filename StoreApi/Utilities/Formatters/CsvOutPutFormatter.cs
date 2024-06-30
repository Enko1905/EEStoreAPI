using Microsoft.AspNetCore.Mvc.Formatters;
using System.Net.Http.Headers;
using System.Text;
using Entities.DataTransferObjects;
namespace StoreApi.Utilities.Formatters
{
    //Kullanılmıyor Test İçin Örnek Olarak Eklendi CSV Formatter
    public class CsvOutPutFormatter:TextOutputFormatter
    {
         public CsvOutPutFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv").MediaType);
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        protected override bool CanWriteType(Type? type)
        {
            if (typeof(ProductDto).IsAssignableFrom(type) ||
                typeof(IEnumerable<ProductDto>).IsAssignableFrom(type))
            {
                return base.CanWriteType(type);
            }
            return false;
        }
        private static void FormatCsv(StringBuilder buffer, ProductDto book)
        {
            buffer.AppendLine($"{book.Id}, {book.Description}, {book.Price}");
        }

        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context,
            Encoding selectedEncoding)
        {
            var response = context.HttpContext.Response;
            var buffer = new StringBuilder();

            if (context.Object is IEnumerable<ProductDto>)
            {
                foreach (var book in (IEnumerable<ProductDto>)context.Object)
                {
                    FormatCsv(buffer, book);
                }
            }
            else
            {
                FormatCsv(buffer, (ProductDto)context.Object);
            }
            await response.WriteAsync(buffer.ToString());
        }

    }
}
