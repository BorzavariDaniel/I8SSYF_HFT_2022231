using System;
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
        //public int CarId { get; set; }
        public string Engine { get; set; }
        public string Model { get; set; }
        public string Shape { get; set; }
        public int FirstRegistrationDate { get; set; }

        [NotMapped]
        public virtual ICollection<EngineType> EngineTypes { get; set; }

        public Car()
        {
            EngineTypes = new HashSet<EngineType>();
        }
    }
}
