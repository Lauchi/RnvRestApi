using Microsoft.AspNetCore.Mvc;
using RnvRestApi.DomainHtos;

namespace RnvRestApi.Controllers
{
    [Route("police-officer")]
    public class PoliceOfficerController : Controller
    {
        [HttpGet("{id}")]
        public PoliceOfficerHto GetPoliceOfficer(int id)
        {
            return new PoliceOfficerHto();
        }

        [HttpPost("{id}")]
        public PoliceOfficerHto PostPoliceOfficer()
        {
            //save to db, get id
            return new PoliceOfficerHto();
        }
    }
}