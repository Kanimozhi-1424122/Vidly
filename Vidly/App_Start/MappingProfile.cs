using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.DTO;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<CustomerDTO, Customer>();
            Mapper.CreateMap<Customer, CustomerDTO>();
            Mapper.CreateMap<MemberShipTypeDto, MemberShipType>();
            Mapper.CreateMap<MemberShipType, MemberShipTypeDto>();
            Mapper.CreateMap<GenreDto, Genre>();
            Mapper.CreateMap<Genre, GenreDto>();
            Mapper.CreateMap<MovieDTO, Movie>();
            Mapper.CreateMap<Movie, MovieDTO>();
        }
    }
}