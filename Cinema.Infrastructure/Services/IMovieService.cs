﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.Infrastructure.Dto;

namespace Cinema.Infrastructure.Services
{
    public interface IMovieService
    {
        MovieDto Get(int id);
        IList<MovieDto> GetAll();
        int InsertOrUpdate(MovieDto item);
        void Remove(int id);
    }
}