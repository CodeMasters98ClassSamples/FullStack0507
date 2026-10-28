using Asp.Versioning;

namespace FullStack0507.MySharedPresentation.Extensions;

public static class PresentationLayerExtensions
{
    public static IServiceCollection AddMyCors(this IServiceCollection services, string name)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(name: name,
                              policy =>
                              {
                                  policy
                                    .AllowAnyOrigin()
                                    .AllowAnyHeader()
                                    .AllowAnyMethod();
                              });
        });
        return services;
    }

    public static IServiceCollection AddMyVersion(this IServiceCollection services)
    {
        services.AddApiVersioning(options =>
                {
                    options.DefaultApiVersion = new ApiVersion(1);
                    options.ReportApiVersions = true;
                    options.AssumeDefaultVersionWhenUnspecified = true;
                    options.ApiVersionReader = ApiVersionReader.Combine(
                        new UrlSegmentApiVersionReader(),
                        new HeaderApiVersionReader("X-Api-Version"));
                })
        .AddMvc() // This is needed for controllers
        .AddApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'V";
            options.SubstituteApiVersionInUrl = true;
        });

        return services;
    }
}
