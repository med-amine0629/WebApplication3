using System.ComponentModel.DataAnnotations;

namespace WebApplication3.ViewModels
{
    public class TodoEditVm
    {
        [Required]
        public string Libelle { get; set; }
        [Required]
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime Datelimit { get; set; }
        [Required]
        public string State { get; set; }
    }
}
