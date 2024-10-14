namespace AmlApi.IoC
{
    using System.Diagnostics.CodeAnalysis;
    using Autofac;
    using Microsoft.Extensions.Configuration;

    [ExcludeFromCodeCoverage]
    public class AmlModule : ModuleBase
    {
        public AmlModule(IConfiguration configuration) : base(configuration)
        {
        }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
        }
    }
}