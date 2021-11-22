﻿using I8SSYF_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I8SSYF_HFT_2021221.Logic
{
    interface ICarLogic
    {
        void Create(Engine engine);
        IQueryable<Engine> ReadAll();
        void Update(Engine engine);
        void Delete(int engineId);

        double AverageNumberOfCylinders();

        IEnumerable<KeyValuePair<string, double>>
            AverageNumberOfCylindersByModels();
    }
}
