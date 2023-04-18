using Microsoft.EntityFrameworkCore;
using RepoMinerAnalysis.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RepoMinerDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("RepoMinerConnectionString")));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
