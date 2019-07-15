using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinPe.Business;
using FinPe.Data.VO;
using FinPe.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinPe.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class LoginController : ControllerBase
    {
        private ILoginBusiness _loginBusiness;

        public LoginController(ILoginBusiness loginBusiness)
        {
            _loginBusiness = loginBusiness;
        }

        // POST: api/Login
        [HttpPost]
        [AllowAnonymous]
        public object Post([FromBody] Login usuarioLoginVO)
        {
            if (usuarioLoginVO == null || _loginBusiness == null) return BadRequest();
            
            var objUsuarioNovo = _loginBusiness.BuscarPorLogin(usuarioLoginVO);

            return objUsuarioNovo;
        }
    }
}
