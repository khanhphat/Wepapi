using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopk.Data.Infrastructure_hatang
{
    //Dùng để giao tiếp khởi tạo các đối tượng
    //ap dụng mẫu factory trong design pattern
    public interface IDbFactory : IDisposable
    {
        MyDbContext Init();//phương thức init dbcontext
    }
}
