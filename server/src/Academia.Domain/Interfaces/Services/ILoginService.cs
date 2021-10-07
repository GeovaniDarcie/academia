using System.Threading.Tasks;

public interface ILoginService
{
    Task<Usuario> Get(string username, string password);
}