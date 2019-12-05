
using Pidev.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pidev.Data.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        Model1 DataContext { get; }
    }

}
