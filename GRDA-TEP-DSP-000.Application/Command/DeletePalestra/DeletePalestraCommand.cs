using GRDA_TEP_DSP_000.Application.Model;
using MediatR;

namespace GRDA_TEP_DSP_000.Application.Command.DeletePalestra
{
    public class DeletePalestraCommand : IRequest<ResultViewModel>
    {
        public DeletePalestraCommand(int id)
        {
            Id = id; 
        }
        public int Id { get; set; }
    }
}
