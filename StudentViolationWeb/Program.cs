using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using StudentViolationWeb;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices(); //mudblazor

builder.Services.AddScoped(sp => new HttpClient { 
    BaseAddress = new Uri("http://localhost:59506/") });

await builder.Build().RunAsync();
//adding commits for pushing 