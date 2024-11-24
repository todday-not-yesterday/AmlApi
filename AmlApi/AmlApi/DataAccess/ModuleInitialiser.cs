using System;
using System.Runtime.CompilerServices;

namespace AmlApi.DataAccess;

public static class ModuleInitialiser
{
    [ModuleInitializer]
    public static void Initalise()
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }
}