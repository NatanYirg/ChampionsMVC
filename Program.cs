using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Globalization;
using TheChampions.Models;
using TheChampions.Repository;
using TheChampions.Repository.Abstract;
using TheChampions.Repository.Imp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddLocalization(options => { options.ResourcesPath = "Resources"; });
builder.Services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix).AddDataAnnotationsLocalization();

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new List<CultureInfo>
    { new CultureInfo("en"),
      new CultureInfo("am"),
      new CultureInfo("fr"),
      new CultureInfo("es")
    };

    options.DefaultRequestCulture = new RequestCulture("en");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

builder.Services.AddControllersWithViews();




builder.Services.AddScoped<ICamp, CampImp>();


builder.Services.AddDbContextPool<CampContext>(
    options => options.UseMySQL(
        builder.Configuration.GetConnectionString(
            "campconnection")));


builder.Services.AddDbContextPool<CustReachContext>(
    options => options.UseMySQL(
        builder.Configuration.GetConnectionString(
            "campconnection")));

builder.Services.AddDbContextPool<PaymentContext>(
    options => options.UseMySQL(
        builder.Configuration.GetConnectionString(
            "campconnection")));




builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<CampContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(op => op.LoginPath = "/UserAuthentication/Login");
builder.Services.AddScoped<IUserAuthenticationService, UserAuthenticationService>();



var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
//app.MapControllers();

//app.UseEndpoints( endpoint =>
//{
//    endpoint.MapControllers();
//});

app.UseAuthentication();
app.UseAuthorization();

var supportedCultures = new[] { "en", "am", "fr", "es" };
var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);

app.UseRequestLocalization(app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
