using System.Collections.Generic;
using System.Text.Json;
using WebApplication3.Models;

namespace WebApplication3.Services
{
    public class SessionManagerService : ISessionManagerService
    {
        public void add(String key,object data, HttpContext Context)
        {
            String Chaine = JsonSerializer.Serialize(data);
            Context.Session.SetString(key, Chaine);
        }
        public T Get<T>(String key, HttpContext Context)
        {
            String Chaine = Context.Session.GetString(key);
            if (Chaine == null)
            {
                return default(T);
            }
            else
            {
                T obj = JsonSerializer.Deserialize<T>(Chaine);
                return obj;
            }
            
            //return JsonSerializer.Deserialize<T>(Context.Session.GetString(key));
        }


    }
}
