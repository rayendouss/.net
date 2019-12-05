using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pidev.data
{
   public class testt
    {
        [Key]
        public int id { get; set; }
      public IEnumerable<tp_jsf_employe> listA { get; set; }
     public  tp_jsf_timesheet listB { get; set; }
    }
}
