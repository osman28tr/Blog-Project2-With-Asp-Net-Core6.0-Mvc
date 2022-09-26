using ProgrammersBlog.Mvc.AutoMapper.Profiles;
using ProgrammersBlog.Mvc.Helpers.Abstract;
using ProgrammersBlog.Mvc.Helpers.Concrete;
using ProgrammersBlog.Services.AutoMapper.Profiles;
using ProgrammersBlog.Services.Extensions;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)); //js de nesnelerin kullanýmý için
    opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve; //iç içe nesnelerin birbirini referansýnda sýkýntý olmamasý için(yenile butonu)
});

builder.Services.AddSession();
builder.Services.AddAutoMapper(typeof(CategoryProfile),typeof(ArticleProfile),typeof(UserProfile));
builder.Services.LoadMyServices();
builder.Services.AddScoped<IImageHelper, ImageHelper>();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = new PathString("/Admin/User/Login");
    options.LogoutPath = new PathString("/Admin/User/LogOut");
    options.Cookie = new CookieBuilder
    {
        Name = "ProgrammersBlog",
        HttpOnly = true,
        SameSite = SameSiteMode.Strict,
        SecurePolicy = CookieSecurePolicy.Always
    };
    options.SlidingExpiration = true; //kullanýcýnýn oturum açýk kalma süresi
    options.ExpireTimeSpan = System.TimeSpan.FromDays(7);
    options.AccessDeniedPath = new PathString("/Admin/User/AccessDenied");
});
var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStatusCodePages();
app.UseSession();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=AdminIndex}/{id?}"
    );
});
app.Run();
