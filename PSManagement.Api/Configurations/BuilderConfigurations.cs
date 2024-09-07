using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSManagement.Api.Configurations
{
    public static class BuilderConfigurations
    {
        #region Use Cors Configure 

        public static IApplicationBuilder UseMyCors(this IApplicationBuilder app)
        {

            app.UseCors("AllowHiast");
            return app;
        }
        #endregion Use Cors Configure

    }
}
