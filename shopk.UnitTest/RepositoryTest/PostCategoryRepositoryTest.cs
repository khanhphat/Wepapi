using Microsoft.VisualStudio.TestTools.UnitTesting;
using shopk.Data.Infrastructure_hatang;
using shopk.Data.Repositories;
using shopk.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopk.UnitTest.RepositoryTest
{
    [TestClass]
    public class PostCategoryRepositoryTest
    {
        //Khaibao

        IDbFactory dbFacetory;
        IPostCategoryRepository objRepository;
        IUnitOfWork unitOfWork;

        //phuong thuc giụp chạy lần đầu tiên
        //để thiết và khởi tạo các đối tượng
        [TestInitialize]
        public void Initialize()
        {
            dbFacetory = new DbFactory();
            objRepository = new PostCategoryRepository(dbFacetory);
            unitOfWork = new UnitOfWork(dbFacetory);
        }

        [TestMethod]
        public void PostCategory_Repository_GetAll()
        {
            //tao list tra ve
            var list = objRepository.GetAll().ToList();
            Assert.AreEqual(3, list.Count);
        }

        [TestMethod]
        public void PostCategory_Repository_Create()
        {
            PostCategory category = new PostCategory();
            category.Name = "Test category";
            category.Alias = "test-category";
            category.Status = true;

            //sau khi khoi tao xong. Thi them vao repository voi method Add.
            var result = objRepository.Add(category);
            //sd unitOfwork de commit
            unitOfWork.Commit();

            //sau khi commit nos se sinhra 1 cai PostCategoryid
            Assert.IsNotNull(result, "Co gia tri");
            Assert.AreEqual(3, result.PostCategoryId);

        }
    }
}
