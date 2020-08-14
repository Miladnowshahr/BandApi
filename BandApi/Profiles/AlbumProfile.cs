using AutoMapper;
using BandApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandApi.Profiles
{
    public class AlbumProfile:Profile
    {
        public AlbumProfile()
        {
            CreateMap<Entities.Album, Model.AlbumDto>().ReverseMap();

            CreateMap<CreatingAlbumForDto, Entities.Album>(); 
        }


    }
}
