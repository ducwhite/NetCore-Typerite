using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Typerite.Models
{
    public class Categories
    {
        public int Id { get; set; }
        [Required]
        public string Category { get; set; }
    }
}
