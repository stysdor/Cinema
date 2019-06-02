using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Cinema.Core.Domain;
using Cinema.Core.Repositories;
using Cinema.Infrastructure.Dto;
using Cinema.Infrastructure.Repositories;

namespace Cinema.Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private IMovieRepository _repository;
        private ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public MovieService(IMapper mapper)
        {
            _repository = new MovieRepository();
            _categoryRepository = new CategoryRepository();
            _mapper = mapper;
        }

        public MovieDto Get(int id)
        {
            var movie = _repository.Get(id);
            return _mapper.Map<MovieDto>(movie);
        }

        public IList<MovieDto> GetAll()
        {
            var movies = _repository.GetAll();
            return _mapper.Map<IList<MovieDto>>(movies);
        }

        public int InsertOrUpdate(MovieDto item)
        {
            var categoryId = _categoryRepository.GetOrAddByName(item.CategoryName);
            var movie = _mapper.Map<Movie>(item);
            movie.CategoryId = categoryId;
            return _repository.InsertOrUpdate(movie);
        }

        public void Remove(int id)
        {
            _repository.Remove(id);
        }
    }
}
