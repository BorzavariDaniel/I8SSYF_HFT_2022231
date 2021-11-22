using I8SSYF_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I8SSYF_HFT_2021221.Logic
{
    interface ICarLogic
    {
        void Create(Car car);
        IQueryable<Car> ReadAll();
        void Update(Car car);
        void Delete(int carId);

        double AveragePrice();

        IEnumerable<KeyValuePair<string, double>>
            AveragePricesByBrands();
    }
}
