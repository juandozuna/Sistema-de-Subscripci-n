using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCSuscriptionSystem.Models.ViewModel
{
    public class UsuarioListado
    {
        public string Id { get; set; }
        public int IdPerfilUsuario { get; set; }

        [Display(Name = "Nombre de Usuario")]
        public string NombreDeUsuario { get; set; }

        [Display(Name="Correo Electronico ")]
        public string CorreoElectronico { get; set; }
        public Perfile perfile { get; set; }
    }
}