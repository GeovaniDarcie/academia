using Academia.Domain.Interfaces.Services.Alunos;
using Academia.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Academia.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IAlunoService, AlunoService>();
        }
    }
}