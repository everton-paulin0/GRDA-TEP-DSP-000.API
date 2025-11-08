using GRDA_TEP_DSP_000.Domain.Entities;

namespace GRDA_TEP_DSP_000.Application.Interface
{
    public interface IPalestraRepository
    {
        Task AddAsync(Palestra palestra);
        Task UpdateAsync(Palestra palestra);
        Task<List<Palestra>> GetAllAsync();
        Task DeleteAsync(int id);
        Task<Palestra> GetByIdAsync(int id);
    }
}
