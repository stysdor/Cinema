using AutoMapper;
using Cinema.Core.Domain;
using Cinema.Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize() => new MapperConfiguration(cfg =>
        {
            
            cfg.CreateMap<Movie, MovieDto>().ForMember(x=> x.CategoryName, m=> m.MapFrom(p=> p.CategoryId.CategoryName))
                                            .ReverseMap();
            cfg.CreateMap<MovieDto, Movie>().ForPath(x => x.CategoryId.CategoryName, m => m.MapFrom(p => p.CategoryName));

            cfg.CreateMap<ReservationDto, Reservation>().ForPath(x => x.ShowingId.Id, m => m.MapFrom(p => p.ShowingId))
                                                        .ForPath(x=> x.ReservationStatusId.Id, m=> m.MapFrom(p =>p.ReservationStatusId))
                                                        .ForPath(x => x.SeatId.Id, m => m.MapFrom(p => p.SeatId))
                                                        .ForPath(x => x.CustomerId.Id, m => m.MapFrom(p => p.CustomerId))
                                                        .ForPath(x => x.EmployeeId.Id, m => m.MapFrom(p => p.EmployeeId));

            cfg.CreateMap<Reservation, ReservationDto>().ForPath(x => x.ShowingId, m => m.MapFrom(p => p.ShowingId.Id))
                                                        .ForPath(x => x.ReservationStatusId, m => m.MapFrom(p => p.ReservationStatusId.Id))
                                                        .ForPath(x => x.SeatId, m => m.MapFrom(p => p.SeatId.Id))
                                                        .ForPath(x => x.CustomerId, m => m.MapFrom(p => p.CustomerId.Id))
                                                        .ForPath(x => x.EmployeeId, m => m.MapFrom(p => p.EmployeeId.Id));

            cfg.CreateMap<ShowingDto, Showing>().ForPath(x => x.MovieId.Id, m => m.MapFrom(p => p.MovieId))
                                                 .ForPath(x => x.TheatreId.Id, m => m.MapFrom(p => p.TheatreId));

            cfg.CreateMap<Showing, ShowingDto>().ForPath(x => x.MovieId, m => m.MapFrom(p => p.MovieId.Id))
                                                .ForPath(x => x.TheatreId, m => m.MapFrom(p => p.TheatreId.Id));
        }).CreateMapper();
    }
}


