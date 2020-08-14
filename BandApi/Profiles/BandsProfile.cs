using AutoMapper;
using BandApi.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandApi.Profiles
{
    public class BandsProfile:Profile
    {
        public BandsProfile()
        {
            CreateMap<Entities.Band, Model.BandDto>()
                .ForMember(
                    des => des.FoundedYearAgo,
                    opt => opt.MapFrom(src => $"{src.Founded.ToString("yyyy")} " +
                      $"({src.Founded.GetYearAgo()} Years ago)"
                ));

            CreateMap<Model.BandForCreatingDto, Entities.Band>();
               
        }
    }
}
