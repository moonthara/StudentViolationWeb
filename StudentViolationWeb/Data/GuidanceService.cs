using System.Net.Http.Json;
using StudentViolationWeb.Model;
using StudentViolationWeb.Model.Response;

namespace StudentViolationWeb.Data;

public class GuidanceService
{
    private readonly HttpClient _http;

    public GuidanceService(HttpClient http)
    {
        _http = http;
    }

    public async Task<ServiceResponse<GetSummaryModel>> GetSummary(GetSummaryModel model)
    {
        try
        {
            var response = await _http.PostAsJsonAsync("api/guidance/summary", model);
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<GetSummaryModel>>();
            return result ?? new ServiceResponse<GetSummaryModel> { Status = 500, Message = "Empty response" };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<GetSummaryModel> { Status = 500, Message = ex.Message };
        }
    }
}
