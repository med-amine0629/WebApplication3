using WebApplication3.Models;
using WebApplication3.ViewModels;

namespace WebApplication3.Service
{
    public class TodoMappers
    {
        public static Todo GetTodoFromTodo(TodoaddVm vm)
        {
            Todo todo = new Todo();
            todo.Libelle = vm.Libelle;
            todo.Description = vm.Description;
            todo.Datelimit = vm.Datelimit;
            todo.State = vm.State;

            return todo;
        }
            
    }
}
