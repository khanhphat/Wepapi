using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopk.Data.Infrastructure_hatang
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private MyDbContext _context;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }
        public MyDbContext DbContext
        {
            get
            {
                return _context ?? (_context = dbFactory.Init());
            }
        }
        public void Commit()
        {
            DbContext.SaveChanges();
        }
    }
}
