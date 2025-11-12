using GRDA_TEP_DSP_000.Application.Model;
using GRDA_TEP_DSP_000.Domain.Entities.Enum;
using MediatR;

namespace GRDA_TEP_DSP_000.Application.Queries.GetPalestraByTrailQuery
{
    public class GetPalestraByTrailQuery : IRequest<ResultViewModel<List<PalestraViewModel>>>
    {
        public GetPalestraByTrailQuery(Trail trail, SessionTimes sessionTime)
        {
            Trail = trail;
            SessionTime = sessionTime;
        }

        public Trail Trail { get; }
        public SessionTimes SessionTime { get; }

        
    }
}
