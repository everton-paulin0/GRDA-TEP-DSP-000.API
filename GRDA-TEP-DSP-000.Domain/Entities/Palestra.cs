using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRDA_TEP_DSP_000.Domain.Entities
{
    public class Palestra : BaseEntities
    {
        public string Subject { get; set; }
        public Trail Trail { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public TimeSpan Duration { get; set; }

        public void TotalDuration()
        {
            Duration = Finish - Start;
        }
    }
}
