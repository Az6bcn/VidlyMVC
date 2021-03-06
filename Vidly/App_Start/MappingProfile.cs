﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            // DOMAIN TO DTO
            Mapper.CreateMap<Customer, CustomerDTO>();
            Mapper.CreateMap<Movie, MovieDTO>();
            Mapper.CreateMap<MemberShipType, MembershipTypeDTO>();
            Mapper.CreateMap<MovieGenre, GenreDTO>();
            Mapper.CreateMap<Rental, NewRentalDTO>();

            // DTO TO DOAMAIN
            Mapper.CreateMap<CustomerDTO, Customer>()
               .ForMember(m => m.ID, opt => opt.Ignore());

            Mapper.CreateMap<MovieDTO, Movie>()
                .ForMember(m => m.Id, opt => opt.Ignore());

            Mapper.CreateMap<NewRentalDTO, Rental>()
                .ForMember(m => m.Movie, opt => opt.Ignore())
                .ForMember(m => m.Customer, opt => opt.Ignore());
        }
    }
}