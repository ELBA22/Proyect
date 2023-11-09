using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistencia.Data;

namespace Aplication.Repositories
{
    public class StateRepository : GenericRepository<State>, IState
    {
        private readonly projectContext _context;
        public StateRepository(projectContext context) : base(context)
        {
            _context = context;
        }
    }
}