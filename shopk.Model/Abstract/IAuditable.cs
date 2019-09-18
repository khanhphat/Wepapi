using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopk.Model.Abstract
{
    public interface IAuditable
    {
        //Khai bao interface ko co pulic (Phuong thuc)
        DateTime? CreateDate { get; set; }
        string CreateBy { get; set; }
        DateTime? UpdateDate { get; set; }
        string UpdatedBy { get; set; }

        string MetaKeyword { get; set; }
        string MetaDescription { get; set; }
        
        bool Status { get; set; }
    }
}
