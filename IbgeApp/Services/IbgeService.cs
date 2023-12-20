using IbgeApp.Interfaces;
using IbgeApp.Models;

namespace IbgeApp.Services
{
    public class IbgeService : IIbgeService
    {
        public async Task<IEnumerable<Locality>> LoadLocalitiesAsync()
        {
            // Retorno temporário para teste
            await Task.Delay(1000); // Simula uma operação assíncrona
            return new List<Locality>(); // Retorna uma lista vazia
        }

        public async Task<IEnumerable<Locality>> SearchAsync(string city, string state, int id)
        {
            // Retorno temporário para teste
            await Task.Delay(1000); // Simula uma operação assíncrona
            return new List<Locality>(); // Retorna uma lista vazia
        }

        public async Task ImportExcelDataAsync(/* parâmetros necessários */)
        {
            // Implementação temporária para teste
            await Task.Delay(1000); // Simula uma operação assíncrona
            // Não retorna nada, pois é um método Task
        }
    }
}
