using Microsoft.Extensions.Options;
using Phantom.Api.Constants;
using Phantom.Api.Interfaces;
using Phantom.Api.Settings;

namespace Phantom.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddConfiguredOptions(this IServiceCollection services, IConfiguration configuration, string environmentName)
    {
        if (environmentName == AppConsts.DockerEnvironment)
        {
            services.AddAppSettings<DockerAppSettings>(configuration);
        }
        else
        {
            services.AddAppSettings<StandaloneAppSettings>(configuration);
        }

        return services;
    }

    private static void AddAppSettings<T>(this IServiceCollection services, IConfiguration configuration) 
        where T : class, IAppSettings
    {
        const string appSettingsSectionName = "AppSettings";

        services.Configure<T>(configuration.GetSection(appSettingsSectionName));
        services.AddSingleton<IAppSettings>(sp => sp.GetRequiredService<IOptions<T>>().Value);
    }
}
