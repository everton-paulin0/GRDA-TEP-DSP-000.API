using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GRDA_TEP_DSP_000.Domain.Entities;
using GRDA_TEP_DSP_000.Domain.Entities.Enum;

namespace GRDA_TEP_DSP_000.Application.Model
{
    public class PalestraItemViewModel
    {
        public PalestraItemViewModel(int id, string subject, string trail, TimeSpan start, TimeSpan finish, TimeSpan duration)
        {
            Id = id;
            Subject = subject;
            Trail = trail;
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

        public static PalestraItemViewModel FromEntityPalestra(Palestra palestra)
            => new(
                palestra.Id,
                palestra.Subject,
                palestra.Trail.ToString(),
                palestra.Start,
                palestra.Finish,
                palestra.Duration
            );
    }
}
