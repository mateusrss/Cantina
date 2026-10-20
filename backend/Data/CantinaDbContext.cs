using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Data;

public class CantinaDbContext(
    DbContextOptions<CantinaDbContext> options
    ) : DbContext(options)
    {
        public DbSet<Produto> Produtos => Set<Produto>();
    }
