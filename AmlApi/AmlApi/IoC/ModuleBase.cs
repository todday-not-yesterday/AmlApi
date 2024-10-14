// Copyright 2023 XLN Telecom, Inc.  All rights reserved.
// This computer source code and related instructions and comments are the unpublished
// confidential and proprietary information of XLN Telecom Ltd. and are protected under UK
// and foreign intellectual property laws. They may not be disclosed to, copied or used by
// any third party without the prior written consent of XLN Telecom Ltd.
// ----------------------------------------------------------------------------------------------------

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