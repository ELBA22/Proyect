using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplication.Repositories;
using Domain.Interfaces;
using Persistencia.Data;

namespace Aplication.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly projectContext _context;

        public UnitOfWork(projectContext context)
        {
            _context = context;
        }

        private CityRepository _citys;
        private CountryRepository _countrys;
        private PersonTypeRepository _personTypes;
        private StateRepository _states;
        public ICity Citys
        {
            get
            {
                if (_citys == null)
                {
                    _citys = new CityRepository(_context);
                }
                return _citys;
            }
        }

        public ICountry Countrys
        {
            get
            {
                if (_countrys == null)
                {
                    _countrys = new CountryRepository(_context);
                }
                return _countrys;
            }
        }
        public IPersonType PersonTypes
        {
            get
            {
                if (_personTypes == null)
                {
                    _personTypes = new PersonTypeRepository(_context);
                }
                return _personTypes;
            }
        }

        public IState States
        {
            get
            {
                if (_states == null)
                {
                    _states = new StateRepository(_context);
                }
                return _states;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}