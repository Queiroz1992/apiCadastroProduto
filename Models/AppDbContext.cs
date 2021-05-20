using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiCadastroProduto.Models
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer
                  ("Data Source=LAPTOP-U8RFURLA\\SQLSERVER19; Initial Catalog=CadastroProdutoDB; Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasKey(e => e.ProdutoId);
                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.Preco).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.UsuarioId);
                entity.Property(e => e.Email).HasMaxLength(250);
                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(80);
                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(80);
            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

