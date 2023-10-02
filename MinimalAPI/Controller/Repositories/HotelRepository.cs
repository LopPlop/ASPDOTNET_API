using Microsoft.EntityFrameworkCore;
using MinimalAPI.Controller.Context;
using MinimalAPI.Data.Interfaces;
using MinimalAPI.Data.Models;

namespace MinimalAPI.Controller.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly AppDbContext _context;

        private bool _disposed = false;

        public HotelRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<List<Hotel>> GetHotelsAsync() => _context.Hotels.ToListAsync();



        public async Task<Hotel> GetHotelByIdAsync(int id) =>
            await _context.Hotels.FindAsync(new Hotel() { Id = id });

        public Task<List<Hotel>> GetHotelsByName(string name) => _context.Hotels.Where(h => h.Name.Contains(name)).ToListAsync();



        public async Task InsertHotelAsync(Hotel hotel)
        {
            await _context.Hotels.AddAsync(hotel);
            await _context.SaveChangesAsync();
        }



        public async Task UpdateHotelAsync(Hotel hotel)
        {
            _context.Hotels.Update(hotel);
            _context.SaveChanges();
        }



        public async Task DeleteHotelAsync(int id)
        {
            var h = await _context.Hotels.FindAsync(new object[] { id });
            if (h == null) return;
            _context.Hotels.Remove(h);
            _context.SaveChanges();
        }



        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    _context.Dispose();
            _disposed = true;
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
