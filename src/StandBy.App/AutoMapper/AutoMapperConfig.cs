using AutoMapper;
using StandBy.App.ViewModels;
using StandBy.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StandBy.App.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            //transforma o ViewModel em Cliente e Cliente em ViewModel
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
        }
    }
}
