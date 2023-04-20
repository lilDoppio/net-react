using net_react.Controllers;
using net_react.Data;
using net_react.Interfaces;
using net_react.Models;
using net_react.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("http://localhost:5000/")
                 .SetIsOriginAllowedToAllowWildcardSubdomains()
                 .AllowAnyHeader()
                 .AllowCredentials()
                 .WithMethods("GET", "POST");
        });
});

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddScoped<IOrganizationRepositiory, OrganizationRepository>();
builder.Services.AddScoped<IRequisitesRepository, RequisitesRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSqlite<DataContext>("Data Source=NetReact.db");

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
