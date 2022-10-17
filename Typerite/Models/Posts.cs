using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Typerite.Models
{
    public class Posts
    {
        public int Id { get; set; }
        [Required]
        [MinLength(10)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        [Display(Name = "Image")]
        public string Background { get; set; }
        [Display(Name = "Author")]
        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public Authors Authors { get; set; }
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Categories Categories { get; set; }

        public string TitleTrimmed
        {
            get
            {
                if (Title.Length > 10) { return Title.Substring(0, 10) + " ..."; }
                else { return Title; }

            }
        }
        public string DescriptionTrimmed
        {
            get
            {
                if (Description.Length > 10) { return Description.Substring(0, 10) + " ..."; }
                else { return Description; }

            }
        }
    }
}
