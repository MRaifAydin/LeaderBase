using LeaderBase.Business.Abstract;
using LeaderBase.Business.Concrete;
using LeaderBase.Conversion;
using LeaderBase.Repository.MongoDB;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBase.Business
{
    public static class BusinessDIModule
    {
        public static void Inject(IServiceCollection services, IConfiguration configuration)
        {
            RepositoryDIModule.Inject(services, configuration);
            ConversionDIModule.Inject(services, configuration);

            services.AddTransient<ILeaderService, LeaderManager>();
            services.AddTransient<IPersonService, PersonManager>();

        }
    }
}
