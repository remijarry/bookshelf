using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        // this is good to have, as is using [ApiController]
        // you could also specify your default route here, e.g. [Route("api/[controller]")]
    }
}