using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCSuscriptionSystem.Models
{
    [Table("ClienteSubscripcion")]
    public class ClienteSubscripcion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ServicioEnPlanID { get; set; }

        public int ClienteID { get; set; }

        public int SuscripcionID { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual Subscripcion Subscripcion { get; set; }
    }
}