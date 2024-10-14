namespace AmlApi.IoC
{
    using System.Diagnostics.CodeAnalysis;
    using Autofac;
    using Microsoft.Extensions.Configuration;

    [ExcludeFromCodeCoverage]
    public class ModuleBase : Module
    {
        protected readonly IConfiguration Configuration;

        public ModuleBase(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterAssemblyTypes(typeof(Startup).Assembly)
                .AsImplementedInterfaces();
        }

        protected T GetSettings<T>()
        {
            return this.GetSettings<T>(this.Configuration);
        }

        protected T GetSettings<T>(IConfiguration configuration)
        {
            return configuration.GetSection(typeof(T).Name).Get<T>();
        }
    }
}