using OrangeRouteModel;
using Microsoft.EntityFrameworkCore;

namespace OrangeRouteData
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<TipoUsuarioModel> TiposUsuario { get; set; } = null!;
        public DbSet<UsuarioModel> Usuarios { get; set; } = null!;
        public DbSet<FavoritosModel> Favoritos { get; set; } = null!;
        public DbSet<TrilhaCarreiraModel> TrilhasCarreira { get; set; } = null!;
        public DbSet<ComentarioModel> Comentarios { get; set; } = null!;
        public DbSet<TagModel> Tags { get; set; } = null!;
        public DbSet<TagPostModel> TagsPost { get; set; } = null!;
    }
}
