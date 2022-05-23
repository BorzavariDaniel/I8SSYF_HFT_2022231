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
    public class CarController : ControllerBase
    {
        ICarLogic carLogic;

        public CarController(ICarLogic carLogic)
        {
            this.carLogic = carLogic;
        }

        // GET: /car
        [HttpGet]
        public IEnumerable<Car> Get()
        {
            return carLogic.ReadAll();
        }

        // GET /car/id
        [HttpGet("{id}")]
        public Car Get(int id)
        {
            return carLogic.Read(id);
        }

        // POST /car
        [HttpPost]
        public void Post([FromBody] Car value)
        {
            carLogic.Create(value);
        }

        // PUT /car/id
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Car value)
        {
            carLogic.Update(value);
        }

        // DELETE /car/id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            carLogic.Delete(id);
        }
    }
}
