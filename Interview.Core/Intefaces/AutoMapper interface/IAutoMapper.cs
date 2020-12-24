using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interview.Core.Intefaces.AutoMaper_interface
{
    public interface IAutoMapper
    {
        void Configure();

        IMapper Get();
    }
}
