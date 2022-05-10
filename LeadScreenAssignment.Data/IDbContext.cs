﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadScreenAssignment.Data
{
    public interface IDbContext : IDisposable
    {
        IDbSet<T> Set<T>() where T: class;
        int SaveChanges();
    }
}
