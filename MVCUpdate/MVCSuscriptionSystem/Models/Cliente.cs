using System.Web.UI.WebControls;

namespace MVCSuscriptionSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cliente : IModel
    {
        [Key]
        public int ClientID { get; set; }

        [Column("Primer Nombre")]
        [Required]
        [StringLength(50)]
        [Display(Name = "Primer Nombre")]
        public string Primer_Nombre { get; set; }

        [Column("Segundo Nombre")]
        [StringLength(50)]
        [Display(Name = "2do Nombre")]
        public string Segundo_Nombre { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name="Apellido")]
        public string Primer_Apellido { get; set; }

        [Column(TypeName = "date")]
        [Display(Name="Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime Fecha_de_nacimiento { get; set; }

        [Column("Numero Telefonico")]
        [StringLength(50)]
        [Display(Name="Numero Telefonico")]
        [DataType(DataType.PhoneNumber)]
        public string Numero_Telefonico { get; set; }

        [Column("e-mail")]
        [Required]
        [StringLength(100)]
        [Display(Name = "Correo Electronico")]
        [DataType(DataType.EmailAddress)]
        public string e_mail { get; set; }

        [Column("Metodo de Pago")]
        [Required]
        [StringLength(50)]
        [Display(Name = "Metodo de Pago")]
        public string Metodo_de_Pago { get; set; }

        [Display(Name = "Numero de Tarjeta")]
        [DataType(DataType.CreditCard)]
        public int? NumeroTarjeta { get; set; }


        [Display(Name = "Codigo CVC")]
        [DataType(DataType.Text)]
        [StringLength(5)]
        public int? CVC_o_CVV { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Expiracion")]
        public DateTime? Fecha_de_expiracion { get; set; }

        public int? SubscripcionID { get; set; }

        public int? ImagenID { get; set; }

        public virtual Image Image { get; set; }

        public virtual Subscripcion Subscripcion { get; set; }
    }
}
