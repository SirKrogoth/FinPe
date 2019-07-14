using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinPe.Business;
using FinPe.Data.VO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinPe.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class UsuarioController : ControllerBase
    {
        public IUsuarioBusiness _usuarioBusiness;

        public UsuarioController(IUsuarioBusiness usuarioBusiness)
        {
            _usuarioBusiness = usuarioBusiness;
        }

        // GET: api/Usuario
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Usuario/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        [ProducesResponseType((201), Type = typeof(UsuarioVO))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        [ProducesResponseType((403))]
        [Authorize("Bearer")]
        //[TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] UsuarioVO usuarioVO)
        {
            if (usuarioVO == null)
                return BadRequest();
            else
            {
                //Criptografando senha.
                //Não pode ser descriptografado
                var senhaHash = BCrypt.Net.BCrypt.HashPassword(usuarioVO.senha);
                usuarioVO.senha = senhaHash;

                return new ObjectResult(_usuarioBusiness.CriarNovo(usuarioVO));
            }                
        }

        // PUT: api/Usuario/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
