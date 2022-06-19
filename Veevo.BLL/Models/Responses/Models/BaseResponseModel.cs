using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace Veevo.BLL.Models.Responses.Models
{
    public abstract class BaseResponseModel
    {
        /// <summary>
        /// При инициализации с ModelState IsSuccess = false
        /// </summary>
        /// <param name="modelState"></param>
        [JsonConstructor]
        public BaseResponseModel(ModelStateDictionary modelState)
        {
            ModelState = modelState.ToDictionary(
                kvp => kvp.Key,
                kvp => kvp.Value?.Errors.Select(e => e.ErrorMessage).ToArray()
            );

            IsSuccess = false;
        }
        public BaseResponseModel(bool isSuccess) => IsSuccess = isSuccess;
        /// <summary>
        /// При инициализации без параместра IsSuccess = true
        /// </summary>
        [JsonConstructor]
        public BaseResponseModel() { 
            IsSuccess = true;
        }
        /// <summary>
        /// Описание всех ошибок пользователя и/или сервера
        /// </summary>
        public Dictionary<string, string[]?>? ModelState { get; set; }
        /// <summary>
        /// Результат обработки запроса пользователя
        /// </summary>
        public bool IsSuccess { get; set; }
        /// <summary>
        /// Описание ошибки при выполнении пользовательского запроса
        /// </summary>
        public string? ErrorMessage { get; set; }
    }
}
