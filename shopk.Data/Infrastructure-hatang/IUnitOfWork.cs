using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopk.Data.Infrastructure_hatang
{
    public interface IUnitOfWork
    {
        //pthuc commit
        void Commit();
    }
}
