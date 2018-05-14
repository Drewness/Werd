using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using Backend.Services;

namespace Backend.Controllers
{
    [AllowAnonymous]
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/xml")]
    public class XmlController : ApiController
    {
        private readonly XmlService _service;

        public XmlController()
        {
            _service = new XmlService();
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetXml(string id)
        {
            var path = HttpContext.Current.Server.MapPath($"~/Data/{id}.xml");

            var doc = _service.GetXmlDocument(path);

            return Ok(doc);
        }
    }
}
