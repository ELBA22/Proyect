using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOS
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name {get; set;} = null!;

        public string IdCostume {get; set;} = null!;

        public int IdTipoPersonaFk {get; set;} 
        public DateOnly DateRegister {get; set;}

        public int IdCityFk {get; set;} 
    }
}