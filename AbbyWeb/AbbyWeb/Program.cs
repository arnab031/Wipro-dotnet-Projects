using Abby.DataAccess.Repository;
using Abby.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Abby.DataAccess.Data;
using Microsoft.AspNetCore.Identity.UI.Services;
using Abby.Utility;
using Stripe;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentity<IdentityUser,IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
builder.Services.AddSingleton<IEmailSender, EmailSender>();
// Add services to the container.
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

builder.Services.AddDbContext<Abby.DataAccess.Data.ApplicationDbContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Identity/Account/Login";
    options.LogoutPath = "/Identity/Account/Logout";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");

    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

string key = builder.Configuration.GetSection("Stripe:SecretKey").Get<string>();
StripeConfiguration.ApiKey = key;

app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.Run();

