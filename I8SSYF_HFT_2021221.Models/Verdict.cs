using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I8SSYF_HFT_2021221.Models
{
    public class Verdict
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int VerdictId { get; set; }
        public string Reliability { get; set; }
        public int PowerRating { get; set; }
        public int AvgConsumption { get; set; }

        [NotMapped]
        public virtual ICollection<EngineType> EngineTypes { get; set; }

        public Verdict()
        {
            EngineTypes = new HashSet<EngineType>();
        }

        //[ForeignKey(nameof(EngineType))]
        //public string EngineCodeFromVerdict { get; set; }
    }
}
