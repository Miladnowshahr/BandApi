using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BandApi.Entities
{
    public class Band
    {
        [Key]
        public Guid BandId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public DateTime Founded { get; set; }

        public string MainGenre { get; set; }

        
        public virtual ICollection<Album> Albums { get; set; } = new List<Album>();// null refrence 
    }
}
