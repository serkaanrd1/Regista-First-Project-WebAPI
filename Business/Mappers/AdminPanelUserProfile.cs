﻿using AutoMapper;
using Model.Dto.AdminPanelUserDtos;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mappers
{
    public class AdminPanelUserProfile : Profile
    {
        public AdminPanelUserProfile() 
        { 
        
        CreateMap<AdminPanelUser,AdminPanelUserDto>();  
        
        }

    }
}
