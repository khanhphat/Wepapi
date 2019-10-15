using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopk.Data.Infrastructure_hatang
{
    //kế thừa 1 interface và class.
    public class DbFactory : Disposable, IDbFactory
    {
        //khai bao 1 biến
        private MyDbContext _context;

        //phương thức init nó sẽ khởi tạo. 1 đối tượng cho dbContext
        public MyDbContext Init()
        {
            //kiểm tra nếu null. thì khởi tạo _context trong MyDbContext()
            return _context ?? (_context = new MyDbContext());
        }
        protected override void DisposeCore()
        {
            //Nếu khác null sẽ dispose nó
            if (_context != null)
                _context.Dispose(); 
        }
    }
}
