using GRDA_TEP_DSP_000.Application.Model;
using GRDA_TEP_DSP_000.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GRDA_TEP_DSP_000.Application.Queries.GetPalestraByIdQuery
{
    public class GetPalestraByIdQuery : IRequest<ResultViewModel<PalestraViewModel>>
    {
        public GetPalestraByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
    public class GetPalestraByIdHandler : IRequestHandler<GetPalestraByIdQuery, ResultViewModel<PalestraViewModel>>
    {
        private readonly AppDbContext _context;
        public GetPalestraByIdHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel<PalestraViewModel>> Handle(GetPalestraByIdQuery request, CancellationToken cancellationToken)
        {
            var palestra = await _context.Palestra
                .Where(o => o.Id == request.Id && !o.IsActive)
                .FirstOrDefaultAsync(cancellationToken);


            if (palestra is null)
            {
                return ResultViewModel<PalestraViewModel>.Error("Palestra não existe");
            }

            var model = PalestraViewModel.FromEntityPalestra(palestra);

            return ResultViewModel<PalestraViewModel>.Success(model);
        }
    }
}
