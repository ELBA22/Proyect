using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistencia.Data;

namespace Aplication.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomer
    {
        private readonly projectContext _context;

        public CustomerRepository(projectContext context) : base(context)
        {
            _context = context;
        }
    }

   
}