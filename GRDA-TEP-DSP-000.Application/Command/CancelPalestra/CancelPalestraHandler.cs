using GRDA_TEP_DSP_000.Application.Model;
using GRDA_TEP_DSP_000.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GRDA_TEP_DSP_000.Application.Command.CancelPalestra
{
    public class CancelPalestraHandler : IRequestHandler<CancelPalestraCommand, ResultViewModel>
    {
        private readonly AppDbContext _context;
        public CancelPalestraHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel> Handle(CancelPalestraCommand request, CancellationToken cancellationToken)
        {
            var palestra = await _context.Palestra.SingleOrDefaultAsync(p => p.Id == request.Id);

            if (palestra is null)
            {
                return ResultViewModel<PalestraViewModel>.Error("Palestra não existe");
            }
            palestra.Cancel();

            _context.Palestra.Update(palestra);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }
    }
}
