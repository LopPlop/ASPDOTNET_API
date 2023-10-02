using MinimalAPI.Data.Models;

namespace MinimalAPI.Data.Interfaces
{
    public interface IHotelRepository : IDisposable
    {
        Task<List<Hotel>> GetHotelsAsync();
        Task<Hotel> GetHotelByIdAsync(int id);
        Task<List<Hotel>> GetHotelsByName(string name);
        Task InsertHotelAsync(Hotel hotel);
        Task UpdateHotelAsync(Hotel hotel);
        Task DeleteHotelAsync(int id);
        Task SaveChangesAsync();
    }
}
