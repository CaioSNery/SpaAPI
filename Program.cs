using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Spa.Data;
using Spa.Interface;
using Spa.Services;
using SpaAPI.Interface;
using SpaAPI.Mappings;
using SpaAPI.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
builder.Services.AddScoped<IVendaService, VendaService>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IServicoService, ServicoService>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

var app = builder.Build();


// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();


app.MapControllers();
app.Run();


