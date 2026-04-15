using System.Net.Http.Json;
using StudentViolationWeb.Model;
using StudentViolationWeb.Model.Response;

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

    public async Task<ServiceResponse<List<ViolationModel>>> GetStudentViolationsAsync()
    {
        try
        {
            var response = await _http.GetAsync("api/violations/student");
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<List<ViolationModel>>>();
            return result ?? new ServiceResponse<List<ViolationModel>> { Status = 500, Message = "Empty response" };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<List<ViolationModel>> { Status = 500, Message = ex.Message };
        }
    }

    public async Task<ServiceResponse<object>> CreateStudent(RegisterModel model)
    {
        try
        {
            var response = await _http.PostAsJsonAsync("api/students", model);
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<object>>();
            return result ?? new ServiceResponse<object> { Status = 500, Message = "Empty response" };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<object> { Status = 500, Message = ex.Message };
        }
    }
}
