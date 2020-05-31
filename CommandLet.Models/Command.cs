using System;
using System.ComponentModel.DataAnnotations; 

namespace CommandLet.Models
{
    public class Command
    {
        public int Id { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Command Description")]
        public string HowTo { get; set; }

        [Required(ErrorMessage = "Command syntax is required")]
        public string CmdLet { get; set; }
        public string Platform { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }
    }
}
