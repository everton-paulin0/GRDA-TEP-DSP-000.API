namespace GRDA_TEP_DSP_000.Domain.Entities
{
    public class BaseEntities
    {
        public BaseEntities()
        {
            
        }
        public BaseEntities(DateTime createdAt, DateTime updateAt, bool isActive)
        {
            CreatedAt = DateTime.UtcNow;
            UpdateAt = DateTime.UtcNow;
            IsActive = true;
        }

        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public bool IsActive { get; set; }

        
    }
}
