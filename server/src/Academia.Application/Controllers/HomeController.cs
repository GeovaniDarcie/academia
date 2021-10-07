using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/account")]
public class HomeController : ControllerBase
{
    private ILoginService _service;
    public HomeController(ILoginService service)
    {
        _service = service;
    }

    [HttpPost]
    [Route("login")]
    [AllowAnonymous]
    public async Task<ActionResult<dynamic>> AuthenTicate([FromBody]Usuario model)
    {
        var usuario = await _service.Get(model.UserName, model.Password);

        if (usuario == null) 
            return NotFound(new {message = "Usuário ou senha inválidos"});
        var token = TokenService.GenerateToken(usuario);
        usuario.Password = "";
        return new {
            usuario = usuario,
            token = token
        };
    }
}