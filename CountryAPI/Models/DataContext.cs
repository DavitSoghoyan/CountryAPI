﻿using Microsoft.EntityFrameworkCore;

namespace CountryAPI.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Country> Countries { get; set; }
    }
}
