using GRDA_TEP_DSP_000.Domain.Entities;


namespace GRDA_TEP_DSP_000.Application.Model
{
    public class PalestraItemViewModel
    {
        public PalestraItemViewModel(int id, string subject, string trail, TimeSpan start, TimeSpan finish, TimeSpan duration, string typePalestra, string sessionTime)
        {
            Id = id;
            Subject = subject;
            Trail = trail.ToString(); 
            Start = start;
            Finish = finish;
            Duration = duration;
            TypePalestra = typePalestra.ToString(); 
            SessionTime = sessionTime.ToString(); 
        }

        public int Id { get; set; }
        public string Subject { get; set; }
        public string Trail { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan Finish { get; set; }
        public TimeSpan Duration { get; set; }        
        public string TypePalestra { get; private set; }        
        public string SessionTime { get; set; }

        public static PalestraItemViewModel FromEntityPalestra(Palestra palestra)
            => new(
                palestra.Id,
                palestra.Subject,
                palestra.Trail.ToString(),
                palestra.Start,
                palestra.Finish,
                palestra.Duration,
                palestra.TypePalestra,
                palestra.SessionTime.ToString()
            );
    }
}
