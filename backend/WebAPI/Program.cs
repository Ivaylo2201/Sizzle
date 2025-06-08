using System.Text;
using Application;
using DotNetEnv;
using Infrastructure;
using Infrastructure.Database;
using Infrastructure.Database.Repositories;
using Infrastructure.Database.Seed;
using Scalar.AspNetCore;

var builder = WebApplication .CreateBuilder(args);

Env.Load();

var jwtSecretKey = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_SECRET_KEY")!);
var jwtIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER")!;
var jwtAudience = Environment.GetEnvironmentVariable("JWT_AUDIENCE")!;
var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING")!;

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(new JwtConfig(jwtSecretKey, jwtIssuer, jwtAudience), connectionString);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

if (args.Contains("seed"))
{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
    var seeder = new Seeder(context, new UserRepository(context));

    await seeder.Run();
    
    return;
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("AllowFrontend");
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();

app.MapControllers();

app.Run();