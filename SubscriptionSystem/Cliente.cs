//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SubscriptionSystem
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cliente
    {
        
        public int ClienteID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Nullable<int> PlanID { get; set; }
        public string MetodoDePago { get; set; }

        public void SetMetodoPago(int opcion)
        {
            
            switch (opcion)
            {
                case 1:
                    MetodoDePago = "Tarjeta de Credito";
                    break;
                case 2:
                    MetodoDePago = "Tarjeta de Debito";
                    break;
                case 3:
                    MetodoDePago = "PayPal";
                    break;
            }
        }

        public string GetMetodoPago() { return MetodoDePago; }
    
        public virtual Plane Plane { get; set; }
    }
}
