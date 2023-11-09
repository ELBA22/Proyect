using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistencia.Data;

namespace Aplication.Repositories
{
    public class CountryRepository : GenericRepository<Country>, ICountry
    {
        private readonly projectContext _context;
        public CountryRepository(projectContext context) : base(context)
        {
            _context = context;
        }
    }
}