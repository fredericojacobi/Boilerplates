using Api;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;

Console.WriteLine(" ... Starting application ...");

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureServices(builder.Configuration);

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    Console.WriteLine(" ... Database connecting ...");
    
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.EnsureCreated();
    dbContext.Database.Migrate();
    
    Console.WriteLine(" ... Database connected ...");
}

if (app.Environment.IsDevelopment())
{
    Console.WriteLine(" ... Development environment ...");
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseCors("all");

Console.WriteLine(" ... Done ...");
app.Run();