using GRDA_TEP_DSP_000.Application.Model;
using GRDA_TEP_DSP_000.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace GRDA_TEP_DSP_000.Application.Queries.GetPalestraByTrailQuery
{
    
    public class GetPalestraByTrailHandler : IRequestHandler<GetPalestraByTrailQuery, ResultViewModel<List<PalestraViewModel>>>
    {
        private readonly AppDbContext _context;

        
        public GetPalestraByTrailHandler(AppDbContext context)
        {
            _context = context;
        }

        
        public async Task<ResultViewModel<List<PalestraViewModel>>> Handle(GetPalestraByTrailQuery request, CancellationToken cancellationToken)
        {
            var palestras = await _context.Palestra
            .Where(p => p.Trail == request.Trail)
            .Select(p => new PalestraViewModel(
                p.Id,
                p.Subject,
                p.Trail.ToString(),
                p.Start,
                p.Finish,
                p.Duration,
                p.TypePalestra,
                p.SessionTime.ToString()
            ))
            .ToListAsync(cancellationToken);

            return ResultViewModel<List<PalestraViewModel>>.Success(palestras);

        }
    }
}

