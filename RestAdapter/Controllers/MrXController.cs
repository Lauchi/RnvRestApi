using Microsoft.AspNetCore.Mvc;
using RestAdapter.DomainHtos;

namespace RestAdapter.Controllers
{
    [Route("mr-x")]
    public class MrXController : Controller
    {
        [HttpGet("{id}")]
        public MrXHto GetMrX(int id)
        {
            return new MrXHto();
        }

        [HttpPost("{id}")]
        public MrXHto PostMrX()
        {
            //save to db, get id
            return new MrXHto();
        }
    }
}