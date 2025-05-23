﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWebApp.Core
{
    public interface ICreateRepository<in T> : IDisposable
        where T : class
    {
        void Create(T item);
    }
}
