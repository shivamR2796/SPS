using Microsoft.EntityFrameworkCore;
using SPS.Models;
using System.Collections.Generic;

namespace SPS.Datafile
{
    public class Data_Base: DbContext
    {
        public Data_Base(DbContextOptions<Data_Base> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<User_Id> User_Ids { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
