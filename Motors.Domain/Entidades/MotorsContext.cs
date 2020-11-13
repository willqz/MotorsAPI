using Microsoft.EntityFrameworkCore;
using Motors.Domain.Helper;

namespace Motors.Domain.Entidades
{
    public partial class MotorsContext : DbContext
    {
        public MotorsContext()
        {
        }

        public MotorsContext(DbContextOptions<MotorsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbAnuncioWebmotors> TbAnuncioWebmotors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionDB.RetornaUrlConnetion());
                optionsBuilder.UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<TbAnuncioWebmotors>(entity =>
            {
                entity.ToTable("tb_AnuncioWebmotors");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Modelo)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Observacao)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Versao)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });
        }
    }
}
