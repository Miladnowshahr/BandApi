using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandApi.Model
{
    public class BandForCreatingDto
    {
        [Required]
        public string Name { get; set; }

        public DateTime FoundedYearAgo { get; set; }

        public string MainGenre { get; set; }
    }
}
