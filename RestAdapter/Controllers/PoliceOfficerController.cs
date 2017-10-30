using Microsoft.AspNetCore.Mvc;
using RestAdapter.DomainHtos;

namespace RestAdapter.Controllers
{
    [Route("police-officer")]
    public class PoliceOfficerController : Controller
    {
        [HttpGet("{id}")]
        public PoliceOfficerHto GetPoliceOfficer(int id)
        {
            return new PoliceOfficerHto(null);
        }

        [HttpPost("{id}")]
        public PoliceOfficerHto PostPoliceOfficer()
        {
            //save to db, get id
            return new PoliceOfficerHto(null);
        }
    }
}