using shopk.Data.Infrastructure_hatang;
using shopk.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopk.Data.Repositories
{
    //0.Phương thức ko có sẵn trong RepositoryBase. ta viết thêm, và cho kế thừa lại ở bên dưới (1.)
    public interface IProductCategoryRepository
    {
        //tra ve list
        IEnumerable<ProductCategory> GetByAlias(string alias);
    }
    //1. ProductCate sẽ kế thừa RepositoryBase, và IproductCate
    public class ProductCategoryRepository : RepositoryBase<ProductCategory>, IProductCategoryRepository
    {
       
        //Truyền - và nhận
        //constructor kế thừa từ base:
        //nguyên nhân
        public ProductCategoryRepository(DbFactory dbFactory) : base(dbFactory)
        {

        }

        //0.1. thì chúng ta sẽ tự định nghĩa.
        // return this.DbContext
        public IEnumerable<ProductCategory> GetByAlias(string alias)
        {
            return this.DbContext.ProductCategories.Where(x => x.Alias == alias);
        }
    }
}
