using AutoMapper;
using Interview.Core.Dtos;
using Interview.Core.Entities;
using Interview.Core.Intefaces.AutoMaper_interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interview.Core.AutoMapper
{
    public class Mapper : IAutoMapper
    {
        public IMapper MapperService = null;
        public MapperConfiguration Configuration = null;
        public Mapper()
        {
            Configure();
            MapperService = Configuration.CreateMapper();
        }
        public void Configure()
        {
            Configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Song, SongDto>().ReverseMap()
                                              .ForPath(x => x.User, opt => opt.Ignore())
                                              .ForPath(c => c.Created, option => option.Ignore());
                cfg.CreateMap<User, UserDto>();
            });
        }
        public IMapper Get()
        {
            return MapperService;
        }
        void IAutoMapper.Configure()
        {
            throw new NotImplementedException();
        }
    }
}
