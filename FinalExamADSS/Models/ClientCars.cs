using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalExamADSS.Models
{
    public class ClientCars
    {
        
        public int ClientId { get; set; }
        public Client Client { get; set; }
        
        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
