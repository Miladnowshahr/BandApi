using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandApi.Model
{
    public class BandDto
    {
        public Guid BandId { get; set; }

        public string Name { get; set; }

        public string FoundedYearAgo { get; set; }

        public string MainGenre { get; set; }
    }
}
