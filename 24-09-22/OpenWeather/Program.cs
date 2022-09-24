using OpenWeather.Clients;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<OpenWeatherOptions>(
    builder.Configuration.GetSection("OpenWeather"));
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IOpenWeatherService, OpenWeatherService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
