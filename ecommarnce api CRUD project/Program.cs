using ecommarce.API.Middlewares;
using ecommarce.BLL.services;
using ecommarce.BLL.services;
using ecommarce.DAL.data;
using ecommarce.DAL.models;
using ecommarce.DAL.repository;
using ecommarce.DAL.repository;
using ecommarce.DAL.repository.GenricRepo;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionstring = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<Appdbcontext>(options => options.UseSqlServer(connectionstring));
builder.Services.AddScoped<ICategoryreop, CategoryRepo>();
builder.Services.AddScoped<ICategoryservices, Categoryservices>();
builder.Services.AddScoped<IProductRepo, ProductRepo>();
builder.Services.AddScoped<IProductservices, Productservices>();
builder.Services.AddScoped(typeof(IGenricRepo<>), typeof(GenricRepo<>));
builder.Services.AddScoped<IOrderReop, OrderRepo>();
builder.Services.AddScoped<ICartRepo, CartRepo>();
builder.Services.AddScoped<ICartItemRepo, CartItemRepo>();
builder.Services.AddScoped<IOrderItemRepo, OrderItemRepo>();
builder.Services.AddScoped<IAuthServices, AuthServices>();
builder.Services.AddScoped<IRoleServices, RoleService>();
builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.Password.RequireUppercase=true;
    options.Password.RequireLowercase=true;
    options.Password.RequireDigit=true;
    options.Password.RequiredLength=8;

})
    .AddEntityFrameworkStores<Appdbcontext>()
    .AddDefaultTokenProviders();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseRouting();



app.UseAuthentication();

app.UseAuthorization();

app.UseMiddleware<RequestLimiterMiddleware>();

app.MapControllers();

app.Run();