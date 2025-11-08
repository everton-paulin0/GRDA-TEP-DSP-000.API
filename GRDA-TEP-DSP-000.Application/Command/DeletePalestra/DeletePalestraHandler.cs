using GRDA_TEP_DSP_000.Application.Model;
using GRDA_TEP_DSP_000.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GRDA_TEP_DSP_000.Application.Command.DeletePalestra
{
    public class DeletePalestraHandler : IRequestHandler<DeletePalestraCommand, ResultViewModel>
    {
       
        private readonly AppDbContext _context;
        public DeletePalestraHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel> Handle(DeletePalestraCommand request, CancellationToken cancellationToken)
        {
            var palestra = await _context.Palestra.SingleOrDefaultAsync(p => p.Id == request.Id);

            if (palestra is null)
            {
                return ResultViewModel<PalestraViewModel>.Error("Palestra não existe");
            }

            palestra.SetAsDeleted();

            _context.Palestra.Update(palestra);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }
    }    
}
