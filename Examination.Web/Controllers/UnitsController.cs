using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Examination.DbModels.Models;
using Examination.Services;

namespace Examination.Web.Controllers
{
    public class UnitsController : ApiController
    {
       private UnitService unitService=new UnitService();
        // GET api/units
        public IEnumerable<Unit> Get()
        {
            return unitService.Where(u => true).ToList();
        }

        // GET api/units/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/units
        public void Post([FromBody]string value)
        {
        }

        // PUT api/units/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/units/5
        public void Delete(int id)
        {
        }
    }
}
