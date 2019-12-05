namespace Pidev.data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("louai.tp_jsf_project")]
    public partial class tp_jsf_project
    {
        [Key]
        public int idp { get; set; }

        [StringLength(255)]
        public string descp { get; set; }

        public DateTime? endDate { get; set; }

        [StringLength(255)]
        public string nomp { get; set; }

        public DateTime? startDate { get; set; }
    }
}
