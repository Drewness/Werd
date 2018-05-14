using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using Backend.Services;

namespace Backend.Controllers
{
    [AllowAnonymous]
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/users")]
    public class UserController : ApiController
    {
        private readonly UserService _service;

        public UserController()
        {
            _service = new UserService();
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            var users = _service.Get().ToList();

            return Ok(users);
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var user = _service.Get(id);

            return Ok(user);
        }
    }
}
