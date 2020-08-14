using AutoMapper;
using BandApi.Entities;
using BandApi.Helper;
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
    [Route("api/bands")]

    [ApiController]
    public class BandsController : ControllerBase
    {
        private readonly IBandAlbumRepository _repo;
        private readonly IMapper _mapper;  //create define field
        public BandsController(IBandAlbumRepository repo, IMapper mapper)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper)); //bind mapper
        }

        public IActionResult GetBands([FromQuery]BandResourceParameter bandParamter)
        {
           
            var bandsFromRepo = _repo.GetBands(bandParamter);

            //به جای استفاده از این همه کد و تکرار کد در متدهای دیگر از روش auto mapper استفاده می کنیم
            //var bandDto = new List<BandDto>();
            //foreach (var item in bandsFromRepo)
            //{
            //    bandDto.Add(new BandDto()
            //    {
            //        BandId=item.BandId,
            //        Name=item.Name,
            //        MainGenre=item.MainGenre,
            //        FoundedYearAgo=$"{item.Founded.ToString("yyyy")} ({item.Founded.GetYearAgo()} years ago)"
            //    });
            //}
            return Ok(_mapper.Map<IEnumerable<BandDto>>(bandsFromRepo ));//create map to banddto
        }

        [HttpGet("{bandId}",Name ="GetBand")]
        public IActionResult GetBand(Guid bandId)
        {
            var bandFromRepo = _repo.GetBand(bandId);
            if (bandFromRepo==null)
            {
                return NotFound();
            }

            return Ok(bandFromRepo);
        }
        [HttpPost]
        public ActionResult<BandDto> CreateBand([FromBody] BandForCreatingDto band)
        {
            var bandEntity = _mapper.Map<Band>(band);
            _repo.AddBand(bandEntity);
            _repo.Save();

            var bandtoReturn = _mapper.Map<BandDto>(bandEntity);
            return CreatedAtRoute("GetBand", new { bandId = bandtoReturn.BandId },bandtoReturn); 
        }

    }
}
