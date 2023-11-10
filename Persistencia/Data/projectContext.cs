using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using System.Reflection;

namespace Persistencia.Data;

public partial class projectContext : DbContext
{
    public projectContext(DbContextOptions<projectContext> options)
        : base(options)
    {
    }

    public DbSet<City> Cities { get; set; }

    public DbSet<Country> Countries { get; set; }

    public DbSet<Persontype> Persontypes { get; set; }

    public DbSet<State> States { get; set; }

    public DbSet<Customer> Customers {get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
