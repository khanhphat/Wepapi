using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopk.Model.Abstract
{
    public abstract class Auditable : IAuditable
    {
        
        public DateTime? CreateDate { get; set; }
        [MaxLength(256)]
        public string CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        [MaxLength(256)]
        public string UpdatedBy { get; set; }

        [MaxLength(500)]
        public string MetaKeyword { get; set; }
        [MaxLength(2000)]
        public string MetaDescription { get; set; }
        
        public bool Status { get; set; }
    }
}
