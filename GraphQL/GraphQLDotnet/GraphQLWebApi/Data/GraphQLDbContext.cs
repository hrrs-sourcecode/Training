﻿using GraphQLWebApi.Model;
using Microsoft.EntityFrameworkCore;

namespace GraphQLWebApi.Data;

public class GraphQLDbContext : DbContext
{
    public GraphQLDbContext(DbContextOptions<GraphQLDbContext>options): base(options)
    {
        
    }

    public DbSet<Product> Products { get; set; }
}