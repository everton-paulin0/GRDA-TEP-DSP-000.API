using GRDA_TEP_DSP_000.Application.Model;
using GRDA_TEP_DSP_000.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GRDA_TEP_DSP_000.Application.Queries.GetAllPalestraQuery
{
    public class GetAllPalestraQuery : IRequest<ResultViewModel<List<PalestraItemViewModel>>>
    {
        public GetAllPalestraQuery()
        {
            
        }

        public class GetAllPalestraHandler : IRequestHandler<GetAllPalestraQuery, ResultViewModel<List<PalestraItemViewModel>>>
        {
            private readonly AppDbContext _context;
            public GetAllPalestraHandler(AppDbContext context)
            {
                _context = context;
            }
            public async Task<ResultViewModel<List<PalestraItemViewModel>>> Handle(GetAllPalestraQuery request, CancellationToken cancellationToken)
            {
                var palestras = await _context.Palestra                    
                    .Where(p => !p.IsActive).ToListAsync();

                var model = palestras.Select(PalestraItemViewModel.FromEntityPalestra).ToList();


                return ResultViewModel<List<PalestraItemViewModel>>.Success(model);
            }
        }
    }
}
