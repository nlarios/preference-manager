using System.Security.Claims;
using PreferenceManager;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PreferenceManager.Infrastructure.Context;
using PreferenceManager.Infrastructure.DAL;
using PreferenceManager.UseCase;

var builder = WebApplication.CreateBuilder(args);

// External services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder
                .WithOrigins("http://localhost:8080")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials();
        });
});

ConfigurationManager configuration = builder.Configuration; // allows both to access and to set up the config

var domain = $"https://{configuration["Auth0:Domain"]}/";

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = domain;
        options.Audience = configuration["Auth0:Audience"];
        // If the access token does not have a `sub` claim, `User.Identity.Name` will be `null`. Map it to a different claim by setting the NameClaimType below.
        options.TokenValidationParameters = new TokenValidationParameters
        {
            NameClaimType = ClaimTypes.NameIdentifier
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("EditUniversalPreferences",
        policy => policy.Requirements.Add(new HasScopeRequirement("edit:universal_preferences", domain)));
    options.AddPolicy("ReadUniversalPreferences",
        policy => policy.Requirements.Add(new HasScopeRequirement("read:universal_preferences", domain)));
    options.AddPolicy("EditSolutionPreferences",
        policy => policy.Requirements.Add(new HasScopeRequirement("edit:solution_preferences", domain)));
    options.AddPolicy("ReadSolutionPreferences",
        policy => policy.Requirements.Add(new HasScopeRequirement("read:solution_preferences", domain)));
    options.AddPolicy("EditConsumerPreferences",
        policy => policy.Requirements.Add(new HasScopeRequirement("edit:consumer_preferences", domain)));
    options.AddPolicy("ReadConsumerPreferences",
        policy => policy.Requirements.Add(new HasScopeRequirement("read:consumer_preferences", domain)));
});

builder.Services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo {Title = "“PerformanceManager", Version = "v1"});
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

// local services
builder.Services.AddDbContext<PmDbContext>(options =>
    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddStackExchangeRedisCache(option =>
{
    option.Configuration = configuration["RedisCacheUrl"];
    option.InstanceName = "master";
});

builder.Services.AddScoped<IPreferenceRepository, PreferenceRepository>();
builder.Services.AddScoped<IGetPreferences, GetPreferences>();
builder.Services.AddScoped<IGetPersonPreferences, GetPersonPreferences>();
builder.Services.AddScoped<IEditPreference, EditPreference>();
builder.Services.AddScoped<IEditPersonPreference, EditPersonPreference>();
builder.Services.AddScoped<ISolutionPreferenceRepository, SolutionPreferenceRepository>();
builder.Services.AddScoped<ISolutionRepository, SolutionRepository>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IPersonPreferenceRepository, PersonPreferenceRepository>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigin");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();