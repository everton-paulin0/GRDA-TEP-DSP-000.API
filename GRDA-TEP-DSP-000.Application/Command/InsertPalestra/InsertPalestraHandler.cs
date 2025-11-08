using GRDA_TEP_DSP_000.Application.Model;
using GRDA_TEP_DSP_000.Application.Notification;
using GRDA_TEP_DSP_000.Infrastructure;
using MediatR;


namespace GRDA_TEP_DSP_000.Application.Command.InsertPalestra
{
    public class InsertPalestraHandler : IRequestHandler<InsertPalestraCommand, ResultViewModel<int>>
    {
        private readonly AppDbContext _context;
        private readonly IMediator _mediator;
        public InsertPalestraHandler(AppDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }
        public async Task<ResultViewModel<int>> Handle(InsertPalestraCommand request, CancellationToken cancellationToken)
        {
            var palestra = request.ToEntityPalestra();

            await _context.Palestra.AddAsync(palestra);
            await _context.SaveChangesAsync();

            var orderCreatead = new PalestraCreatedNotification(palestra.Id, palestra.Subject);

            await _mediator.Publish(orderCreatead);

            return ResultViewModel<int>.Success(palestra.Id);
        }
    }
}



