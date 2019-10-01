using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopk.Model.Models
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }
        [Required]
        [MaxLength(256)]
        public string Name { get; set; }
        [Required]
        [MaxLength(256)]
        public string Address { get; set; }
        [Required]
        [MaxLength(256)]
        public string Email { get; set; }
        [Required]
        [MaxLength(50)]
        public string Mobile { get; set; }
        [Required]
        [MaxLength(256)]
        public string Message { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        [MaxLength(256)]
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }
        public bool? Status { get; set; }

        public virtual IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}
