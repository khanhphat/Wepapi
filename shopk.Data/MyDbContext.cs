using shopk.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopk.Data
{
    //Lớp này kế thừa từ dbcontext
    public class MyDbContext : DbContext
    {
        //key connectionstring: ShopKConnection
        public MyDbContext() : base("ShopKConnection")
        {
            //Khi load bảng cha thì nó ko tự động include bảng con
            this.Configuration.LazyLoadingEnabled = false;
        }

        //Khai bao cac bang:
        public DbSet<Footer> Footers { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuGroup> MenuGroups { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        public DbSet<Slide> Slides { get; set; }
        public DbSet<SupportOnline> SupportOnlines { get; set; }
        public DbSet<SystemConfig> SystemConfigs { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<VisitorStatistic> VisitorStatistics { get; set; }

        //No chay khi ta khoi tao.
        protected override void OnModelCreating(DbModelBuilder builder)
        {

        }

    }
}
