using System.Net.Http.Json;
using StudentViolationWeb.Model;
using StudentViolationWeb.Model.Response;

namespace StudentViolationWeb.Data;

public class StudentService
{
    private readonly HttpClient _http;

    public StudentService(HttpClient http)
    {
        _http = http;
    }

    public async Task<ServiceResponse<StudentModel>> GetStudentInfo(int studentId)
    {
        try
        {
            var response = await _http.GetAsync($"api/students/{studentId}");
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<StudentModel>>();
            return result ?? new ServiceResponse<StudentModel> { Status = 500, Message = "Empty response" };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<StudentModel> { Status = 500, Message = ex.Message };
        }
    }

    public async Task<ServiceResponse<StudentModel>> GetCurrentStudentAsync()
    {
        try
        {
            var response = await _http.GetAsync("api/students/current");
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<StudentModel>>();
            return result ?? new ServiceResponse<StudentModel> { Status = 500, Message = "Empty response" };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<StudentModel> { Status = 500, Message = ex.Message };
        }
    }
}
