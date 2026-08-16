using ApiCotacoes.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCotacoes.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Cotacao> Cotacoes => Set<Cotacao>();
}
