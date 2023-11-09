using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Persistencia.Data;

namespace Aplication.Repositories
{
    public class CityRepository : GenericRepository<City>, ICity
    {
        private readonly projectContext _context;
        public CityRepository(projectContext context) : base(context)
        {
            _context = context;
        }
    }
}