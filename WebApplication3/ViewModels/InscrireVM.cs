using System.ComponentModel.DataAnnotations;

namespace WebApplication3.ViewModels
{
    public class InscrireVM
    {
        [Required]
        public String login { get; set; }
        [Required]
        public String password { get; set; }
    }
}
