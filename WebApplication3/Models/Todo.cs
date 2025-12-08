using WebApplication3.Enums;
using WebApplication3.ViewModels;

namespace WebApplication3.Models
{
    public class Todo
    {
        public string Libelle { get; set; }
        public string Description { get; set; }
        public DateTime Datelimit { get; set; }
        public State State { get; set; }
        public Todo()
        {
        }
    }
}
