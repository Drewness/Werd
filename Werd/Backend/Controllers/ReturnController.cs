using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using Backend.Services;

namespace Backend.Controllers
{
    [AllowAnonymous]
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/returns")]
    public class ReturnController : ApiController
    {
        private readonly ReturnService _service;

        public ReturnController()
        {
            _service = new ReturnService();
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            var returns = _service.Get().ToList();

            return Ok(returns);
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Get(string id)
        {
            var ret = _service.Get(id);

            return Ok(ret);
        }
    }
}
