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
    
    public partial class PerfilRole
    {
        public int perfiRolesID { get; set; }
        public int perfilId { get; set; }
        public string roleName { get; set; }
    
        public virtual Perfile Perfile { get; set; }
    }
}