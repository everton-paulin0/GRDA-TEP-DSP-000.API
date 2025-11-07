using System.ComponentModel.DataAnnotations;
using GRDA_TEP_DSP_000.Domain.Entities;
using GRDA_TEP_DSP_000.Domain.Entities.Enum;

namespace GRDA_TEP_DSP_000.Application.Model
{
    public class CreatePalestraInputModel
    {
        [Required]

        public string Subject { get; set; }
        public Trail Trail { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan Finish { get; set; }
        public TimeSpan Duration { get; set; }

        public Palestra ToEntityPalestra()        
            => new Palestra(Subject, Trail, Start, Finish, Duration);
    }
}
