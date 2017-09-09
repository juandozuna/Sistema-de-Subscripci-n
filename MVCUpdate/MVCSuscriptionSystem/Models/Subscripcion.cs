namespace MVCSuscriptionSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Subscripcion")]
    public partial class Subscripcion 
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Subscripcion()
        {
            Clientes = new HashSet<Cliente>();
        }

        public int SubscripcionID { get; set; }

        [DisplayName("ID del cliente:")]
        public int ClientID { get; set; }

        [DisplayName("Plan:")]
        public int? PlanID { get; set; }

        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString ="{0:dd-MM-yyyy}", ApplyFormatInEditMode =true)]
        [DisplayName( "Fecha de creacion:")]
        public DateTime Fecha_creacion { get; set; }

        [DisplayName("Plan Activo")]
        public bool Active { get; set; }

        public int? ImageID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cliente> Clientes { get; set; }

        public virtual Image Image { get; set; }

        public virtual Plan Plan { get; set; }
    }
}
