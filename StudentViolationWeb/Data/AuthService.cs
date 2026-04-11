using Blazored.LocalStorage;
using StudentViolationWeb.Model;
using StudentViolationWeb.Model.Response;
using System.Net.Http.Headers;
using System.Net.Http.Json;


public class AuthService
{
    private readonly HttpClient _http;
    private readonly ILocalStorageService _localStorage;



    public AuthService(HttpClient http, ILocalStorageService localStorage)
    {
        _http = http;
        _localStorage = localStorage;
    }

    public async Task<ServiceResponse<LoginDto>> LoginAsync(LoginModel login)
    {
        try
        {
            var response = await _http.PostAsJsonAsync("api/auth/login", login);
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<LoginDto>>();
           

            if (result?.Token != null)
            {
                await _localStorage.SetItemAsync("authToken", result.Token);
                _http.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", result.Token);
            }

            return result ?? new ServiceResponse<LoginDto> { Status = 500, Message = "Empty response" };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<LoginDto> { Status = 500, Message = ex.Message };
        }
    }

    public async Task<ServiceResponse<LoginDto>> RegisterAsync(RegisterModel register)
    {
        try
        {
            var response = await _http.PostAsJsonAsync("api/auth/register", register);
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<LoginDto>>();


            if (result?.Token != null)
            {
                await _localStorage.SetItemAsync("authToken", result.Token);
                _http.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", result.Token);
            }

            return result ?? new ServiceResponse<LoginDto> { Status = 500, Message = "Empty response" };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<LoginDto> { Status = 500, Message = ex.Message };
        }
    }

    public async Task Logout()
    {
        await _localStorage.RemoveItemAsync("authToken");
        _http.DefaultRequestHeaders.Authorization = null;
    }
}

public class LoginDto
{
    public string Role { get; set; } = "";
    public string? Token { get; set; }
}
