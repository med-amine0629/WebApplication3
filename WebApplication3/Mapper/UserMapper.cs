using WebApplication3.Models;
using WebApplication3.ViewModels;

namespace WebApplication3.Mapper
{
    public class UserMapper
    {
        public static User GetUserFromInscrire(InscrireVM vm)
        {
            User user = new User();
            user.login = vm.login;
            user.password = vm.password;
            return user;
        }
    }
}
