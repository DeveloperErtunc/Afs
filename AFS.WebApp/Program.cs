using AFS.Data.Context;
using AFS.Data.DbModels;
using AFS.Service.IServices;
using AFS.Service.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("MyLocalSqlConnectionString");
builder.Services.AddIdentity<AppUser, AppUserRole>().AddEntityFrameworkStores<AFSContext>();
builder.Services.AddDbContext<AFSContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddRazorPages();
builder.Services.AddScoped<ITranslateService, TranslateService>();
builder.Services.AddScoped<ILogBusinessService, LogBusinessService>();
builder.Services.ConfigureApplicationCookie(opt =>
{
    opt.LoginPath = new PathString("/Home/SignIn");
});
var app = builder.Build();

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
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=SignIn}/{id?}");
app.Run();
