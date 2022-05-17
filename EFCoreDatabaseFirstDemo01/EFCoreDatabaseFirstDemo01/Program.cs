var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();


// dotnet ef dbcontext scaffold "server=localhost;database=EmpDB; User ID=sa;Password=Arnab@123" microsoft.entityframeworkcore.sqlserve

// dotnet ef migrations add migration02

// dotnet ef database update 