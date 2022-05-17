using System.Configuration;
using EFCoreGenerateDBApp01;
using Microsoft.EntityFrameworkCore;
var cs1 = "server=localhost;user id=sa;password=Arnab@123;database=EmpDB";
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<EmpDBContext>(options => options.UseSqlServer(cs1));
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();

//add-migration migration01
//update-database
