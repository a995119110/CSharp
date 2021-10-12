using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using yungching.Models;
using System.Data.Entity;

namespace yungching.Dal
{
    public class NorthWind
    {
        public DbSet<NorthWind> northWinds { get; set; }

    }
}