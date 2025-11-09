
using System.Reflection;
using GRDA_TEP_DSP_000.Application.Command.InsertPalestra;

namespace GRDA_TEP_DSP_000.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            // ✅ Registra todos os handlers e notificações da camada Application
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssemblies(
                    Assembly.GetExecutingAssembly(),                   // o próprio Application
                    typeof(InsertPalestraHandler).Assembly             // garante que o handler seja incluído
                )
            );

            return services;
        }
    }
}







