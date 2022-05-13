using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MojSwiat2.Models
{
    public class SpecialTag
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Name")]
        public string SpecialTags { get; set; }
    }
}
