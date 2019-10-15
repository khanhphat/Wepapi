using shopk.Data.Infrastructure_hatang;
using shopk.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopk.Data.Repositories
{
    public interface IMenuRepository { }
    public class MenuRepository : RepositoryBase<Menu>, IMenuRepository
    {
        public MenuRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }
}
