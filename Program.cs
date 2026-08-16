using ApiCotacoes.Data;
using ApiCotacoes.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")
        ?? "Data Source=cotacoes.db"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/api/cotacoes", async (AppDbContext db) =>
    Results.Ok(await db.Cotacoes.AsNoTracking().ToListAsync()));

app.MapGet("/api/cotacoes/{id:int}", async (int id, AppDbContext db) =>
{
    var cotacao = await db.Cotacoes.FindAsync(id);
    return cotacao is null ? Results.NotFound() : Results.Ok(cotacao);
});

app.MapPost("/api/cotacoes", async (Cotacao cotacao, AppDbContext db) =>
{
    cotacao.Id = 0;
    db.Cotacoes.Add(cotacao);
    await db.SaveChangesAsync();

    return Results.Created($"/api/cotacoes/{cotacao.Id}", cotacao);
});

app.MapPut("/api/cotacoes/{id:int}", async (int id, Cotacao input, AppDbContext db) =>
{
    var cotacao = await db.Cotacoes.FindAsync(id);

    if (cotacao is null)
        return Results.NotFound();

    cotacao.Descricao = input.Descricao;
    cotacao.Fornecedor = input.Fornecedor;
    cotacao.Valor = input.Valor;
    cotacao.Data = input.Data;

    await db.SaveChangesAsync();

    return Results.Ok(cotacao);
});

app.MapDelete("/api/cotacoes/{id:int}", async (int id, AppDbContext db) =>
{
    var cotacao = await db.Cotacoes.FindAsync(id);

    if (cotacao is null)
        return Results.NotFound();

    db.Cotacoes.Remove(cotacao);
    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.Run();

public partial class Program { }
