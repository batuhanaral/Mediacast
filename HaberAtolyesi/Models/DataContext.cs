using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HaberAtolyesi.Models
{
    public class DataContext:DbContext
    {
        public DataContext(): base("dbConnection")
        {

        }
        public DbSet<Haber> Habers { get; set; }
        public DbSet<Bolumler> Bolumlers { get; set; }
    }
}