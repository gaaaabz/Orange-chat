using OrangeChatModel;
using Microsoft.EntityFrameworkCore;

namespace OrangeChatData
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<UsuarioModel> Usuarios { get; set; } = null!;
        public DbSet<ReclamacaoModel> Reclamacoes { get; set; } = null!;
        public DbSet<ConversaModel> Conversas { get; set; } = null!;
        public DbSet<MensagemModel> Mensagens { get; set; } = null!;
        public DbSet<StatusModel> Status { get; set; } = null!;
        public DbSet<CategoriaModel> Categorias { get; set; } = null!;
        public DbSet<AvaliacaoModel> Avaliacoes { get; set; } = null!;
        public DbSet<AnexoModel> Anexos { get; set; } = null!;
        public DbSet<FaqModel> Faqs { get; set; } = null!;
    }
}