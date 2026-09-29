using Ecotrack.Api.Net.Data.Contexts;
using Ecotrack.Api.Net.Data.Repository;
using Ecotrack.Api.Net.Services;
using Ecotrack.Net.Services;
using EcoTrack.API.Data.Repository;
using EcoTrack.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

#region Banco de Dados

var connectionString =
    builder.Configuration.GetConnectionString("DatabaseConnection");

builder.Services.AddDbContext<EcotrackContext>(
    options => options.UseOracle(connectionString)
);

#endregion

#region Repository

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IAcaoRepository, AcaoRepository>();
builder.Services.AddScoped<IDicaRepository, DicaRepository>();

#endregion

#region Services

builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IAcaoService, AcaoService>();
builder.Services.AddScoped<IDicaService, DicaService>();

#endregion

#region JWT

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme =
        JwtBearerDefaults.AuthenticationScheme;

    options.DefaultChallengeScheme =
        JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters =
        new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,

            IssuerSigningKey =
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(
                        builder.Configuration["Jwt:SecretKey"]!
                    )
                ),

            ValidateIssuer = true,
            ValidateAudience = true,

            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"]
        };
});
builder.Services.AddAuthorization();

#endregion

#region Controllers

builder.Services.AddControllers();

#endregion

#region Swagger

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#endregion

var app = builder.Build();

#region Pipeline

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

#endregion

app.Run();