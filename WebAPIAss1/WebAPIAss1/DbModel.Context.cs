﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAPIAss1
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Student_AssigEntities : DbContext
    {
        public Student_AssigEntities()
            : base("name=Student_AssigEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<EntityEmployee> EntityEmployees { get; set; }
        public DbSet<HotelReservation> HotelReservations { get; set; }
        public DbSet<HotelDetail> HotelDetails { get; set; }
    }
}
