using AddressBook.Data;
using AddressBook.Services;
using AddressBook.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


//public static async Task Main(string[] args)
//{
//    var host = CreateHostBuilder(args).Build();

//    var dbContext = host.Servces.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();

//    await dbContext.Database.MigrateAsync();

//    host.Run();
//}




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Add npgsql service
var configuration = builder.Configuration;
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
//options.UseNpgsql(DataUtility.GetConnectionString(Configuration)

//IImage service registration
builder.Services.AddScoped<IImageService, BasicImageService>();

var app = builder.Build();

/* Everything below this line is the middleware pipeline */

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

app.Run();
