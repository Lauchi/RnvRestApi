using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RnvRestApi.Controllers
{
    [Route("location")]
    public class LocationController : Controller
    {
        [HttpGet("{id}")]
        public string Get(string id)
        {
            return $"id: {id} name: lol, geloc: lol1, lol2";
        }


        [HttpGet]
        public string SearchStation([FromQuery] string name)
        {
            return name;
        }


        [HttpGet("{id}/to/{idTo}")]
        public string GetRoute(string id, string idTo)
        {
            return $"from {id} to {idTo} Via lololol";
        }
    }
}