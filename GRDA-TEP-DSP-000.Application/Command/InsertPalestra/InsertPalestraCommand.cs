using GRDA_TEP_DSP_000.Application.Model;
using GRDA_TEP_DSP_000.Domain.Entities;
using GRDA_TEP_DSP_000.Domain.Entities.Enum;
using MediatR;

namespace GRDA_TEP_DSP_000.Application.Command.InsertPalestra
{
    public class InsertPalestraCommand : IRequest<ResultViewModel<int>>
    {
        public string Subject { get; set; }
        public Trail Trail { get; set; }
        public string Start { get; set; }
        public string Finish { get; set; }


        public Palestra ToEntityPalestra()
        => new Palestra(
            Subject,
            Trail,
            TimeSpan.Parse(Start),
            TimeSpan.Parse(Finish)
            
        );
    }
}
