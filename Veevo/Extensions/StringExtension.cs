using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace Veevo.API.Extensions
{
    public static class StringExtension
    {
        public static string ToJson(this ModelStateDictionary modelState) => JsonConvert.SerializeObject(modelState);
        public static string ModelStateToString(this string s, ModelStateDictionary modelState) => JsonConvert.SerializeObject(modelState);
    }
}
