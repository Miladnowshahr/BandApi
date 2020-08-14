using AutoMapper;
using BandApi.Model;
using BandApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandApi.Controllers
{
    [ApiController]
    [Route("api/bands/{bandId}/albums")]
    public class AlbumController:ControllerBase
    {
        private readonly IBandAlbumRepository _repo;
        private readonly IMapper _mapper;

        public AlbumController(IBandAlbumRepository repo, IMapper mapper)
        {
            _repo = repo?? 
                throw new ArgumentNullException(nameof(repo));
            _mapper = mapper??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public ActionResult<IEnumerable<AlbumDto>> GetAlbumsForBand(Guid bandId)
        {
            if (!_repo.BandExist(bandId))
            {
                return NotFound();
            }
            var albumsFromRepo = _repo.GetAlbums(bandId);
            return Ok(_mapper.Map<IEnumerable<AlbumDto>>(albumsFromRepo));
        }
        
        [HttpGet("{albumId}",Name = "GetAlbumForBand")]
        public ActionResult<AlbumDto> GetAlbumForBand(Guid bandId,Guid albumId)
        {
            if (!_repo.BandExist(bandId))
            {
                return NotFound();
            }

            var albumFromRepo = _repo.GetAlbum(bandId, albumId);
            if (albumFromRepo==null)
            {
                return NotFound();
            }
            return (_mapper.Map<AlbumDto>(albumFromRepo));
        }

        [HttpPost]
        public ActionResult<AlbumDto> CreatingAlbum(Guid bandId,[FromBody] CreatingAlbumForDto album)
        {
            if (!_repo.BandExist(bandId))
            {
                return NotFound();
            }

            var albumEntity = _mapper.Map<Entities.Album>(album);
            _repo.AddAlbum(bandId, albumEntity);
            _repo.Save();

            var albumToReturn = _mapper.Map<AlbumDto>(albumEntity);
            return CreatedAtRoute("GetAlbumForBand", new { bandId = bandId, albumId = albumToReturn.Id },albumToReturn);

        }

    }
}
