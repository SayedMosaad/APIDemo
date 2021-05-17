using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Commander.DTOs
{
    public class CommandWriteDTO
    {
        
        [Required]
        public string HowTo { get; set; }
        [Required]
        public string Line { get; set; }
        [Required]  
        public string Platform { get; set; }
    }
}
