

using Business.Extensions;
using RegistaAdmin.Extensions;
using RegistaAdmin.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAPIServices();
builder.Services.AddBusinessServices();
// Add services to the container.


var app = builder.Build();

// Configure the HTTP request pipeline.
    app.UseSwagger();
    app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();
app.UseCustomException();

app.Run();
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  