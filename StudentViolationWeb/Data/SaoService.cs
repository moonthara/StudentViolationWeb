using StudentViolationWeb.Model;
using StudentViolationWeb.Model.Response;
using System.Net.Http.Json;

public class SaoService
{
    private readonly HttpClient _http;

    public SaoService(HttpClient http)
    {
        _http = http;
    }

    public async Task<ServiceResponse<SaoModel>> GetSaoInfo(int saoId)
    {
        try
        {
            var response = await _http.GetAsync($"api/sao/{saoId}");
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<SaoModel>>();
            return result ?? new ServiceResponse<SaoModel> { Status = 500, Message = "Empty response" };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<SaoModel> { Status = 500, Message = ex.Message };
        }
    }
}
