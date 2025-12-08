namespace WebApplication3.Services
{
    public interface ISessionManagerService
    {
        public void add(String key, object data, HttpContext Context);
        public T Get<T>(String key, HttpContext Context);
    }
}
