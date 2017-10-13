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
    using System.ComponentModel;

    public partial class Cliente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cliente()
        {
            this.ClienteSuscripcions = new HashSet<ClienteSuscripcion>();
        }
    
        public int ClientID { get; set; }
        [DisplayName("Primer Nombre:")]
        public string Primer_Nombre { get; set; }
        [DisplayName("Segundo Nombre:")]
        public string Segundo_Nombre { get; set; }
        [DisplayName("Primer Apellido:")]
        public string Primer_Apellido { get; set; }
        [DisplayName("Fecha de Nacimiento:")]
        public System.DateTime Fecha_de_nacimiento { get; set; }
        [DisplayName("N�mero Telef�nico:")]
        public string Numero_Telefonico { get; set; }
        [DisplayName("e-mail:")]
        public string e_mail { get; set; }
        [DisplayName("M�todo de Pago:")]
        public string Metodo_de_Pago { get; set; }
        [DisplayName("N�mero de Tarjeta:")]
        public Nullable<int> NumeroTarjeta { get; set; }
        [DisplayName("CVC o CVV:")]
        public Nullable<int> CVC_o_CVV { get; set; }
        [DisplayName("Fecha de Expiraci�n:")]
        public Nullable<System.DateTime> Fecha_de_expiracion { get; set; }
        public Nullable<int> ImagenID { get; set; }
        public int IDPedro { get; set; }
        public int IDErick { get; set; }
    
        public virtual Image Image { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClienteSuscripcion> ClienteSuscripcions { get; set; }
    }
}
