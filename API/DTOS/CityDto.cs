using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOS
{
    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdStateFk { get; set; }
    }
}