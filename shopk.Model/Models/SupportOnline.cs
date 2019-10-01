﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopk.Model.Models
{
    [Table("SupportOnline")]
    public class SupportOnline
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SupportID { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Skype { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Yahoo { get; set; }
        public string Facebook { get; set; }
        public bool? Status { get; set; }
    }
}
