using GRDA_TEP_DSP_000.Domain.Entities.Enum;

namespace GRDA_TEP_DSP_000.Domain.Entities
{
    public class Palestra : BaseEntities
    {
        public Palestra(string subject, Trail trail, TimeSpan start, TimeSpan finish)
        {
            Subject = subject;
            Trail = trail;
            Start = start;
            Finish = finish;
            Duration = finish - start; 
        }

        public string Subject { get; set; }
        public Trail Trail { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan Finish { get; set; }
        public TimeSpan Duration { get; private set; }
        public string TipoPalestra { get; private set; }

        public void TotalDuration()
        {
            Duration = Finish - Start;

            if (Duration < TimeSpan.FromMinutes(5))
            {
                // Marca como palestra relâmpago
                Duration = TimeSpan.FromMinutes(5);
                TipoPalestra = "Relâmpago";
                Console.WriteLine("Relâmpago");
            }
            else
            {
                // Palestra normal
                TipoPalestra = "Normal";
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
        //{
        //    if (Status != OrderStatus.PaymentPending && Status != OrderStatus.Fronzen && Status != OrderStatus.Cancelled)
        //    {
        //        Status = OrderStatus.Finished;
        //        UpdatedAt = DateTime.Now;
        //    }           
        //}
         
    }
}
