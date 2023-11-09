using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        ICity Citys {get;}
        ICountry Countrys {get;}
        IPersonType PersonTypes {get;}
        IState States {get;}
        Task SaveAsync();
    }
}