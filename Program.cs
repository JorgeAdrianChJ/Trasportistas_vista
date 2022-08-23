using Microsoft.EntityFrameworkCore;
using Rotativa.AspNetCore;
using Trasportistas_vista.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BD_TRASPORTISTASContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BD_TRASPORTISTASContext") ?? throw new InvalidOperationException("Connection string 'BD_TRASPORTISTASContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

IWebHostEnvironment env = app.Environment;
RotativaConfiguration.Setup((Microsoft.AspNetCore.Hosting.IHostingEnvironment)env);

app.Run();
