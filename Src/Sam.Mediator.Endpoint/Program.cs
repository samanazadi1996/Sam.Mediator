using FluentValidation;
using Microsoft.OpenApi.Models;
using Sam.Mediator;
using Sam.Mediator.Endpoint.Behaviours;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sam.Mediator", Version = "v1" });
});

builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

builder.Services.AddMediator([Assembly.GetExecutingAssembly()])
    .AddBehavior(typeof(ValidationBehavior<,>));

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sam.Mediator v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
