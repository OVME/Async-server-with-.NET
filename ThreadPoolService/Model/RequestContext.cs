using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ThreadPoolService.Model
{
    public class RequestContext : DbContext
    {
        
        public DbSet<Request> Requests { get; set; }
    }
}