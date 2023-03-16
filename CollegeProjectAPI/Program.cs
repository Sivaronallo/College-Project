using CollegeProject.Api.Configuration;
using CollegeProject.Core.Entities;
using CollegeProject.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("CollegeContext");
builder.Services.AddDbContext<CollegeContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDefaultIdentity<CollegeUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<CollegeContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<CollegeSetting>(
    builder.Configuration.GetSection("Settings"));

builder.Services.AddCoreServices();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
