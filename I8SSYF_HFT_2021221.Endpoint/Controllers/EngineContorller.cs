using I8SSYF_HFT_2021221.Logic;
using I8SSYF_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace I8SSYF_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EngineContorller : ControllerBase
    {
        IEngineLogic engineLogic;

        public EngineContorller(IEngineLogic engineLogic)
        {
            this.engineLogic = engineLogic;
        }

        // GET: /engine
        [HttpGet]
        public IEnumerable<Engine> Get()
        {
            return engineLogic.ReadAll();
        }

        // GET /engine/id
        [HttpGet("{id}")]
        public Engine Get(int id)
        {
            return engineLogic.Read(id);
        }

        // POST /engine
        [HttpPost]
        public void Post([FromBody] Engine value)
        {
            engineLogic.Create(value);
        }

        // PUT /engine/id
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Engine value)
        {
            engineLogic.Update(value);
        }

        // DELETE /engine/id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            engineLogic.Delete(id);
        }
    }
}
