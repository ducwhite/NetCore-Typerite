using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Typerite.Models
{
    public class Contacts
    {
        public int Id { get; set; }
        [Display(Name = "Full name")]
        [Required]
        public string FullName { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [MinLength(2)]
        [Required]
        public string Message { get; set; }

        public string MessageTrimmed
        {
            get
            {
                if (Message != null)
                {
                    if (Message.Length > 20) { return Message.Substring(0, 20) + " ..."; }
                    else { return Message; }
                }
                else { return Message; }

            }
        }

    }
}
