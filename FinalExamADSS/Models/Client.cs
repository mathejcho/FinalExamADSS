using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalExamADSS.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(18, 70)]
        public int Age { get; set; }
        [Required]
        
        public int PassportNumber { get; set; }

        public List<ClientCars> ClientCars { get; set; }

    }
    }

