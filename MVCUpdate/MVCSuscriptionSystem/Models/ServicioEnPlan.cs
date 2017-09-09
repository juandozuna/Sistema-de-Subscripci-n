namespace MVCSuscriptionSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ServicioEnPlan")]
    public partial class ServicioEnPlan : IModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ServicioEnPlanID { get; set; }

        public int ServicioID { get; set; }

        public int PlanID { get; set; }

        public virtual Plan Plan { get; set; }

        public virtual Servicio Servicio { get; set; }
    }
}
