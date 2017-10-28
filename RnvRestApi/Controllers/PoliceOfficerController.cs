using Microsoft.AspNetCore.Mvc;
using RnvRestApi.DomainDtos;

namespace RnvRestApi.Controllers
{
    [Route("police-officer")]
    public class PoliceOfficerController : Controller
    {
        [HttpGet("{id}")]
        public PoliceOfficerDto GetGameSession(int id)
        {
            return new PoliceOfficerDto();
        }

        [HttpPost("{id}")]
        public PoliceOfficerDto CreateGameSession()
        {
            //save to db, get id
            return new PoliceOfficerDto();
        }
    }
}