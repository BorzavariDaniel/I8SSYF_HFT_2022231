using I8SSYF_HFT_2021221.Models;
using I8SSYF_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I8SSYF_HFT_2021221.Logic
{
    public class CarLogic : ICarLogic
    {
        ICarRepository repo;

        public CarLogic(ICarRepository repo)
        {
            this.repo = repo;
        }

        public double AveragePrice()
        {
            return repo.ReadAll().Average(y => y.Price);

        }

        public IEnumerable<KeyValuePair<string, double>> AveragePriceByModels()
        {
            return repo.ReadAll().GroupBy(x => x.Model).Select(x => new KeyValuePair<string, double>(x.Key.Shape, x.Average(y => y.Price)));
        }

        public void Create(Car car)
        {
            repo.Create(car);
        }

        public void Delete(int carId)
        {
            repo.Delete(carId);
        }

        public Car Read(int carId)
        {
            return repo.Read(carId);
        }

        public IQueryable<Car> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Car car)
        {
            repo.Update(car);
        }
    }
}
