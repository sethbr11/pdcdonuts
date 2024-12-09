//using System;
//using System.Collections.Generic;
//using Microsoft.EntityFrameworkCore;
//using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

//namespace donuts;

//public partial class ModelContext : DbContext
//{
//    public ModelContext()
//    {
//    }

//    public ModelContext(DbContextOptions<ModelContext> options)
//        : base(options)
//    {
//    }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        => optionsBuilder.UseMySql("name=ConnectionStrings:DefaultConnection", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.39-mysql"));

//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        OnModelCreatingPartial(modelBuilder);
//    }

//    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//}
