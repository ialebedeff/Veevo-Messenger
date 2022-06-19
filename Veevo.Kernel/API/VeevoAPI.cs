using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Veevo.Kernel.Models;
using Veevo.Kernel.Models.Requests;
using Veevo.Kernel.Models.Responses;
using Veevo.Kernel.Models.Responses.Account;
using Veevo.Kernel.Models.Responses.Dialogs;
using Veevo.Kernel.Models.Responses.Message;
using Veevo.Kernel.Models.Responses.Updates;
using Veevo.Kernel.Token;

namespace Veevo.Kernel.API
{
    public static class VeevoAPI
    {
        public static UserModel? User { get; set; }
        public static bool IsInitialized { get; set; }

        private static HttpClient _client = null!;
        public static bool IsConnected { get; set; }
        public static void Initialize()
        {
            _client = new HttpClient()
            {
                BaseAddress = new Uri(ApplicationData.Constsants.ServerBaseAddress),
            };

            _client.DefaultRequestHeaders.Add("User-Agent", ApplicationData.Constsants.UserAgent);
        }
        public async static Task<UpdateResponseModel> GetUpdates()
        {
            var response = await GetAsync("Update/GetUpdates");

            try
            {
                return JsonConvert.DeserializeObject<UpdateResponseModel>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                return new UpdateResponseModel() { ErrorMessage = ex.Message };
            }
        }
        public async static Task<UserResponseModel> GetUserById(UserRequestModel userRequestModel)
        {
            var response = await PostAsync("User/GetUserById", userRequestModel);

            try
            {
                return JsonConvert.DeserializeObject<UserResponseModel>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                return new UserResponseModel() { ErrorMessage = response.ReasonPhrase ?? ex.Message };
            }
        }

        public async static Task<UserResponseModel> GetUserByUsernameAsync(UserRequestModel userRequestModel)
        {
            var response = await PostAsync("User/GetUserByUsername", userRequestModel);

            try
            {
                var userModel = JsonConvert.DeserializeObject<UserResponseModel>(await response.Content.ReadAsStringAsync());

                return userModel;
            }
            catch (Exception ex)
            {
                return new UserResponseModel() { ErrorMessage = await response.Content.ReadAsStringAsync() ?? ex.Message };
            }
        }
        public async static Task<bool?> IsAccountVerified(VerificationRequestModel verificationRequestModel)
        {
            var response = await PostAsync("User/CheckVerification", verificationRequestModel);

            try
            {
                var verifyModel = JsonConvert.DeserializeObject<CheckVerificationResponseModel>(await response.Content.ReadAsStringAsync());

                return verifyModel.IsAccountVerified;
            }
            catch
            {

            }

            return response.IsSuccessStatusCode;
        }

        public async static Task<UserResponseModel> GetMeAsync()
        {
            try
            {
                var response = await GetAsync("User/User");
                var userResponse = JsonConvert.DeserializeObject<UserResponseModel>(await response.Content.ReadAsStringAsync());

                if (userResponse.IsSuccess)
                    User = userResponse.User;

                return userResponse;
            }
            catch (Exception ex)
            {
                return new UserResponseModel() { ErrorMessage = ex.Message };
            }
        }

        public async static Task<CreateAccountResponseModel> CreateAccountAsync(RegistrationRequestModel registrationRequestModel)
        {
            var response = await PostAsync("User/CreateUser", registrationRequestModel);

            return JsonConvert.DeserializeObject<CreateAccountResponseModel>(await response.Content.ReadAsStringAsync());
        }
        private async static Task<HttpResponseMessage> PostAsync(string uri, object? data)
        {
            if (_client == null)
                Initialize();

            try
            {
                return await _client.PostAsJsonAsync(uri, data);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage() { ReasonPhrase = ex.Message };
            }
        }
        public async static Task<MessageSentResponseModel> SendTextMessageAsync(SendMessageTextRequestModel sendMessageTextRequestModel)
        {
            try
            {
                var response = await PostAsync("Message/SendMessageText", sendMessageTextRequestModel);
                var messageResponse = JsonConvert.DeserializeObject<MessageSentResponseModel>(await response.Content.ReadAsStringAsync());
                //messageResponse.HttpResponse = response;
                return messageResponse ?? new MessageSentResponseModel() { HttpResponse = response, ErrorMessage = await response.Content.ReadAsStringAsync() };
            }
            catch (Exception ex)
            {
                return new MessageSentResponseModel() { ErrorMessage = ex.Message };
            }
        }
        public async static Task<GetDialogsResponseModel> GetDialogs()
        {
            try
            {
                var response = await PostAsync("Message/GetDialogs", null);
                var dialogResponse = JsonConvert.DeserializeObject<GetDialogsResponseModel>(await response.Content.ReadAsStringAsync());
                return dialogResponse;
            }
            catch (Exception ex)
            {
                return new GetDialogsResponseModel() { ErrorMessage = ex.Message };
            }
        }
        public async static Task<MessagesResponseModel> GetMessages(GetMessagesRequestModel getMessagesRequest)
        {
            try
            {
                var response = await PostAsync("Message/GetMessages", getMessagesRequest);
                var messagesResponse = JsonConvert.DeserializeObject<MessagesResponseModel>(await response.Content.ReadAsStringAsync());
                return messagesResponse;
            }
            catch (Exception ex)
            {
                return new MessagesResponseModel() { ErrorMessage = ex.Message };
            }
        }
        private async static Task<HttpResponseMessage> GetAsync(string uri)
        {
            if (_client == null)
                Initialize();

            return await _client.GetAsync(uri);
        }
        public async static Task<TokenResponseModel> LoginAsync(LoginRequestModel loginRequestModel)
        {
            var response = (await PostAsync("Auth/SignIn", loginRequestModel));

            try
            {
                var tokenResponse = JsonConvert.DeserializeObject<TokenResponseModel>(await response.Content.ReadAsStringAsync());
                //tokenResponse.HttpResponse = response;

                if (response.IsSuccessStatusCode && tokenResponse != null)
                {
                    _client.DefaultRequestHeaders.Remove("Authorization");
                    _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {tokenResponse.Token}");

                    TokenReader.SaveToken(tokenResponse);
                }

                return tokenResponse ?? new TokenResponseModel() { Status = 400 };
            }
            catch (Exception ex)
            {
                return new TokenResponseModel() { ErrorMessage = ex.Message };
            }
        }
    }
}
