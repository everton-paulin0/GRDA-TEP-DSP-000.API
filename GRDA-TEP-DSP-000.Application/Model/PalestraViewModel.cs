using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GRDA_TEP_DSP_000.Domain.Entities;

namespace GRDA_TEP_DSP_000.Application.Model
{
    public class PalestraViewModel
    {
        public PalestraViewModel(int id, string subject, string trail, TimeSpan start, TimeSpan finish, TimeSpan duration)
        {
            Id = id;
            Subject = subject;
            Trail = trail.ToString();
            Start = start;
            Finish = finish;
            Duration = duration;
        }

        public int Id { get; set; }
        public string Subject { get; set; }
        public string Trail { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan Finish { get; set; }
        public TimeSpan Duration { get; set; }

        public static PalestraViewModel FromEntityPalestra(Palestra entity)
            => new PalestraViewModel(entity.Id, entity.Subject, entity.Trail.ToString(), entity.Start, entity.Finish, entity.Duration);
    }
}
