using shopk.Data.Infrastructure_hatang;
using shopk.Data.Repositories;
using shopk.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopk.Service
{
    public interface IPostService
    {
        void Add(Post post);

        void Update(Post post);

        void Delete(int id);

        IEnumerable<Post> GetAll();

        IEnumerable<Post> GetAllPaging(int page, int pageSize, out int totalRow);
        IEnumerable<Post> GetAllByCategoryPaging(int categoryId, int page, int pageSize, out int totalRow);
       
        //lay ra 1 bang ghi
        Post GetById(int id);

        IEnumerable<Post> GetAllByTagPaging(string tag, int page, int pageSize, out int totalRow);

        void SaveChanges();
    }
    //ke thua tu IPostService
    public class PostService : IPostService
    {

        //Muốn gọi Repository nao thi ta goi ở trên này
        IPostRepository _postRepository;
        IUnitOfWork _unitOfWork;

        //constructor
        /// <summary>
        /// Đây là cơ chế dependency injection
        /// nó sẽ
        /// </summary>
        /// <param name="postRepository"></param>
        /// <param name="unitOfWork"></param>
        public PostService(IPostRepository postRepository, IUnitOfWork unitOfWork)
        {
            this._postRepository = postRepository;
            this._unitOfWork = unitOfWork;
        }

        //element lai cac pthuoc cua lop cha
        public void Add(Post post)
        {
            _postRepository.Add(post);
        }

        public void Delete(int id)
        {
            _postRepository.Delete(id);
        }


        /// <summary>
        /// cach viết có chứa 1 array và include = null. 
        /// để khi lấy bài viết ta có thể vừa lấy tin tức kèm với danh mục tin
        /// thuộc tính "PostCategory" trong Model Post
        /// [ForeignKey("PostCategoryID")]
        /// public virtual PostCategory PostCategory { get; set; }
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Post> GetAll()
        {
            return _postRepository.GetAll(new string[] { "PostCategory" });
        }

        //khi click vao tung danh muc thi se lay ra pagin
        public IEnumerable<Post> GetAllByCategoryPaging(int categoryId, int page, int pageSize, out int totalRow)
        {
            //neu x=>x.Status = true
            return _postRepository.GetMultiPaging(x=>x.Status && x.PostCategoryID == categoryId, out totalRow, page,pageSize, new string[] { "PostCategory" });
        }

        public IEnumerable<Post> GetAllByTagPaging(string tag, int page, int pageSize, out int totalRow)
        {
            //Filter ta sẽ truyền chuỗi lamda
            //TODO: select all post by tag
            return _postRepository.GetAllByTag(tag, page, pageSize, out totalRow);
        }

        public IEnumerable<Post> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _postRepository.GetMultiPaging(x => x.Status, out totalRow, page, pageSize);
        }

        public Post GetById(int id)
        {
            return _postRepository.GetSingleById(id);
        }

        //Commit la phthuc insert vao db
        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Post post)
        {
            _postRepository.Update(post);
        }
    }
}
