using System.ComponentModel;
using GRDA_TEP_DSP_000.Domain.Entities.Enum;

namespace GRDA_TEP_DSP_000.Domain.Entities
{
    public class Palestra : BaseEntities
    {
        public Palestra(string subject, Trail trail, TimeSpan start, TimeSpan finish, TimeSpan duration, SessionTimes sessionTime)
        {
            Subject = subject;
            Trail = trail;
            Start = start;
            Finish = finish;
            Duration = finish - start;
            SessionTime = sessionTime;
        }

        [Description("Tema da Palestra")]
        public string Subject { get; set; }
        [Description("Trilha")]
        public Trail Trail { get; set; }
        [Description("Horário de Início")]
        public TimeSpan Start { get; set; }
        [Description("Horário do Fim")]
        public TimeSpan Finish { get; set; }
        [Description("Duração da Palestra")]
        public TimeSpan Duration { get; private set; }
        [Description("Tipo de Palestra")]
        public string TypePalestra { get; private set; }
        [Description("Horários das sessões")]
        public SessionTimes SessionTime { get; set; }

        public void TotalDuration()
        {
            Duration = Finish - Start;

            if (Duration < TimeSpan.FromMinutes(5))
            {
                // Marca como palestra relâmpago
                Duration = TimeSpan.FromMinutes(5);
                TypePalestra = "Relâmpago";
                Console.WriteLine("Relâmpago");
            }
            else
            {
                // Palestra normal
                TypePalestra = Duration.ToString();
            }
        }

        public void ValidateTrailTime()
        {
            switch (SessionTime)
            {
                case SessionTimes.Morning:
                    // Matutino: entre 9h e 12h
                    if (Start < TimeSpan.FromHours(9) || Finish > TimeSpan.FromHours(12))
                        throw new InvalidOperationException("Sessões matutinas devem ocorrer entre 9h e 12h.");
                    break;

                case SessionTimes.Evening:
                    // Vespertino: entre 13h e 17h (antes do networking)
                    if (Start < TimeSpan.FromHours(13) || Finish > TimeSpan.FromHours(17))
                        throw new InvalidOperationException("Sessões vespertinas devem ocorrer entre 13h e 17h.");
                    break;

                case SessionTimes.LunchBreak:
                    // Almoço: normalmente 12h às 13h
                    if (Start < TimeSpan.FromHours(12) || Finish > TimeSpan.FromHours(13))
                        throw new InvalidOperationException("O almoço deve ocorrer entre 12h e 13h.");
                    break;

                case SessionTimes.NetworkingEvent:
                    // Networking: entre 16h e 17h
                    if (Start < TimeSpan.FromHours(16) || Finish > TimeSpan.FromHours(17))
                        throw new InvalidOperationException("O evento de networking deve começar entre 16h e 17h.");
                    break;
            }
        }
    

        public void Update(string subject, Trail trail, string start, string finish)
        {
            Subject = subject;
            Trail = trail;
            Start = TimeSpan.Parse(start);
            Finish = TimeSpan.Parse(finish);
            UpdatedAt = DateTime.Now;
        }

        public void Cancel()
        {
            //if (Status == OrderStatus.Started || Status == OrderStatus.Fronzen)
            //{
            //    Status = OrderStatus.Cancelled;
            //    UpdatedAt = DateTime.Now;
            //}
            UpdatedAt = DateTime.Now;
        }

        public void Complete()
        {
            UpdatedAt = DateTime.Now;
        }
        
    }
}
