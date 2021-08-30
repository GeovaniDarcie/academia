using Academia.Domain.Interfaces.Services.Alunos;
using Academia.Service.Services;
using Microsoft.Extensions.DependencyInjection;
using Academia.Domain.Interfaces.Services;

namespace Academia.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IAlunoService, AlunoService>();
            serviceCollection.AddTransient<IAdminService, AdminService>();
            serviceCollection.AddTransient<IAcademiaEntityService, AcademiaEntityService>();
            serviceCollection.AddTransient<IProfessorService, ProfessorService>();
        }
    }
}