using Ecotrack.Api.Net.Models;
using Ecotrack.Net.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecotrack.Api.Net.Data.Contexts
{
    public class EcotrackContext : DbContext
    {
        public EcotrackContext(DbContextOptions<EcotrackContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Acao> Acoes { get; set; }
        public virtual DbSet<Dica> Dicas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // USUARIO
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("TB_NET_USUARIO");

                entity.HasKey(u => u.Id);

                entity.Property(u => u.Nome)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(u => u.Email)
                      .IsRequired()
                      .HasMaxLength(150);

                entity.Property(u => u.Senha)
                      .IsRequired();

                entity.Property(u => u.Role)
                      .IsRequired();

                entity.HasIndex(u => u.Email)
                      .IsUnique();
            });

            //ACAO
            modelBuilder.Entity<Acao>(entity =>
            {
                entity.ToTable("TB_NET_ACAO");

                entity.HasKey(a => a.Id);

                entity.Property(a => a.Titulo)
                      .IsRequired()
                      .HasMaxLength(150);

                entity.Property(a => a.Descricao)
                      .HasMaxLength(500);

            });

            //DICA
            modelBuilder.Entity<Dica>(entity =>
            {
                entity.ToTable("TB_NET_DICA");

                entity.HasKey(d => d.Id);

                entity.Property(d => d.Titulo)
                      .IsRequired()
                      .HasMaxLength(150);

                entity.Property(d => d.Conteudo)
                      .IsRequired()
                      .HasMaxLength(1000);

                entity.Property(d => d.Categoria)
                          .IsRequired();
            });
        }
    }
}