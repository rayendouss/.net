namespace Pidev.data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("louai.tp_jsf_timesheet")]
    public partial class tp_jsf_timesheet
    {
        [Key]
        public int idT { get; set; }

        [StringLength(255)]
        public string EtatTache { get; set; }

        public int NbreConge { get; set; }

        public int NbreHeureTRavJour { get; set; }

        public int NbreHeureTRavS { get; set; }

        public int? etat { get; set; }

        public int? idEmploye { get; set; }

        public int? idpfk { get; set; }
    }
}
