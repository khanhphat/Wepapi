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
        public string TagID { get; set; }
    }
}
