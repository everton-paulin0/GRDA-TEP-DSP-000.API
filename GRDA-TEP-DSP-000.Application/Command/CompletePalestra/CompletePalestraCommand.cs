using GRDA_TEP_DSP_000.Application.Model;
using MediatR;

namespace GRDA_TEP_DSP_000.Application.Command.CompletePalestra
{
    public class CompletePalestraCommand : IRequest<ResultViewModel>
    {
        public CompletePalestraCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
