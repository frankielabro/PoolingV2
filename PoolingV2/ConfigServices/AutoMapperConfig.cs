using AutoMapper;
using PoolingV2.Models;
using PoolingV2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolingV2.ConfigServices
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            /* ReverseMap is used to map from one object to another object vice-versa
             */
            CreateMap<UserRegistrationViewModel, Freelancer>()
                .ForSourceMember(x => x.Password, y => y.Ignore())
                .ForSourceMember(x => x.UserType, y => y.Ignore())
                .ReverseMap();
            CreateMap<UserRegistrationViewModel, Employer>()
                .ForSourceMember(x => x.Password, y => y.Ignore())
                .ForSourceMember(x => x.UserType, y => y.Ignore())
                .ReverseMap();
            

        }
    }
}
