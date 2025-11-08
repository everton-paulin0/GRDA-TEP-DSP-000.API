using GRDA_TEP_DSP_000.Domain.Entities.Enum;

namespace GRDA_TEP_DSP_000.Domain.Entities
{
    public class Palestra : BaseEntities
    {
        public Palestra(string subject, Trail trail, TimeSpan start, TimeSpan finish, TimeSpan duration)
        {
            Subject = subject;
            Trail = trail;
            Start = start;
            Finish = finish;
            Duration = duration;
        }

        public string Subject { get; set; }
        public Trail Trail { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan Finish { get; set; }
        public TimeSpan Duration { get; set; }

        public void TotalDuration()
        {
            Duration = Finish - Start;
        }

        public void Update(string subject, Trail trail, TimeSpan start, TimeSpan finish, TimeSpan duration)
        {
            Subject = subject;
            Trail = trail;
            Start = start;
            Finish = finish;
            Duration = duration;
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
