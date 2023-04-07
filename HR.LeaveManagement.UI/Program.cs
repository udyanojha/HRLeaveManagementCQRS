using HR.LeaveManagement.UI;
using HR.LeaveManagement.UI.ApiClient;
using HR.LeaveManagement.UI.Contracts;
using HR.LeaveManagement.UI.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Reflection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IWebApiExecuter, WebApiExecuter>();
builder.Services.AddScoped<ILeaveAllocationService, LeaveAllocationService>();
builder.Services.AddScoped<ILeaveTypeService, LeaveTypeService>();
builder.Services.AddScoped<ILeaveRequestService, LeaveRequestService>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

//builder.Services.AddScoped<WebApiExecuter>(new WebApiExecuter("https://localhost:7276");
await builder.Build().RunAsync();
