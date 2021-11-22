using I8SSYF_HFT_2021221.Models;
using I8SSYF_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I8SSYF_HFT_2021221.Logic
{
    public class ModelLogic : IModelLogic
    {
        IModelRepository repo;

        public ModelLogic(IModelRepository repo)
        {
            this.repo = repo;
        }

        public void Create(Model model)
        {
            repo.Create(model);
        }

        public void Delete(int modelId)
        {
            repo.Delete(modelId);
        }

        public IQueryable<Model> ReadAll()
        {
            return repo.ReadAll();
        }

        public IEnumerable<KeyValuePair<string, double>> CountOfShape()
        {
            return repo.ReadAll().GroupBy(x => x.Car).Select(x => new KeyValuePair<string, double>(x.Key.Name, x.GroupBy(y => y.Shape).Count()));
        }

        public int ShapeCounter()
        {
            return repo.ReadAll().GroupBy(y => y.Shape).Count();
        }

        public void Update(Model model)
        {
            repo.Update(model);
        }
    }
}
