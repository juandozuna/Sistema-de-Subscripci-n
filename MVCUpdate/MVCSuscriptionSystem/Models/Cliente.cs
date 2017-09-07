namespace MVCSuscriptionSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cliente
    {
        [Key]
        public int ClientID { get; set; }

        [Column("Primer Nombre")]
        [Required]
        [StringLength(50)]
        public string Primer_Nombre { get; set; }

        [Column("Segundo Nombre")]
        [StringLength(50)]
        public string Segundo_Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string Primer_Apellido { get; set; }

        [Column(TypeName = "date")]
        public DateTime Fecha_de_nacimiento { get; set; }

        [Column("Numero Telefonico")]
        [StringLength(50)]
        public string Numero_Telefonico { get; set; }

        [Column("e-mail")]
        [Required]
        [StringLength(100)]
        public string e_mail { get; set; }

        [Column("Metodo de Pago")]
        [Required]
        [StringLength(50)]
        public string Metodo_de_Pago { get; set; }

        public int? NumeroTarjeta { get; set; }

        public int? CVC_o_CVV { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Fecha_de_expiracion { get; set; }

        public int? SubscripcionID { get; set; }

        public int? ImagenID { get; set; }

        public virtual Image Image { get; set; }

        public virtual Subscripcion Subscripcion { get; set; }
    }
}
