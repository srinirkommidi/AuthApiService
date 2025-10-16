using System.Text;
using LogInAuthService.Data;
using LogInAuthService.Models;
using LogInAuthService.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Bind Jwt settings
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();
//DB Connection
var connString = builder.Configuration.GetConnectionString("prodbConnn");
builder.Services.AddDbContext<UserDBContext>(options => options.UseSqlServer(connString));

// Register token service
builder.Services.AddSingleton<ITokenService, TokenService>();

// Add authentication with JWT Bearer
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false; // true in production
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings.Issuer,
        ValidAudience = jwtSettings.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey)),
        ClockSkew = TimeSpan.Zero
    };
});

//Add Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",  policy =>
    {
        policy.WithOrigins("http:localhost:4200")
                        .AllowAnyMethod()
                        .AllowAnyHeader();
        });
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); //jwt?
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();//need to check this

app.UseAuthorization();

app.MapControllers();

app.Run();
