using GRDA_TEP_DSP_000.Application.Model;
using GRDA_TEP_DSP_000.Domain.Entities;
using GRDA_TEP_DSP_000.Domain.Entities.Enum;
using MediatR;

namespace GRDA_TEP_DSP_000.Application.Command.InsertPalestra
{
    public class InsertPalestraCommand : IRequest<ResultViewModel<int>>
    {
        public string Subject { get; set; }
        public Trail Trail { get; set; }
        public string Start { get; set; }
        public string Finish { get; set; }

        private SessionTimes DetectSessionByTime(TimeSpan start)
        {
            if (start >= TimeSpan.FromHours(9) && start < TimeSpan.FromHours(12))
                return SessionTimes.Morning;
            if (start >= TimeSpan.FromHours(12) && start < TimeSpan.FromHours(13))
                return SessionTimes.LunchBreak;
            if (start >= TimeSpan.FromHours(13) && start < TimeSpan.FromHours(17))
                return SessionTimes.Evening;
            return SessionTimes.NetworkingEvent;
        }


        public Palestra ToEntityPalestra()
        {
            var start = TimeSpan.Parse(Start);
            var finish = TimeSpan.Parse(Finish);
            var duration = finish - start;

            var session = DetectSessionByTime(start); 

            return new Palestra(Subject, Trail, start, finish, duration, session);
        }
    }
}
