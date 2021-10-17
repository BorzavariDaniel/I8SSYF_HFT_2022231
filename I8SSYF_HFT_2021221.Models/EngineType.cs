using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I8SSYF_HFT_2021221.Models
{
    public class EngineType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int EngineId { get; set; }
        public string EngineCode { get; set; }
        public int Power { get; set; }
        public int NumberOfCylinders { get; set; }
        public string Fuel { get; set; }

        [NotMapped]
        public virtual Car Car { get; set; }
        public virtual Verdict Verdict { get; set; }

        [ForeignKey(nameof(Car))]
        public string Engine { get; set; }

        [ForeignKey(nameof(Verdict))]
        public string Reliability { get; set; }
    }
}
