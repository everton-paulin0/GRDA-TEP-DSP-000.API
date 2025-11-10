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
        public string Start { get; set; }
        public string Finish { get; set; }
        
        public TimeSpan GetStartTime() => TimeSpan.Parse(Start);
        public TimeSpan GetFinishTime() => TimeSpan.Parse(Finish);
    }
}
