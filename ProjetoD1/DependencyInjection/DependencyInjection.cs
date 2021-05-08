using Microsoft.Extensions.DependencyInjection;
using ProjetoD1.Data;
using ProjetoD1.Data.Repository;
using ProjetoD1.Interfaces.Repository;



namespace ProjetoD1.DependencyInjection
{
    public class DependencyInjection
    {
        public static void AdicionarInjecoesDependencia(IServiceCollection services)
        {
            //-- Repositorios
            services.AddScoped<IClienteRepository, ClienteRepository>();


            //-- Contexts            
            services.AddSingleton<MongoContext>();
        }
    }
}
