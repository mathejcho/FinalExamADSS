using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalExamADSS.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Manufacturer { get; set; }
        public string Photo { get; set; }
        public int YearOfManufacture { get; set; }


        public List<ClientCars> ClientCars { get; set; }
    }
}
