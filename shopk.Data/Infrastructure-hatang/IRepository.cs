using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace shopk.Data.Infrastructure_hatang
{
    //Dùng để định nghĩa các class generate
    public interface IRepository<T> where T : class
    {
        //Marks an entity as new
        T Add(T entity);

        //Marks an entity as modified
        void Update(T entity);
        
        
        //removed
        //T delete khi delete thi no tra ve doi tuong do
        T Delete(T entity);
        T Delete(int id);

        //delete multi records
        void DeleteMulti(Expression<Func<T, bool>> where);

        //get an entity by int id
        T GetSingleById(int id);
        //includes: chính là thêm các bảng con vào
        T GetSingleByCondition(Expression<Func<T, bool>> expression, string[] includes = null);

        IEnumerable<T> GetAll(string[] includes = null);
        IEnumerable<T> GetMulti(Expression<Func<T, bool>> predicate, string[] includes = null);
        IEnumerable<T> GetMultiPaging(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50, string[] includes = null);

        int Count(Expression<Func<T, bool>> where);
        bool CheckContains(Expression<Func<T, bool>> predicate);
    }
}
