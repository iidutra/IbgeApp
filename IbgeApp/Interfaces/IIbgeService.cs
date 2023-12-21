using IbgeApp.Models;

namespace IbgeApp.Interfaces
{
    public interface IIbgeService
    {
        Task<IEnumerable<Locality>> LoadLocalitiesAsync();
        Task<IEnumerable<Locality>> SearchAsync(string city, string state, int id);
        Task ImportExcelDataAsync(); // Trazer os parâmetros para questão do excel. Futuramente. 
    }
}
