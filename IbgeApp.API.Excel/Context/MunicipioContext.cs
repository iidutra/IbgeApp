using IbgeApp.API.Excel.Model;
using Microsoft.EntityFrameworkCore;

namespace IbgeApp.API.Excel.Context
{
    public class MunicipioContext : DbContext
    {
        public MunicipioContext(DbContextOptions<MunicipioContext> options)
            : base(options)
        {
        }

        public DbSet<Municipio> Municipios { get; set; }
    }

}
