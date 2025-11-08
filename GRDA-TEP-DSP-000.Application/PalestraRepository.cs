using GRDA_TEP_DSP_000.Application.Interface;
using GRDA_TEP_DSP_000.Domain.Entities;
using GRDA_TEP_DSP_000.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace GRDA_TEP_DSP_000.Application
{
    public class PalestraRepository : IPalestraRepository
    {
        private readonly AppDbContext _context;
        public PalestraRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Palestra palestra)
        {
            _context.Palestra.Add(palestra);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var palestra = await GetByIdAsync(id);
            _context.Palestra.Remove(palestra);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Palestra>> GetAllAsync()
        {
            return await _context.Palestra.AsNoTracking().ToListAsync();
        }

        public async Task<Palestra> GetByIdAsync(int id)
        {
            return await _context.Palestra.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Palestra palestra)
        {
            _context.Update(palestra);
            await _context.SaveChangesAsync();
        }
    }
}
