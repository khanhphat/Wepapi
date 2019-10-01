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
    [Table("PostCategories")]
    public class PostCategory : Auditable 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PostCategoryId { get; set; }
        public string PostCategoryName { get; set; }
        public string PostCategoryAlias { get; set; }
        public string PostCategoryDescription { get; set; }
        public int ParentID { get; set; }
        public string PostCategoryImage {get; set;}
        public int DisplayOrder { get; set; }
        public bool? HomeFlag { get; set; }

        public virtual IEnumerable<Post> Posts { get; set; }
    }
}
