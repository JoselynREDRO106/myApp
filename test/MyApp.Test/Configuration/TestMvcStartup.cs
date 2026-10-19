using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace MyApp.Test.Configuration;

public class TestMvcStartup
{
    public static Action<MvcOptions> ConfigureMvcAuthorization()
    {
        return options => { options.Filters.Add(new AllowAnonymousFilter()); };
    }
}
