using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GRDA_TEP_DSP_000.Domain.Entities.Enum;

namespace GRDA_TEP_DSP_000.Application.Model
{
    public class UpdatePalestraInputModel
    {
        public int IdPalestra { get; set; }
        public string Subject { get; set; }
        public Trail Trail { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan Finish { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
