
using Pidev.service;
using Pidev.data;
using Pidev.Data.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pidev.servicePattern;
using MyFinance.service;

namespace Pidev.service
{
    public class timesheetService : Service<tp_jsf_timesheet> ,ItimesheetService
    {
      static IDatabaseFactory factory = new DatabaseFactory();
        static IUnitOfWork UOW = new UnitOfWork(factory);
        public timesheetService() :base(UOW)
        {

        }
        /* public  IEnumerable <Product> ListProduitTrie()
           {
               return GetAll().OrderByDescending(P => P.Price);
           }
           public IEnumerable<Product> ListProduitParCategory(Category c)
           {
               return GetMany(e => e.Category.Equals(c));
           }
           public IEnumerable<Product> ListProduitParQuantité()
           {
               return GetAll().OrderByDescending(p => p.Quantity).Take(2);

           }
           */
        public IEnumerable<tp_jsf_timesheet> Listtimeparemp(int id)
        {
            return GetMany(e => e.idEmploye == id).ToList();

        }

    }

}
