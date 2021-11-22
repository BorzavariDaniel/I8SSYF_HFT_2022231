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
        ICarRepository repo;

        public CarLogic(ICarRepository repo)
        {
            this.repo = repo;
        }

        public double AveragePrice()
        {
            return repo.ReadAll().Average(x => x.Price);
        }

        public IEnumerable<KeyValuePair<string, double>> AveragePricesByBrands()
        {
            throw new NotImplementedException();
        }

        public void Create(Car car)
        {
            throw new NotImplementedException();
        }

        public void Delete(int carId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Car> ReadAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            throw new NotImplementedException();
        }
    }
}
