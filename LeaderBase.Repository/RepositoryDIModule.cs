using LeaderBase.Repository.Abstract;
using LeaderBase.Repository.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBase.Repository
{
    public static class RepositoryDIModule
    {
        public static void Inject(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ILeaderRepository, LeaderRepository>();
            services.AddTransient<IPersonRepository, PersonRepository>();
        }
    }
}
