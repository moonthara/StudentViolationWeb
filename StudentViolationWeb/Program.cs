using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using StudentViolationWeb;



var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddBlazoredLocalStorage();
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();

builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<StudentService>();
builder.Services.AddScoped<GuardService>();
builder.Services.AddScoped<GuidanceService>();
builder.Services.AddScoped<SaoService>();

// API base URL — update this IP if your network changes
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://10.65.47.154:5277") }); 

await builder.Build().RunAsync();