//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Servicio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Servicio()
        {
            this.ServicioEnPlans = new HashSet<ServicioEnPlan>();
        }
    
        public int ServicioID { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public Nullable<int> ImagenID { get; set; }
        public Nullable<int> IDPedro { get; set; }
        public Nullable<int> IDErick { get; set; }
    
        public virtual Image Image { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServicioEnPlan> ServicioEnPlans { get; set; }
    }
}
