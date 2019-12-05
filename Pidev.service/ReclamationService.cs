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
   public class ReclamationService: Service<tp_jsf_reclamation>, IReclamationService
    {

        static IDatabaseFactory factory = new DatabaseFactory();
        static IUnitOfWork UOW = new UnitOfWork(factory);
        public ReclamationService() : base(UOW)
        {

        }
        public IEnumerable<tp_jsf_reclamation> Listrec(int id)
        {
            return GetMany(e => e.idemp == id).ToList();

        }
    }
}
