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
    public class Employe : Service<tp_jsf_employe>, IEmploye
    {
        static IDatabaseFactory factory = new DatabaseFactory();
        static IUnitOfWork UOW = new UnitOfWork(factory);
        public Employe() : base(UOW)
        {

        }
    }
}
