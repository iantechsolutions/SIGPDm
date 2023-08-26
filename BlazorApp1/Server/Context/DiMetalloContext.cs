using System;
using System.Collections.Generic;
using BlazorApp1.Shared.Models;
using BlazorApp1.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BlazorApp1.Server.Context
{
    public partial class DiMetalloContext : DbContext
    {
        public DiMetalloContext()
        {
        }

        public DiMetalloContext(DbContextOptions<DiMetalloContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; } = null!;
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; } = null!;
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; } = null!;
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; } = null!;
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; } = null!;
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; } = null!;
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Cotizacione> Cotizaciones { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<EventosProduccion> EventosProduccions { get; set; } = null!;
        public virtual DbSet<FechasEvento> FechasEventos { get; set; } = null!;
        public virtual DbSet<Insumo> Insumos { get; set; } = null!;
        public virtual DbSet<MaquinasHerramienta> MaquinasHerramientas { get; set; } = null!;
        public virtual DbSet<MateriaPrima> MateriaPrimas { get; set; } = null!;
        public virtual DbSet<Ordencompra> Ordencompras { get; set; } = null!;
        public virtual DbSet<Ordentrabajo> Ordentrabajos { get; set; } = null!;
        public virtual DbSet<PedidosPañol> PedidosPañols { get; set; } = null!;
        public virtual DbSet<Personal> Personals { get; set; } = null!;
        public virtual DbSet<Proveedore> Proveedores { get; set; } = null!;
        public virtual DbSet<Repuesto> Repuestos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Trusted_Connection=True;Database=DiMetallo;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.Property(e => e.RoleId).HasMaxLength(450);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.Property(e => e.UserId).HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.Property(e => e.UserId).HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK_AspNetUserRoles_1");

                entity.Property(e => e.RoleId).HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithOne(p => p.AspNetUserRole)
                    .HasForeignKey<AspNetUserRole>(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Corredor).IsUnicode(false);

                entity.Property(e => e.Cp)
                    .IsUnicode(false)
                    .HasColumnName("CP");

                entity.Property(e => e.Cuit).IsUnicode(false);

                entity.Property(e => e.Direccion).IsUnicode(false);

                entity.Property(e => e.DomicilioEntrega)
                    .IsUnicode(false)
                    .HasColumnName("domicilioEntrega");

                entity.Property(e => e.Expreso).IsUnicode(false);

                entity.Property(e => e.Mail).IsUnicode(false);

                entity.Property(e => e.NombreContacto).IsUnicode(false);

                entity.Property(e => e.NombreEmpresa).IsUnicode(false);

                entity.Property(e => e.Observaciones).IsUnicode(false);

                entity.Property(e => e.RazonSocial).IsUnicode(false);

                entity.Property(e => e.Telefono).IsUnicode(false);
            });

            modelBuilder.Entity<Cotizacione>(entity =>
            {
                entity.ToTable("cotizaciones");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Alcance)
                    .IsUnicode(false)
                    .HasColumnName("alcance");

                entity.Property(e => e.Cantidad)
                    .IsUnicode(false)
                    .HasColumnName("cantidad");

                entity.Property(e => e.Cliente)
                    .IsUnicode(false)
                    .HasColumnName("cliente");

                entity.Property(e => e.Codigo)
                    .IsUnicode(false)
                    .HasColumnName("codigo");

                entity.Property(e => e.Color)
                    .IsUnicode(false)
                    .HasColumnName("color");

                entity.Property(e => e.Descripcion)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Estado)
                    .IsUnicode(false)
                    .HasColumnName("estado");

                entity.Property(e => e.Fechaentrega)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaentrega");

                entity.Property(e => e.Observaciones)
                    .IsUnicode(false)
                    .HasColumnName("observaciones");

                entity.Property(e => e.Planos)
                    .IsUnicode(false)
                    .HasColumnName("planos");

                entity.Property(e => e.Titulo)
                    .IsUnicode(false)
                    .HasColumnName("titulo");

                entity.Property(e => e.Tratamientosuperficial)
                    .IsUnicode(false)
                    .HasColumnName("tratamientosuperficial");

                entity.Property(e => e.Valordolar)
                    .IsUnicode(false)
                    .HasColumnName("valordolar");

                entity.Property(e => e.Valorpeso)
                    .IsUnicode(false)
                    .HasColumnName("valorpeso");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Dni)
                    .HasMaxLength(30)
                    .HasColumnName("DNI");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.LastNames).HasMaxLength(100);

                entity.Property(e => e.Names).HasMaxLength(100);

                entity.Property(e => e.Phone).HasMaxLength(30);

                entity.Property(e => e.Status).HasMaxLength(15);
            });

            modelBuilder.Entity<EventosProduccion>(entity =>
            {
                entity.ToTable("EventosProduccion");

                entity.Property(e => e.Etapa).IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Tipo).IsUnicode(false);
            });

            modelBuilder.Entity<FechasEvento>(entity =>
            {
                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("datetime");
            });

            modelBuilder.Entity<Insumo>(entity =>
            {
                entity.ToTable("Insumo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Codigo).IsUnicode(false);

                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.Property(e => e.Foto).IsUnicode(false);

                entity.Property(e => e.Lotes).IsUnicode(false);

                entity.Property(e => e.Nombre).IsUnicode(false);

                entity.Property(e => e.Recepcion).IsUnicode(false);
            });

            modelBuilder.Entity<MaquinasHerramienta>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Asignacion).IsUnicode(false);

                entity.Property(e => e.Codigo).IsUnicode(false);

                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.Property(e => e.DescripcionMantenimiento).IsUnicode(false);

                entity.Property(e => e.Disposicion).IsUnicode(false);

                entity.Property(e => e.Estado).IsUnicode(false);

                entity.Property(e => e.FechaIngreso).HasColumnType("datetime");

                entity.Property(e => e.Marca).IsUnicode(false);

                entity.Property(e => e.MotivoDisposicion).IsUnicode(false);

                entity.Property(e => e.MotivoEstado).IsUnicode(false);

                entity.Property(e => e.Nombre).IsUnicode(false);

                entity.Property(e => e.PeriodicidadMantenimiento).IsUnicode(false);
            });

            modelBuilder.Entity<MateriaPrima>(entity =>
            {
                entity.ToTable("MateriaPrima");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Codigo).IsUnicode(false);

                entity.Property(e => e.Nombre).IsUnicode(false);
            });

            modelBuilder.Entity<Ordencompra>(entity =>
            {
                entity.ToTable("ordencompra");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Aprobada)
                    .HasColumnType("datetime")
                    .HasColumnName("aprobada");

                entity.Property(e => e.Archivo)
                    .IsUnicode(false)
                    .HasColumnName("archivo");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.CondicionPago)
                    .IsUnicode(false)
                    .HasColumnName("condicionPago");

                entity.Property(e => e.Especificacion)
                    .IsUnicode(false)
                    .HasColumnName("especificacion");

                entity.Property(e => e.Estado)
                    .IsUnicode(false)
                    .HasColumnName("estado");

                entity.Property(e => e.Generada)
                    .HasColumnType("datetime")
                    .HasColumnName("generada");

                entity.Property(e => e.InfoInsumo).HasColumnName("infoInsumo");

                entity.Property(e => e.Insumo).HasColumnName("insumo");

                entity.Property(e => e.Precio)
                    .IsUnicode(false)
                    .HasColumnName("precio");

                entity.Property(e => e.Proveedor).HasColumnName("proveedor");

                entity.Property(e => e.Recepcionada)
                    .HasColumnType("datetime")
                    .HasColumnName("recepcionada");

                entity.HasOne(d => d.InfoInsumoNavigation)
                    .WithMany(p => p.Ordencompras)
                    .HasForeignKey(d => d.InfoInsumo)
                    .HasConstraintName("FK__ordencomp__infoI__2739D489");
            });

            modelBuilder.Entity<Ordentrabajo>(entity =>
            {
                entity.ToTable("ordentrabajo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cantidad)
                    .IsUnicode(false)
                    .HasColumnName("cantidad");

                entity.Property(e => e.Cliente)
                    .IsUnicode(false)
                    .HasColumnName("cliente");

                entity.Property(e => e.Codigo)
                    .IsUnicode(false)
                    .HasColumnName("codigo");

                entity.Property(e => e.Descripcion)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Despiece)
                    .IsUnicode(false)
                    .HasColumnName("despiece");

                entity.Property(e => e.Especificaciones)
                    .IsUnicode(false)
                    .HasColumnName("especificaciones");

                entity.Property(e => e.Estado)
                    .IsUnicode(false)
                    .HasColumnName("estado");

                entity.Property(e => e.Fechaentrega)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaentrega");

                entity.Property(e => e.Fechas)
                    .IsUnicode(false)
                    .HasColumnName("fechas");

                entity.Property(e => e.Insumosusados)
                    .IsUnicode(false)
                    .HasColumnName("insumosusados");

                entity.Property(e => e.Lugarentrega)
                    .IsUnicode(false)
                    .HasColumnName("lugarentrega");

                entity.Property(e => e.Observaciones)
                    .IsUnicode(false)
                    .HasColumnName("observaciones");

                entity.Property(e => e.Pedidofabrica)
                    .HasColumnType("datetime")
                    .HasColumnName("pedidofabrica");

                entity.Property(e => e.Planos)
                    .IsUnicode(false)
                    .HasColumnName("planos");

                entity.Property(e => e.Fechaaplazada)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaaplazada");

            });

            modelBuilder.Entity<PedidosPañol>(entity =>
            {
                entity.ToTable("PedidosPañol");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.Codigo)
                    .IsUnicode(false)
                    .HasColumnName("codigo");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.Insumo).HasColumnName("insumo");

                entity.Property(e => e.Operario).HasColumnName("operario");
            });

            modelBuilder.Entity<Personal>(entity =>
            {
                entity.ToTable("Personal");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("apellido");

                entity.Property(e => e.Categoria)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("categoria");

                entity.Property(e => e.CondicionContractual)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("condicionContractual");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.Dni).HasColumnName("dni");

                entity.Property(e => e.Legajo).HasColumnName("legajo");

                entity.Property(e => e.Mail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("mail");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombres");

                entity.Property(e => e.PremioEstablecido)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("premioEstablecido");

                entity.Property(e => e.Puesto)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("puesto");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("telefono");

                entity.Property(e => e.Activo).HasColumnName("activo");
            });

            modelBuilder.Entity<Proveedore>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Categorias)
                    .IsUnicode(false)
                    .HasColumnName("categorias");

                entity.Property(e => e.Cp)
                    .IsUnicode(false)
                    .HasColumnName("CP");

                entity.Property(e => e.Cuit).IsUnicode(false);

                entity.Property(e => e.Direccion).IsUnicode(false);

                entity.Property(e => e.Mail).IsUnicode(false);

                entity.Property(e => e.NombreContacto).IsUnicode(false);

                entity.Property(e => e.NombreEmpresa).IsUnicode(false);

                entity.Property(e => e.Observaciones).IsUnicode(false);

                entity.Property(e => e.RazonSocial).IsUnicode(false);

                entity.Property(e => e.Telefono).IsUnicode(false);
            });

            modelBuilder.Entity<Repuesto>(entity =>
            {
                entity.ToTable("Repuesto");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Codigo).IsUnicode(false);

                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.Property(e => e.Foto).IsUnicode(false);

                entity.Property(e => e.Nombre).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
