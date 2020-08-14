using BandApi.DataLayer;
using BandApi.Entities;
using BandApi.Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandApi.Services
{
    public class BandAlbumRepostitory : IBandAlbumRepository
    {
        private readonly BandDbContext _context;

        public BandAlbumRepostitory(BandDbContext context)
        {
            _context = context?? throw new ArgumentNullException(nameof(context));
        }
        public void AddAlbum(Guid bandId, Album album)
        {
            if (bandId==null)
            {
                throw new ArgumentNullException(nameof(bandId));
            }
            if (album== null)
            {
                throw new ArgumentNullException(nameof(album));
            }
            album.BandId = bandId;
            _context.Add(album);
        }

        public void AddBand(Band band)
        {
            if (band==null)
            {
                throw new ArgumentNullException(nameof(band));
            }

            _context.Add(band);
        }

        public bool AlbumExist(Guid albumId)
        {
            if (albumId==Guid.Empty)
            {
                throw new ArgumentNullException(nameof(albumId));
            }
            return _context.Albums.Any(a=>a.Id==albumId);
        }

        public bool BandExist(Guid bandId)
        {
            if (bandId==Guid.Empty)
            {
                throw new ArgumentNullException(nameof(bandId));
            }
            return _context.Bands.Any(a => a.BandId == bandId);
        }

        public void DeleteAlbum(Album album)
        {
            if (album==null)
            {
                throw new ArgumentNullException(nameof(album));
            }
            _context.Albums.Remove(album);
        }

        public void DeleteBand(Band band)
        {
            if (band==null)
            {
                throw new ArgumentNullException(nameof(band));
            }
            _context.Bands.Remove(band);
        }

        public Album GetAlbum(Guid bandId, Guid albumId)
        {
            if (bandId==Guid.Empty)
            {
                throw new ArgumentNullException(nameof(bandId));
            }
            if (albumId==Guid.Empty)
            {
                throw new ArgumentNullException(nameof(albumId));
            }

            return _context.Albums.FirstOrDefault(f => f.BandId == bandId && f.Id == albumId);

        }

        public IEnumerable<Album> GetAlbums(Guid bandId)
        {
            if (bandId==Guid.Empty)
            {
                throw new ArgumentNullException(nameof(bandId));
            }
            return _context.Albums.Where(w => w.BandId == bandId);

        }

        public Band GetBand(Guid bandId)
        {
            if (bandId==Guid.Empty)
            {
                throw new ArgumentNullException(nameof(bandId));
            }

            return _context.Bands.FirstOrDefault(f => f.BandId == bandId);
        }

        public IEnumerable<Band> GetBands()
        {
            return _context.Bands.ToList();
        }

        public IEnumerable<Band> GetBands(BandResourceParameter bandParam)
        {
            if (string.IsNullOrWhiteSpace(bandParam.MainGenre) && string.IsNullOrWhiteSpace(bandParam.SearchQuery))
            {
                return GetBands();
            }

            var collection = _context.Bands as IQueryable<Band>;

            if(!string.IsNullOrWhiteSpace(bandParam.MainGenre))
            {
                var mainGenre = bandParam.MainGenre.Trim();
                collection = collection.Where(w => w.MainGenre == mainGenre);
            }
            if (!string.IsNullOrWhiteSpace(bandParam.SearchQuery))
            {
                var searchQuery = bandParam.SearchQuery.Trim();
                collection = collection.Where(w => w.Name.Contains(searchQuery));
            }

            return collection.ToList();
        }

        public IEnumerable<Band> GetBands(IEnumerable<Guid> bandIds)
        {
            if (bandIds==null)
            {
                throw new ArgumentNullException(nameof(bandIds));
            }
            return _context.Bands.Where(w => bandIds.Contains(w.BandId)).ToList();
        }

        public bool Save()
        {
            return (_context.SaveChanges()>=0);
        }

        public void UpdateAlbum(Album album)
        {
            //not implmented
        }

        public void UpdateBand(Band band)
        {
            //not implmented
        }
    }
}
