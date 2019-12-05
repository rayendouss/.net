namespace Pidev.data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("louai.tp_jsf_tache")]
    public partial class tp_jsf_tache
    {
        [Key]
        public int idt { get; set; }

        public DateTime? EndDate { get; set; }

        public DateTime? StartDate { get; set; }

        [StringLength(255)]
        public string desct { get; set; }

        [StringLength(255)]
        public string nomt { get; set; }

        public int? employes_id { get; set; }

        public int? id { get; set; }

        public int? timesheets_idT { get; set; }
    }
}
