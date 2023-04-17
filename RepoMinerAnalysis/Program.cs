using Microsoft.EntityFrameworkCore;
using RepoMinerAnalysis.Data;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.Services.AddDbContext<RepoMinerDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("RepoMinerConnectionString")));

app.MapGet("/", () => "Hello World!");

app.Run();
