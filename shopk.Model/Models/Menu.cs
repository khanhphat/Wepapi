using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shopk.Model.Models
{
    [Table("Menus")]
    public class Menu
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string URL { get; set; }
        public int? DisplayOrder { get; set; }

        [Required]
        public int GroupID { get; set; } // Khoa ngoai

        [ForeignKey("GroupID")]
        public virtual MenuGroup MenuGroup { get; set; } //Khoas ngoai

        public string Target { get; set; }
        [Required]
        public bool Status { get; set; }
    }
}
