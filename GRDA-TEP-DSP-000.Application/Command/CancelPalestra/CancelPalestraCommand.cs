using GRDA_TEP_DSP_000.Application.Model;
using MediatR;

namespace GRDA_TEP_DSP_000.Application.Command.CancelPalestra
{
    public class CancelPalestraCommand : IRequest<ResultViewModel>
    {
        public CancelPalestraCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
