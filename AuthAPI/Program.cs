using AuthAPI;
using AuthAPI.Authorization;
using AuthAPI.Data;
using AuthAPI.Models;
using AuthAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var con = builder.Configuration["ConnectionStrings:AuthCon"]; // DANDO ALGUM ERRO DE CONEXAO AQUI
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AuthContext>(opts => opts.UseSqlServer(con));
// Add authentication to application.
builder.Services
        .AddIdentity<User, IdentityRole>()
        .AddEntityFrameworkStores<AuthContext>()
        .AddDefaultTokenProviders();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSingleton<IAuthorizationHandler, AgeAuthorization>();
builder.Services.AddAuthentication(op =>
{
    op.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(op =>
    {
        op.TokenValidationParameters =
            new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(builder.Configuration["SecurityKey"])),
                ValidateAudience = false,
                ValidateIssuer = false,
                ClockSkew = TimeSpan.Zero
            };
    });
builder.Services.AddAuthorization(op =>
{
    op.AddPolicy("MinAge", policy => policy.AddRequirements(new MinAge(16)));
});

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<TokenService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
// Put in this order.
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
