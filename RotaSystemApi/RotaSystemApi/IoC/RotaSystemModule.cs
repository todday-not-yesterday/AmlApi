// Copyright 2024 XLN Telecom, Inc.  All rights reserved.
// This computer source code and related instructions and comments are the unpublished
// confidential and proprietary information of XLN Telecom Ltd. and are protected under UK
// and foreign intellectual property laws. They may not be disclosed to, copied or used by
// any third party without the prior written consent of XLN Telecom Ltd.
// ----------------------------------------------------------------------------------------------------

namespace RotaSystemApi.IoC
{
    using System.Diagnostics.CodeAnalysis;
    using Autofac;
    using Microsoft.Extensions.Configuration;

    [ExcludeFromCodeCoverage]
    public class RotaSystemModule : ModuleBase
    {
        public RotaSystemModule(IConfiguration configuration) : base(configuration)
        {
        }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
        }
    }
}