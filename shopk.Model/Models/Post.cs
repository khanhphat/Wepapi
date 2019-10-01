using shopk.Model.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopk.Model.Models
{
    [Table("Posts")]
    public class Post : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PostsID { get; set; }
        public string PostsName { get; set; }
        public string PostsAlias { get; set; }
        public int PostCategoryID { get; set; } //fk
        public string PostsImage { get; set; }
        public string PostsDescription { get; set; }
        public string Content { get; set; }
        public bool? HomeFlag { get; set; }
        public bool? HotFlag { get; set; }
        public int? ViewCount { get; set; }

        [ForeignKey("PostCategoryID")]
        public virtual PostCategory PostCategory { get; set; }
    }
}
