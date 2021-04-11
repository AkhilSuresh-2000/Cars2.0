using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cars2._0.Models
{
    public class Make
    {
        public int id { get; set; }
        [Required]
        [StringLength(255)]
        public string  Name { get; set; }

        
    }
}
