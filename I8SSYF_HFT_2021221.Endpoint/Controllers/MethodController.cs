using I8SSYF_HFT_2021221.Logic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace I8SSYF_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MethodController : ControllerBase
    {
        ICarLogic carLogic;

        public MethodController(ICarLogic carLogic)
        {
            this.carLogic = carLogic;
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> AverageNumberOfCylindersByModels()
        {
            return this.carLogic.AverageNumberOfCylindersByModels();
        }

        [HttpGet]
        public double AveragePrice()
        {
            return this.carLogic.AveragePrice();
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> AveragePriceByModels()
        {
            return this.carLogic.AveragePriceByModels();
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> CarCountByModels()
        {
            return this.carLogic.CarCountByModels();
        }

        [HttpGet]
        public int PetrolCars()
        {
            return this.carLogic.PetrolCars();
        }

        [HttpGet]
        public int SedanCount()
        {
            return this.carLogic.SedanCount();
        }
    }
}
