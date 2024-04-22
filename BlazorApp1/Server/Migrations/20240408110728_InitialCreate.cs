using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp1.Server.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreEmpresa = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cuit = table.Column<string>(type: "longtext", unicode: false, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Direccion = table.Column<string>(type: "longtext", unicode: false, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Mail = table.Column<string>(type: "longtext", unicode: false, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "longtext", unicode: false, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CP = table.Column<string>(type: "longtext", unicode: false, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreContacto = table.Column<string>(type: "longtext", unicode: false, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Observaciones = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RazonSocial = table.Column<string>(type: "longtext", unicode: false, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Corredor = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Expreso = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    domicilioEntrega = table.Column<string>(type: "longtext", unicode: false, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CondicionPago",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CondicionPago", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cotizaciones",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    cliente = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    titulo = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    descripcion = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    alcance = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tratamientosuperficial = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    color = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    valorpeso = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    valordolar = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    estado = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    codigo = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cantidad = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    observaciones = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fechaentrega = table.Column<DateTime>(type: "datetime", nullable: true),
                    obra = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    referencia = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Planos = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cotizaciones = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    remito = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Tipo = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cotizaciones", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Names = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastNames = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DNI = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Rol = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EventosProduccion",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    operario = table.Column<int>(type: "int", nullable: true),
                    etapa = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ot = table.Column<int>(type: "int", nullable: true),
                    fecha = table.Column<DateTime>(type: "datetime", nullable: true),
                    tipo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventosProduccion", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FechasEventos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: true),
                    Descripcion = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FechasEventos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Insumo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StockMin = table.Column<int>(type: "int", nullable: true),
                    StockMax = table.Column<int>(type: "int", nullable: true),
                    StockReal = table.Column<int>(type: "int", nullable: true),
                    Nombre = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Codigo = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Foto = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Recepcion = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Lotes = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Proveedor = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Tipo = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProveedoresPosibles = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insumo", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Lotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Tipo = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Numero = table.Column<int>(type: "int", nullable: true),
                    Cantidad = table.Column<int>(type: "int", nullable: true),
                    FechaIngreso = table.Column<DateTime>(type: "datetime", nullable: true),
                    Alto = table.Column<int>(type: "int", nullable: true),
                    Ancho = table.Column<int>(type: "int", nullable: true),
                    NroRemito = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Proveedor = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdInsumo = table.Column<int>(type: "int", nullable: true),
                    OC = table.Column<int>(type: "int", nullable: true),
                    CantidadIngreso = table.Column<int>(type: "int", nullable: true),
                    Estado = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Presupuesto = table.Column<int>(type: "int", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lotes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MaquinasHerramientas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Marca = table.Column<string>(type: "longtext", unicode: false, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nombre = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaIngreso = table.Column<DateTime>(type: "datetime", nullable: false),
                    Codigo = table.Column<string>(type: "longtext", unicode: false, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Asignacion = table.Column<string>(type: "longtext", unicode: false, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PeriodicidadMantenimiento = table.Column<int>(type: "int", unicode: false, nullable: false),
                    DescripcionMantenimiento = table.Column<string>(type: "longtext", unicode: false, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Estado = table.Column<string>(type: "longtext", unicode: false, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MotivoEstado = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Disposicion = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MotivoDisposicion = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "longtext", unicode: false, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UltimoMant = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaquinasHerramientas", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MateriaPrima",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StockMin = table.Column<int>(type: "int", nullable: true),
                    StockMax = table.Column<int>(type: "int", nullable: true),
                    StockReal = table.Column<int>(type: "int", nullable: true),
                    Nombre = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Codigo = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MateriaPrima", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ordentrabajo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    cliente = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fechaentrega = table.Column<DateTime>(type: "datetime", nullable: true),
                    descripcion = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    lugarentrega = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    especificaciones = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    estado = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    planos = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    codigo = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    despiece = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    pedidofabrica = table.Column<DateTime>(type: "datetime", nullable: true),
                    cantidad = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    observaciones = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Fechas = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    insumosusados = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fechaaplazada = table.Column<DateTime>(type: "datetime", nullable: true),
                    color = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    titulo = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    obra = table.Column<string>(type: "char(10)", fixedLength: true, maxLength: 10, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    referencia = table.Column<string>(type: "char(10)", fixedLength: true, maxLength: 10, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ChapaEstructura = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ChapaBandejas = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Zocalo_Trineo = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Portaplanos = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TrabaViento = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Contrafrentes = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipoCierre = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SentidoPuertas = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cancamos = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DobleMarcoInterno = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CaballetesTermicas = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CaballetesInterruptores = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TapasPiso = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PerfilesC1yC2 = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PerfilesOmega = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SistemasAisladores = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RejillasVentilacion = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Sobretecho = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ChapaPuertas = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Remitos = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cotizaciones = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ordentrabajo", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PedidosPañol",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    insumo = table.Column<int>(type: "int", nullable: true),
                    cantidad = table.Column<int>(type: "int", nullable: true),
                    operario = table.Column<int>(type: "int", nullable: true),
                    fecha = table.Column<DateTime>(type: "datetime", nullable: true),
                    codigo = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidosPañol", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Personal",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombres = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    apellido = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    dni = table.Column<int>(type: "int", nullable: true),
                    mail = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    telefono = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    direccion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    condicionContractual = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    legajo = table.Column<int>(type: "int", nullable: true),
                    puesto = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    categoria = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    premioEstablecido = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    activo = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personal", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Presupuesto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    estado = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    especificacion = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    archivo = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    insumo = table.Column<int>(type: "int", nullable: true),
                    cantidad = table.Column<int>(type: "int", nullable: true),
                    proveedor = table.Column<int>(type: "int", nullable: true),
                    generada = table.Column<DateTime>(type: "datetime", nullable: true),
                    aprobada = table.Column<DateTime>(type: "datetime", nullable: true),
                    recepcionada = table.Column<DateTime>(type: "datetime", nullable: true),
                    condicionPago = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    precio = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    precioUnitario = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IVA = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    infoInsumo = table.Column<int>(type: "int", nullable: true),
                    Comentario = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NroRemito = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OC = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presupuesto", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreEmpresa = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cuit = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Direccion = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Mail = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CP = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreContacto = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Observaciones = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RazonSocial = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    categorias = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Repuesto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StockMin = table.Column<int>(type: "int", nullable: true),
                    StockMax = table.Column<int>(type: "int", nullable: true),
                    StockReal = table.Column<int>(type: "int", nullable: true),
                    Nombre = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Codigo = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Foto = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repuesto", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(type: "varchar(450)", maxLength: 450, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoleAspNetUser",
                columns: table => new
                {
                    RolesId = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UsersId = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleAspNetUser", x => new { x.RolesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_AspNetRoleAspNetUser_AspNetRoles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetRoleAspNetUser_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(450)", maxLength: 450, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderKey = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<string>(type: "varchar(450)", maxLength: 450, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoleId = table.Column<string>(type: "varchar(450)", maxLength: 450, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles_1", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LoginProvider = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Prestamos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Operario = table.Column<int>(type: "int", nullable: true),
                    Lote = table.Column<int>(type: "int", nullable: true),
                    Insumo = table.Column<int>(type: "int", nullable: true),
                    Cantidad = table.Column<int>(type: "int", nullable: true),
                    Maquina = table.Column<int>(type: "int", nullable: true),
                    Estado = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaInicio = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaFin = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaFinReal = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamos", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Prestamos__Insum__318258D2",
                        column: x => x.Insumo,
                        principalTable: "Insumo",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Prestamos__Opera__32767D0B",
                        column: x => x.Operario,
                        principalTable: "Personal",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Prestamos_MaquinasHerramientas_Maquina",
                        column: x => x.Maquina,
                        principalTable: "MaquinasHerramientas",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ordencompra",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    estado = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    especificacion = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    archivo = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    insumo = table.Column<int>(type: "int", nullable: true),
                    cantidad = table.Column<int>(type: "int", nullable: true),
                    proveedor = table.Column<int>(type: "int", nullable: true),
                    generada = table.Column<DateTime>(type: "datetime", nullable: true),
                    aprobada = table.Column<DateTime>(type: "datetime", nullable: true),
                    recepcionada = table.Column<DateTime>(type: "datetime", nullable: true),
                    condicionPago = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    precio = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    precioUnitario = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IVA = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    infoInsumo = table.Column<int>(type: "int", nullable: true),
                    Comentario = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NroRemito = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ordencompra", x => x.id);
                    table.ForeignKey(
                        name: "FK__ordencomp__infoI__02FC7413",
                        column: x => x.infoInsumo,
                        principalTable: "Insumo",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__ordencomp__insum__282DF8C2",
                        column: x => x.insumo,
                        principalTable: "Insumo",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__ordencomp__prove__2739D489",
                        column: x => x.proveedor,
                        principalTable: "Proveedores",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleAspNetUser_UsersId",
                table: "AspNetRoleAspNetUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ordencompra_infoInsumo",
                table: "ordencompra",
                column: "infoInsumo");

            migrationBuilder.CreateIndex(
                name: "IX_ordencompra_insumo",
                table: "ordencompra",
                column: "insumo");

            migrationBuilder.CreateIndex(
                name: "IX_ordencompra_proveedor",
                table: "ordencompra",
                column: "proveedor");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_Insumo",
                table: "Prestamos",
                column: "Insumo");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_Maquina",
                table: "Prestamos",
                column: "Maquina");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_Operario",
                table: "Prestamos",
                column: "Operario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleAspNetUser");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "CondicionPago");

            migrationBuilder.DropTable(
                name: "cotizaciones");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "EventosProduccion");

            migrationBuilder.DropTable(
                name: "FechasEventos");

            migrationBuilder.DropTable(
                name: "Lotes");

            migrationBuilder.DropTable(
                name: "MateriaPrima");

            migrationBuilder.DropTable(
                name: "ordencompra");

            migrationBuilder.DropTable(
                name: "ordentrabajo");

            migrationBuilder.DropTable(
                name: "PedidosPañol");

            migrationBuilder.DropTable(
                name: "Prestamos");

            migrationBuilder.DropTable(
                name: "Presupuesto");

            migrationBuilder.DropTable(
                name: "Repuesto");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Proveedores");

            migrationBuilder.DropTable(
                name: "Insumo");

            migrationBuilder.DropTable(
                name: "Personal");

            migrationBuilder.DropTable(
                name: "MaquinasHerramientas");
        }
    }
}
