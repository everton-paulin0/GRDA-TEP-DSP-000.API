using GRDA_TEP_DSP_000.Application.Model;
using GRDA_TEP_DSP_000.Domain.Entities.Enum;
using MediatR;

namespace GRDA_TEP_DSP_000.Application.Command.UpdatePalestraCommand
{
    public class UpdatePalestraCommand : IRequest<ResultViewModel>
    {
        public int IdPalestra { get; set; }
        public string Subject { get; set; }
        public Trail Trail { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan Finish { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
