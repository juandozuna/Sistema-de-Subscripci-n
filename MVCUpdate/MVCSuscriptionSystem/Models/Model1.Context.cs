﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCSuscriptionSystem.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MVCSuscriptionDatabseEntities : DbContext
    {
        public MVCSuscriptionDatabseEntities()
            : base("name=MVCSuscriptionDatabseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<ClienteSuscripcion> ClienteSuscripcions { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Perfile> Perfiles { get; set; }
        public virtual DbSet<PerfilRole> PerfilRoles { get; set; }
        public virtual DbSet<PerfilUsuario> PerfilUsuarios { get; set; }
        public virtual DbSet<Plan> Plans { get; set; }
        public virtual DbSet<Servicio> Servicios { get; set; }
        public virtual DbSet<ServicioEnPlan> ServicioEnPlans { get; set; }
        public virtual DbSet<Subscripcion> Subscripcions { get; set; }
    }
}
