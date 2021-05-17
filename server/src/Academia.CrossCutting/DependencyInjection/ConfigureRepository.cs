using Academia.Data.Repository;
using Academia.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Academia.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRespository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
        }
    }
}