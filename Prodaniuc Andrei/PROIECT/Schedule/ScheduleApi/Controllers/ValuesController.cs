using Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ScheduleApi.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/Values")]
    public class ValuesController : ApiController
    {
     
        [HttpGet]
        [Route("GetSchedule")]
        public IHttpActionResult GetSchedule(string sectia)
        {
            ReadRepository repo = new ReadRepository();
            var orar =repo.IncarcaOrar(sectia);
            return Ok(orar);
        }
       
    }
}
