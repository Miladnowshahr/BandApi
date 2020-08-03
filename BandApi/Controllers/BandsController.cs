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
    [Route("api/bands")]
    public class BandsController:ControllerBase
    {
        private readonly IBandAlbumRepository _repo;

        public BandsController(IBandAlbumRepository repo)
        {
            _repo = repo?? throw new ArgumentNullException(nameof(repo));
        }
        public IActionResult GetBands()
        {
            var bandsFromRepo = _repo.GetBands();
            return new JsonResult(bandsFromRepo);
        }

        [HttpGet("{bandId}")]
        public IActionResult GetBand(Guid bandId)
        {
            var bandFromRepo = _repo.GetBand(bandId);
            if (bandFromRepo==null)
            {
                return NotFound();
            }

            return Ok(bandFromRepo);
        }

    }
}
