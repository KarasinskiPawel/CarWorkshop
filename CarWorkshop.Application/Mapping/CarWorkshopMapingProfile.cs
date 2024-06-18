﻿using AutoMapper;
using CarWorkshop.Application.CarWorkshop;
using CarWorkshop.Application.Commands.UpdateCarWorkshop;
using CarWorkshop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.Mapping
{
    public class CarWorkshopMapingProfile : Profile
    {
        public CarWorkshopMapingProfile()
        {
            CreateMap<CarWorkshopDto, Domain.Entities.CarWorkshop>()
                .ForMember(a => a.ContactDetails, opt => opt.MapFrom(src => new CarWorkshopContactDetails()
                {
                    City = src.City,
                    PhoneNumber = src.PhoneNumber,
                    PostalCode = src.PostalCode,
                    Street = src.Street,
                }));

            CreateMap<Domain.Entities.CarWorkshop, CarWorkshopDto>()
                .ForMember(dto => dto.Street, opt => opt.MapFrom(src => src.ContactDetails.Street))
                .ForMember(dto => dto.City, opt => opt.MapFrom(src => src.ContactDetails.City))
                .ForMember(dto => dto.PostalCode, opt => opt.MapFrom(src => src.ContactDetails.PostalCode))
                .ForMember(dto => dto.PhoneNumber, opt => opt.MapFrom(src => src.ContactDetails.PhoneNumber));

            CreateMap<CarWorkshopDto, EditCarWorkshopCommand>();
            //.ForMember(dto => dto.Street, opt => opt.MapFrom(src => src.ContactDetails.Street))
            //.ForMember(dto => dto.City, opt => opt.MapFrom(src => src.ContactDetails.City))
            //.ForMember(dto => dto.PostalCode, opt => opt.MapFrom(src => src.ContactDetails.PostalCode))
            //.ForMember(dto => dto.PhoneNumber, opt => opt.MapFrom(src => src.ContactDetails.PhoneNumber));
        }
    }
}