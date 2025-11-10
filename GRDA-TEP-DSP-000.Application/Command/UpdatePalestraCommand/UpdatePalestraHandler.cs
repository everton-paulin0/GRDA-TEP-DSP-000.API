using GRDA_TEP_DSP_000.Application.Model;
using GRDA_TEP_DSP_000.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GRDA_TEP_DSP_000.Application.Command.UpdatePalestraCommand
{
    public class UpdatePalestraHandler : IRequestHandler<UpdatePalestraCommand, ResultViewModel>
    {
        private readonly AppDbContext _context;
        public UpdatePalestraHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel> Handle(UpdatePalestraCommand request, CancellationToken cancellationToken)
        {
            var palestra = await _context.Palestra.SingleOrDefaultAsync(p => p.Id == request.IdPalestra);

            if (palestra is null)
            {
                return ResultViewModel<PalestraViewModel>.Error("Palestra não existe");
            }

            palestra.Update(request.Subject, request.Trail, request.Start, request.Finish);

            _context.Palestra.Update(palestra);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }
    }
}
