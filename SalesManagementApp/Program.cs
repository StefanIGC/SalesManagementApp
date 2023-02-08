
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using SalesManagementApp.Data;
using SalesManagementApp.Services;
using SalesManagementApp.Services.Contracts;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("SalesManagementDbConnection")
    ?? throw new InvalidOperationException("Connection 'SalesManagementDbConnection'| not found");

builder.Services.AddDbContext<SalesManagementDbContext>(
    options => options.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddSyncfusionBlazor();

builder.Services.AddScoped<IEmployeeManagementService, EmployeeManagementService>();

var app = builder.Build();
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBaFt/QHRqVVhkVFpFdEBBXHxAd1p/VWJYdVt5flBPcDwsT3RfQF5jS35bdkdjUHtacXxQQA==;Mgo+DSMBPh8sVXJ0S0J+XE9AflRDX3xKf0x/TGpQb19xflBPallYVBYiSV9jS31TdEVrWX1eeXBRRGBcVw==;ORg4AjUWIQA/Gnt2VVhkQlFacldJXGFWfVJpTGpQdk5xdV9DaVZUTWY/P1ZhSXxQdkdjUX9ccH1RQmJdV0I=;MTA4NTc0NUAzMjMwMmUzNDJlMzBZMlJlT04zaUR3T3VIWlRJMGx5VS9sc2krU0dxTTlsbnpOTU15UERzNmFVPQ==;MTA4NTc0NkAzMjMwMmUzNDJlMzBuTC8wcXNrcTRQV01FUi9LT2RRejNIakltNzcvTmljOUtqZ3krSW9LS1JJPQ==;NRAiBiAaIQQuGjN/V0Z+WE9EaFtKVmJLYVB3WmpQdldgdVRMZVVbQX9PIiBoS35RdUVhWXdecnRcQmRfUUB0;MTA4NTc0OEAzMjMwMmUzNDJlMzBYMUlqUnRBQkZUWWJ4QVJUQXFzK0JsYU9RZXB0ZzVyZU51NElldHI1Y25ZPQ==;MTA4NTc0OUAzMjMwMmUzNDJlMzBSWEZINzA0dzVzaGxHdHZsS1NKamNneUlYUklrT2pzajNyejdaajh2OU1nPQ==;Mgo+DSMBMAY9C3t2VVhkQlFacldJXGFWfVJpTGpQdk5xdV9DaVZUTWY/P1ZhSXxQdkdjUX9ccH1RQmNbWEM=;MTA4NTc1MUAzMjMwMmUzNDJlMzBsei9mMkUvSGhhSjVraWlGNUFZMmNyNldtVjZKNVYyeVlrYkEzRnBVMXkwPQ==;MTA4NTc1MkAzMjMwMmUzNDJlMzBZK2tnVUJ2OEFOUmRMZ1JRVzFTbmZiSGtSU2p4ZVNtSythZXRra01FQmpjPQ==;MTA4NTc1M0AzMjMwMmUzNDJlMzBYMUlqUnRBQkZUWWJ4QVJUQXFzK0JsYU9RZXB0ZzVyZU51NElldHI1Y25ZPQ==");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
