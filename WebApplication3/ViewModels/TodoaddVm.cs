using System.ComponentModel.DataAnnotations;

using WebApplication3.Enums;
namespace WebApplication3.ViewModels
{
    public class TodoaddVm
    {
        [Required]
        public string Libelle { get; set; }
        [Required]
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime Datelimit { get; set; }
        [Required]
        public State State { get; set; }
    }
}
