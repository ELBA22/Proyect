using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class City :BaseEntity
{
    public string Name { get; set; }

    public int IdStateFk { get; set; }

    public virtual State IdStateFkNavigation { get; set; }
    public ICollection<Customer> Customers {get; set;}
}
