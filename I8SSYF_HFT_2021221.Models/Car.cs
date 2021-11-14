﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I8SSYF_HFT_2021221.Models
{
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        [NotMapped]
        public virtual ICollection<Engine> Engines { get; set; }

        [NotMapped]
        public virtual ICollection<Model> Models { get; set; }

        public Car()
        {
            Engines = new HashSet<Engine>();
            Models = new HashSet<Model>();
        }
    }
}