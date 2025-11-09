using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GRDA_TEP_DSP_000.Application.Model;
using GRDA_TEP_DSP_000.Domain.Entities.Enum;
using MediatR;

namespace GRDA_TEP_DSP_000.Application.Queries.GetPalestraByTrailQuery
{
    public class GetPalestraByTrailQuery : IRequest<ResultViewModel<List<PalestraViewModel>>>
    {
        public Trail Trail { get; }

        public GetPalestraByTrailQuery(Trail trail)
        {
            Trail = trail;
        }
    }
}
