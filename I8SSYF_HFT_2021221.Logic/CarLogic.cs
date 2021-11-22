using I8SSYF_HFT_2021221.Models;
using I8SSYF_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I8SSYF_HFT_2021221.Logic
{
    class CarLogic : ICarLogic
    {
        IEngineRepository repo;

        public CarLogic(IEngineRepository repo)
        {
            this.repo = repo;
        }

        public double AverageNumberOfCylinders()
        {
            return repo.ReadAll().Average(y => y.NumOfCylinders);
        }

        public IEnumerable<KeyValuePair<string, double>> AverageNumberOfCylindersByModels()
        {
            return repo.ReadAll().GroupBy(x => x.Car).Select(x => new KeyValuePair<string, double>(x.Key.Name, x.Average(y => y.NumOfCylinders)));
        }

        public void Create(Engine engine)
        {
            repo.Create(engine);
        }

        public void Delete(int engineId)
        {
            repo.Delete(engineId);
        }

        public IQueryable<Engine> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Engine engine)
        {
            repo.Update(engine);
        }
    }
}
