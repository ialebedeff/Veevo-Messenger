using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace Veevo.API.Extensions
{
    public static class StringExtension
    {
        /// <summary>
        /// ModelState преобразование в Json
        /// </summary>
        /// <param name="modelState"></param>
        /// <returns></returns>
        public static string ToJson(this ModelStateDictionary modelState) => JsonConvert.SerializeObject(modelState);
    }
}
