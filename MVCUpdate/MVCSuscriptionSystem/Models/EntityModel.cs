namespace MVCSuscriptionSystem.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EntityModel : DbContext
    {
        public EntityModel()
            : base("LocalConnection")//Esta es la conexion local con la base de Datos
            //:base("AzureConnection") //Esta es la conexion con azure a la base de Datos
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Plan> Plans { get; set; }
        public virtual DbSet<Servicio> Servicios { get; set; }
        public virtual DbSet<ServicioEnPlan> ServicioEnPlans { get; set; }
        public virtual DbSet<Subscripcion> Subscripcions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .Property(e => e.Primer_Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.Segundo_Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.Primer_Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.Numero_Telefonico)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.e_mail)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.Metodo_de_Pago)
                .IsUnicode(false);

            modelBuilder.Entity<Image>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Image>()
                .HasMany(e => e.Clientes)
                .WithOptional(e => e.Image)
                .HasForeignKey(e => e.ImagenID);

            modelBuilder.Entity<Image>()
                .HasMany(e => e.Plans)
                .WithOptional(e => e.Image)
                .HasForeignKey(e => e.ImagenID);

            modelBuilder.Entity<Image>()
                .HasMany(e => e.Servicios)
                .WithOptional(e => e.Image)
                .HasForeignKey(e => e.ImagenID);

            modelBuilder.Entity<Image>()
                .HasMany(e => e.Subscripcions)
                .WithOptional(e => e.Image)
                .HasForeignKey(e => e.ImageID);

            modelBuilder.Entity<Plan>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Plan>()
                .HasMany(e => e.ServicioEnPlans)
                .WithRequired(e => e.Plan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Plan>()
                .HasMany(e => e.Subscripcions)
                .WithRequired(e => e.Plan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Servicio>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Servicio>()
                .HasMany(e => e.ServicioEnPlans)
                .WithRequired(e => e.Servicio)
                .WillCascadeOnDelete(false);
        }
    }
}
