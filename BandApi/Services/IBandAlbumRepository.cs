using BandApi.DataLayer;
using BandApi.Entities;
using BandApi.Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandApi.Services
{
    public interface IBandAlbumRepository
    {
        IEnumerable<Album> GetAlbums (Guid bandId);

        Album GetAlbum(Guid bandId,Guid ablumId);

        void AddAlbum(Guid bandId, Album album);

        void UpdateAlbum(Album album);

        void DeleteAlbum(Album album) ;

        IEnumerable<Band> GetBands();
        IEnumerable<Band> GetBands(BandResourceParameter bandParam);
        Band GetBand(Guid bandId);
        IEnumerable<Band> GetBands(IEnumerable<Guid> bandId);
        void AddBand(Band band);
        void UpdateBand(Band band);
        void DeleteBand(Band band);

        bool BandExist(Guid bandId);
        bool AlbumExist(Guid albumId);
        bool Save();

    }
}
