//using System.Net.Http.Json;
//using Microsoft.JSInterop;
//using StudentViolationWeb.Model;

//namespace StudentViolationWeb.Data
//{
//    public class AuthService
//    {
//        private readonly HttpClient _http;
//        private readonly IJSRuntime _js;

//        public AuthService(HttpClient http, IJSRuntime js)
//        {
//            _http = http;
//            _js = js;
//        }

//        public async Task<bool> Login(LoginModel loginModel)
//        {
//            var response = await _http.PostAsJsonAsync("api/auth/login", loginModel);

//            if (response.IsSuccessStatusCode)
//            {
//                var result = await response.Content.ReadFromJsonAsync<LoginResponse>();
//                // Store token in localStorage
//                await _js.InvokeVoidAsync("localStorage.setItem", "token", result!.Token);
//                return true;
//            }

//            return false;
//        }

//        public async Task Logout()
//        {
//            await _js.InvokeVoidAsync("localStorage.removeItem", "token");
//        }

//        public async Task<string?> GetToken()
//        {
//            return await _js.InvokeAsync<string>("localStorage.getItem", "token");
//        }

//        public async Task<bool> IsLoggedIn()
//        {
//            var token = await GetToken();
//            return !string.IsNullOrEmpty(token);
//        }
//    }
//}