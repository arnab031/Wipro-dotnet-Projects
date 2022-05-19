﻿using EfCoreApp02;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var cs1 = "server=localhost;database=ProductsDB; User ID=sa;Password=Arnab@123";
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ProductsDBContext>(x => x.UseSqlServer(cs1));

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

