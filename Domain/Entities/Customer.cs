using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Customer :BaseEntity
    {
        public string Name {get; set;} = null!;

        public string IdCostume {get; set;} = null!;

        public int IdTipoPersonaFk {get; set;} 
        public DateOnly DateRegister {get; set;}

        public int IdCityFk {get; set;} 

        public virtual Persontype IdTipoPersonaFkNavigation {get; set;} = null!;

        public virtual City IdcityFkNavigation {get; set;} = null!;
    }
}