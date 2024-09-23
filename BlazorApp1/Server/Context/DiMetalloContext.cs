using BlazorApp1.Shared.Models; //cambiazo
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.EntityFrameworkCore;
using Radzen;
using Personal = BlazorApp1.Shared.Models.Personal;
using Prestamo = BlazorApp1.Shared.Models.Prestamo;
using Proveedore = BlazorApp1.Shared.Models.Proveedore;

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
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; } = null!;
        public virtual DbSet<Categoria> Categorias { get; set; } = null!;
        public virtual DbSet<CondicionPago> CondicionPago { get; set; } = null!;

        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Cotizacione> Cotizaciones { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<EventosProduccion> EventosProduccions { get; set; } = null!;
        public virtual DbSet<Fallas> Fallas { get; set; } = null!;
        public virtual DbSet<FechasEvento> FechasEventos { get; set; } = null!;
        public virtual DbSet<Shared.Models.Insumo> Insumos { get; set; } = null!;

        public virtual DbSet<ItemPresupuesto> ItemPresupuesto { get; set; } = null!;
        public virtual DbSet<Lote> Lotes { get; set; } = null!;
        public virtual DbSet<MaquinasHerramienta> MaquinasHerramientas { get; set; } = null!;

        public virtual DbSet<Mantenimiento> Mantenimiento { get; set; } = null!;

        public virtual DbSet<MateriaPrima> MateriaPrimas { get; set; } = null!;
        public virtual DbSet<MovimientosOT> MovimientosOT { get; set; } = null!;

        public virtual DbSet<Shared.Models.Ordencompra> Ordencompras { get; set; } = null!;
        public virtual DbSet<Ordentrabajo> Ordentrabajos { get; set; } = null!;
        public virtual DbSet<PedidosPañol> PedidosPañols { get; set; } = null!;
        public virtual DbSet<Shared.Models.Personal> Personals { get; set; } = null!;
        public virtual DbSet<Prestamo> Prestamos { get; set; } = null!;
        public virtual DbSet<Presupuesto> Presupuestos { get; set; } = null!;
        public virtual DbSet<Proveedore> Proveedores { get; set; } = null!;
        public virtual DbSet<RecepcionesHistoricas> RecepcionesHistoricas { get; set; } = null!;

        public virtual DbSet<Repuesto> Repuestos { get; set; } = null!;

        public virtual DbSet<ValorDolar> ValorDolar { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS; DataBase= DiMetallo; Trusted_Connection= True; TrustServerCertificate= true;");
                optionsBuilder.UseMySql("server=localhost;user=root;password=Dimetallo2337;persist security info=True;database=DiMetallo;convert zero datetime=True", ServerVersion.Parse("10.3.39-mariadb"));
                //optionsBuilder.UseMySql("server=192.168.100.108;user=usuarioMetallo;password=Dimetallo2337;persist security info=True;database=DiMetallo;convert zero datetime=True", ServerVersion.Parse("10.3.39-mariadb"));
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

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre).IsUnicode(false);
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
            
            modelBuilder.Entity<CondicionPago>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.Nombre).IsUnicode(false);
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

                entity.Property(e => e.Obra)
                    .IsUnicode(false)
                    .HasColumnName("obra");

                entity.Property(e => e.Observaciones)
                    .IsUnicode(false)
                    .HasColumnName("observaciones");

                entity.Property(e => e.Cotizaciones)
                    .IsUnicode(false)
                    .HasColumnName("cotizaciones");

                entity.Property(e => e.Referencia)
                    .IsUnicode(false)
                    .HasColumnName("referencia");

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

                entity.Property(e => e.Tipo)
                   .IsUnicode(false)
                   .HasColumnName("Tipo");

                entity.Property(e => e.Remito)
                    .IsUnicode(false)
                    .HasColumnName("remito");
                entity.Property(e => e.Planos)
                                    .IsUnicode(false)
                                    .HasColumnName("Planos");

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

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Etapa)
                    .IsUnicode(false)
                    .HasColumnName("etapa");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.Operario).HasColumnName("operario");

                entity.Property(e => e.Ot).HasColumnName("ot");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tipo");
            });

            modelBuilder.Entity<Fallas>(entity =>
            {
                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.observacion).IsUnicode(false);

                entity.Property(e => e.fecha).IsUnicode(false);

                entity.Property(e => e.etapa).IsUnicode(false);

                entity.Property(e => e.empleado).HasColumnType("int");

                entity.Property(e => e.OT).HasColumnType("int");

                entity.Property(e => e.codigo).IsUnicode(false);

                entity.Property(e => e.correccion).IsUnicode(false);

                entity.Property(e => e.gravedad).IsUnicode(false);

            });
            modelBuilder.Entity<ItemPresupuesto>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Insumo).HasColumnType("int");

                entity.Property(e => e.Presupuesto).HasColumnType("int");

                entity.Property(e => e.Precio).IsUnicode(false);

                entity.Property(e => e.PrecioUnitario).IsUnicode(false);

                entity.Property(e => e.Cantidad).HasColumnType("int");

                entity.Property(e => e.OC).HasColumnType("int");

                entity.Property(e => e.Proveedor).HasColumnType("int");

                entity.Property(e => e.Estado).IsUnicode(false);

                entity.Property(e => e.Codigo).IsUnicode(false);


                entity.Property(e => e.Comentario).IsUnicode(false);

                entity.Property(e => e.NroRemito).IsUnicode(false);

                entity.Property(e => e.CondicionPago).IsUnicode(false);

                entity.Property(e => e.Moneda).IsUnicode(false);



                entity.Property(e => e.Observacion).IsUnicode(false);
                entity.Property(e => e.Descripcion).IsUnicode(false);



            });


            modelBuilder.Entity<ValorDolar>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Valor).HasColumnName("Valor");


            });
            modelBuilder.Entity<Fallas>(entity =>
            {
                entity.HasOne(e => e.personalNavigation)
                   .WithMany(s => s.Fallas)
                   .HasForeignKey(t => t.empleado)
                   .HasPrincipalKey(s => s.Id);

            });
            //modelBuilder.Entity<Fallas>(entity =>
            //{
            //    entity.HasOne(e => e.ordenNavigation)
            //        .WithMany(s => s.Fallas)
            //       .HasForeignKey(t => t.OT)
            //       .HasPrincipalKey(s => s.Id);

            //});

            modelBuilder.Entity<FechasEvento>(entity =>
            {
                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("datetime");
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

            modelBuilder.Entity<Shared.Models.Insumo>(entity =>
            {
                entity.ToTable("Insumo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Codigo).IsUnicode(false);

                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.Property(e => e.Foto).IsUnicode(false);

                entity.Property(e => e.Lotes).IsUnicode(false);

                entity.Property(e => e.Nombre).IsUnicode(false);

                entity.Property(e => e.Proveedor).IsUnicode(false);

                entity.Property(e => e.ProveedoresPosibles).IsUnicode(false);

                entity.Property(e => e.Recepcion).IsUnicode(false);

                entity.Property(e => e.Tipo).IsUnicode(false);

                entity.Property(e => e.UltimoPrecio).IsUnicode(false);

            });

            modelBuilder.Entity<Lote>(entity =>
            {
                entity.Property(e => e.FechaIngreso).HasColumnType("datetime");

                entity.Property(e => e.NroRemito).IsUnicode(false);

                entity.Property(e => e.OC).HasColumnName("OC");

                entity.Property(e => e.Proveedor).IsUnicode(false);

                entity.Property(e => e.Tipo).IsUnicode(false);

                entity.Property(e => e.Estado).IsUnicode(false);

                entity.Property(e => e.Presupuesto).IsUnicode(false);

                entity.Property(e => e.NumeroMuestra).IsUnicode(false);


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



                entity.Property(e => e.DetalleMantenimiento).IsUnicode(false);

                entity.Property(e => e.PeriodicidadMantenimiento).IsUnicode(false);

                entity.Property(e => e.UltimoMant).HasColumnName("UltimoMant").HasColumnType("datetime");

                entity.Property(e => e.DetalleCorrectivo).IsUnicode(false);

                entity.Property(e => e.Cantidad).HasColumnType("int");

                entity.Property(e => e.MantenimientoPreventivo).HasColumnName("mantenimientoPreventivo").HasColumnType("datetime");

                entity.Property(e => e.Personal).IsUnicode(false);


            });
            modelBuilder.Entity<Mantenimiento>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.Cantidad).HasColumnType("int");

                entity.Property(e => e.Detalle).IsUnicode(false);

                entity.Property(e => e.Etapas).IsUnicode(false);

                entity.Property(e => e.Maquina).HasColumnType("int");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e. Name).IsUnicode(false);

                entity.Property(e => e.Personal).IsUnicode(false);


            });


            modelBuilder.Entity<MateriaPrima>(entity =>
            {
                entity.ToTable("MateriaPrima");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Codigo).IsUnicode(false);

                entity.Property(e => e.Nombre).IsUnicode(false);
            });


            modelBuilder.Entity<MovimientosOT>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.OT).HasColumnType("int");

                entity.Property(e => e.EtapaOrigen).IsUnicode(false);

                entity.Property(e => e.EtapaDestino).IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("datetime").IsUnicode(false);

            });
            modelBuilder.Entity<Shared.Models.Ordencompra>(entity =>
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

                entity.Property(e => e.Comentario).IsUnicode(false);

                entity.Property(e => e.NroRemito).IsUnicode(false);

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

                entity.Property(e => e.TipoCuenta)
                    .IsUnicode(false)
                    .HasColumnName("TipoCuenta");

                entity.Property(e => e.PrecioUnitario)
                    .IsUnicode(false)
                    .HasColumnName("precioUnitario");

                entity.Property(e => e.Iva)
                    .IsUnicode(false)
                    .HasColumnName("IVA");

                entity.Property(e => e.Proveedor).HasColumnName("proveedor");

                entity.Property(e => e.Moneda).IsUnicode(false);

                entity.Property(e => e.Recepcionada)
                    .HasColumnType("datetime")
                    .HasColumnName("recepcionada");

                entity.HasOne(d => d.InfoInsumoNavigation)
                    .WithMany(p => p.OrdencompraInfoInsumoNavigations)
                    .HasForeignKey(d => d.InfoInsumo)
                    .HasConstraintName("FK__ordencomp__infoI__02FC7413");

                entity.HasOne(d => d.InsumoNavigation)
                    .WithMany(p => p.OrdencompraInsumoNavigations)
                    .HasForeignKey(d => d.Insumo)
                    .HasConstraintName("FK__ordencomp__insum__282DF8C2");

                entity.HasOne(d => d.ProveedorNavigation)
                    .WithMany(p => p.Ordencompras)
                    .HasForeignKey(d => d.Proveedor)
                    .HasConstraintName("FK__ordencomp__prove__2739D489");

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

                entity.Property(e => e.Color)
                    .IsUnicode(false)
                    .HasColumnName("color");

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

                entity.Property(e => e.Fechaaplazada)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaaplazada");

                entity.Property(e => e.Fechaentrega)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaentrega");

                entity.Property(e => e.Fechas).IsUnicode(false);

                entity.Property(e => e.Insumosusados)
                    .IsUnicode(false)
                    .HasColumnName("insumosusados");

                entity.Property(e => e.Lugarentrega)
                    .IsUnicode(false)
                    .HasColumnName("lugarentrega");

                entity.Property(e => e.Obra)
                    .HasMaxLength(10)
                    .HasColumnName("obra")
                    .IsFixedLength();

                entity.Property(e => e.Observaciones)
                    .IsUnicode(false)
                    .HasColumnName("observaciones");

                entity.Property(e => e.Pedidofabrica)
                    .HasColumnType("datetime")
                    .HasColumnName("pedidofabrica");

                entity.Property(e => e.Planos)
                    .IsUnicode(false)
                    .HasColumnName("planos");

                entity.Property(e => e.Referencia)
                    .HasMaxLength(10)
                    .HasColumnName("referencia")
                    .IsFixedLength();

                entity.Property(e => e.Titulo)
                    .IsUnicode(false)
                    .HasColumnName("titulo");

                entity.Property(e => e.ChapaEstructura)
                    .IsUnicode(false)
                    .HasColumnName("ChapaEstructura");

                entity.Property(e => e.ChapaBandejas)
                    .IsUnicode(false)
                    .HasColumnName("ChapaBandejas");

                entity.Property(e => e.Zocalo_Trineo)
                    .IsUnicode(false)
                    .HasColumnName("Zocalo_Trineo");

                entity.Property(e => e.Portaplanos)
                    .IsUnicode(false)
                    .HasColumnName("Portaplanos");

                entity.Property(e => e.TrabaViento)
                                    .IsUnicode(false)
                                    .HasColumnName("TrabaViento");

                entity.Property(e => e.Contrafrentes)
                                    .IsUnicode(false)
                                    .HasColumnName("Contrafrentes");

                entity.Property(e => e.TipoCierre)
                                    .IsUnicode(false)
                                    .HasColumnName("TipoCierre");

                entity.Property(e => e.SentidoPuertas)
                                    .IsUnicode(false)
                                    .HasColumnName("SentidoPuertas");

                entity.Property(e => e.Cancamos)
                                    .IsUnicode(false)
                                    .HasColumnName("Cancamos");

                entity.Property(e => e.DobleMarcoInterno)
                                    .IsUnicode(false)
                                    .HasColumnName("DobleMarcoInterno");

                entity.Property(e => e.CaballetesTermicas)
                                    .IsUnicode(false)
                                    .HasColumnName("CaballetesTermicas");

                entity.Property(e => e.CaballetesInterruptores)
                                    .IsUnicode(false)
                                    .HasColumnName("CaballetesInterruptores");

                entity.Property(e => e.TapasPiso)
                                    .IsUnicode(false)
                                    .HasColumnName("TapasPiso");

                entity.Property(e => e.PerfilesC1yC2)
                                    .IsUnicode(false)
                                    .HasColumnName("PerfilesC1yC2");

                entity.Property(e => e.PerfilesOmega)
                                    .IsUnicode(false)
                                    .HasColumnName("PerfilesOmega");

                entity.Property(e => e.SistemasAisladores)
                                    .IsUnicode(false)
                                    .HasColumnName("SistemasAisladores");

                entity.Property(e => e.RejillasVentilacion)
                                    .IsUnicode(false)
                                    .HasColumnName("RejillasVentilacion");

                entity.Property(e => e.Sobretecho)
                                    .IsUnicode(false)
                                    .HasColumnName("Sobretecho");

                entity.Property(e => e.ChapaPuertas)
                                    .IsUnicode(false)
                                    .HasColumnName("ChapaPuertas");
                entity.Property(e => e.Cotizaciones)
                    .IsUnicode(false)
                    .HasColumnName("Cotizaciones");
                entity.Property(e => e.Remitos)
                    .IsUnicode(false)
                    .HasColumnName("Remitos");


                entity.Property(e => e.UltimaEtapa).IsUnicode(false)
                    .HasColumnName("UltimaEtapa");

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

                entity.Property(e => e.Lote).HasColumnName("lote");


                entity.Property(e => e.Insumo).HasColumnName("insumo");

                entity.Property(e => e.Operario).HasColumnName("operario");
            });

            modelBuilder.Entity<PedidosPañol>()
           .HasOne(p => p.operarioNavigation)
           .WithMany(s => s.PedidosNavigation)
           .HasForeignKey(t => t.Operario)
           .HasPrincipalKey(s => s.Id);


            modelBuilder.Entity<PedidosPañol>()
           .HasOne(p => p.insumoNavigation)
           .WithMany(s => s.PedidosNavigation)
           .HasForeignKey(t => t.Insumo)
           .HasPrincipalKey(s => s.Id);




            modelBuilder.Entity<Shared.Models.Personal>(entity =>
            {
                entity.ToTable("Personal");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo).HasColumnName("activo");

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
            });

            modelBuilder.Entity<Prestamo>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.Estado).IsUnicode(false);

                entity.Property(e => e.FechaFin).HasColumnType("datetime");

                entity.Property(e => e.FechaInicio).HasColumnType("datetime");

                entity.HasOne(d => d.InsumoNavigation)
                    .WithMany(p => p.Prestamos)
                    .HasForeignKey(d => d.Insumo)
                    .HasConstraintName("FK__Prestamos__Insum__318258D2");

                entity.HasOne(d => d.OperarioNavigation)
                    .WithMany(p => p.Prestamos)
                    .HasForeignKey(d => d.Operario)
                    .HasConstraintName("FK__Prestamos__Opera__32767D0B");

                entity.HasOne(p => p.MaquinaNavigation)
                   .WithMany(s => s.Prestamos)
                   .HasForeignKey(t => t.Maquina)
                   .HasPrincipalKey(s => s.Id);
            });


            modelBuilder.Entity<Shared.Models.Presupuesto>(entity =>
            {
                entity.ToTable("Presupuesto");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Aprobada)
                    .HasColumnType("datetime")
                    .HasColumnName("aprobada");

                entity.Property(e => e.Archivo)
                    .IsUnicode(false)
                    .HasColumnName("archivo");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.Comentario).IsUnicode(false);

                entity.Property(e => e.NroRemito).IsUnicode(false);

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

                entity.Property(e => e.OC).HasColumnName("OC");

                entity.Property(e => e.Precio)
                    .IsUnicode(false)
                    .HasColumnName("precio");
                entity.Property(e => e.Moneda).IsUnicode(false);

                entity.Property(e => e.PrecioUnitario)
                    .IsUnicode(false)
                    .HasColumnName("precioUnitario");

                entity.Property(e => e.Iva)
                    .IsUnicode(false)
                    .HasColumnName("IVA");

                entity.Property(e => e.Proveedor).HasColumnName("proveedor");

                entity.Property(e => e.Recepcionada)
                    .HasColumnType("datetime")
                    .HasColumnName("recepcionada");

                entity.Property(e => e.PlazoDePago).HasColumnName("PlazoDePago");

                entity.Property(e => e.TipoCuenta).HasColumnName("TipoCuenta");

            });

            modelBuilder.Entity<Presupuesto>(entity =>
            {
                entity.HasOne(e => e.InsumoNavigation)
                   .WithMany(s => s.PresupuestoInsumoNavigations)
                   .HasForeignKey(t => t.Insumo)
                   .HasPrincipalKey(s => s.Id);

            });


            modelBuilder.Entity<Presupuesto>(entity =>
            {
                entity.HasOne(e => e.ProveedorNavigation)
                   .WithMany(s => s.Presupuestos)
                   .HasForeignKey(t => t.Proveedor)
                   .HasPrincipalKey(s => s.Id);

            });

            //modelBuilder.Entity<Presupuesto>(entity =>
            //{
            //    entity.HasOne(e => e.InsumoNavigation)
            //       .WithMany(s => s.Presupuestos)
            //       .HasForeignKey(t => t.Insumo)
            //       .HasPrincipalKey(s => s.Id);

            //});

            //modelBuilder.Entity<Presupuesto>(entity =>
            //{
            //    entity.HasOne(e => e.ProveedorNavigation)
            //       .WithMany(s => s.Presupuestos)
            //       .HasForeignKey(t => t.Proveedor)
            //       .HasPrincipalKey(s => s.Id);

            //});

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

                entity.Property(e => e.NombreFantasia).IsUnicode(false);

                entity.Property(e => e.NumeroContacto).IsUnicode(false);

                entity.Property(e => e.Direccion).IsUnicode(false);

                entity.Property(e => e.Mail).IsUnicode(false);

                entity.Property(e => e.NombreContacto).IsUnicode(false);

                entity.Property(e => e.Localidad).IsUnicode(false);

                entity.Property(e => e.NombreEmpresa).IsUnicode(false);

                entity.Property(e => e.Observaciones).IsUnicode(false);

                entity.Property(e => e.RazonSocial).IsUnicode(false);

                entity.Property(e => e.Telefono).IsUnicode(false);
                
                entity.Property(e => e.TipoCuenta).IsUnicode(false);

            });

            modelBuilder.Entity<RecepcionesHistoricas>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cantidad).HasColumnType("int");

                entity.Property(e => e.Fecha).HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.NroRemito).IsUnicode(false);

                entity.Property(e => e.PrecioCotizado).IsUnicode(false);

                entity.Property(e => e.CondicionEntrada).IsUnicode(false);

                entity.Property(e => e.Insumo).HasColumnType("int");

                entity.Property(e => e.Presupuesto).HasColumnType("int");


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
