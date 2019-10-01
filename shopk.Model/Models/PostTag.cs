using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopk.Model.Models
{
    [Table("PostTags")]
    public class PostTag
    {
        [Key]
        public int PostTagID { get; set; }
        [Key]
        public string TagID { get; set; }

        [ForeignKey("PostTagID")]
        public virtual Post Post { get; set; }

        [ForeignKey("TagID")]
        public virtual Tag Tag { get; set; }

    }
}
