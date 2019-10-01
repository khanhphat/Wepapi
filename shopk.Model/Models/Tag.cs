using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopk.Model.Models
{
    [Table("Tags")]
    public class Tag
    {
        [Key]
        [MaxLength(50)]
        public string TagID { get; set; }
        [MaxLength(50)]
        [Required]
        public string TagName { get; set; }
        [MaxLength(50)]
        [Required]
        public string TagType { get; set; }
    }
}
