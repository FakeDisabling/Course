﻿using AutoMapper;
using BLL.DTO;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
    public class DevelopersGamesProfile : Profile
    {
        public DevelopersGamesProfile()
        {
            CreateMap<DevelopersGames, DevelopersGamesDTO>().ReverseMap();
        }
    }
}