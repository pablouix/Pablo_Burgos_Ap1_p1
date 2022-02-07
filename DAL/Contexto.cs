using Microsoft.EntityFrameworkCore;
using Pablo_Burgos_Ap1_p1.Entidades;

public class Contexto:DbContext
{
    DbSet<Productos>? Productos {get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source=DATA\Productos.db");

    }
}