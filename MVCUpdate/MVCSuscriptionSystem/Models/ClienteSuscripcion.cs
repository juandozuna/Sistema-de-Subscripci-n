using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCSuscriptionSystem.Models
{
    [Table("ClienteSuscripcion")]
    public class ClienteSuscripcion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClienteSuscripcionId { get; set; }

        public int ClienteId { get; set; }

        public int SubscripcionId { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual Subscripcion Subscripcion { get; set; }
        
    }
}