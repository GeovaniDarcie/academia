using System.Threading.Tasks;
using Academia.Domain.Entities;
using Academia.Domain.Interfaces;

public class LoginService : ILoginService
{
    private IRepository<Usuario> _repository;
    public LoginService(IRepository<Usuario> repository)
    {
        _repository = repository;
    }
    public async Task<Usuario> Get(string userName, string password) {
       return await _repository.Get(userName, password);
    }
}