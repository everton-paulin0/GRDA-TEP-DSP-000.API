namespace GRDA_TEP_DSP_000.Domain.Entities
{
    public class BaseEntities
    {
        public BaseEntities()
        {
            
        }
        public BaseEntities(DateTime createdAt, DateTime updatedAt, bool isActive)
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            IsActive = true;
        }

        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsActive { get; set; }

        public void SetAsDeleted()
        {
            IsActive = true;
        }


    }
}
