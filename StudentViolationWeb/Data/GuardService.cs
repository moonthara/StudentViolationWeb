using System.Net.Http.Json;
using StudentViolationWeb.Model;
using StudentViolationWeb.Model.Response;

public class GuardService
{
    private readonly HttpClient _http;

    public GuardService(HttpClient http)
    {
        _http = http;
    }

    public async Task<ServiceResponse<StudentModel>> ValidateStudentAsync(string studentNo)
    {
        try
        {
            var response = await _http.GetAsync($"api/guard/student/validate?qrCode={Uri.EscapeDataString(studentNo)}");
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<StudentModel>>();
            return result ?? new ServiceResponse<StudentModel> { Status = 500, Message = "Empty response" };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<StudentModel> { Status = 500, Message = ex.Message };
        }
    }

    public async Task<ServiceResponse<RecordViolationModel>> RecordViolationAsync(RecordViolationModel model)
    {
        try
        {
            var response = await _http.PostAsJsonAsync("api/violations", model);
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<RecordViolationModel>>();
            return result ?? new ServiceResponse<RecordViolationModel> { Status = 500, Message = "Empty response" };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<RecordViolationModel> { Status = 500, Message = ex.Message };
        }
    }
}
