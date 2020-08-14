using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandApi.Model
{
    public class CreatingAlbumForDto:IValidatableObject
    {
        [Required]
        public string Title { get; set; }
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
        public Guid? BandId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Title == Description)
                yield return new ValidationResult("The title and description need to be diffrent", new[] { "CreatingAlbumForDto" });
        }
    }
}
