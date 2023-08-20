using RegisterSchoolAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RegisterSchoolAPI.Repositories;
using RegisterSchoolAPI.Services;
using RegisterSchoolAPI.Domain;
using RegisterSchoolAPI.Tools;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using RegisterSchoolAPI.Domain.Auth;

var builder = WebApplication.CreateBuilder(args);

//Add contexto
builder.Services.AddDbContext<AplicacionContexto>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("JR")));
// Add services to the container.
builder.Services.AddScoped<IRepositorioUsuario, ServicioUsuario>();
builder.Services.AddScoped<IUsuario, DUsuario>();
builder.Services.AddScoped<IAuth, DAuth>();
builder.Services.AddScoped<IRepositoryAuth, ServicioAutenticacion>();
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddAutoMapper(typeof(MappingConfig));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "RegisterShoolAPI", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

//JWT service
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
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

app.UseAuthorization();

app.MapControllers();

app.Run();
