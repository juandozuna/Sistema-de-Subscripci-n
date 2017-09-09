namespace MVCSuscriptionSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Plan")]
    public partial class Plan 
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Plan()
        {
            ServicioEnPlans = new HashSet<ServicioEnPlan>();
            Subscripcions = new HashSet<Subscripcion>();
        }

        public int PlanID { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        public double Precio { get; set; }

        public int? ImagenID { get; set; }

        public virtual Image Image { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServicioEnPlan> ServicioEnPlans { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Subscripcion> Subscripcions { get; set; }
    }
}
