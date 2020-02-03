using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Appreciation.Models
{
    public class MessageViewModel
    {
        [Required]
        public string Id { get; set; }
        
        [Required]
        public string AppreciateToName { get; set; }

        [MaxLength(1000)]
        [MinLength(15)]
        [DataType(DataType.MultilineText)]
        [Required]
        public string AppreciationMessage { get; set; }

        [Required]
        public DateTime CreationDateTime { get; set; }

       
        
        public bool ShowAppreciatorName { get; set; }

        public string NameOfPoster { get; set; }
    }
}
