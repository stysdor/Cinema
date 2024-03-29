﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.Core.Domain;

namespace Cinema.Core.Repositories
{
    public interface IGetDataRepository<T> where T:EntityBase
    {
        T Get(int id);
        IList<T> GetAll();
    }
}
