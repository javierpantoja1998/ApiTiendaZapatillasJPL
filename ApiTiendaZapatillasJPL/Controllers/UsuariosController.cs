using ApiTiendaZapatillasJPL.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuggetTiendaZapatillasJPL.Models;

namespace ApiTiendaZapatillasJPL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private RepositoryUsuarios repo;

        public UsuariosController(RepositoryUsuarios repo)
        {
            this.repo = repo;
        }

        [HttpGet("{id}")]
        
        public async Task<ActionResult<Usuario>> FindUsuario(int id)
        {
            return await this.repo.FindUsuarioAsync(id);
        }

        //METODO PARA INSERTAR USUARIO
        [HttpPost]
        public async Task<ActionResult> InsertUsuario(Usuario user)
        {
            //await this.repo.InsertUsuario(user.IdUsuario, user.Nombre,
            //    user.Dni, user.Direccion, user.Telefono, user.Email,
            //    user.Password);
            //return Ok();
        }
    }
}
