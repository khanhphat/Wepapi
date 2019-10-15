using shopk.Data.Infrastructure_hatang;
using shopk.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopk.Data.Repositories
{
    public interface IProductRepository
    {

    }
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {

        //constructor
        //Lúc khởi tạo constructor ta sẽ truyền "IDbFactory dbFactory", 
        //đồng thời nó sẽ lấy cái giá trị "dbFactory". đồng truyền vào cho base
        public ProductRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
