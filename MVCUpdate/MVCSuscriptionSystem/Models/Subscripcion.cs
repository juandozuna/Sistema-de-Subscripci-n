namespace MVCSuscriptionSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Subscripcion")]
    public partial class Subscripcion : IModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Subscripcion()
        {
            Clientes = new HashSet<Cliente>();
        }

        public int SubscripcionID { get; set; }

        public int PlanID { get; set; }

        [Column(TypeName = "date")]
        public DateTime Fecha_creacion { get; set; }

        public bool Active { get; set; }

        public int? ImageID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cliente> Clientes { get; set; }

        public virtual Image Image { get; set; }

        public virtual Plan Plan { get; set; }
    }
}
