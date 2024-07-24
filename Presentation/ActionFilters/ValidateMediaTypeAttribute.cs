using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Net.Http.Headers;


namespace Presentation.ActionFilters
{
    // ValidateMediaTypeAttribute sınıfı, bir eylem filtresi olarak davranır ve HTTP isteklerini belirli koşullar altında doğrulamak için kullanılır.
    public class ValidateMediaTypeAttribute : ActionFilterAttribute
    {
        // OnActionExecuting metodu, eylem metodunun çalıştırılmasından önce çağrılır.
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Accept başlığının var olup olmadığını kontrol eder.
            var acceptHeaderPresent = context.HttpContext.Request.Headers.ContainsKey("Accept");

            // Eğer Accept başlığı mevcut değilse, bir BadRequestObjectResult döndürerek isteği sonlandırır.
            if (!acceptHeaderPresent)
            {
                context.Result = new BadRequestObjectResult("Accept header is missing!");
                return;
            }

            // Accept başlığının değerini alır ve string türüne dönüştürür.
            var mediaType = context.HttpContext.Request.Headers["Accept"].ToString();

            // MediaTypeHeaderValue.TryParse metodunu kullanarak Accept başlığının geçerli bir medya türü olup olmadığını kontrol eder.
            if (!MediaTypeHeaderValue.TryParse(mediaType, out MediaTypeHeaderValue? outMediaType))
            {
                // Eğer medya türü geçerli değilse, bir BadRequestObjectResult döndürerek isteği sonlandırır ve bir hata mesajı gönderir.
                context.Result = new BadRequestObjectResult("Media Type not present. Please add Accept header with required media type.");
                return;
            }

            // Eğer medya türü geçerliyse, bu değeri HttpContext.Items koleksiyonuna ekler.
            context.HttpContext.Items.Add("AcceptHeaderMediaType", outMediaType);
        }
    }
}
