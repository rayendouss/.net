using Pidev.data;
using Pidev.Data.Infrastructure;
using Pidev.servicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pidev.service
{
   public class tacheService :Service<tp_jsf_tache> ,ItacheService
    {
        static IDatabaseFactory factory = new DatabaseFactory();
        static IUnitOfWork UOW = new UnitOfWork(factory);
        public tacheService() : base(UOW)
        {

        }
        public IEnumerable<tp_jsf_tache> Listtacheparprojet(int id)
        {
            return GetMany(e => e.id == id).ToList();
           
        }
        public IEnumerable<tp_jsf_tache> ListTache(int id)
        {
            return GetMany(e => e.id == id).ToList();

        }
    }
}

