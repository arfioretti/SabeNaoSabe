using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SabeNaoSabe.WebAPI.Data;
using SabeNaoSabe.WebAPI.Services;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.AddSecurityDefinition("oauth2", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey

    });
    option.OperationFilter<SecurityRequirementsOperationFilter>();
});
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("questionariocs")));
builder.Services.AddIdentityApiEndpoints<IdentityUser>().
    AddRoles<IdentityRole>().
    AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddScoped<IRoleService, RoleService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyPolicy",
        policy =>
        {
            //policy.WithOrigins("https://localhost:7084")
            policy.WithOrigins("https://sabenaosabewasm20240704115206.azurewebsites.net")
                //.WithMethods("PUT", "DELETE", "GET", "POST");
                .AllowAnyHeader()
                .AllowAnyOrigin()
                .AllowAnyMethod();
        });

});

var app = builder.Build();
app.MapIdentityApi<IdentityUser>();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
app.UseSwagger();
app.UseSwaggerUI();


#if !DEBUG
    app.UseHttpsRedirection();
#endif

app.UseCors();


app.UseAuthorization();


app.MapControllers();

app.Run();
