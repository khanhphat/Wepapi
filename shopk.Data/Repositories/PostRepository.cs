using shopk.Data.Infrastructure_hatang;
using shopk.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopk.Data.Repositories
{
    public interface IPostRepository : IRepository<Post>
    {
        //dùng để hiển thị danh sách các bài viết
        IEnumerable<Post> GetAllByTag(string tag, int pageIndex, int pageSize, out int totalRow);
    }

    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Post> GetAllByTag(string tag, int pageIndex, int pageSize, out int totalRow)
        {

            //join bảng
            var query = from p in DbContext.Posts
                        join pt in DbContext.PostTags
                        on p.PostsID equals pt.PostTagID
                        where pt.TagID == tag && p.Status //lấy theo tag. p.Status ko gì là băng true
                        orderby p.CreateDate descending 
                        select p;
            //query.count(): ddeems cac bang ghi va dua vao database
            totalRow = query.Count();
            //skip: lấy từ bảng ghi số bao nhiêu
            query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return query;
        }

        //public IEnumerable<Post> GetAllByTag(string tag, int pageIndex, int pageSize, out int totalRow)
        //{
        //    var query = from p in DbContext.Posts
        //                join pt in DbContext.PostTags
        //                on p.ID equals pt.PostID
        //                where pt.TagID == tag && p.Status
        //                orderby p.CreatedDate descending
        //                select p;

        //    totalRow = query.Count();

        //    query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);

        //    return query;
        //}
    }
}