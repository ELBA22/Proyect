using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOS
{
    public class CountryDto
    {
        public int Id {get; set;}
        public string Name { get; set; } = null!;
    }
}