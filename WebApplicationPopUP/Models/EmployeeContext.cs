﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplicationPopUP.Models
{
    public class EmployeeContext : DbContext
    {
        public DbSet<Employee> dbSetemployee { get; set; }
    }
}