using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CrudBS.Models;

public partial class CrudBsContext : DbContext
{
    public CrudBsContext()
    {
    }

    public CrudBsContext(DbContextOptions<CrudBsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Habitacione> Habitaciones { get; set; }

    public virtual DbSet<Hospedaje> Hospedajes { get; set; }

    public virtual DbSet<Huespede> Huespedes { get; set; }

    public virtual DbSet<PaquetesTuristico> PaquetesTuristicos { get; set; }

    public virtual DbSet<Permiso> Permisos { get; set; }

    public virtual DbSet<Reserva> Reservas { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        { }
    
    
    }

//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        //=> optionsBuilder.UseSqlServer("Server=LAPTOP-NHQ1PKN2\\SQLEXPRESS01; Database=CrudBS; Integrated Security=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Habitacione>(entity =>
        {
            entity.HasKey(e => e.NumeroHabitacion).HasName("PK__Habitaci__2B08D8A8CFF7D929");

            entity.Property(e => e.NumeroHabitacion).HasColumnName("Numero_habitacion");
            entity.Property(e => e.CapacidadHuespedes).HasColumnName("Capacidad_huespedes");
            entity.Property(e => e.Caracteristicas)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Tarifa).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TipoHabitacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Tipo_habitacion");
        });

        modelBuilder.Entity<Hospedaje>(entity =>
        {
            entity.HasKey(e => e.CodigoHospedaje).HasName("PK__Hospedaj__21170C9ACE455A66");

            entity.ToTable("Hospedaje");

            entity.Property(e => e.CodigoHospedaje).HasColumnName("Codigo_hospedaje");
            entity.Property(e => e.CedulaHospedaje).HasColumnName("Cedula_hospedaje");
            entity.Property(e => e.CodigoReservaHospedaje)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("Codigo_reserva_hospedaje");
            entity.Property(e => e.FechaFinal).HasColumnName("Fecha_final");
            entity.Property(e => e.FechaInicial).HasColumnName("Fecha_inicial");
            entity.Property(e => e.NumeroHabitacionHospedaje).HasColumnName("Numero_habitacion_hospedaje");

            entity.HasOne(d => d.CedulaHospedajeNavigation).WithMany(p => p.Hospedajes)
                .HasForeignKey(d => d.CedulaHospedaje)
                .HasConstraintName("FK__Hospedaje__Cedul__71D1E811");

            entity.HasOne(d => d.CodigoReservaHospedajeNavigation).WithMany(p => p.Hospedajes)
                .HasForeignKey(d => d.CodigoReservaHospedaje)
                .HasConstraintName("FK__Hospedaje__Codig__6FE99F9F");

            entity.HasOne(d => d.NumeroHabitacionHospedajeNavigation).WithMany(p => p.Hospedajes)
                .HasForeignKey(d => d.NumeroHabitacionHospedaje)
                .HasConstraintName("FK__Hospedaje__Numer__70DDC3D8");
        });

        modelBuilder.Entity<Huespede>(entity =>
        {
            entity.HasKey(e => e.Cedula).HasName("PK__Huespede__B4ADFE3944298E96");

            entity.Property(e => e.Cedula).ValueGeneratedNever();
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CodigoReservaHuesped)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("Codigo_reserva_huesped");
            entity.Property(e => e.FechaEntrada).HasColumnName("Fecha_entrada");
            entity.Property(e => e.FechaSalida).HasColumnName("Fecha_salida");
            entity.Property(e => e.IdPaquetesTuristicos).HasColumnName("ID_Paquetes_turisticos");
            entity.Property(e => e.IdServiciosHuesped).HasColumnName("ID_servicios_huesped");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NumeroHabitacionHuesped).HasColumnName("Numero_habitacion_huesped");

            entity.HasOne(d => d.CodigoReservaHuespedNavigation).WithMany(p => p.Huespedes)
                .HasForeignKey(d => d.CodigoReservaHuesped)
                .HasConstraintName("FK__Huespedes__Codig__6D0D32F4");

            entity.HasOne(d => d.IdPaquetesTuristicosNavigation).WithMany(p => p.Huespedes)
                .HasForeignKey(d => d.IdPaquetesTuristicos)
                .HasConstraintName("FK__Huespedes__ID_Pa__6C190EBB");

            entity.HasOne(d => d.IdServiciosHuespedNavigation).WithMany(p => p.Huespedes)
                .HasForeignKey(d => d.IdServiciosHuesped)
                .HasConstraintName("FK__Huespedes__ID_se__6B24EA82");

            entity.HasOne(d => d.NumeroHabitacionHuespedNavigation).WithMany(p => p.Huespedes)
                .HasForeignKey(d => d.NumeroHabitacionHuesped)
                .HasConstraintName("FK__Huespedes__Numer__6A30C649");
        });

        modelBuilder.Entity<PaquetesTuristico>(entity =>
        {
            entity.HasKey(e => e.IdPaquete).HasName("PK__Paquetes__1039C7A3A3026864");

            entity.ToTable("Paquetes_turisticos");

            entity.Property(e => e.IdPaquete).HasColumnName("ID_paquete");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Destino)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IdServicios).HasColumnName("ID_servicios");
            entity.Property(e => e.NombreServicio)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nombre_servicio");
            entity.Property(e => e.NumeroHabitacion).HasColumnName("Numero_habitacion");
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TipoDeViaje)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Tipo_de_viaje");

            entity.HasOne(d => d.IdServiciosNavigation).WithMany(p => p.PaquetesTuristicos)
                .HasForeignKey(d => d.IdServicios)
                .HasConstraintName("FK__Paquetes___ID_se__5DCAEF64");

            entity.HasOne(d => d.NumeroHabitacionNavigation).WithMany(p => p.PaquetesTuristicos)
                .HasForeignKey(d => d.NumeroHabitacion)
                .HasConstraintName("FK__Paquetes___Numer__5CD6CB2B");
        });

        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Permisos__3214EC273EF5EC7F");

            entity.Property(e => e.Id)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ID");
            entity.Property(e => e.Accion)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.CodigoReserva).HasName("PK__Reservas__3E81AB3EC0957BF8");

            entity.Property(e => e.CodigoReserva)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("Codigo_reserva");
            entity.Property(e => e.Anticipo).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.FechaFinal).HasColumnName("Fecha_final");
            entity.Property(e => e.FechaInicial).HasColumnName("Fecha_inicial");
            entity.Property(e => e.FechaReserva)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("Fecha_reserva");
            entity.Property(e => e.IdPaquetesReserva).HasColumnName("ID_paquetes_reserva");
            entity.Property(e => e.IdServiciosReserva).HasColumnName("ID_servicios_reserva");
            entity.Property(e => e.IdUsuario)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ID_usuario");
            entity.Property(e => e.NumeroHabitacionReserva).HasColumnName("Numero_habitacion_reserva");
            entity.Property(e => e.NumeroPersonas).HasColumnName("Numero_personas");
            entity.Property(e => e.Valor).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdPaquetesReservaNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdPaquetesReserva)
                .HasConstraintName("FK__Reservas__ID_paq__656C112C");

            entity.HasOne(d => d.IdServiciosReservaNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdServiciosReserva)
                .HasConstraintName("FK__Reservas__ID_ser__6477ECF3");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Reservas__ID_usu__66603565");

            entity.HasOne(d => d.NumeroHabitacionReservaNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.NumeroHabitacionReserva)
                .HasConstraintName("FK__Reservas__Numero__6754599E");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__ROLES__182A541277B84A21");

            entity.ToTable("ROLES");

            entity.Property(e => e.IdRol).HasColumnName("ID_rol");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("Fecha_creacion");
            entity.Property(e => e.IdPermisos)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ID_Permisos");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NumUsuarios).HasColumnName("Num_usuarios");

            entity.HasOne(d => d.IdPermisosNavigation).WithMany(p => p.Roles)
                .HasForeignKey(d => d.IdPermisos)
                .HasConstraintName("FK__ROLES__ID_Permis__4CA06362");
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.IdServicio).HasName("PK__Servicio__6D7F8A44584EC0E9");

            entity.Property(e => e.IdServicio).HasColumnName("ID_servicio");
            entity.Property(e => e.Categoria)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Costo).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NombreServicio)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nombre_servicio");
            entity.Property(e => e.Observacion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TipoDeServicio)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Tipo_de_servicio");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuarios__DF3D42525DA8FE1B");

            entity.HasIndex(e => e.CorreoElectronico, "UQ__Usuarios__E0991C1B5CC21C1A").IsUnique();

            entity.Property(e => e.IdUsuario)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ID_usuario");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contraseña)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Correo_electronico");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("Fecha_creacion");
            entity.Property(e => e.IdRol).HasColumnName("ID_rol");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__Usuarios__ID_rol__5165187F");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
