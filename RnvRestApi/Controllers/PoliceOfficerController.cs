using Microsoft.AspNetCore.Mvc;
using RnvRestApi.DomainDtos;

namespace RnvRestApi.Controllers
{
    [Route("police-officer")]
    public class PoliceOfficerController : Controller
    {
        [HttpGet("{id}")]
        public PoliceOfficerDto GetPoliceOfficer(int id)
        {
            return new PoliceOfficerDto();
        }

        [HttpPost("{id}")]
        public PoliceOfficerDto PostPoliceOfficer()
        {
            //save to db, get id
            return new PoliceOfficerDto();
        }
    }
}