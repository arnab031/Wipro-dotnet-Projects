using Azure.Storage.Blobs;
using BlobStorageDemoApp01.Models;

var builder = WebApplication.CreateBuilder(args);

var blobConnection = builder.Configuration.GetValue<string>("BlobConnection");
builder.Services.AddSingleton(x => new BlobServiceClient(blobConnection));
builder.Services.AddSingleton<IBlobService, BlobService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

