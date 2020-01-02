using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using shopk.Data.Infrastructure_hatang;
using shopk.Data.Repositories;
using shopk.Model.Models;
using shopk.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopk.UnitTest.ServiceTest
{
    [TestClass]
    public class PostCategoryServiceTest
    {
        private Mock<IPostCategoryRepository> _mockRepository;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private IPostCategoryService _categoryService;
        private List<PostCategory> _listCategory;

        //1. khoi tao
        [TestInitialize]
        public void Initialize()
        {
            //khi mock ra no se khoi tao 1 doi tuong gia
            _mockRepository = new Mock<IPostCategoryRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _categoryService = new PostCategoryService(_mockRepository.Object, _mockUnitOfWork.Object);
            _listCategory = new List<PostCategory>()
            {
                new PostCategory() {PostCategoryId = 1, Name = "Danh muc 1", Status=true},
                new PostCategory() {PostCategoryId = 2, Name = "Danh muc 2", Status = true},
                new PostCategory() {PostCategoryId = 3, Name = "Danh muc 3", Status = true}
            };
        }

        [TestMethod]
        public void PostCategory_Service_GetAll()
        {
            //1.setup method
            _mockRepository.Setup(m => m.GetAll(null)).Returns(_listCategory);
            //2.call action
            var result = _categoryService.GetAll() as List<PostCategory>;
            //3.compare
            Assert.IsNotNull(result, "Result phai khac null");
            Assert.AreEqual(3, result.Count);
        }

        [TestMethod]
        public void PostCategory_Service_Create()
        {
            //khoi tao postcategory
            PostCategory category = new PostCategory();
            int id = 1;
            category.Name = "Test Service";
            category.Alias = "test-service";
            category.Status = true;

            //gan cho postid = 1
            _mockRepository.Setup(m => m.Add(category)).Returns((PostCategory p) => {
                p.PostCategoryId = 1;
                return p;
            });

            var result = _categoryService.Add(category);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.PostCategoryId);
        }
    }
}
