namespace Pidev.data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("louai.tp_jsf_reclamation")]
    public partial class tp_jsf_reclamation
    {
     
        [Key]
        public int idRec { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        
        public int idemp { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        [StringLength(255)]
        public string rep { get; set; }

        public int? emps_id { get; set; }
    }
}
